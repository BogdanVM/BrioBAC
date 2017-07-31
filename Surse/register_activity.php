<?php

         include 'functions.php';

         if (existentUser($_POST["Email"])){
               echo "Utilizator existent";
         }

      else{
         $id = numberOfRows();
         $dbconnection = mysqli_connect("localhost", "id905754_user_briobac",
                                 	"password_briobac", "id905754_briobac");
	 
	 $name = $_POST["Nume"];
	 $email = $_POST["Email"];
         $password = $_POST["Parola"];
	 $updated = $_POST["Actualizat"];
	 $last_updated = $_POST["Ultima_Actualizare"];
         $profilePic = $_POST["Poza"];
	 
	 $statement = mysqli_prepare($dbconnection, "INSERT INTO conturi(Nume, Email, Parola, Actualizat,
                                             	 Ultima_Actualizare, Poza) VALUES (?, ?, ?, ?, ?, ?)");
	 
	 mysqli_stmt_bind_param($statement, "sssisb", $name, $email, $password, $updated, $last_updated, $profilePic);
	 mysqli_stmt_execute($statement);
	 
	 mysqli_stmt_close($statement);
	 mysqli_close($dbconnection);

         echo json_encode($id);
      }
?>