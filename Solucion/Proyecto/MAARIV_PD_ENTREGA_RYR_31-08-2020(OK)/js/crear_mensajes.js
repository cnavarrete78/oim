$(function () {
    $('#activator').click(function () {
        $('#overlay1').fadeIn('fast', function () {
            $('#box').animate({ 'top': '160px' }, 500);
        });
    });
    $('#boxclose').click(function () {
        $('#box').animate({ 'top': '-1000px' }, 500, function () {
            $('#overlay1').fadeOut('fast');
        });
    });

});


$(function () {
    $('#activator').click(function () {
        $('#overlay1').fadeIn('fast', function () {
            $('#box').animate({ 'top': '160px' }, 500);
        });
    });
    $('#boxclose').click(function () {
        $('#box').animate({ 'top': '-1000px' }, 500, function () {
            $('#overlay1').fadeOut('fast');
        });
    });

});

var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-7243260-2']);
_gaq.push(['_trackPageview']);

(function () {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();