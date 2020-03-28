<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of IndexController
 *
 * @author Lenovo
 */
class IndexController {
    //put your code here
     public function execute()
    {
     if(isset($_COOKIE["email"]) && isset($_COOKIE["password"]))   {//then automatically log in
            include 'View\LoggedInView.php';
            $view = new LoggedInView();
            echo $view->createView();
        }
        else
        {//go to the normal log in page
            include 'View\LogInView.php';
            $view = new LogInView("LogIn.php");
            echo $view->createView();
        }
    }
    
    
}