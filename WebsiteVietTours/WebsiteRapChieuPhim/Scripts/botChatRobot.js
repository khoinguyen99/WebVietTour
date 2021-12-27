addChat("","Xin chào quý khách!")

$(window).load(function () {
   
    const inputField = document.getElementById("input").value;
    if (inputField === "") {
        setInterval(function () {
            addChat("", "Quý khách muốn tìm hiểu thông tin gì nữa không ạ!")
        }, 500000);
    } 
});



document.addEventListener("DOMContentLoaded", () => {
    const inputField = document.getElementById("input");
    inputField.addEventListener("keydown", (e) => {
        if (e.code === "Enter") {
            let input = inputField.value;
            inputField.value = "";
            output(input);
        }
    });
});


$('.message-submit').click(function () {
    const inputField = document.getElementById("input");
    let input = inputField.value;
    inputField.value = "";
    output(input);
});

function output(input) {
    let product;

  

    let text = input.toLowerCase().trim();
   


   
    if (compare(prompts, replies, text)) {
      
        product = compare(prompts, replies, text);
    } else if (text.match(/thank/gi)) {
        product = "You're welcome!"
    } else if (text.match(/(corona|covid|virus)/gi)) {
       
        product = coronavirus[Math.floor(Math.random() * coronavirus.length)];
    } else {
       
        product = alternative[Math.floor(Math.random() * alternative.length)];
    }

    
    addChat(input, product);
}

function compare(promptsArray, repliesArray, string) {
    let reply;
    let replyFound = false;
    for (let x = 0; x < promptsArray.length; x++) {
        for (let y = 0; y < promptsArray[x].length; y++) {
            if (promptsArray[x][y] === string) {
                let replies = repliesArray[x];
                reply = replies[Math.floor(Math.random() * replies.length)];
                replyFound = true;
              
                break;
            }
        }
        if (replyFound) {
          
            break;
        }
    }
    return reply;
}

function addChat(input, product) {

    

    messagesContainer = document.getElementById("messagess");

    let userDiv = document.createElement("div");
    userDiv.id = "user";
    userDiv.className = "user response";
    
    userDiv.innerHTML = '<span id="sp">' + input +  '</span>';
    messagesContainer.appendChild(userDiv);
  


    let botDiv = document.createElement("div");
    let botText = document.createElement("span");
    botText.id = "botsc";
    let botImg = document.createElement("img");
    botImg.style.borderRadius = 40 + '%';




    botDiv.id = "bot";
    botImg.src = "https://iweb.tatthanh.com.vn/pic/3/blog/images/logo-ban-tay(10).jpg";


    botImg.className = "avatar";
    botDiv.className = "bot response";

    

    botText.innerHTML = '...';
    botDiv.appendChild(botImg);
    botDiv.appendChild(botText);
    
    messagesContainer.appendChild(botDiv);
   

    messagesContainer.scrollTop = messagesContainer.scrollHeight - messagesContainer.clientHeight;

    var timeer = new Date(); 
  
    setTimeout(() => {
        botText.innerHTML = `${product}` + '<p style="display:flex;justify-content: flex-end;">' +'<span style="font-size:10px;">' +timeer.getHours() + ":" + timeer.getMinutes()+ '</span></p>';
       
        
    }, 2000)
   
    



}

