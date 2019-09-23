<?php
	
	$con = mysqli_connect('localhost', 'root', 'root', 'userdatabase'); // create connection variable
	
	//check connection happened
	if (mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 = connection failed
		exit();
	}
	
	$username = $_POST["name"];
	$password = $_POST["password"];
	
	// check if the name has already existed
	$namecheckquery = "SELECT username FROM users WHERE username='" . $username . "';";
	
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); // error code number 2 = name check query failed
	
	if (mysqli_num_rows($namecheck) > 0){
		echo "3: Name already exists";
		exit();
	}
	
	// Add the user to the table
	$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";// using encryption, running through 5000 shifting round for password
	$hash = crypt($password, $salt);
	$insertuserquery = "INSERT INTO users (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
	mysqli_query($con, $insertuserquery) or die("4: Insert user query failed"); // error code 4 = insert query failed
	
	echo("0"); // Insert player success
?>