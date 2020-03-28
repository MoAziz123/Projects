<?php
include_once 'Model/DatabaseConnection.php';
//instantiating model - as controller allows model to handle data
session_start();
if(!isset($_SESSION["count"]))
{
    $_SESSION["count"] = 1;
}

class LogInController {
    public $model;
    public $count;
    public function __construct()
    {
       
        $this->count = $_SESSION["count"]; 
        $this->model = new DataConnectionModel();
    }
   
    public function execute()
    {
        $found = false;
       
        
        if(!empty($_POST["email"]) && !empty($_POST["password"]))
        {
            $email = $_POST["email"];
            $password = $_POST["password"];
            if($this->check_dataset())//change it to if in database
            {
                if(isset($_POST["check"]))
                {
                    setcookie("email", $email);
                    setcookie("password", md5($password));
                    
                }
                include 'View\LoggedInView.php';
                $view = new LoggedInView();
                echo $view->createView();
                
            }
            
            else
            {
               if($this->count == 3)
               {
                include 'View\RegisterView.php';
                header('Location: Register.php');
                
                }
                else
                {
                    echo "Wrong log-in. Please try again. Incorrect attempts: $this->count";
                    include 'View\LogInView.php';
                    $view = new LogInView("");
                    echo $view->createView();
                    $_SESSION["count"]++;
                }
            }
            
        }
        else
        {
            echo "Please fill in all the fields.";
            include 'View\LogInView.php';
            $view = new LogInView("");
            echo $view->createView();
            
        }
        
        
    }
    public function check_dataset()
        {
            $email = $_POST["email"];
            $password = md5($_POST["password"]);
            $dataset = $this->model->select("user_storage", "user, pass");
            $rows = $dataset->fetchAll(PDO::FETCH_ASSOC);
            foreach($rows as $key)
            {
                if($email == $key["user"] && $password == $key["pass"])
                {
                    return true;
                }
            }
            
        }
}