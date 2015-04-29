
var color = ["red", "green", "blue", "yellow", "orange"];
var r = [];

function Rectangle(id,color, counter)
{
    this.id = id;
    this.color = color;
    this.counter = counter;
}

function ReColor(rect) {
    document.getElementById(rect.id).style.backgroundColor = color[rect.counter];
    document.getElementById(rect.id).children[0].innerHTML = color[rect.counter];
}

function IncColor(rect)
{
    if (rect.counter < color.length-1 && rect.counter >= 0)
    {
        rect.counter++;
    }
    else
    {
        rect.counter = 0;
    }
}

function f(ob)
{
    rect = new Rectangle(ob.id, ob.style.backgroundColor, 0);
    if (r.length > 0) {
        for (var i = 0; i < r.length; i++) {
            if (r[i].id == ob.id) {
                rect = r[i];
                break;
            }
        }

    }
    if (r.indexOf(rect) == -1)
    { r.push(rect); }


    ReColor(rect);
    IncColor(rect);

 
    
    //Non-user defined objective model solution:

    //var curColor = ob.style.backgroundColor;
    //var cur = -1;
    //switch (ob.id)
    //{
    //    case "first": cur = 0;
    //        break;
    //    case "second": cur = 1;
    //        break;
    //    case "third": cur = 2;
    //        break;
    //}

    //if (color.indexOf(curColor) < color.length-1 && color.indexOf(curColor) >= 0)
    //{ r[cur] = color.indexOf(curColor)+1; }
    //else
    //{
    //    r[cur] = 0;
    //}

    //console.log(color.indexOf(curColor));
    //ob.style.backgroundColor = color[r[cur]];
    //ob.children[0].innerHTML = color[r[cur]];
    //console.log(r);

}