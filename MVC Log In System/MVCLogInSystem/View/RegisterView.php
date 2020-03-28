<?php

/**
 *instantiates the view for creating an account
 * @author - Mo
 **/

class RegisterView
{
    public $output;
    public function __construct()
    {
        $this->output = "";
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
                <title>Create Account</title>
                </head>
                
                HEADER;
    }
    public function createBody()
    {
        $this->output .= <<<BODY
                <body>
                <fieldset>
                <form method="post" action="Register.php">
                <h1>Create Account</h1>
                <label for="email">Email:</label>
                <input type="text" name="email">
                <br><br>
                <label for="password">Password:</label>
                <input type="password" name="password">
                BODY;
        if(isset($_POST["submit"]))
        {
            $this->output .= <<<BODY
                    <br><br>
                    <label for="confirm"> Confirmation Code: </label>
                    <input type="text" name="confirm">
                    <br><br>
                    <button type="submit" name="submit">Register</button>
                    </form>
                    </fieldset>
                    </body>
                    BODY;
        }
        else
        {
                $this->output .= <<<BODY
                <br><br>
                <button type="submit" name="submit">Continue</button>
                </form>
                </fieldset>
                </body>
                BODY;
        }
        
    
    }
    public function createFooter()
    {
        $this->output .= <<<FOOTER
                <p> &copy; Mo Aziz - 2020 </p>
                FOOTER;
        
    }
    
}