
<?php

/* 
 * instantiates the log in screen so that users can enter their details 
 * and access the files
 */

class LogInView
{
    public $output;
    public $action;
    public function __construct($action)
    {
        $this->output = "";
        $this->action = $action;
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
        $this->output = "<br>The time is: " . date("d M Y - H:m");
    }
    public function createBody()
    {
        $this->output .= <<<BODY
                <body>
                <fieldset>
                <form method="post" action="$this->action">
                <h1>Web Portal</h1>
                <label for="email">Email:</label>
                <input type="email" name="email">
                <br><br>
                <label for="password">Password:</label>
                <input type="password" name="password">
                <br><br>
                <input type="checkbox" name="check"> Save as Cookie?
                <br><br>
                <button type="submit" name="submit">Log In</button>
                </form>
                <a href="Register.php"><button>Register</button></a>
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