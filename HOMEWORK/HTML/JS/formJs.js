
//document.forms[0];
function func()
{
    //alert(document.forms[o].elements["color"].value);
    //alert(document.forms["f1"].elements["color"].value);
    //alert(document.querySelectorAll("input[type='checkbox']:checked"));

    body.style.backgroundColor = document.querySelector("[name='color']").value;

    var s = "", res = "Registration successful!";

    if (document.querySelectorAll("input[type='checkbox']:checked").length < 1) {
        s += "<p>Neither of checkboxes were checked!</p>";

        document.querySelector("#checklist").style.border = "2px solid red";
    }
    else
    {
        document.querySelector("#checklist").style.border = "none";
        var sel = document.querySelectorAll("input[type='checkbox']:checked");
        res += "<p>Next rules were checked:</p>";
        for (var i = 0; i < sel.length; i++) {
            res += "<p>"+sel[i].value+"</p>";
        }
        res += "<br />";
    }

    res += "<p>Next condition was checked:</p>";
    res += "<p>" + document.querySelector("input[type=radio]:checked").value + "</p>"   
    
    if (document.querySelectorAll("option:checked").length < 1) {
        s += "<p>Neither of groups were selected!</p>";

        document.querySelector("[name=group]").style.border = "2px solid red";
    }
    else
    {
        document.querySelector("[name=group]").style.border = "none";
        var sel = document.querySelectorAll("option:checked");
        res += "<p>Next groups were checked:</p>";
        for (var i = 0; i < sel.length; i++) {
            res += "<p>"+sel[i].innerHTML+"</p>";
        }
        res += "<br />";

    }

    res += "<p>Next color was checked:</p>";
    res += "<p>" + document.querySelector("input[type=color]").value + "</p>"


    var ob = document.querySelectorAll("[name='name'],[name='comment'],[name='pass']");
    for (var i = 0; i < ob.length; i++) {
        if (ob[i].value == "") { s += "<p>Empty " + ob[i].name + " field!</p>"; ob[i].style.border = "2px red solid"; }
        else
        {
            ob[i].style.border = "none";
            res += "<p>" + ob[i].name + " : " + ob[i].value+ "</p>"
        }
    }

    if (s.length > 2) {
        errorBox.style.display = "block";
        resBox.style.display = "none";
        errorBox.innerHTML = s;
        resBox.innerHTML = "";
    }
    else
    {
        errorBox.style.display = "none";
        errorBox.innerHTML = "";
        resBox.style.display = "block";
        resBox.innerHTML = res;
    }


}



