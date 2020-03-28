<?php
//logged in page that executes controller
include 'Controller/LoggedInController.php';
$controller = new LoggedInController();
$controller->execute();