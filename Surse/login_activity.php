<?php

        $dbconnection = mysqli_connect("localhost", "id905754_user_briobac",
                                 	"password_briobac", "id905754_briobac");

	$password = $_POST["Password"];
	$mail = $_POST["Email"];
	
	$statement = mysqli_prepare($dbconnection, "SELECT * FROM conturi WHERE Email = ? AND Parola = ? LIMIT 1");
	mysqli_stmt_bind_param($statement, "ss", $mail, $password);
	mysqli_stmt_execute($statement);
	
	mysqli_stmt_store_result($statement);

 if (mysqli_stmt_num_rows($statement) > 0){
	mysqli_stmt_bind_result($statement, $userID, $name, $email, $pwd, $updated, $last_update, $profile);

	$user = array();
	
	while(mysqli_stmt_fetch($statement)){
                $user["ID"] = $userID;
		$user["Nume"] = $name;
		$user["Email"] = $email;
		$user["Parola"] = $pwd;
		$user["Actualizat"] = $updated;
                $user["Ultima_Actualizare"] = $last_update;
		$user["Poza"] = $profile;
	}
	
	echo json_encode($user);
	
	mysqli_stmt_close($statement);
	mysqli_close($dbconnection);
 }

  else 
     echo "User not found";
?>