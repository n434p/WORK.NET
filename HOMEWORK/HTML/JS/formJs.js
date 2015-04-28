
//document.forms[0];
function func()
{
    //alert(document.forms[o].elements["color"].value);
    //alert(document.forms["f1"].elements["color"].value);

    //body.style.backgroundColor = document.forms["f1"].elements["color"].value;

    //alert(document.querySelectorAll("input[type='checkbox']:checked"));

    var el = document.forms[0].elements["name", "comment", "group", "pass"].value;
    var s="";

    if (document.querySelectorAll("input[type='checkbox']:checked").length < 1) s += "<p>Neither checkbox was checked!</p>";


    if (document.forms[0].elements["name"].value = "") s +="<p>Empty name field!</p>";
    if (document.forms[0].elements["comment"].value = "") s += "<p>Empty comment field!</p>";
    if (document.forms[0].elements["pass"].value = "") s += "<p>Empty password field!</p>";

    if (s.length > 2)
    body.innerHTML += "<div style = 'border: 2px solid red;'>"+s+"</div>";
}

