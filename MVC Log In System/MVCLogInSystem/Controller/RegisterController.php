<?php

/* 
 *if the user enters the username/pass incorrectly too many times, it redirects to
 * this controller and webpage, where the user needs to create a new account - an email
 * will be sent with a code to verify the email before adding to the database
 */
include 'Model/DatabaseConnection.php';
include 'Model/Validate.php';
class RegisterController{
    public $model;
    public $validate;
    public function __construct()
    {
        $this->model = new DataConnectionModel();
        $this->validate = new Validate();
    }
    public function execute()
    {
        include 'View\RegisterView.php';
        
        
        
        if(isset($_POST["submit"]))
        {
            $email = $this->validate->validate_email($_POST["email"]);
            $password = md5($this->validate->validate_password($_POST["password"]));
            $__SALT__ = "RickRolled";
            $confirmation_code = substr(md5($__SALT__ . strlen($password)/2), 0, 6);
            if(!$this->check_dataset($email, $password))
            {
                if(!isset($_POST["confirm"]))
                {
                       echo "Please check the confirmation code send to your email and enter it below.";
                        mail($email, "Verification of Email", 
                        "Hello,\n"
                        . "Please enter the following confirmation code in order to access the Web Portal.\n"
                        . $confirmation_code, "From:mohammed4685@outlook.com") or die("Email could not be sent.");
                }
                else
                {
                    $this->model->insert("user_storage", "user, pass", "'$email', '$password'");
                    echo "Account created successfully.";
         
                }  
            }
            else
            {
                echo "Account already exists. Please use another email.";
            }
        }
        $view = new RegisterView();
        echo $view->createView();
       
    }
    public function check_dataset($email, $password)
    {
            
            $dataset = $this->model->select("user_storage", "user, pass");
            $rows = $dataset->fetchAll(PDO::FETCH_ASSOC);
            foreach($rows as $key)
            {
                if($email == $key["user"] && $password == $key["pass"])
                {
                    return true;
                }
                
            }
            return false;
    }
    
       
          
            
        
        
        
        
        
    
    
        
    }
