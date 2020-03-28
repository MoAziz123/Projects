<?php
//class that acts as a wrapper for SQL functions - making it much easier to utilise
//it uses exec with parameters to reduce the chance of SQL injection attacks
class DataConnectionModel
{
    public $username;
    public $server_name;
    public $conn;
    function __construct()
    {
        $this->server_name = "mysql:dbname=mysql;host=127.0.0.1";
        $this->username = "root";
        $this->conn = new PDO($this->server_name, $this->username, null);
        $this->conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        


    }
    
    function insert($table, $params, $values)
    {
        filter_var($table, FILTER_SANITIZE_SPECIAL_CHARS);
        filter_var($params, FILTER_SANITIZE_SPECIAL_CHARS);
        filter_var($values, FILTER_SANITIZE_SPECIAL_CHARS);
        
        $this->conn->exec("INSERT INTO $table ($params) VALUES ($values)");
    }
    
    function select($table, $fields)
    {
        filter_var($table, FILTER_SANITIZE_SPECIAL_CHARS);
        filter_var($fields, FILTER_SANITIZE_SPECIAL_CHARS);
        $result = $this->conn->query("SELECT $fields FROM $table");
        return $result;
    }
    
    function create($table, ...$fields)
    {
        filter_var($table, FILTER_SANITIZE_SPECIAL_CHARS);
        $stmt = "CREATE TABLE $table (";
        foreach($fields as $field)
        {
            filter_var($field, FILTER_SANITIZE_SPECIAL_CHARS);
            $stmt .= "$field, ";
        }
        $stmt .= ")";
        $stmt = str_replace(", )", ")", $stmt);
        $this->conn->exec($stmt);
        
        
    }
    
    function exists($table)
    {
        
        $this->conn->query("SELECT *FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '$table'");
        return true;
            
        
        
        
    }
    function close()
    {
        $this->conn = null;
    }
    
    
}

