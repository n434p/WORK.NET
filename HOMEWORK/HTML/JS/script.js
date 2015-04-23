// JavaScript source code
function T()
{
    alert("Take a number from 1 to 100...");
    var start = 0, end = 100, cur, check;

    while(true)
    {
        cur=Math.round((end-start)/2)+start;
        res = confirm("Is your number less than " + cur + " ?");
        

        if (check == cur) break;

        if (end - start == 1) {
            alert("1 "+cur);
            if (res) { cur = end; }
            else { cur = start; }
            break;
        }

        if (start - end == 1) {
            alert("2 "+cur);
            if (res) { cur = start; }
            else { cur = end; }
            break;
        }

        if (res) { end = cur; }
        else
        { start = cur; }

        check = cur;

    }

    alert("Your number is - " +cur+"\n\n*** our friendship site: www.badcheater.com");
}


function N()
{
    var arr = new Array(8);
    for (var i = 0; i < arr.length; i++)
    {
        arr[i] = i+1;
    }
    document.write(arr.join(","));
   
}