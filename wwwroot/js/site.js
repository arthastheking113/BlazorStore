window.sliderFunctions = {
    startSlider: function () {

        /*=======================
            Popular Slider JS
        =========================*/
        $('.popular-slider').owlCarousel({
            items: 1,
            autoplay: true,
            autoplayTimeout: 5000,
            smartSpeed: 400,
            animateIn: 'fadeIn',
            animateOut: 'fadeOut',
            autoplayHoverPause: true,
            loop: true,
            nav: true,
            merge: true,
            dots: false,
            navText: ['<i class="ti-angle-left"></i>', '<i class="ti-angle-right"></i>'],
            responsive: {
                0: {
                    items: 1,
                },
                300: {
                    items: 1,
                },
                480: {
                    items: 2,
                },
                768: {
                    items: 3,
                },
                1170: {
                    items: 4,
                },
            }
        });


    }
}

window.mobileFunction = {
    startFunction: function () {

        /*====================================
        Mobile Menu
    ======================================*/
        $('.menu').slicknav({
            prependTo: ".mobile-nav",
            duration: 300,
            animateIn: 'fadeIn',
            animateOut: 'fadeOut',
            closeOnClick: true,
        });

        /*====================================
        03. Sticky Header JS
        ======================================*/
        jQuery(window).on('scroll', function () {
            if ($(this).scrollTop() > 200) {
                $('.header').addClass("sticky");
            } else {
                $('.header').removeClass("sticky");
            }
        });

		/*=======================
	Search JS JS
  =========================*/
		$('.top-search a').on("click", function () {
			$('.search-top').toggleClass('active');
		});



    }
}



window.fullfunctionTest = {
    startFunction: function () {

		/*====================================
			Mobile Menu
		======================================*/
		$('.menu').slicknav({
			prependTo: ".mobile-nav",
			duration: 300,
			animateIn: 'fadeIn',
			animateOut: 'fadeOut',
			closeOnClick: true,
		});

		/*====================================
		03. Sticky Header JS
		======================================*/
		jQuery(window).on('scroll', function () {
			if ($(this).scrollTop() > 200) {
				$('.header').addClass("sticky");
			} else {
				$('.header').removeClass("sticky");
			}
		});
		/*=======================
			  Search JS JS
			=========================*/
		$('.top-search a').on("click", function () {
			$('.search-top').toggleClass('active');
		});

		/*=======================
		  Slider Range JS
		=========================*/
		$(function () {
			$("#slider-range").slider({
				range: true,
				min: 0,
				max: 500,
				values: [120, 250],
				slide: function (event, ui) {
					$("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
				}
			});
			$("#amount").val("$" + $("#slider-range").slider("values", 0) +
				" - $" + $("#slider-range").slider("values", 1));
		});

		/*=======================
		  Home Slider JS
		=========================*/
		$('.home-slider').owlCarousel({
			items: 1,
			autoplay: true,
			autoplayTimeout: 5000,
			smartSpeed: 400,
			animateIn: 'fadeIn',
			animateOut: 'fadeOut',
			autoplayHoverPause: true,
			loop: true,
			nav: true,
			merge: true,
			dots: false,
			navText: ['<i class="ti-angle-left"></i>', '<i class="ti-angle-right"></i>'],
			responsive: {
				0: {
					items: 1,
				},
				300: {
					items: 1,
				},
				480: {
					items: 2,
				},
				768: {
					items: 3,
				},
				1170: {
					items: 4,
				},
			}
		});

		/*=======================
		  Popular Slider JS
		=========================*/
		$('.popular-slider').owlCarousel({
			items: 1,
			autoplay: true,
			autoplayTimeout: 5000,
			smartSpeed: 400,
			animateIn: 'fadeIn',
			animateOut: 'fadeOut',
			autoplayHoverPause: true,
			loop: true,
			nav: true,
			merge: true,
			dots: false,
			navText: ['<i class="ti-angle-left"></i>', '<i class="ti-angle-right"></i>'],
			responsive: {
				0: {
					items: 1,
				},
				300: {
					items: 1,
				},
				480: {
					items: 2,
				},
				768: {
					items: 3,
				},
				1170: {
					items: 4,
				},
			}
		});

		/*===========================
		  Quick View Slider JS
		=============================*/
		$('.quickview-slider-active').owlCarousel({
			items: 1,
			autoplay: true,
			autoplayTimeout: 5000,
			smartSpeed: 400,
			autoplayHoverPause: true,
			nav: true,
			loop: true,
			merge: true,
			dots: false,
			navText: ['<i class=" ti-arrow-left"></i>', '<i class=" ti-arrow-right"></i>'],
		});

		/*===========================
		  Home Slider 4 JS
		=============================*/
		$('.home-slider-4').owlCarousel({
			items: 1,
			autoplay: true,
			autoplayTimeout: 5000,
			smartSpeed: 400,
			autoplayHoverPause: true,
			nav: true,
			loop: true,
			merge: true,
			dots: false,
			navText: ['<i class=" ti-arrow-left"></i>', '<i class=" ti-arrow-right"></i>'],
		});

		/*====================================
		14. CountDown
		======================================*/
		$('[data-countdown]').each(function () {
			var $this = $(this),
				finalDate = $(this).data('countdown');
			$this.countdown(finalDate, function (event) {
				$this.html(event.strftime(
					'<div class="cdown"><span class="days"><strong>%-D</strong><p>Days.</p></span></div><div class="cdown"><span class="hour"><strong> %-H</strong><p>Hours.</p></span></div> <div class="cdown"><span class="minutes"><strong>%M</strong> <p>MINUTES.</p></span></div><div class="cdown"><span class="second"><strong> %S</strong><p>SECONDS.</p></span></div>'
				));
			});
		});

		/*====================================
		16. Flex Slider JS
		======================================*/


		

		/*=======================
		  Extra Scroll JS
		=========================*/
		$('.scroll').on("click", function (e) {
			var anchor = $(this);
			$('html, body').stop().animate({
				scrollTop: $(anchor.attr('href')).offset().top - 0
			}, 900);
			e.preventDefault();
		});

		/*===============================
		10. Checkbox JS
		=================================*/
		$('input[type="checkbox"]').change(function () {
			if ($(this).is(':checked')) {
				$(this).parent("label").addClass("checked");
			} else {
				$(this).parent("label").removeClass("checked");
			}
		});

		/*==================================
		 12. Product page Quantity Counter
		 ===================================*/
		$('.qty-box .quantity-right-plus').on('click', function () {
			var $qty = $('.qty-box .input-number');
			var currentVal = parseInt($qty.val(), 10);
			if (!isNaN(currentVal)) {
				$qty.val(currentVal + 1);
			}
		});
		$('.qty-box .quantity-left-minus').on('click', function () {
			var $qty = $('.qty-box .input-number');
			var currentVal = parseInt($qty.val(), 10);
			if (!isNaN(currentVal) && currentVal > 1) {
				$qty.val(currentVal - 1);
			}
		});

		/*=====================================
		15.  Video Popup JS
		======================================*/
		$('.video-popup').magnificPopup({
			type: 'iframe',
			removalDelay: 300,
			mainClass: 'mfp-fade'
		});

		/*====================================
			Scroll Up JS
		======================================*/
		$.scrollUp({
			scrollText: '<span><i class="fa fa-angle-up"></i></span>',
			easingType: 'easeInOutExpo',
			scrollSpeed: 900,
			animation: 'fade'
		});

    }
}


function runDataTable() {
	
	$('table tfoot th').each(function () {
		var title = $(this).text();
		$(this).html('<input type="text" placeholder="Search ' + title + '" />');
	});

	var table = $('.table').DataTable({
		"pageLength": 15,
		responsive: true,
		"paging": true,
		"scrollX": true,
		initComplete: function () {
			// Apply the search
			this.api().columns().every(function () {
				var that = this;

				$('input', this.footer()).on('keyup change clear', function () {
					if (that.search() !== this.value) {
						that
							.search(this.value)
							.draw();
					}
				});
			});
		}
	});
}

function destroyTable() {
	//var table = $('.table').DataTable();
	table.destroy();
}

function runSummernote() {
	$(document).ready(function () {
		$('#new').summernote();
	});
	
}

