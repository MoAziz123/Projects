document.getElementById("name").addEventListener('keyup', checkname);
document.getElementById("age").addEventListener('keyup', checkage);
document.getElementById("email").addEventListener('keyup', checkemail);

function checkname(){
    var name, text;
    name = document.getElementById("name");
    text = document.getElementById("validatename");
    if(isEmpty(name.value))
    {
      text.style.color = "red";
      name.style.borderBottomColor = "red";
      text.innerHTML = "Please fill in this field";
      return false;
    }
    else if(name.value.length > 30)
    {
        text.style.color = "red";
        name.style.borderBottomColor = "red";
        text.innerHTML = "Name should be less than 30 characters!";
        return false;
        
        
    }
    else{
        text.style.color = "forestgreen";
        name.style.borderBottomColor ="forestgreen";
        text.innerHTML = "Name is valid";
        return true;
    }
    

}

function checkage(){
    //validation function
    //to check for age:
    //of type int
    var age, text;
    text = document.getElementById("validateage");
    age = document.getElementById("age");
    if(isEmpty(age.value))
    {
      text.style.color = "red";
      text.innerHTML = "Please fill in this field";
      age.style.borderBottomColor ="red";
      return false;
    }
    else if(isNaN(age.value) || age.value < 1)
    {
        text.innerHTML = "Age must be not be less than 1";
        age.style.borderBottomColor = "red";
        text.style.color = "red";
        return false;
        
        
    }
    else{
        text.innerHTML = "Age is valid";
        age.style.borderBottomColor = "forestgreen";
        text.style.color = "forestgreen";
        return true;
    }
}

function checkemail(){
    //validating email
    //checking against regex characters
    //if false, don't submit
    var email;
    var text;
    email = document.getElementById("email");
    text  = document.getElementById("validateemail");
    if(isEmpty(email.value))
    {
       text.innerHTML = "Please fill in this field";
       text.style.color = "red";
       email.style.borderBottomColor ="red";
       return false;
    }
    else if(!email.checkValidity())
    {
      text.innerHTML = "Email must be a valid address";
      text.style.color = "red";
      email.style.borderBottomColor = "red";
      return false;

    }
    else{
        text.innerHTML = "Email is fine";
        email.style.borderBottomColor = "forestgreen";
        text.style.color = "forestgreen";
        return true;
    }
    
}
    

       