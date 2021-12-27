const prompts = [
    ["xin chào", "xin chào công ty", "hi", "good morning", "good afternoon"],
    ["thông tin tour"],
    ["tour giá rẻ"],
    ["tour khuyến mãi nhiều"],
    ["tour hot"],
    ["thông tin khách sạn"],
    ["thông tin xe"],
    ["thông tin công ty"],
    ["tin tức về công ty"],
    [
        "tôi muốn hỏi thêm một số câu hỏi"
        

    ],
    ["tôi không hài lòng về dịch vụ của bạn 😠"],
    ["😷"],
    ["cảm ơn"],
    ["giá tour rẻ nhất"],
    ["bro"],
    ["không vấn đề nào cả"],
    ["no", "not sure", "maybe", "no thanks"],
    [""],
    ["haha", "ha", "lol", "hehe", "funny", "joke"],
    ["💖", "😱", "👌", "❣️", "😆", "😍", "😂"]
    
     
]



// Possible responses, in corresponding order
var str = "https://TourReNhat";
var result = str.link("https://localhost:44328/Home/giamin");

var strs = "<img src='/resource/upload/images/14.jpg' width='40px' height='40px'/>";
var str1 = "https://TourGiamGiaNhieu";
var result1 = str1.link("https://localhost:44328/Home/giamgianhieu");
var strs1 = "<img src='/resource/upload/images/14.jpg' width='50px' height='70px'/>";

var str2 = "https://TourHot";
var result2 = str2.link("https://localhost:44328/Home/TourHot");

var str3 = "https://Khachsan";
var result3 = str3.link("https://localhost:44328/KhachSan/khacsans");

var str4 = "https://ThongTinXe";
var result4 = str4.link("https://localhost:44328/thongtinxe/tXe");

var str5 = "https://Tintuc";
var result5 = str5.link("https://localhost:44328/TinTucss/tinTuc");

var gifs = "<img src='/resource/admin/images/giphylike.gif' width='40px' height='40px'/>";

var gifss = "<img src='/resource/admin/images/arrow2.gif' width='40px' height='40px'/>";


var gifhot = "<img src='https://www.fiditour.com/Upload/images/Icons/hot2.gif' alt='Tour giá tốt'>";

var gifbuss = "<img src='/resource/admin/images/giphybus.gif' style='border-radius: 25px' width='150px' height='40px' alt='Tour giá tốt'>";

var gifnews = "<img src='/resource/admin/images/giphynewsgif.gif'  width='40px' height='40px' alt='newspaper'>";

var gifhotel = "<img src='/resource/admin/images/hotel.gif' width='25px' height='25px' alt='hotel'>";

var giare = "<table style='width:100%'><tr ><td rowspan='3'><a href='https://localhost:44328/Home/chitietTour/29'><img src='/resource/upload/images/14.jpg' width='50px' height='70px'/></a></td><td  style='font-size: 10px'>Khởi hành ngày:HÀNG NGÀY</td></tr><tr><td  style='font-size: 10px'>Giá tour:<span style='color:red'>490,000 VNĐ<span></td></tr><tr style='font-size: 10px'><td>Thời gian : 1 ngày</td></tr></table>";

const replies = [
    ["Xin chào quý khách, tôi có thể giúp gì cho quý khách !", "Xin chào bạn,tôi có thể giúp gì cho bạn !","Chào anh chị,cảm ơn anh chị đã liên lạc với fanpage của công ty VietTour,bên em có giúp gì cho anh chị ạ?  "],

    [
    "Vui lòng cho bên em biết anh chị đang cần những thông tin gì về tour ạ ?",
    "Quý khách vui lòng cung cấp các câu hỏi về các tour ?",
    "Bạn muốn tìm hiểu về vấn đề nào ạ ?"
    ],

    [
        "Quý khách có thể tham khảo qua đây : " + "</br>" + result + gifss,
        "Bạn có thể tham khảo qua đây : " + "</br>" + result + gifss,
        "Anh chị có thể tham khảo qua đây : " + "</br>" + result + gifss
        
    ],
    
    [
        "Quý khách có thể tham khảo qua đây :" + result1 + gifhot,
        "Bạn có thể tham khảo qua đây :" + result1 + gifhot,
        "Anh chị có thể tham khảo qua đây :" + result1 + gifhot
        

    ],
    [
        "Quý khách có thể tham khảo qua đây:" + result2 + gifhot,
        "Bạn có thể tham khảo qua đây:" + result2 + gifhot,
        "Anh chị có thể tham khảo qua đây:" + result2 + gifhot
    ],
    [
        "Quý khách có thể tham khảo khách sạn qua đây:" + result3 + gifhotel,
        "Bạn có thể tham khảo khách sạn qua đây:" + result3 + gifhotel,
        "Anh chị có thể tham khảo khách sạn qua đây:" + result3 + gifhotel

    ],
    [
        "Quý khách có thể tham khảo xe qua đây:" + result4 + gifbuss,
        "Bạn có thể tham khảo xe qua đây:" + result4 + gifbuss,
        "Anh chị có thể tham khảo xe qua đây:" + result4 + gifbuss


    ],


    [
        "Quý khách có thể tham khảo tin tức qua đây :" + result5 +""+ gifnews,
        "Bạn có thể tham khảo tin tức qua đây :" + result5 + ""+gifnews,
        "Anh chị có thể tham khảo tin tức qua đây :" + result5 +""+ gifnews
    ],
    ["Have you ever felt bad?", "Glad to hear it"],
    ["Chắn chắn rồi, quý khách muốn hỏi về vấn đề gì ạ ?"],
    [
        "Chúng tôi thật sự xin lỗi về dịch vụ của mình 😟😟😟",
        "Xin lỗi quý khách ,quý khách không hài lòng về vấn đề nào ạ"
    ],
    ["Quý khách nhớ đeo khẩu trang khi ra ngoài nhé 🤗"],
    [
        "Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi" + gifs,
        "Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi" + gifs,
        "Cảm ơn anh chị khách đã sử dụng dịch vụ của chúng tôi" + gifs

    ],
    [
        "DU LỊCH TẾT: CHÙA BA VÀNG - YÊN TỬ </br>" + giare,

    ],
    ["Bro!"],
    [
        "Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi" + gifs,
        "Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi" + gifs,
        "Cảm ơn anh chị khách đã sử dụng dịch vụ của chúng tôi" + gifs
    ],
    ["That's ok", "I understand", "What do you want to talk about?"],
    ["Please say something !"],
    ["Haha!", "Good one!"],
    ["💓", "❣️", "😂", "😍", "😆", "😝"]
    
]


// Random for any other user input

const alternative = [
    "Same",
    "Go on...",
    "Bro...",
    "Try again",
    "I'm listening...",
    "I don't understand :/"
]

// Whatever else you want :)

const coronavirus = ["Please stay home", "Wear a mask", "Fortunately, I don't have COVID", "These are uncertain times"]