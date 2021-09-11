$(window).load(function () {
    $('.flexslider').flexslider({
        animation: "slide",
        start: function (slider) {
            $('body').removeClass('loading');
        }
    });
});
$(document).ready(function () {
    $("#owl-demo").owlCarousel({
        items: 1,
        lazyLoad: true,
        autoPlay: true,
        navigation: false,
        navigationText: false,
        pagination: true,
    });
});
$(window).load(function () {
    $("#flexiselDemo1").flexisel({
        visibleItems: 4,
        animationSpeed: 1000,
        autoPlay: true,
        autoPlaySpeed: 3000,
        pauseOnHover: true,
        enableResponsiveBreakpoints: true,
        responsiveBreakpoints: {
            portrait: {
                changePoint: 480,
                visibleItems: 1
            },
            landscape: {
                changePoint: 640,
                visibleItems: 2
            },
            tablet: {
                changePoint: 768,
                visibleItems: 2
            }
        }
    });

});
$(window).load(function () {
    $.fn.lightspeedBox();
});
$(document).ready(function () {
    /*
        var defaults = {
        containerID: 'toTop', // fading element id
        containerHoverID: 'toTopHover', // fading element hover id
        scrollSpeed: 1200,
        easingType: 'linear'
        };
    */

    $().UItoTop({ easingType: 'easeOutQuart' });

});
jQuery(document).ready(function ($) {
    $(".scroll").click(function (event) {
        event.preventDefault();
        $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
    });
});


/* Function to run the sticky navigation bar */
$(function () {
    $(document).scroll(function () {
        var $nav = $(".navbar-fixed-top");
        $nav.toggleClass('scrolled', $(this).scrollTop() > $nav.height());
    });
});



/* Function to Solar Calculator Pge Dotted Navigation Bar */
$(document).ready(function ($) {
    var parPosition = [];
    $('.par').each(function () {
        parPosition.push($(this).offset().top+500);
    });

    $('a').click(function () {
        $('html, body').animate({
            scrollTop: $($.attr(this, 'href')).offset().top-80
        }, 500);
        return false;
    });

    $('.vNav ul li a').click(function () {
        $('.vNav ul li a').removeClass('active');
        $(this).addClass('active');
    });

    $('.vNav a').hover(function () {
        $(this).find('.label').show();
    }, function () {
        $(this).find('.label').hide();
    });

    $(document).scroll(function () {
        var position = $(document).scrollTop(),
            index;
        for (var i = 0; i < parPosition.length; i++) {
            if (position <= parPosition[i]) {
                index = i;
                break;
            }
        }
        $('.vNav ul li a').removeClass('active');
        $('.vNav ul li a:eq(' + index + ')').addClass('active');
    });

    $('.vNav ul li a').click(function () {
        $('.vNav ul li a').removeClass('active');
        $(this).addClass('active');
    });
});


