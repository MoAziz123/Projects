<?php
//class that acts as a wrapper for FTP functions - making it easier to call without having to constantly log in
class FTPConnection
{
    public $stream;
    public function __construct()
    {
        $this->stream = ftp_connect("127.0.0.1")or die("Unable to establish a connection");
        ftp_login($this->stream)or die("Unable to log in.");
        ftp_pasv($this->stream, true);
        
        
        
    }
    
    
    public function add($upload, $file, $mode=FTP_ASCII)
    {
    ftp_put($this->stream, basename($upload), $file, $mode);
    
            
    }
    
    public function remove($file)
    {
        ftp_delete($this->stream, $file);
        echo "Successful";
    
    }
    public function get($download, $remote)
    {
        ftp_get($this->stream, "uploads/" . $download, $remote);
        
        
    }
    public function scan($dir)
    {
        return scandir($dir . "/");
    }
    public function close()
    {
        ftp_close($this->stream);
    }
    public function pwd()
    {
        
        return scandir(realpath(ftp_pwd($this->stream) . "/"));
    }
}