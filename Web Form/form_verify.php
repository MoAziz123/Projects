<?php

function filter_name($name)
{
    if($name == "")
{
    return false;
}
elseif(strlen($name) > 30)
{
    return false;
}
else
{
    $name = filter_var($name, FILTER_SANITIZE_STRING);
    return $name; 
}
    
}

function filter_age($age)
{
    if($age < 1)
    {
        return false;
    }
    return filter_var((int)$age,FILTER_SANITIZE_NUMBER_INT);
   
}

function filter_email($email)
{
    if($email == "")
    {
        return false;
    }
    elseif(!filter_var($email, FILTER_VALIDATE_EMAIL))
    {
        return false;
    }
    else
    {
        filter_var($email, FILTER_SANITIZE_EMAIL);
        return $email;
    }
}
echo filter_name($_POST["name"]) . "<br>";
echo filter_age($_POST["age"]) . "<br>";
echo filter_email($_POST["email"]) . "<br>";
echo $_POST["gender"] . "<br>";
echo $_POST["region"] . "<br>";
