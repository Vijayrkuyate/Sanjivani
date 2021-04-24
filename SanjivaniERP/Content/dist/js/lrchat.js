/*
 * @package    WHMCS
 * @author     Amr M. Ibrahim <mailamr@gmail.com>
 * @copyright  Copyright (c) WHMCSAdminTheme 2016
 * @link       http://www.whmcsadmintheme.com
 */

(function() {

var debug = false;
var lrchat_state;
var staffWidget = false;

var cUserId;
var cUserName;
var firstMsgId;
var lastMsgId;

var cData;
var lSender;
var lDateTime;

var lHash = "";
var notifyOnly;
var msgHistory = null;

var sTimer = null;
var animationSpeed = 500;
var pTimer = 5000;
var dTimer = 30000;
var cTimer = pTimer;

var ftleft  = 0;
var fblockedTo  = 0;


function getChatIds(){
	if ((lrchat_state == "open")){
		firstMsgId = $(".direct-chat-text").first().data('lrchatext-msgid');
		lastMsgId  = $(".direct-chat-text").last().data('lrchatext-msgid');
	}else{
		firstMsgId = lastMsgId  = null;
	}
	
	if (debug){console.log("First Message ID : ("+firstMsgId+") - Last Message ID : ("+lastMsgId+")");}	
}


function lrChatAjax(arr){
    $("#lrchat_loading").html('<i class="fa fa-spinner fa-pulse"></i>'); 
	getChatIds();
	if (typeof arr === 'object'){
		try {
			arr.push({name: 'firstmsgid', value: firstMsgId});
			arr.push({name: 'lastmsgid', value: lastMsgId});
		}catch(e){
			arr['firstmsgid'] = firstMsgId;
			arr['lastmsgid'] = lastMsgId;
		}
	}	
	if (debug){console.log(arr);}
	return $.ajax({
		method: "POST",
		url: getlrFullPath("addonmodules.php?module=lara_addon"),
		data: arr,
		dataType: 'json'
	})
	.done(function (data, textStatus, jqXHR) {
		if (debug){console.log(data);}
		if (data.status != "done"){
			displayErrorMsg(data);
		}
	})
	.fail(function (jqXHR, textStatus, errorThrown) {
		if (debug){
			console.log(jqXHR);
			console.log(textStatus);
			console.log(errorThrown);
		}
	})
	.always(function (dataOrjqXHR, textStatus, jqXHRorErrorThrown) {
		$("#lrchat_loading").html("");
	});	
}

function updateWidgetStatus(save){
	lrchat_state = "closed";
	notifyOnly = "yes";
	cTimer = dTimer;
	if ($('#lrchat-widget').is(":visible")){
		lrchat_state = "open";
		if ($("#lrchat-body-container").is(':hidden')){
			lrchat_state = "collapsed";
		}else if ($("#lrchat-widget").hasClass('direct-chat-contacts-open')){
			lrchat_state = "contacts";
		}
	}
	
	if ((lrchat_state == "open")){
		cTimer = pTimer;
		notifyOnly = "no";
		getMsg();
	}
	
	if (debug){console.log("Current State: "+ lrchat_state);
	           console.log("Notification Only: "+ notifyOnly);}
	
	resetChatTimer();
	
	if (save){
		setThemeSettings({'mode': 'update', 'lrchat_state': lrchat_state, 'lrchat_lastuid': cUserId});
	}
}


function resetChatTimer(nTimer){
	clearTimeout(sTimer);
	sTimer = null;
	if (nTimer){ cTimer = nTimer; }
	sTimer = setTimeout(getMsg, cTimer);
	if (debug){console.log("Timer reset to : "+ cTimer);}
}

function floodProtection(){
	var cTime = Math.floor(Date.now() / 1000);
	if (fblockedTo > 0){
		ftleft = fblockedTo - cTime;
		if (ftleft >= 1) {
			displayErrorMsg("Flood Protection Error : You've exceeded the maximum allowed messages per minute, please try again after "+ftleft+" seconds.");
			return true;
		}else{fblockedTo = 0;}
	}	

	dismissError();
	return false;
}

function displayErrorMsg(msg){
	$("#lrchat-chat-error").html(msg);
	$("#lrchat-chat-error").show();
}

function dismissError(){
	$("#lrchat-chat-error").html("");
	$("#lrchat-chat-error").hide();
}

function sendMsg(){
	resetChatTimer(dTimer);
	var flProtection = floodProtection();
	if (flProtection == false){
		var sendRequest = lrChatAjax($("#lrchat-sendmsg").serializeArray());
		$("#lrchat-message").val('');
		
		sendRequest.done(function (data, textStatus, jqXHR) {
			if (data.status == "done"){
				resetChatTimer(pTimer);
				displayChat(data);
			}else{
				displayErrorMsg(data['msg']);
				fblockedTo = Math.floor(Date.now() / 1000) + data['ftleft'];
			}
		});	
	}
}



function getMsg(){
	return lrChatAjax({lrchat : "1", command : "getmsg", userid : cUserId, notifyonly: notifyOnly, msghistory: msgHistory }).done(function (data, textStatus, jqXHR) {
		if (data.status == "done"){
			cData = data;
			
			if (!staffWidget){
				prepareStaffWidget();
				staffWidget = true;
			}
			
			if (notifyOnly == "no"){
				if (cData.lastMsgId != null){
					cTimer = pTimer;
				}else if ((cData.lastMsgId == null) && (cTimer <  dTimer)){
					cTimer = cTimer + 1000;
				}
				displayChat(cData);
			}
			
			if (data.nhash !== lHash){
				if (('undefined' !== typeof lrchataudio) && (lHash != "")) {lrchataudio.play();}
				lHash = data.nhash;
				notifications(cData);
			}

			resetChatTimer();
		}
		
	});	
}


function displayChat(data){
	try{
		cUserName = cData.notifications.messages[cUserId].name;
	} catch(err) {
		console.log(err.message);
	}	

	$("#lrchat-title").html(cUserName);
	if (data.mode == "recent"){
		$("#lrchat-chat-window").empty();
	}else if (data.mode == "update"){
		  if (data.lastMsgId == null){
			  return;
		  }
	}

	var currentHeight = $('#lrchat-chat-window').prop('scrollHeight');
	var scrollToPx;	
	var msg = "";
	
	$.each(data.messages, function( i, row ){
		var cDateTime = moment.utc(row.timestamp).local();
		var msgDirection = "";
		var repeated = "";
		var newDay = false;
		
		if (row.fromid == data.adminid){msgDirection = "right";}
		if (lDateTime !== cDateTime.format("DD-MM-YYYY")){ newDay = true; }
		
		if (newDay){
			msg += "<div class='direct-chat-day'>"+cDateTime.format("dddd, MMMM D, YYYY")+"</div>";
		}
		msg += "<div class='direct-chat-msg "+msgDirection+"'>";
		
		if ((newDay) || (lSender != row.fromid) ){
			if ((row.fromid != data.adminid)){ msg += "<img class='direct-chat-img' src='//www.gravatar.com/avatar.php?gravatar_id="+data.notifications.messages[row.fromid].uimg+"'>";}
		}else{ repeated = "repeated";}
		
		msg += "<span class='direct-chat-timestamp "+repeated+"'>"+cDateTime.format("h:mm A")+"</span>\
		     	   <div class='direct-chat-text "+repeated+"' data-lrchatext-msgid='"+row.id+"' > "+row.message+"</div>\
				</div>";

		lDateTime = cDateTime.format("DD-MM-YYYY");		
		lSender = row.fromid;
	});
	
	 if (data.mode != "history"){
		 $("#lrchat-chat-window").append(msg);
		 $('#lrchat-chat-window').slimScroll({ scrollTo : $('#lrchat-chat-window').prop('scrollHeight') + 'px' });	
	 }else{
		 $("#lrchat-chat-window").prepend(msg);
		 scrollToPx = ($('#lrchat-chat-window').prop('scrollHeight') - currentHeight) - 100;
		 $('#lrchat-chat-window').slimScroll({ scrollTo : scrollToPx + 'px' });	
	 }
}

function notifications(data){
	$("[data-widget='lrchat-notifications-count']").html(data.notifications.total > 0 ? data.notifications.total : '');
	updateContactsList(data);
}

function toggleSendMsg(value){
	$("#lrchat-sendmsg-submit").prop("disabled",value);
	$("#lrchat-message").prop("disabled",value);	
}

function updateContactsList(data){
	$.each(data.notifications.messages, function( index, contact ) {
		if (contact.cuser != 1){
			if (contact.total){
				$('[data-lrchat-messagefor='+contact.id+']').html(contact.lastmessage.message.substring(0,20) + " ...");
				$('[data-lrchat-notificationsfor='+contact.id+']').html(contact.total);
				$('[data-lrchat-timestampfor='+contact.id+']').html("[ "+moment.utc(contact.lastmessage.timestamp).local().format('lll')+" ]" );
				$('[data-lrchat-notificationsfor='+contact.id+']').parents("li").attr("data-lrchat-mtstamp", moment(contact.lastmessage.timestamp).unix());
			}else{
				$('[data-lrchat-messagefor='+contact.id+']').html("");
				$('[data-lrchat-notificationsfor='+contact.id+']').html("");
				$('[data-lrchat-notificationsfor='+contact.id+']').parents("li").attr("data-lrchat-mtstamp", "0");				
			}
		}
	});	
	
	$('#lrchat-popup-nav-contacts li').sort(function(a, b){
		return $(a).attr("data-lrchat-mtstamp") < $(b).attr("data-lrchat-mtstamp") ? 1 : -1;
	}).appendTo('#lrchat-popup-nav-contacts');
	
	$('#lrchat-top-nav-contacts li').sort(function(a, b){
		return $(a).attr("data-lrchat-mtstamp") < $(b).attr("data-lrchat-mtstamp") ? 1 : -1;
	}).appendTo('#lrchat-top-nav-contacts');	
}

function openChatWindow(){
	toggleSendMsg(false);
	
	$("#lrchat-widget").show();
	$("#lrchat-body-container").show();//to be revised
	$("#lrchat-widget [data-widget='lrchat-collapse']").html("<i class='fa fa-minus'></i>");//to be revised
	$("#lrchat-chat-window").empty();
	$("#lrchat-widget").removeClass('direct-chat-contacts-open');
	
	$('#lrchat-sendmsg input[name=userid]').val(cUserId);
	cUserName = cData.notifications.messages[cUserId].name;
	$("#lrchat-title").html(cUserName);
	
	updateWidgetStatus(true);
}

function adjustChatHeight(){
		var cHeight = $( window ).height();
		var cWidth = $( window ).width();
		var adjustedHeight ="250px";
		if (cWidth < 768){ adjustedHeight = (cHeight - 95) + "px";}
		
		$("#lrchat-chat-window").css({ 'height': adjustedHeight });
		$("#lrchat-chat-window").parent(".slimScrollDiv").css({ 'height': adjustedHeight });
		$("#lrchat-chat-contacts").css({ 'height': adjustedHeight }); 
		
		if (debug){console.log("Current width : "+ cWidth);
		           console.log("Height set to : "+ adjustedHeight);}
}

function prepareStaffWidget(){
	if ($(".lr-home-widgets-container [data-larawidget='staff']").is(':visible')){
		if (debug){console.log("Preparing Staff Widget");}
		$(".lr-home-widgets-container [data-larawidget='staff'] div.staff").each(function( index ) {
			var cDiv = $( this );
			var cUserName = cDiv.children("div.name").text().toLowerCase();
			$.each(cData.notifications.messages, function( i, user ){
				if ((user.cuser != 1) && (user.name.toLowerCase() == cUserName)){
					cDiv.css( 'position', 'relative' );
					cDiv.children("img").attr('data-lrchat-adminid',user.id).css( 'cursor', 'pointer' ).after('<span class="label label-success" data-lrchat-notificationsfor="'+user.id+'" style="position: absolute;right: 35px;"></span>');
					return false;
				}
			});		
		});
		$("[data-lrchat-adminid]").unbind( "click" );	
		$("[data-lrchat-adminid]").on('click', function (e) {
			e.preventDefault();
			cUserId = $(this).data('lrchat-adminid');
			openChatWindow();
		});	
	}
}

$(document).ready(function(){

	cUserId = $('#lrchat-sendmsg input[name=userid]').val();
	updateWidgetStatus();
	

	
	$("#lrchat-chat-window").slimScroll({
		start: "bottom",
		alwaysVisible: true,
		wheelStep : 15,
		touchScrollStep : 75
	});

    adjustChatHeight();	
	
	$('#lrchat-chat-window').scroll(function(){
		if (((!$("#lrchat-chat-window").is(':empty'))) && ($('#lrchat-chat-window').scrollTop() == 0)){
			
			msgHistory = "yes";
			getMsg().done(function (data, textStatus, jqXHR) {
				msgHistory ="no";
			});
		}
	});
	
	$( window ).resize(function() {
		adjustChatHeight();
		
	});	
	
	if ((lrchat_state !== "open")){
		getMsg();
	}
	
	$("#lrchat-sendmsg").on( "submit", function(e) {
		e.preventDefault();
		if (($.trim($('#lrchat-sendmsg input[name=message]').val()) != "") && (cUserId != "")){
			sendMsg();
		}
	});
	
	$("#lrchat-widget [data-widget='lrchat-hide']").on('click', function () {
		$("#lrchat-widget").slideUp( animationSpeed, function() {
			updateWidgetStatus(true);
		});
	});
	
	$("#lrchat-widget [data-widget='lrchat-collapse']").on('click', function () {
		$("#lrchat-body-container").slideToggle( animationSpeed, function() {
			updateWidgetStatus(true);
			if (lrchat_state == "collapsed"){
				$("#lrchat-widget [data-widget='lrchat-collapse']").html("<i class='fa fa-plus'></i>");
			}else{
				$("#lrchat-widget [data-widget='lrchat-collapse']").html("<i class='fa fa-minus'></i>");
			}
		});
	});	
	
	$("#lrchat-widget [data-widget='lrchat-contacts']").on('click', function () {
		if (lrchat_state == "collapsed"){
			$('#lrchat-widget').addClass('direct-chat-contacts-open');
			$("#lrchat-widget [data-widget='lrchat-collapse']").trigger('click');
		}else{
			$('#lrchat-widget').toggleClass('direct-chat-contacts-open');
		}

		updateWidgetStatus();

		if (lrchat_state == "contacts"){
			$("#lrchat-title").html("Contacts");
			toggleSendMsg(true);
		}else{
			$("#lrchat-title").html(cUserName);
			toggleSendMsg(false);			
		}
	});	
	
	
	$("[data-lrchat-adminid]").on('click', function (e) {
		e.preventDefault();
		cUserId = $(this).data('lrchat-adminid');
		openChatWindow();
    });
	
	$(".lr-home-widgets-container [data-larawidget='staff'] .widget-refresh").on('click', function () {
		setTimeout( function(){
			staffWidget = false;
			getMsg().done(function (data, textStatus, jqXHR) {
				notifications(data);
			});
		  }  , 2000 );
	});	

});


})();

