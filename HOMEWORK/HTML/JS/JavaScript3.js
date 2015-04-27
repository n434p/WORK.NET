var arr = [];
var cur = 0;

function TestItem(question, var1, var2, ans)
{
    this.question = question;
    this.var1 = var1;
    this.var2 = var2;
    this.ans = ans;
}

function Init() {
    arr.push(new TestItem("Q1", 'a1', 'a2', 0));
    arr.push(new TestItem("Q2", 'a1', 'a2', 1));
    arr.push(new TestItem("Q3", 'a1', 'a2', 1));
    arr.push(new TestItem("Q4", 'a1', 'a2', 0));
    //arr.push(new TestItem("Q5", 'a1', 'a2', 1));
    //arr.push(new TestItem("Q6", 'a1', 'a2', 0));
    //arr.push(new TestItem("Q7", 'a1', 'a2', 1));
    //arr.push(new TestItem("Q8", 'a1', 'a2', 0));
    //arr.push(new TestItem("Q9", 'a1', 'a2', 1));
    //arr.push(new TestItem("Q10", 'a1', 'a2', 0));

    Step();
}

function Run()
{
    if (but.value == "OK") {
        document.body.innerHTML = "";
    }
    else
    {
        GetRadioValue();
        cur++;
        Step();
    }
}

function Step() {
    if( cur< arr.length)
    {
        question.innerHTML = arr[cur].question;
        answers.innerHTML = "<input type='radio' name='answer' value='0'/>" + arr[cur].var1;
        answers.innerHTML += "<input type='radio' name='answer' value='1'/>" + arr[cur].var2;
    }
    else
    {
        question.innerHTML = "";
        answers.innerHTML = "";
        but.value = "OK";
        for (var i = 0; i < arr.length; i++) {  
          
            question.innerHTML += "<span id='span'></span>";

            if (arr[i].ans) span.style.color= "green";
            else span.style.color = "red";

            span.innerHTML = "<br/>" + (i + 1) + ". " + arr[i].question + "<br/>" + arr[i].ans;
            span.id += i;
        }
    }
}


function GetRadioValue()
{
    var ans = document.getElementsByName("answer");
    for (var i = 0; i < ans.length; i++)
    {
        if (ans[i].type == "radio" && ans[i].checked) {
        arr[cur].ans = (arr[cur].ans == ans[i].value);
        }
    }
}

function RandomNum(min, max)
{
    return Math.random() * (max - min) + min;
}

