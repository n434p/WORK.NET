
var color = ["red", "green", "blue", "yellow", "orange"];
var r = [];

function Rectangle(id,color, counter)
{
    this.id = id;
    this.color = color;
    this.counter = counter;
}

function f(ob)
{
    rect = new Rectangle(ob.id, ob.style.backgroundColor, 0);
    ob.style.backgroundColor = color[rect.counter];
    r.push(rect);
    
    

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