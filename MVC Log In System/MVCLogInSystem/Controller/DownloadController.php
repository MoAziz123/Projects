<?php

/*
 * when download is clicked, it will be handled by this controller
 */
session_start();
set_time_limit(20);
include 'View/DownloadView.php';
class DownloadController 
{

    //put your code hre
    public function __construct()
    {
      if(!empty($_GET["value2"]))
      {
       $_SESSION["value"] = $_GET["value2"];
       $view = new DownloadView($_GET["value2"]);
       echo $view->createView();
       
      }
      else
      {
          if(file_exists("/xampp/htdocs/FTP Uploads/" . $_SESSION["value"]))
          {
            copy("/xampp/htdocs/FTP Uploads/".$_SESSION["value"], dirname($_GET["file"]) . "\\" . $_SESSION["value"]);
            echo "File downloaded.";
            sleep(3);
            header("Location: index.php");

              
          }
          else
          {
              echo "Unable to find file.";
              sleep(3);
              header("Location: index.php");
          
      }
        
    }
    
}
}