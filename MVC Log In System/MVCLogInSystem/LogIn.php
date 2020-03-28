<?php
//login page that executes controller
/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

include 'Controller\LogInController.php';
$controller = new LogInController();
$controller->execute();