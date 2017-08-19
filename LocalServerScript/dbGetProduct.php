<?php
	include ("testDB.php");
	
	if(isset($_POST["barcode"])){
		$barcode = $_POST["barcode"];
		
		$qry = "SELECT * FROM product WHERE barcode = '$barcode'";
		
		$result = mysqli_query($conn,$qry);
		
		if(mysqli_num_rows($result)>0){
			$row = mysqli_fetch_assoc($result);
			echo json_encode($row);
		}else{
			echo "The item does not exist in database.";
		}
		
	}else{
		echo "No barcode passed into php.";
	}
	mysqli_close($conn);
?>