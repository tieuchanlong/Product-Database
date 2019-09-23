<?php
	
	$con = mysqli_connect('localhost', 'root', 'root', 'productinfodatabase'); // create connection variable
	
	//check connection happened
	if (mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 = connection failed
		exit();
	}
	
	$name = $_POST["name"];
	$newname = $_POST["newname"];
	$price = $_POST["price"];
	$description = $_POST["description"];
	$usage = $_POST["usage"];
	$img = $_POST["img"];
	
	// check if the name has already existed
	$namecheckquery = "SELECT name, price, description, product_use, image FROM products WHERE name='" . $name . "';";
	
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); // error code number 2 = name check query failed
	
	if (mysqli_num_rows($namecheck) > 1){
		echo "3: More than two same name exists";
		exit();
	}

	$namedelete = "DELETE FROM products WHERE name='" . $newname . "';";

	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); // error code number 2 = name check query failed
	

	
	// Add the user to the table
	$insertuserquery = "INSERT INTO products (name, price, description, product_use, image) VALUES ('" . $name . "', '" . $price . "', '" . $description . "', '"  . $usage . "', '" . $img . "');";
	mysqli_query($con, $insertuserquery) or die("4: Insert user query failed"); // error code 4 = insert query failed
	
	echo("0"); // Insert player success
?>