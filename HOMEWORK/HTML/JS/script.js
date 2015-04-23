// JavaScript source code
function T()
{
    alert("Take a number from 1 to 100...");
    var start = 0, end = 100, cur;

    while(true)
    {
        cur=Math.round((end-start)/2)+start;
        res = confirm("Is your number less than " + cur + " ?");

        if (end - start == 1) {
            if (res) { cur = end; }
            else { cur = start; }
            break;
        }

        if (start - end == 1) {
            if (res) { cur = start; }
            else { cur = end; }
            break;
        }

        if (res) { end = cur; }
        else
        { start = cur; }

        
    }
    alert("Your number is - " +cur+"\n\n*** our friendship site: www.badcheater.com");
}