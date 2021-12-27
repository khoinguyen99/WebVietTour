
    var next = 0;
    var chuyen = 0;
        function check() {
        next += 300;
            chuyen += 1;

            if (chuyen % 2 == 0) {

        document.getElementById('content').style.marginLeft = '-' + next + 'px';


            } else {
        document.getElementById('content').style.marginLeft = '-' + next + 'px';



            }
            if (chuyen == 7) {
        document.getElementById('content').style.marginLeft = 0 + 'px';
                chuyen = 0;
                next = 0;
            }




        }

        setInterval(function () {

        check();
        }, 3000);
  