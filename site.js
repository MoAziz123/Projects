function checkValidity()
{
    error = "";
    email = document.getElementById("email");
    subject = document.getElementById("subject");
    msg = documnet.getElementById("msg");
    
    if(!email.checkValidity())
        {
            error += "Email is not a valid email.";
        }
    if(!isNaN(subject) || subject == "")
        {
            error += "Subject needs to be a string and not be empty.";
        }
    if(!isNaN(subject) || msg == "")
        {
            error += "Message needs to be a string and not empty.";
        }
    document.getElementById("msgerror").innerHTML = error;
}