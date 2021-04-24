

	$(document).ready(function() {
		if ($(window).width() < 441) {
           var winHeight = $(window).height() - 87;
		   $(".rightSec").css("min-height" , winHeight);
	   } else { 
	   	   var winHeight = $(window).height() - 50;
		   $(".rightSec").css("min-height" , winHeight);
	   }
	   
    });
	
//side script---------------------------------



$(document).ready(function(){
						   
		if ($(window).width() < 1025){
			var a = false;
		$(".sideBar").animate({left: '-240px'});
		 $(".menuIcon").click(function(){					   
			 jQuery( ".menuIcon" ).toggleClass( "arrow_change" );
			 jQuery( ".sideBar" ).toggleClass( "change" );
			 if( a == false ){
				 $(".sideBar").animate({left: '0'});
				  
				  a = true;
			 }else if( a == true ){
					$(".sideBar").animate({left: '-240px'});
					a = false; 
				 }			 
		   });
		} else {
			jQuery(".menuIcon").click(function() {
				jQuery(".sideBar").slideToggle(700);
				jQuery( ".menuIcon" ).toggleClass( "arrow_change" );
			});
		}
		
});
$(document).ready(function(){
	$(".menuSec ul li").click(function() {
		if($(this).siblings().children("ul").is(":visible")){
               $(this).siblings().children("ul").slideUp();
			   $(this).siblings().children(".fa-angle-right").removeClass("rot");
           }
		$(this).children("ul").slideToggle(700);
		$(this).children(".fa-angle-right").toggleClass("rot");
	});
});


