
var d = new Date();

function Init()
{
    setTimeout("Lighting()", 2000);
}

function Lighting()
{
    red.style.backgroundColor = "red";
    var i = setTimeout("", 500);

    yel.style.backgroundColor = "yellow";
    var i = setTimeout("", 500);

    red.style.backgroundColor = "white";
    yel.style.backgroundColor = "white";
    green.style.backgroundColor = "green";
    var i = setTimeout("", 500);
}