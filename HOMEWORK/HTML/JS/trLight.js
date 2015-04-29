
var d = new Date();

var interval=15, stopTime=2, readyTime = 1, goTime = 5, blinkTime = 4, readyTime2 = 2;

var id, int, tick=15;

function Init()
{
    //Ticker();
}

function Ticker()
{
    setInterval("Lighting();tick--;", 1000);
}

function Lighting()
{   
    switch (tick) {
        case interval: Stop();
            break;
        case interval-stopTime: Ready(0);
            break;
        case interval-stopTime-readyTime: Go();
            break;
        case interval-stopTime-readyTime-goTime: Blinking();
            break;
        case readyTime2: Ready(1);
            break;
        default: 

            break;
    }

}

var obj, t, i;

function Blinking() {
    i1 = setInterval("green.style.opacity = 1;", 300);
    i2 = setInterval("green.style.opacity = 0.2;", 1000);
}


function Go()
{
    red.style.opacity = 0.2;
    yel.style.opacity = 0.2;
    green.style.opacity = 1;
}

function Ready(j) {
    if (j == 0) {
        red.style.opacity = 1;}
    else {
        clearInterval(i);
        red.style.opacity = 0.2;
    }
        yel.style.opacity = 1;
        green.style.opacity = 0.2;
}

function Stop() {
    red.style.opacity = 1;
    yel.style.opacity = 0.2;
    green.style.opacity = 0.2;
}





