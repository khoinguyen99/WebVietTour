
$( window ).load(function() {
    render_size();
    var url = window.location.href;
    $('.menu-item  a[href="' + url + '"]').parent().addClass('active');
});

$( window ).resize(function() {
    render_size();
});



function render_size(){

    var h_6667 = $('.h_6667 img').width();
    $('.h_6667 img').height( 0.6667 * parseInt(h_6667));

    var h_6667z = $('.h_6667z img').width();
    $('.h_6667z img').height( 0.6667 * parseInt(h_6667z));

    var h_246 = $('.h_246 img').width();
    $('.h_246 img').height( 0.246 * parseInt(h_246));

    var h_707 = $('.h_707 img').width();
    $('.h_707 img').height( 0.707 * parseInt(h_707));


}


if (window.innerWidth > 768) {
    $(window).scroll(function () {
        if ($(window).scrollTop() >= 220) {
            $('.sticky-header').addClass('fixed');
        } else {
            $('.sticky-header').removeClass('fixed');
        }
    });
}
if (window.innerWidth > 320) {
    $(window).scroll(function () {
        if ($(window).scrollTop() >= 100) {
            $('.sticky-header').addClass('clearfix');
        } else {
            $('.sticky-header').removeClass('clearfix');
        }
    });
}