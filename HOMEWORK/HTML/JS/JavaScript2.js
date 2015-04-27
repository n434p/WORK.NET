var obj1 = { };
var obj2 = { a:3,b:5};
var obj3 = { a: { x: 3, y: 8 }, b: 12 };

document.write(obj2.a + " " + obj2.b + "<br/>");

var d = new Date();
document.writeln(d.getDay());
document.writeln(d.getMonth());

function People(fio, age)
{
    this.fio = fio;
    this.age = age;
    this.toString = function () { return "<br/>" + p.age + " " + p.fio; }
}

var p = new People("qwerty", 12);
document.writeln(p.toString());

document.writeln("<br/>" + ("f" in p) + "<br/>");
delete p.age;
document.writeln(p.toString());