/*! SlimScroll Version: 1.3.8 - Copyright (c) 2011 Piotr Rochala (http://rocha.la) - Dual licensed under the MIT (http://www.opensource.org/licenses/mit-license.php) and GPL (http://www.opensource.org/licenses/gpl-license.php) licenses. */
(function(e){e.fn.extend({slimScroll:function(f){var a=e.extend({width:"auto",height:"250px",size:"7px",color:"#000",position:"right",distance:"1px",start:"top",opacity:.4,alwaysVisible:!1,disableFadeOut:!1,railVisible:!1,railColor:"#333",railOpacity:.2,railDraggable:!0,railClass:"slimScrollRail",barClass:"slimScrollBar",wrapperClass:"slimScrollDiv",allowPageScroll:!1,wheelStep:20,touchScrollStep:200,borderRadius:"7px",railBorderRadius:"7px"},f);this.each(function(){function v(d){if(r){d=d||window.event;
var c=0;d.wheelDelta&&(c=-d.wheelDelta/120);d.detail&&(c=d.detail/3);e(d.target||d.srcTarget||d.srcElement).closest("."+a.wrapperClass).is(b.parent())&&n(c,!0);d.preventDefault&&!k&&d.preventDefault();k||(d.returnValue=!1)}}function n(d,g,e){k=!1;var f=b.outerHeight()-c.outerHeight();g&&(g=parseInt(c.css("top"))+d*parseInt(a.wheelStep)/100*c.outerHeight(),g=Math.min(Math.max(g,0),f),g=0<d?Math.ceil(g):Math.floor(g),c.css({top:g+"px"}));l=parseInt(c.css("top"))/(b.outerHeight()-c.outerHeight());g=
l*(b[0].scrollHeight-b.outerHeight());e&&(g=d,d=g/b[0].scrollHeight*b.outerHeight(),d=Math.min(Math.max(d,0),f),c.css({top:d+"px"}));b.scrollTop(g);b.trigger("slimscrolling",~~g);w();p()}function x(){u=Math.max(b.outerHeight()/b[0].scrollHeight*b.outerHeight(),30);c.css({height:u+"px"});var a=u==b.outerHeight()?"none":"block";c.css({display:a})}function w(){x();clearTimeout(B);l==~~l?(k=a.allowPageScroll,C!=l&&b.trigger("slimscroll",0==~~l?"top":"bottom")):k=!1;C=l;u>=b.outerHeight()?k=!0:(c.stop(!0,
!0).fadeIn("fast"),a.railVisible&&m.stop(!0,!0).fadeIn("fast"))}function p(){a.alwaysVisible||(B=setTimeout(function(){a.disableFadeOut&&r||y||z||(c.fadeOut("slow"),m.fadeOut("slow"))},1E3))}var r,y,z,B,A,u,l,C,k=!1,b=e(this);if(b.parent().hasClass(a.wrapperClass)){var q=b.scrollTop(),c=b.siblings("."+a.barClass),m=b.siblings("."+a.railClass);x();if(e.isPlainObject(f)){if("height"in f&&"auto"==f.height){b.parent().css("height","auto");b.css("height","auto");var h=b.parent().parent().height();b.parent().css("height",
h);b.css("height",h)}else"height"in f&&(h=f.height,b.parent().css("height",h),b.css("height",h));if("scrollTo"in f)q=parseInt(a.scrollTo);else if("scrollBy"in f)q+=parseInt(a.scrollBy);else if("destroy"in f){c.remove();m.remove();b.unwrap();return}n(q,!1,!0)}}else if(!(e.isPlainObject(f)&&"destroy"in f)){a.height="auto"==a.height?b.parent().height():a.height;q=e("<div></div>").addClass(a.wrapperClass).css({position:"relative",overflow:"hidden",width:a.width,height:a.height});b.css({overflow:"hidden",
width:a.width,height:a.height});var m=e("<div></div>").addClass(a.railClass).css({width:a.size,height:"100%",position:"absolute",top:0,display:a.alwaysVisible&&a.railVisible?"block":"none","border-radius":a.railBorderRadius,background:a.railColor,opacity:a.railOpacity,zIndex:90}),c=e("<div></div>").addClass(a.barClass).css({background:a.color,width:a.size,position:"absolute",top:0,opacity:a.opacity,display:a.alwaysVisible?"block":"none","border-radius":a.borderRadius,BorderRadius:a.borderRadius,MozBorderRadius:a.borderRadius,
WebkitBorderRadius:a.borderRadius,zIndex:99}),h="right"==a.position?{right:a.distance}:{left:a.distance};m.css(h);c.css(h);b.wrap(q);b.parent().append(c);b.parent().append(m);a.railDraggable&&c.bind("mousedown",function(a){var b=e(document);z=!0;t=parseFloat(c.css("top"));pageY=a.pageY;b.bind("mousemove.slimscroll",function(a){currTop=t+a.pageY-pageY;c.css("top",currTop);n(0,c.position().top,!1)});b.bind("mouseup.slimscroll",function(a){z=!1;p();b.unbind(".slimscroll")});return!1}).bind("selectstart.slimscroll",
function(a){a.stopPropagation();a.preventDefault();return!1});m.hover(function(){w()},function(){p()});c.hover(function(){y=!0},function(){y=!1});b.hover(function(){r=!0;w();p()},function(){r=!1;p()});b.bind("touchstart",function(a,b){a.originalEvent.touches.length&&(A=a.originalEvent.touches[0].pageY)});b.bind("touchmove",function(b){k||b.originalEvent.preventDefault();b.originalEvent.touches.length&&(n((A-b.originalEvent.touches[0].pageY)/a.touchScrollStep,!0),A=b.originalEvent.touches[0].pageY)});
x();"bottom"===a.start?(c.css({top:b.outerHeight()-c.outerHeight()}),n(0,!0)):"top"!==a.start&&(n(e(a.start).position().top,null,!0),a.alwaysVisible||c.hide());window.addEventListener?(this.addEventListener("DOMMouseScroll",v,!1),this.addEventListener("mousewheel",v,!1)):document.attachEvent("onmousewheel",v)}});return this}});e.fn.extend({slimscroll:e.fn.slimScroll})})(jQuery);

var AdminLTEOptions = {	
	enableBSToppltip: false,
	BSTooltipSelector: "[data-toggle='lara_tooltipx']",
	enableFastclick: true,
	controlSidebarOptions: { toggleBtnSelector: "[data-toggle='control-sidebar']", selector: ".control-sidebar", slide: false}
};

/*! AdminLTE app.js - version 2.3.8 - (modified) - Author  Almsaeed Studio - Support <http://www.almsaeedstudio.com> - Email   <abdullah@almsaeedstudio.com> - license MIT <http://opensource.org/licenses/MIT> */
function _init(){"use strict";$.AdminLTE.layout={activate:function(){var a=this;a.fix(),a.fixSidebar(),$("body, html, .wrapper").css("height","auto"),$(window,".wrapper").resize(function(){a.fix(),a.fixSidebar()})},fix:function(){$(".layout-boxed > .wrapper").css("overflow","hidden");var a=$(".main-header").outerHeight()+$(".main-footer").outerHeight(),b=$(window).height(),c=$(".sidebar").height();if($("body").hasClass("fixed"))$(".content-wrapper, .right-side").css("min-height",b-$(".main-footer").outerHeight());else{var d;b>=c?($(".content-wrapper, .right-side").css("min-height",b-a),d=b-a):($(".content-wrapper, .right-side").css("min-height",c),d=c);var e=$($.AdminLTE.options.controlSidebarOptions.selector);"undefined"!=typeof e&&e.height()>d&&$(".content-wrapper, .right-side").css("min-height",e.height())}},fixSidebar:function(){return $("body").hasClass("fixed")?("undefined"==typeof $.fn.slimScroll&&window.console&&window.console.error("Error: the fixed layout requires the slimscroll plugin!"),void($.AdminLTE.options.sidebarSlimScroll&&"undefined"!=typeof $.fn.slimScroll&&($(".sidebar").slimScroll({destroy:!0}).height("auto"),$(".sidebar").slimscroll({height:$(window).height()-$(".main-header").height()+"px",color:"rgba(0,0,0,0.2)",size:"3px"})))):void("undefined"!=typeof $.fn.slimScroll&&$(".sidebar").slimScroll({destroy:!0}).height("auto"))}},$.AdminLTE.pushMenu={activate:function(a){var b=$.AdminLTE.options.screenSizes;$(document).on("click",a,function(a){a.preventDefault(),$(window).width()>b.sm-1?$("body").hasClass("sidebar-collapse")?$("body").removeClass("sidebar-collapse").trigger("expanded.pushMenu"):$("body").addClass("sidebar-collapse").trigger("collapsed.pushMenu"):$("body").hasClass("sidebar-open")?$("body").removeClass("sidebar-open").removeClass("sidebar-collapse").trigger("collapsed.pushMenu"):$("body").addClass("sidebar-open").trigger("expanded.pushMenu")}),$(".content-wrapper").click(function(){$(window).width()<=b.sm-1&&$("body").hasClass("sidebar-open")&&$("body").removeClass("sidebar-open")}),($.AdminLTE.options.sidebarExpandOnHover||$("body").hasClass("fixed")&&$("body").hasClass("sidebar-mini"))&&this.expandOnHover()},expandOnHover:function(){var a=this,b=$.AdminLTE.options.screenSizes.sm-1;$(".main-sidebar").hover(function(){$("body").hasClass("sidebar-mini")&&$("body").hasClass("sidebar-collapse")&&$(window).width()>b&&a.expand()},function(){$("body").hasClass("sidebar-mini")&&$("body").hasClass("sidebar-expanded-on-hover")&&$(window).width()>b&&a.collapse()})},expand:function(){$("body").removeClass("sidebar-collapse").addClass("sidebar-expanded-on-hover")},collapse:function(){$("body").hasClass("sidebar-expanded-on-hover")&&$("body").removeClass("sidebar-expanded-on-hover").addClass("sidebar-collapse")}},$.AdminLTE.tree=function(a){var b=this,c=$.AdminLTE.options.animationSpeed;$(document).off("click",a+" li a").on("click",a+" li a",function(a){var d=$(this),e=d.next();if(e.is(".treeview-menu")&&e.is(":visible")&&!$("body").hasClass("sidebar-collapse"))e.slideUp(c,function(){e.removeClass("menu-open")}),e.parent("li").removeClass("active");else if(e.is(".treeview-menu")&&!e.is(":visible")){var f=d.parents("ul").first(),g=f.find("ul:visible").slideUp(c);g.removeClass("menu-open");var h=d.parent("li");e.slideDown(c,function(){e.addClass("menu-open"),f.find("li.active").removeClass("active"),h.addClass("active"),b.layout.fix()})}e.is(".treeview-menu")&&a.preventDefault()})},$.AdminLTE.controlSidebar={activate:function(){var a=this,b=$.AdminLTE.options.controlSidebarOptions,c=$(b.selector),d=$(b.toggleBtnSelector);d.on("click",function(d){d.preventDefault(),c.hasClass("control-sidebar-open")||$("body").hasClass("control-sidebar-open")?a.close(c,b.slide):a.open(c,b.slide)});var e=$(".control-sidebar-bg");a._fix(e),$("body").hasClass("fixed")?a._fixForFixed(c):$(".content-wrapper, .right-side").height()<c.height()&&a._fixForContent(c)},open:function(a,b){b?a.addClass("control-sidebar-open"):$("body").addClass("control-sidebar-open")},close:function(a,b){b?a.removeClass("control-sidebar-open"):$("body").removeClass("control-sidebar-open")},_fix:function(a){var b=this;if($("body").hasClass("layout-boxed")){if(a.css("position","absolute"),a.height($(".wrapper").height()),b.hasBindedResize)return;$(window).resize(function(){b._fix(a)}),b.hasBindedResize=!0}else a.css({position:"fixed",height:"auto"})},_fixForFixed:function(a){a.css({position:"fixed","max-height":"100%",overflow:"auto","padding-bottom":"50px"})},_fixForContent:function(a){$(".content-wrapper, .right-side").css("min-height",a.height())}},$.AdminLTE.boxWidget={selectors:$.AdminLTE.options.boxWidgetOptions.boxWidgetSelectors,icons:$.AdminLTE.options.boxWidgetOptions.boxWidgetIcons,animationSpeed:$.AdminLTE.options.animationSpeed,activate:function(a){var b=this;a||(a=document),$(a).on("click",b.selectors.collapse,function(a){a.preventDefault(),b.collapse($(this))}),$(a).on("click",b.selectors.remove,function(a){a.preventDefault(),b.remove($(this))})},collapse:function(a){var b=this,c=a.parents(".box").first(),d=c.find("> .box-body, > .box-footer, > form  >.box-body, > form > .box-footer");c.hasClass("collapsed-box")?(a.children(":first").removeClass(b.icons.open).addClass(b.icons.collapse),d.slideDown(b.animationSpeed,function(){c.removeClass("collapsed-box")})):(a.children(":first").removeClass(b.icons.collapse).addClass(b.icons.open),d.slideUp(b.animationSpeed,function(){c.addClass("collapsed-box")}))},remove:function(a){var b=a.parents(".box").first();b.slideUp(this.animationSpeed)}}}if("undefined"==typeof jQuery)throw new Error("AdminLTE requires jQuery");$(function(){"use strict";$.AdminLTE={},$.AdminLTE.options={navbarMenuSlimscroll:!0,navbarMenuSlimscrollWidth:"3px",navbarMenuHeight:"200px",animationSpeed:500,sidebarToggleSelector:"[data-toggle='offcanvas']",sidebarPushMenu:!0,sidebarSlimScroll:!0,sidebarExpandOnHover:!1,enableBoxRefresh:!0,enableBSToppltip:!0,BSTooltipSelector:"[data-toggle='tooltip']",enableFastclick:!1,enableControlSidebar:!0,controlSidebarOptions:{toggleBtnSelector:"[data-toggle='control-sidebar']",selector:".control-sidebar",slide:!0},enableBoxWidget:!0,boxWidgetOptions:{boxWidgetIcons:{collapse:"fa-minus",open:"fa-plus",remove:"fa-times"},boxWidgetSelectors:{remove:'[data-widget="remove"]',collapse:'[data-widget="collapse"]'}},directChat:{enable:!0,contactToggleSelector:'[data-widget="chat-pane-toggle"]'},colors:{lightBlue:"#3c8dbc",red:"#f56954",green:"#00a65a",aqua:"#00c0ef",yellow:"#f39c12",blue:"#0073b7",navy:"#001F3F",teal:"#39CCCC",olive:"#3D9970",lime:"#01FF70",orange:"#FF851B",fuchsia:"#F012BE",purple:"#8E24AA",maroon:"#D81B60",black:"#222222",gray:"#d2d6de"},screenSizes:{xs:480,sm:768,md:992,lg:1200}},$("body").removeClass("hold-transition"),"undefined"!=typeof AdminLTEOptions&&$.extend(!0,$.AdminLTE.options,AdminLTEOptions);var a=$.AdminLTE.options;_init(),$.AdminLTE.layout.activate(),$.AdminLTE.tree(".sidebar"),a.enableControlSidebar&&$.AdminLTE.controlSidebar.activate(),a.navbarMenuSlimscroll&&"undefined"!=typeof $.fn.slimscroll&&$(".navbar .menu").slimscroll({height:a.navbarMenuHeight,alwaysVisible:!1,size:a.navbarMenuSlimscrollWidth}).css("width","100%"),a.sidebarPushMenu&&$.AdminLTE.pushMenu.activate(a.sidebarToggleSelector),a.enableBSToppltip&&$("body").tooltip({selector:a.BSTooltipSelector}),a.enableBoxWidget&&$.AdminLTE.boxWidget.activate(),a.enableFastclick&&"undefined"!=typeof FastClick&&FastClick.attach(document.body),a.directChat.enable&&$(document).on("click",a.directChat.contactToggleSelector,function(){var a=$(this).parents(".direct-chat").first();a.toggleClass("direct-chat-contacts-open")}),$('.btn-group[data-toggle="btn-toggle"]').each(function(){var a=$(this);$(this).find(".btn").on("click",function(b){a.find(".btn.active").removeClass("active"),$(this).addClass("active"),b.preventDefault()})})}),function(a){"use strict";a.fn.boxRefresh=function(b){function e(a){a.append(d),c.onLoadStart.call(a)}function f(a){a.find(d).remove(),c.onLoadDone.call(a)}var c=a.extend({trigger:".refresh-btn",source:"",onLoadStart:function(a){return a},onLoadDone:function(a){return a}},b),d=a('<div class="overlay"><div class="fa fa-refresh fa-spin"></div></div>');return this.each(function(){if(""===c.source)return void(window.console&&window.console.log("Please specify a source first - boxRefresh()"));var b=a(this),d=b.find(c.trigger).first();d.on("click",function(a){a.preventDefault(),e(b),b.find(".box-body").load(c.source,function(){f(b)})})})}}(jQuery),function(a){"use strict";a.fn.activateBox=function(){a.AdminLTE.boxWidget.activate(this)},a.fn.toggleBox=function(){var b=a(a.AdminLTE.boxWidget.selectors.collapse,this);a.AdminLTE.boxWidget.collapse(b)},a.fn.removeBox=function(){var b=a(a.AdminLTE.boxWidget.selectors.remove,this);a.AdminLTE.boxWidget.remove(b)}}(jQuery),function(a){"use strict";a.fn.todolist=function(b){var c=a.extend({onCheck:function(a){return a},onUncheck:function(a){return a}},b);return this.each(function(){"undefined"!=typeof a.fn.iCheck?(a("input",this).on("ifChecked",function(){var b=a(this).parents("li").first();b.toggleClass("done"),c.onCheck.call(b)}),a("input",this).on("ifUnchecked",function(){var b=a(this).parents("li").first();b.toggleClass("done"),c.onUncheck.call(b)})):a("input",this).on("change",function(){var b=a(this).parents("li").first();b.toggleClass("done"),a("input",b).is(":checked")?c.onCheck.call(b):c.onUncheck.call(b)})})}}(jQuery);


/*
 * @package    WHMCS Main Lara Controlers
 * @author     Amr M. Ibrahim <mailamr@gmail.com>
 * @copyright  Copyright (c) WHMCSAdminTheme 2016
 * @link       http://www.whmcsadmintheme.com
 */
 
var lr_entityMap = {
  '&': '&amp;',
  '<': '&lt;',
  '>': '&gt;',
  '"': '&quot;',
  "'": '&#39;',
  '/': '&#x2F;',
  '`': '&#x60;',
  '=': '&#x3D;'
};

function lr_escapeHtml (string) {
  return String(string).replace(/[&<>"'`=\/]/g, function (s) {
    return lr_entityMap[s];
  });
} 
 
function setThemeSettings(settingsArray){
	var errormsg="";
	$.ajax({
		type    : 'POST',
		url     : getlrFullPath("addonmodules.php?module=lara_addon"),
		data    : settingsArray,
		dataType: 'json',
		success: function(data, textStatus, jqXHR) { },
		error: function(jqXHR, textStatus, errorThrown) { 
					if (jqXHR.readyState < 4) {
						console.log("aborted");
					}else{
						$('#ljsonerror').remove();
						$('section.content').prepend("<div id='ljsonerror' class='callout callout-danger'><h4>Error :</h4>Couldn't save settings! .. Make sure that your administrator group has access to <b>Lara Theme Settings</b> module </div>");
					}
		}
	});
}

$.fn.textWidth = function(text, font) {
    if (!$.fn.textWidth.fakeEl) $.fn.textWidth.fakeEl = $('<span>').hide().appendTo(document.body);
    $.fn.textWidth.fakeEl.text(text || this.val() || this.text()).css('font', font || this.css('font'));
    return $.fn.textWidth.fakeEl.width();
};

var lara_skins = [
	"skin-blue",
	"skin-black",
	"skin-red",
	"skin-yellow",
	"skin-purple",
	"skin-green",
	"skin-blue-light",
	"skin-black-light",
	"skin-red-light",
	"skin-yellow-light",
	"skin-purple-light",
	"skin-green-light"
];

var delay = (function(){
  var timer = 0;
  return function(callback, ms){
    clearTimeout (timer);
    timer = setTimeout(callback, ms);
  };
})();


function resetMainNav(){
	$(".sidebar-menu li").removeClass('active').show();
	$("#IntSearchResults").html('');
	$('.main-sidebar').css("width", "");
	setNavigation();	
}

function doiSearch(form){
	var searchIconsArray = {clients:"fa-user", contacts:"fa-user", "products/services":"fa-server", domains:"fa-globe", invoices:"fa-usd", "support tickets":"fa-ticket"};
	var currentSearchSection = "";
	var currentSearchIcon = "";
	var obj = {};
	var stats = {};
	var resultsObj = {};
	
	var start_time = new Date().getTime();
	$.post(whmcsBaseUrl + adminBaseRoutePath + "/search.php", $(form).serialize(),
	
	function(data){
		var request_time = (new Date().getTime() - start_time) / 1000;
		var resultsCount=0;
		var maxWidth=0;
		var longest="";
		
		$(data).each(function( index ) {
			if (this.className == "searchresultheader"){currentSearchSection = this.innerHTML.toLowerCase();}
			if ( !searchIconsArray[currentSearchSection] ){ currentSearchIcon = "fa-circle"; }else{currentSearchIcon = searchIconsArray[currentSearchSection]; }    
			if (this.className == "searchresult"){
				resultsCount++;
				obj[index]= {};
				obj[index]['icon'] = currentSearchIcon;
				obj[index]['url'] = $( this ).children('a').attr('href');
				obj[index]['classText'] = lr_escapeHtml($( this ).children('a').children('span.label').text());
				obj[index]['class'] = $( this ).children('a').children('span.label').removeClass('label').attr('class');
				obj[index]['desc'] = lr_escapeHtml($( this ).children('a').children('span.desc').text());
				$( this ).children('a').children('span').remove();
				obj[index]['result'] = lr_escapeHtml($( this ).children('a').text());  					 
				
				
				if (Object.keys(obj[index]['desc']).length > maxWidth){ 
					maxWidth = Object.keys(obj[index]['desc']).length;
					longest = obj[index]['desc'];
				}
				if (Object.keys(obj[index]['result']).length > maxWidth){ 
					maxWidth = Object.keys(obj[index]['result']).length;
					longest = obj[index]['result'];
				}
			}
		});
		
		stats['time'] = request_time;
		stats['resultscount'] = resultsCount;
		stats['maxWidth'] = maxWidth;
		stats['longest'] = longest;
		resultsObj ={'stats' : stats, 'results' : obj};
		showISearchResults(form, resultsObj);
	});
}

function showISearchResults(form, resultsObj){
	if (form == "#lrmenuintellisearch"){
			$(".sidebar-menu li").hide();
			$("#IntSearchResults").html('');
			$('.main-sidebar').css("width", "");
			$("#isearch-icon").removeClass('fa-pulse').removeClass('fa-spinner').addClass('fa-search');

			if ($.isEmptyObject(resultsObj['results'])){
				$("#IntSearchResults").append('<li><a href="#"><i class="fa fa-ban"></i><strong>No Matches Found!</strong></a></li>');
			}else{
				var maxCalcWidth = $.fn.textWidth(resultsObj['stats']['longest']) + 140;
				if (maxCalcWidth > 230){ $('.main-sidebar').css("width", maxCalcWidth+"px");}
				setTimeout(function(){
					$("#IntSearchResults").append("<li class='header' ><b>"+resultsObj['stats']['resultscount']+"</b> results ("+resultsObj['stats']['time']+" seconds)</li>");
					$.each( resultsObj['results'], function( key, value ) {
						$("#IntSearchResults").append('<li><a href="'+value['url']+'"><i class="fa '+value['icon']+'"></i><strong>'+value['result']+'</strong>\
						<span class="label '+value['class']+' pull-right">'+value['classText']+'</span><br><span class="desc">'+value['desc']+'</span></a></li>');
					});
				}, $.AdminLTE.options.animationSpeed);
			}			
	}
}

$(document).ready(function(){
	
	if ($('body').hasClass('expandonhover')){
		$.AdminLTE.pushMenu.expandOnHover();
	}

	if ($('body').hasClass('fixed')){
		$("aside.control-sidebar").css("overflow-x","hidden");
	}	
	
	try {	
		$(".lara-bootstrap-switch").bootstrapSwitch();
		
		$('.lara-bootstrap-switch').on('switchChange.bootstrapSwitch', function(event, state) {
			var sArray = {mode: 'update'};
			sArray[this.name]= state;
			setThemeSettings(sArray);
		});	
	} catch(err) {
		console.log(err.message);
	}	
	
    $("#lrmenuintellisearch").submit(function(e) {
        e.preventDefault();
		if ($('#lrmenuintellisearch input[name=value]').val()){
			$("#isearch-icon").removeClass('fa-search').addClass('fa-spinner fa-pulse');
			$('.main-sidebar').css("width", "");
			$("#IntSearchResults").html('<li><a href="#"><i class="fa fa-spinner fa-pulse fa-fw"></i> <strong> Searching ... </strong></a></li>');
			doiSearch("#lrmenuintellisearch");
		}
	});
	
	$("#intellisearchval").keyup(function (e) {
		var key = e.which;
		if(key == 13){return;}
		if (this.value.length > 0) {
			$("#IntSearchResults").html('');	
			var input =  this.value.toLowerCase().split(" ");
			var query = '';
			var results = 0;

			$.each( input, function( key, value ) {
				query += "(?=.*"+value+")";
			});	

			$(".sidebar-menu li").each(function () {
				 if ($(this).text().toLowerCase().match("^"+query+".*$")) {
					 if ($(this).parents('li').attr("id") != "SideMenu-Home"){
						 $(this).show();
						 $(this).parents('li').addClass('active').show();
						 $(this).parents('ul').addClass('active').show();
						 results++;
					 }
				 }else{
					$(this).hide(); 
				 }
					
			});
			if( results == 0 ){
				$("#IntSearchResults").append('<li><a href="#">To use Intelligent Search, press <br>enter or click on the &nbsp;<i class="fa fa-search"></i>icon.</a></li>');
			}
		}else{
			resetMainNav();
		}
	});	
	
	$.each(lara_skins, function (i) {
		if ($("body").hasClass(lara_skins[i])){
			$("[data-lara-skin="+lara_skins[i]+"]").next('p').css( 'text-decoration','underline' );
		}
	});	
	
	$(document).on('click', "[data-toggle='offcanvas']" , function (e) {
		if ($("body").hasClass('sidebar-collapse')) {
			WHMCS.http.jqClient.post(whmcsBaseUrl + adminBaseRoutePath + "/search.php","a=minsidebar");
			$("#intellisearchval").val("");
			resetMainNav();		
		} else {
			WHMCS.http.jqClient.post(whmcsBaseUrl + adminBaseRoutePath + "/search.php","a=maxsidebar");
		} 
	});	
	
	$("[data-toggle='control-sidebar']").on('click', function (e) {
		if (typeof (Storage) !== "undefined") {	
			if ($("body").hasClass('control-sidebar-open')) {
				localStorage.setItem('controlsidebaropen', '1');
			} else {
				localStorage.setItem('controlsidebaropen', '0');
			}
		}
	});	
	
	$(".control-sidebar .nav-tabs [data-toggle='tab']").on('click', function (e) {
		if (typeof (Storage) !== "undefined") {
			localStorage.setItem('controlsidebartab', $(this).attr('href'));
		}
	});

	if (typeof (Storage) !== "undefined"){
		if (localStorage.getItem('controlsidebartab')){
			$('.control-sidebar .nav-tabs a[href="'+localStorage.getItem('controlsidebartab')+'"]').tab('show');
		}
	}
    
    $("[data-lara-skin]").on('click', function (e) {
		e.preventDefault();
		var sideBarSkin ="";
	
		$.each(lara_skins, function (i) {
			$("body").removeClass(lara_skins[i]);
		});
		
		$("body").addClass($(this).data('lara-skin'));
		
		
		$("[data-lara-skin]").next('p').css( 'text-decoration','' );
		$(this).next('p').css( 'text-decoration','underline' );
		
		$(".control-sidebar").removeClass("control-sidebar-dark");
		$(".control-sidebar").removeClass("control-sidebar-light");
		if( $(this).data('lara-skin').indexOf('light') >= 0){
			sideBarSkin = "control-sidebar-light";
		}else{
			sideBarSkin = "control-sidebar-dark";
		}
		$(".control-sidebar").addClass(sideBarSkin);
	
		setThemeSettings({'mode': 'update', 
		                  'current_skin': $(this).data('lara-skin'),
                          'sidebar_skin':sideBarSkin});
		return false;
			  
    });
	
    $("[data-lrlayout]").on('click', function (e) {
		var cLayout = "";
		if($(this).is(":checked")) {
			$("body").addClass('fixed');
			$( "[data-lrsidebar]" ).prop( "checked", true );
			$( "[data-lrsidebar]" ).prop( "disabled", true );
			cLayout = "fixed";
		}else{
			$("body").removeClass('fixed');
			$( "[data-lrsidebar]" ).prop( "checked", false );
			$( "[data-lrsidebar]" ).prop( "disabled", false );			
		}
		$('[data-layout-settings="save"]').prop('disabled', false);
		setThemeSettings({'mode': 'update', 'lrlayout':cLayout, 'lrsidebar':""});
			  
    });

	$("[data-layout-settings]").on('click', function () {
		location.reload();
    });		
	
    $("[data-lrsidebar]").on('click', function (e) {
		var clrsidebar = "";
		if($(this).is(":checked")) {
			$.AdminLTE.pushMenu.expandOnHover();
			if (!$('body').hasClass('sidebar-collapse')){
				$("[data-toggle='offcanvas']").click();
			}
			clrsidebar = "expandonhover";
		}else{
			if ($('body').hasClass('sidebar-collapse')){
				$("[data-toggle='offcanvas']").click();
			}
		}
		setThemeSettings({'mode': 'update', 'lrsidebar':clrsidebar});
    });
	
	$("[data-lrdismiss]").on('click', function (e) {
		var request = {'mode': 'update'};
		var dismissedID = $(this).data("lrdismiss");
		var timeDismissed = new Date().getTime();
		request[dismissedID] = timeDismissed;
		$(this).parent("div").slideUp();
		setThemeSettings(request);
	});	
	
	$(".tablebg a").each(function( index ) {
		var bgColor = $( this ).css('backgroundColor') ;
		if (bgColor != "rgba(0, 0, 0, 0)" && bgColor != "transparent" && bgColor != "rgb(255, 255, 255)") {
			$(this).parent("td").css("background-color", bgColor);
			$(this).css("color", "#fff");     
		}
	});
	
	$("[data-modal-class='modal-configure-settings']").css('margin','25px');
	
	try {	
		$("#intelliSearchRealtime").bootstrapSwitch('labelWidth',130);
		$("#intellisearchval").click();
	} catch(err) {
		console.log(err.message);
	}	
});