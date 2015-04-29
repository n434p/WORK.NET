
//document.forms[0];
function func()
{
    //alert(document.forms[o].elements["color"].value);
    //alert(document.forms["f1"].elements["color"].value);
    //alert(document.querySelectorAll("input[type='checkbox']:checked"));

    body.style.backgroundColor = document.querySelector("[name='color']").value;

    var s="";

    if (document.querySelectorAll("input[type='checkbox']:checked").length < 1)
    {
        s += "<p>Neither of checkboxes were not checked!</p>";
        
        document.querySelector("#checklist").style.border = "2px solid red";
    }

    if (document.querySelectorAll("option:checked").length < 1)
    {
        s += "<p>Neither of groups were not selected!</p>";

        document.querySelector("[name=group]").style.border = "2px solid red";
    }

    var ob = document.querySelectorAll("[name='name'],[name='comment'],[name='pass']");
    for (var i = 0; i < ob.length; i++) {
        if(ob[i].value == "") { s += "<p>Empty " + ob[i].name + " field!</p>"; ob[i].style.border = "2px red solid"; }
    }

    if (s.length > 2)
    body.innerHTML += "<div style = 'border: 2px solid red; widht:300px; margin-top:10px;'>"+s+"</div>";
}

