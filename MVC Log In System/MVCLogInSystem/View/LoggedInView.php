<?php

/* 
 * Instantiates the view when logged in
 */
include 'Model/FTPConnection.php';
class LoggedInView
{
    public $output;
    public $email;
    public $model;
    public $filemodel;
    
    public function __construct()
    {
        $this->output = "";
        $this->filemodel = new FTPConnection();
    }
    public function createView()
    {
        $this->createHeader();
        $this->createBody();
        $this->createFooter();
        return $this->output;
    }
    public function createHeader()
    {
        $this->output .= <<<HEADER
                <!DOCTYPE html>
                <head>
                <meta charset="UTF-8"></meta>
                <title>Web Portal </title>
                </head>
                
                HEADER;
    }
    public function createBody()
    {
        $this->output .= <<<BODY
                <body>
                <p>Welcome to the Web Portal</p>
                <fieldset>
                <table border="1px solid black">
                <tr>
                  <th width="35%;">File Name </th>
                  <th>Type</th>
                  <th>View</th>
                  <th>Download</th>
                </tr>
                BODY;
        $path = "/xampp/htdocs/FTP Uploads";
        $key = scandir($path);
        foreach($key as $value)
        {
            
            if(!is_dir($value))
            {
                copy($path . "/" . $value, "uploads/$value");

            }
            $this->output .= "<tr>";
            $this->output .= "<td>" . $value . "</td>";
            if(is_dir($value))
            {
                $this->output .= "<td>dir</td>";
                $this->output .= "<td></td>";
            }
            else
            {
                $this->output .= "<td>file</td>";
                $this->output .= "<td><a href='uploads/$value' value='$value'>View</a></td>";

            }
            $this->output .= "<td><a href='DownloadFile.php?value2=$value'>Download</a></td>";
            $this->output .= "</tr>";
        }
        
      
        $this->output .= "</table>";
        $this->output .= <<<BODY
                </fieldset>
                <div style="display:inline;">
                <fieldset>
                <h2>Add</h2>
                <form method="post" action="LoggedIn.php">
                File Name:
                <br>
                <input type="file" name="addfile">
                <br><br>
                <button type="submit" name="submit" value="ADD">Add File</button>
                </form>
                </fieldset>
                </div>
                BODY;
        
        $this->output .= <<<BODY
                <fieldset>
                <h2>Remove</h2>
                <form method="post" action="LoggedIn.php">
                File Name: 
                <br>
                <select name="item">
                
                BODY;
        foreach($key as $value)
        {
            $this->output .= "<option value='$value'>$value</option>";
            
        }
        $this->output .= <<< BODY
                </select>
                <button type="submit" name="submit" value="REMOVE">Remove File</button>
                <br><br>
                </form>
                </fieldset>
                BODY;
                
        
    }
    public function createFooter()
    {
        $this->output .= <<<FOOTER
                <p> &copy; Mo Aziz - 2020 </p>
                FOOTER;
        
    }
    
}
                