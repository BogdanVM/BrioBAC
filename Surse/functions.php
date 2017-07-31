<?php

 function existentUser($email) {
        $dbconnection = mysqli_connect("localhost", "id905754_user_briobac",
                                 	"password_briobac", "id905754_briobac");
        $stmt = $dbconnection->prepare("SELECT Email from conturi WHERE Email = ?");
 
        $stmt->bind_param("s", $email);
 
        $stmt->execute();
 
        $stmt->store_result();
 
        if ($stmt->num_rows > 0) {

            $stmt->close();
            return true;
        } 
        else {
        
            $stmt->close();
            return false;
        }
    }

   function getUserByEmailAndPassword($email, $password) {
        
        $dbconnection = mysqli_connect("localhost", "id905754_user_briobac",
                                 	"password_briobac", "id905754_briobac");
        $stmt = $dbconnection->prepare("SELECT * FROM conturi WHERE Email = ? AND Parola = ?");
 
        $stmt->bind_param("ss", $email, $password);
 
        if ($stmt->execute()) {
            $user = $stmt->get_result()->fetch_assoc();
            $stmt->close();
            
            return $user;
        } 
        else {
            return NULL;
        }
    }

   function numberOfRows(){

     $dbconnection = mysqli_connect("localhost", "id905754_user_briobac",
                                 	"password_briobac", "id905754_briobac");
     $getID = mysqli_fetch_assoc(mysqli_query($dbconnection, "SELECT Count(*) FROM conturi"));

     return $getID;

    }
?>