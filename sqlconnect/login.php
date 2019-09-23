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
	$namecheckquery = "SELECT username, salt, hash FROM users WHERE username='" . $username . "';";
	
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); // error code number 2 = name check query failed
	
	if (mysqli_num_rows($namecheck) > 1){
		echo "5: Name exists more than once or none";
		exit();
	}

	//get log in info from query
	$logininfo = mysqli_fetch_assoc($namecheck); // get associated values inside the namecheck
	$salt = $logininfo["salt"];
	$hash = $logininfo["hash"];

	$loginhash = crypt($password, $salt);

	if ($loginhash != $hash)
	{
		echo "6: Incorrect Password"; // Password does not match to hash table
	}	

	echo "0";
?>