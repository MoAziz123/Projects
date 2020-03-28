<?php

/**
 * instantiates the view for downloading a file
 * @author - Mo
 **/

class DownloadView {
    public $output;
    public function __construct($file) 
    {
        $this->value = $_GET["value2"];
        $this->output = "";
        $this->file = $file;
        
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
                <title>Web Portal - Log In</title>
                </head>
                
                HEADER;
    }
    public function createBody()
    {
        $this->output .= <<<BODY
                <body>
                <fieldset>
                <form method="get" action ="DownloadFile.php?value=$this->file">
                <h2>Download</h2>
                The file to download is: $this->file. <br>Please select a location to download to. <br>
                <input type="file" name="file" multiple> <br>
                <button type="submit">Download</button>
                </form>
                </fieldset>
                </body>
                BODY;
    }
    public function createFooter()
    {
        $this->output .= <<<FOOTER
                <p> &copy; Mo Aziz - 2020 </p>
                FOOTER;
        
    }
    
}
