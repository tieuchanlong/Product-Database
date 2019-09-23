<?php
	
	$con = mysqli_connect('localhost', 'root', 'root', 'productinfodatabase'); // create connection variable
	
	//check connection happened
	if (mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 = connection failed
		exit();
	}
	
	$name = $_POST["name"];
	
	// check if the name has already existed
	$namecheckquery = "SELECT name, price, description, product_use, image FROM products WHERE name='" . $name . "';";
	
	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); // error code number 2 = name check query failed
	
	if (mysqli_num_rows($namecheck) > 1){
		echo "3: More than two same name exists";
		exit();
	}

	if (mysqli_num_rows($namecheck) < 1){
		echo "4: Product doesnt exist.";
		exit();
	}
	
	// Fetch the info of product
	$productinfo = mysqli_fetch_assoc($namecheck);
	
	
	echo($productinfo["name"] . "*" . $productinfo["price"] . "*" . $productinfo["description"] . "*" . $productinfo["product_use"] . "*" . $productinfo["image"]); // Insert player success
?>