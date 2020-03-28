<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of LoggedInController
 *
 * @author Lenovo
 */
set_time_limit(30);
include 'Model/FTPConnection.php';
class LoggedInController {
    //put your code here
    public $filemodel;
    public function __construct()
    {
        $this->filemodel = new FTPConnection();
    }
    public function execute()
    {
        if($_POST["submit"] == "ADD")
        {
            $this->filemodel->add($_POST["addfile"], $_POST["addfile"], FTP_ASCII);
            echo basename($_POST['addfile']) . " added. Redirecting...";
            sleep(2);
            header("Location: index.php");
            
            
        }
        elseif($_POST["submit"] == "REMOVE")
        {
            
            $this->filemodel->remove($_POST["item"]);
            
        }
        
    }
        
}
