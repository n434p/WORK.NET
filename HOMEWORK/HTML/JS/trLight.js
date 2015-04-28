
var d = new Date();

var readyTime = 500, goTime = 1000, blinkTime = 3000, readyTime2 = 5000;

var id, int;

function Init()
{
    setInterval(Lighting, 5000);
}

function Lighting()
{   
    Stop();
    
    setTimeout("Ready(0);", readyTime);

    setTimeout("Go();", goTime);

    setTimeout("Blinking();", blinkTime);

    setTimeout("Ready(1);", readyTime2);

}

var obj, t, i;

function Blinking() {
    i = setInterval("Blink('green');", 990);
    setTimeout('clearTimeout(id); clearInterval(i); console.log(id, i);', blinkTime);
}

function Blink(ob) {
    obj = document.getElementById(ob);
    obj.style.opacity = 1;
    t = setTimeout("obj.style.opacity = 0; console.log('t: '+t)", 500);
}

function Go()
{
    red.style.opacity = 0;
    yel.style.opacity = 0;
    green.style.opacity = 1;
}

function Ready(j) {
    if (j == 0) {
        red.style.opacity = 1;}
    else {
        red.style.opacity = 0;}
        yel.style.opacity = 1;
        green.style.opacity = 0;
}

function Stop() {
    red.style.opacity = 1;
    yel.style.opacity = 0;
    green.style.opacity = 0;
}





