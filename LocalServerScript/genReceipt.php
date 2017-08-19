<?php
	include("testDB.php");
	include("TestPDF.php");
	
	if(isset($_POST["receipt"])){
		$receipt=$_POST["receipt"];
		$myArray = json_decode($receipt,true);
		
		$receipt ="abc";
		
		$date = date('Y-m-d');
		$time = date('H:i:s');
		$qry = "INSERT INTO receipt (date,time) VALUES ('$date','$time');";
		
		if (mysqli_query($conn,$qry)) {
			//echo "New receipt created successfully \n";
			$qry = "SELECT id FROM receipt WHERE date='$date' AND time='$time'";
				
			$result = mysqli_query($conn,$qry);
			if(mysqli_num_rows($result)>0){
				$row = mysqli_fetch_assoc($result);
				$receipt = $row['id'];
				
				for($i =0 ; $i < sizeof($myArray) ; $i++){
					$barcode = $myArray[$i]['barcode'];
					$name = $myArray[$i]['name'];
					$price = $myArray[$i]['price'];
					
					$qry = "INSERT INTO purchase (id,barcode) VALUES ($receipt,$barcode);";
					
					if (mysqli_query($conn,$qry)) {
						//echo "New record created successfully \n";
						//add deduct item query
						$deduct = "UPDATE product SET quantity = quantity - 1 WHERE barcode = '$barcode'";
						if (mysqli_query($conn,$deduct)) {
							//echo "Success deduct item \n";
						}else{
							echo "Error: " . $deduct . "<br>" . mysqli_error($conn);
						}
						
					}else {
						echo "Error: " . $qry . "<br>" . mysqli_error($conn);
					}
				}
				$receipt = $date . '-' .$receipt;
				genPDF($myArray,$receipt,$date,$time);
				
			}else{
				echo "The receipt is not exist in database.";
			}
			
			if($receipt!=("abc")){
				echo $receipt.".pdf";
			}
			
			
		}else {
			echo "Error: " . $qry . "<br>" . mysqli_error($conn);
		}	
	}
	mysqli_close($conn);
?>