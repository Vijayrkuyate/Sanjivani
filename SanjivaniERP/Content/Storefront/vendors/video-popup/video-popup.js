(function ( $ ) {
	"use strict";
    $.fn.VideoPopUp = function(options) {

        var VideoPopUpOptions = $.extend({
                autoplay: 1
        }, options );

        $(this).on('click', function (e) {

            var youtubeLink = $(this).attr("href");

            if( youtubeLink.match(/(youtube.com)/) ){
                var split_c = "v=";
                var split_n = 1;
            }

            if( youtubeLink.match(/(youtu.be)/) || youtubeLink.match(/(vimeo.com\/)+[0-9]/) ){
                var split_c = "/";
                var split_n = 3;
            }

            if( youtubeLink.match(/(vimeo.com\/)+[a-zA-Z]/) ){
                var split_c = "/";
                var split_n = 5;
            }

            var getVideoVideoID = youtubeLink.split(split_c)[split_n];

            var cleanVideoID = getVideoVideoID.replace(/(&)+(.*)/, "");

            if( youtubeLink.match(/(youtu.be)/) || youtubeLink.match(/(youtube.com)/) ){
                var videoEmbedLink = "https://www.youtube.com/embed/"+cleanVideoID+"?autoplay="+VideoPopUpOptions.autoplay+"";
            }

            if( youtubeLink.match(/(vimeo.com\/)+[0-9]/) || youtubeLink.match(/(vimeo.com\/)+[a-zA-Z]/) ){
                var videoEmbedLink = "https://player.vimeo.com/video/"+cleanVideoID+"?autoplay="+VideoPopUpOptions.autoplay+"";
            }

            $("body").append('<div class="VideoPopUp-Wrap VideoPopUp-animation"><div class="VideoPopUp-Content"><span class="VideoPopUp-Close"></span><iframe src="'+videoEmbedLink+'" allowfullscreen></iframe></div></div>');

            if( $('.VideoPopUp-Wrap').hasClass('VideoPopUp-animation') ){
                setTimeout(function() {
                    $('.VideoPopUp-Wrap').removeClass("VideoPopUp-animation");
                }, 600);
            }

            $(".VideoPopUp-Wrap, .VideoPopUp-Close").click(function(){
                $(".VideoPopUp-Wrap").addClass("VideoPopUp-Hide").delay(515).queue(function() { $(this).remove(); });
            });

            e.preventDefault();

        });

        $(document).keyup(function(e) {

            if ( e.keyCode == 27 ){
                $('.VideoPopUp-Wrap, .VideoPopUp-Close').click();
            }

        });

    };

}( jQuery ));
