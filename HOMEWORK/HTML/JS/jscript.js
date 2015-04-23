//first.click = f;
//second.click = f;
//third.click = f;

first.i = 0;
second.i = 0;
third.i = 0;

var color = ["brown", "aqua", "azure", "blue", "pink"];

function f(ob)
{
    
    ob.style.backgroundColor = color[++this.i];
    alert("1");
}