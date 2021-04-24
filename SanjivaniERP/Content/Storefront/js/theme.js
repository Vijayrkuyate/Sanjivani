(function($) {
    "use strict";
    $(document).on("ready", function(e) {
		/*----------------------------------------------------*/
        /*  Boxed Layout
        /*----------------------------------------------------*/							 
         /*$('body').addClass('boxed-layout');*/
		 
        /*----------------------------------------------------*/
        /*  Preloader
        /*----------------------------------------------------*/
        $(".preloader").fadeOut('slow');
        /*----------------------------------------------------*/
        /*  Main Slider
        /*----------------------------------------------------*/
        $('.home_slider').owlCarousel({
            loop:true,
            margin:0,
            nav:true,
			autoplay:true,
           autoplayTimeout:5000, 
			dots: false,
            navText: [
              "<span class='lnr lnr-chevron-left'></span>",
              "<span class='lnr lnr-chevron-right'></span>"
              ],
            items: 1
        });

		/*----------------------------------------------------*/
        /*  Toottip
        /*----------------------------------------------------*/  
		$('[data-toggle="tooltip"]').tooltip();
		
		/*----------------------------------------------------*/
        /*  Popover
        /*----------------------------------------------------*/  
		$('[data-toggle="popover"]').popover();
	
		/*----------------------------------------------------*/
        /*  Logo Slider
        /*----------------------------------------------------*/       
		$(".portfolio_slider").owlCarousel({
			loop:true,
			margin:0,
			nav:true,
			dots: true,
			navText: [
			  "<span class='lnr lnr-arrow-left'></span>",
			  "<span class='lnr lnr-arrow-right'></span>"
			  ],
			autoplay:true,            
			responsive:{
				0:{
					items:1
				},
				800:{
					items:4
				}
			}
		});
		
		//Gallery-Slider
		$('.gallery-slider .work').hover(
			function(){
				$(this).find('.layer').fadeIn( "fast" );
				$(this).find('.more').fadeIn( "fast" );
			}, 
			function(){
				$(this).find('.layer').fadeOut( "fast" );
				$(this).find('.more').fadeOut( "fast" );
			}
		);
		
		// Phone Gallery Slider
		var $galleryCarouselDiv = $('.screen-carousel-1');
		if ($galleryCarouselDiv.length && $.fn.owlCarousel) {
			$galleryCarouselDiv.owlCarousel({
				loop: true,
				center: true,
				autoplay: true,
				responsive: {
					0: {
						items: 1,
						margin: 50,
						autoWidth: false,
						dots: true
					},
					600: {
						items: 4,
						margin: 100,
						autoWidth: true,
						dots: false
					}
				}
			});
		}
	
		// Testimonials 2
		var $loopDiv = $('.loop');
		if ($loopDiv.length && $.fn.slick) {
			$loopDiv.slick({
				centerMode: true,
				centerPadding: '60px',
				autoplay: true,
				autoplaySpeed: 5000,
				arrows: true,
				dots: true,
				slidesToShow: 3,
				responsive: [{
					breakpoint: 992,
					settings: {
						arrows: false,
						centerMode: true,
						centerPadding: '40px',
						slidesToShow: 1
					}
				}, {
					breakpoint: 768,
					settings: {
						arrows: false,
						centerMode: true,
						centerPadding: '40px',
						slidesToShow: 1
					}
				}, {
					breakpoint: 480,
					settings: {
						arrows: false,
						centerMode: true,
						centerPadding: '40px',
						slidesToShow: 1
					}
				}]
			});
		}
		
		//Clients
		var $clientSlider = $('.client-slide');
		if ($clientSlider.length && $.fn.owlCarousel) {
			// Client Slider
			$('.client-slide').owlCarousel({
				margin: 30,
				loop: true,
				autoWidth: true,
				autoplay: true,
				items: 5
			});
		}
		
		//Mobile-Slider
		var $ScreenSlider = $('.screen-slider');
		if ($ScreenSlider.length && $.fn.owlCarousel) {
			$('.screen-slider').owlCarousel({
				margin:0,
				loop: true,
				autoWidth: false,
				autoplay: true,
				dots: false,
				items: 1
			});
		}
		
		//Single Project Slider
		$(".single-project").owlCarousel({
			loop:true,
			margin:0,
			nav:true,
			autoplay:true,
			autoplayTimeout:5000, 
			dots: false,
			navText: [
				"<span class='lnr lnr-arrow-left'></span>",
				"<span class='lnr lnr-arrow-right'></span>"
			],
			items: 1
		});

		//Progress Bars
		setTimeout(function(){
			$('.progress .progress-bar').each(function() {
				var me = $(this);
				var perc = me.attr("data-percentage");
	
				//TODO: left and right text handling
	
				var current_perc = 0;
	
				var progress = setInterval(function() {
					if (current_perc>=perc) {
						clearInterval(progress);
					} else {
						current_perc +=1;
						me.css('width', (current_perc)+'%');
					}
					var meandclass = me.find(".skills-percentage");
					meandclass.text((current_perc)+'%');
	
				}, 50);
	
			});
	
		},50);
		/*----------------------------------------------------*/
        /*  Countdown Timers
        /*----------------------------------------------------*/

		if ($('.countdown').length) {
			$('.countdown').each(function() {
				var date = $(this).attr('data-date');
				$(this).countdown(date, function(event) {
					$(this).text(
						event.strftime('%D days %H:%M:%S')
					);
				});
			});
		}
        
        /*----------------------------------------------------*/
        /*  Find Domain Form Dropdown
        /*----------------------------------------------------*/
        $('.domain_search_drop').on("click",function(){
            $(this).toggleClass('rotate')
        });
		
		
        /*----------------------------------------------------*/
        /*  Pricing Plans Slider
        /*----------------------------------------------------*/
        $('.pricing_plan').owlCarousel({
            loop:true,
            margin:0,
            nav:true,
            autoplay:true,
            navContainer: "#pricing_nav",
            navText: [
              "<span class='lnr lnr-arrow-left'></span>",
              "<span class='lnr lnr-arrow-right'></span>"
              ],
            responsiveClass:true,
            responsive:{
                0:{
                    items:1,
                    center: true
                },
                992:{
                    items:3,
                    center: true
                }
            }
        });
		
		/*----------------------------------------------------*/
        /*  Fixed Top Header
        /*----------------------------------------------------*/        
		$(".navbar-default").affix({
			offset: {
				top: $('.top_header').height()
			}
		});
	
        /*----------------------------------------------------*/
        /*  Pricing Slider
        /*----------------------------------------------------*/        
        $('.pricing_slider').owlCarousel({
            loop:true,
            margin:0,
            nav:false,
            dots: true,
            autoplay:true,
            responsiveClass:true,
            responsive:{
                0:{
                    items:1
                },
                700:{
                    items:2
                },
                992:{
                    items:4
                },
                1501:{
                    items:4
                }
            }
        });
		
		/*----------------------------------------------------*/
        /*  dropdown Slider
        /*----------------------------------------------------*/        
        $('.dropdown_slider').owlCarousel({
            loop:true,
            margin:0,
            nav:true,
            dots: true,
            autoplay:true,
			autoplayTimeout:2000,
            responsiveClass:true,
            responsive:{
                0:{
                    items:1
                }
            }
        });
		
		/*----------------------------------------------------*/
        /*  dropdown Slider
        /*----------------------------------------------------*/        
        $('.dropdown_sliderfull').owlCarousel({
            loop:true,
            margin:0,
            nav:true,
            dots: true,
            autoplay:true,
			autoplayTimeout:2000,
            responsiveClass:true,
            responsive:{
               0:{
					items:1
				},
			   800:{
					items:4
				}
            }
        });
        
		 /*----------------------------------------------------*/
        /*  Logo Slider
        /*----------------------------------------------------*/       
			$(".logo_slider").owlCarousel({
				loop:true,
				margin:0,
				nav:false,
				pagination : true,
				slideSpeed : 200,
				paginationSpeed : 800,
				rewindSpeed : 1000,
				navText: [
				  "<span class='lnr lnr-arrow-left'></span>",
				  "<span class='lnr lnr-arrow-right'></span>"
				  ],
				autoplay:true,            
				responsive:{
					0:{
						items:1
					},
					800:{
						items:4
					}
				}
			});
			
		/*----------------------------------------------------*/
        /*  Domain Price Slider
        /*----------------------------------------------------*/       
			$(".domain_slider").owlCarousel({
				loop:true,
				margin:0,
				nav:false,
				navText: [
				  "<span class='lnr lnr-arrow-left'></span>",
				  "<span class='lnr lnr-arrow-right'></span>"
				  ],
				autoplay:true,            
				responsive:{
					0:{
						items:1
					},
					800:{
						items:6
					}
				}
			});

        /*----------------------------------------------------*/
        /*  Testimonial Slider
        /*----------------------------------------------------*/        
        $('.testimonial_slider').owlCarousel({
            loop:true,
            margin:0,
            nav:true,
            navText: [
              "<span class='lnr lnr-arrow-left'></span>",
              "<span class='lnr lnr-arrow-right'></span>"
              ],
            autoplay:true,
            items: 1
        });      
        $('.testimonial_slider2').owlCarousel({
            loop:true,
            margin:0,
            nav:true,
            navText: [
              "<span class='lnr lnr-arrow-left'></span>",
              "<span class='lnr lnr-arrow-right'></span>"
              ],
            autoplay:true,            
            responsive:{
                0:{
                    items:1
                },
                800:{
                    items:2
                }
            }
        });
        
        /*----------------------------------------------------*/
        /*  Domain Search Filter
        /*----------------------------------------------------*/    
		$('.searchFilters .dropdown-menu').find('a').on("click", function(e){
            e.preventDefault();
            var param = $(this).attr("href").replace("#","");
            var concept = $(this).text();
            $('.searchFilters span#searchFilterValue').text(concept);
            $('.input-group #search_param').val(param)
        });
        
        /*----------------------------------------------------*/
        /*  Counter Up - Fun Facts
        /*----------------------------------------------------*/
        $('.fact strong').counterUp({
            delay: 10,
            time: 1000
        });
        
        /*----------------------------------------------------*/
        /*  Counter Up - Fun Facts
        /*----------------------------------------------------*/
        $('.we_used .progress-bar').each(function(){
            var $this = $(this);
            var width = $(this).data('skill');
            $this.css({
                'transition' : 'width 2s'
            });
            
            setTimeout(function() {
                $this.waypoint(function(direction) {
                    if( direction === 'down' ) {
                        $this.css({
                            'width' : width + '%'
                        })
                    }
                } , { offset: '100%' } )
            }, 500)
        });
        
        /*----------------------------------------------------*/
        /*  PopUps
        /*----------------------------------------------------*/
        $('.portfolio-link').magnificPopup({
            type: 'image'
        });
				
        /*----------------------------------------------------*/
        /*  Back To Top Button
        /*----------------------------------------------------*/
		$(window).on("scroll", function(e) {
			if ($(this).scrollTop() > 300) {
				$('#back-to-top').fadeIn('slow');
			} else {
				$('#back-to-top').fadeOut('slow');
			}
		});
	
		$("#back-to-top").on("click", function(e){
			$("html, body").animate({
				scrollTop: 0
			}, 600);
			return false;
		})
		
		/*----------------------------------------------------*/
        /*  Background Cover Image
        /*----------------------------------------------------*/  	
		 $( ".cover-image").each(function() {
			  var attr = $(this).attr('data-image-src');
			
			  if (typeof attr !== typeof undefined && attr !== false) {
				  $(this).css('background', 'url('+attr+') center center');
			  }
		});
		
		 $( ".cover-image2").each(function() {
			  var attr = $(this).attr('data-image-src');
			
			  if (typeof attr !== typeof undefined && attr !== false) {
				  $(this).css('background', 'url('+attr+') center center');
			  }
		});

		/*----------------------------------------------------*/
        /*  TreeView
        /*----------------------------------------------------*/  
		$.fn.extend({
			treed: function (o) {
			  
			  var openedClass = 'glyphicon-minus-sign';
			  var closedClass = 'glyphicon-plus-sign';
			  
			  if (typeof o != 'undefined'){
				if (typeof o.openedClass != 'undefined'){
				openedClass = o.openedClass;
				}
				if (typeof o.closedClass != 'undefined'){
				closedClass = o.closedClass;
				}
			  };
			  
				//initialize each of the top levels
				var tree = $(this);
				tree.addClass("tree");
				tree.find('li').has("ul").each(function () {
					var branch = $(this); //li with children ul
					branch.prepend("<i class='indicator glyphicon " + closedClass + "'></i>");
					branch.addClass('branch');
					branch.on('click', function (e) {
						if (this == e.target) {
							var icon = $(this).children('i:first');
							icon.toggleClass(openedClass + " " + closedClass);
							$(this).children().children().toggle();
						}
					})
					branch.children().children().toggle();
				});
				//fire event from the dynamically added icon
			  tree.find('.branch .indicator').each(function(){
				$(this).on('click', function () {
					$(this).closest('li').click();
				});
			  });
				//fire event to open branch if the li contains an anchor instead of text
				tree.find('.branch>a').each(function () {
					$(this).on('click', function (e) {
						$(this).closest('li').click();
						e.preventDefault();
					});
				});
				//fire event to open branch if the li contains a button instead of text
				tree.find('.branch>button').each(function () {
					$(this).on('click', function (e) {
						$(this).closest('li').click();
						e.preventDefault();
					});
				});
			}
		});
		
		//Initialization of treeviews
		$('#tree1').treed();
		
		$('#tree2').treed({openedClass:'glyphicon-folder-open', closedClass:'glyphicon-folder-close'});
		
		$('#tree3').treed({openedClass:'glyphicon-chevron-right', closedClass:'glyphicon-chevron-down'});
	
		//set equalize height
		$('.equalize').equalize();

        /*----------------------------------------------------*/
        /*  Contact Form Height
        /*----------------------------------------------------*/
        $('#success, #error').each(function(){
            var line_height = $(this).height();
            $(this).find('p').css( "line-height", function(){
                return line_height + 'px'
            })
        })
        
    })
    
})(jQuery)