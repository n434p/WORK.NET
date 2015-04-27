
var radius = 100, a = 0, dA = 2 * Math.PI / 180, delay = 25;


function Init()
{
    var i = setInterval("Lisssage()", delay);
}

function Circle()
{
    plane.style.left = 250 + radius * Math.cos(a)+"px";
    plane.style.top = 250 + radius * Math.sin(a) + "px";
    a += dA;
}


function Lisssage()
{
    plane.style.left = 600+250 * Math.cos(0.5* a) + "px";
    plane.style.top = 400+250 * Math.sin(0.2 * a) + "px";
    a += dA;
}

function over()
{
    //plane.style.display = "none";
    clearInterval();
    i = setInterval("Lissage()", delay);
    a += dA;
    //plane.style.left = event.
}

function out()
{
    plane.style.display = "block";
}