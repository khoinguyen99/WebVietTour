﻿var $messages = $('.messages-content'),
    d, h, m,
    i = 0;

$(window).load(function () {
    $messages.mCustomScrollbar();
    setTimeout(function () {
        fakeMessage();
    }, 100);
});


function updateScrollbar() {
    $messages.mCustomScrollbar("update").mCustomScrollbar('scrollTo', 'bottom', {
        scrollInertia: 10,
        timeout: 0
    });
}

function setDate() {
    d = new Date()
    if (m != d.getMinutes()) {
        m = d.getMinutes();
        $('<div class="timestamp">' + d.getHours() + ':' + m + '</div>').appendTo($('.message:last'));
        $('<div class="checkmark-sent-delivered">&check;</div>').appendTo($('.message:last'));
        $('<div class="checkmark-read">&check;</div>').appendTo($('.message:last'));
    }
}

function insertMessage() {
    msg = $('.message-input').val();
    if ($.trim(msg) == '') {
        return false;
    }
    $('<div class="message message-personal">' + msg + '</div>').appendTo($('.mCSB_container')).addClass('new');
    setDate();
    $('.message-input').val(null);
    updateScrollbar();
    setTimeout(function () {
        fakeMessage();
    }, 1000 + (Math.random() * 20) * 100);
}

$('.message-submit').click(function () {
    insertMessage();
});

$(window).on('keydown', function (e) {
    if (e.which == 13) {
        insertMessage();
        return false;
    }
})

var linkTou = [

    'Cao Bằng',
    'Lạng Sơn',
    'Yên bái',
    


]

var lists = []

var str = "";
var result = str.link("https://localhost:44328/Home/TimKiem?key=Cao+B%E1%BA%B1ng");
function check() {
    var vl =  'Cao Bằng';
    lists.push(vl);
    var dem = 0;
    
    for (var i = 0; i < linkTou.length; i++)
    {
        if (linkTou[i] !== lists[i]) {
           
            dem = 1;

        } else {
            lists[i] = str;
           
            dem = 0;
        }
    }
    if (dem == 0) {
        return "str1";
    } else {
        return str + "j";

    }
};

//var rand = linkTou[Math.floor(Math.random() * linkTou.length)];

var Fake = [
    'Xin chào, tôi có thể giúp gì cho bạn',
    'Bạn có thể tham khảo qua đây \n',
    'Bạn khỏe không?',
    'Not too bad, thanks',
    'What do you do?',
    'That\'s awesome',
    'Codepen is a nice place to stay',
    'I think you\'re a nice person',
    'Why do you think that?',
    'Can you explain?',
    'Anyway I\'ve gotta go now',
    'It was a pleasure chat with you',
    'Time to make a new codepen',
    'Bye',
    ':)'
]

function fakeMessage() {
    if ($('.message-input').val() != '') {
        return false;
    }
    $('<div class="message loading new"><figure class="avatar"><img src="https://iweb.tatthanh.com.vn/pic/3/blog/images/logo-ban-tay(10).jpg" /></figure><span></span></div>').appendTo($('.mCSB_container'));
    updateScrollbar();

    setTimeout(function () {
        $('.message.loading').remove();
        $('<div class="message new"><figure class="avatar"><img src="https://iweb.tatthanh.com.vn/pic/3/blog/images/logo-ban-tay(10).jpg" /></figure>' + Fake[i] + '</div>').appendTo($('.mCSB_container')).addClass('new');
        setDate();
        updateScrollbar();
        i++;
    }, 1000 + (Math.random() * 20) * 100);

   

    
}

$('.button').click(function () {
    $('.menu .items span').toggleClass('active');
    $('.menu .button').toggleClass('active');
});
