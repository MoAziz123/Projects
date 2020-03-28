<?php
//validation wrapper used to validate the username and password inputs before
//santiziation
class Validate
{
    public function __construct()
    {
        
        
    }
    public function validate_email(string $item)
    {
        return filter_var($item, FILTER_VALIDATE_EMAIL);
    }
    public function validate_password(string $item)
    {
        return filter_var($item, FILTER_SANITIZE_STRING);
        
    }
    
}