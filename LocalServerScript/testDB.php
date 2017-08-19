<?php
		$servername = "localhost";
		$dbname = "psm";
		$username = "root";
		$password = "";
		
		$conn = mysqli_connect($servername,$username,$password,$dbname);
		
		if(!$conn){
			die("Connection failed: " . mysqli_connect_error());
		}
		/*else{
			echo 'success connect database.';
		}*/
		//mysqli_close($conn);
		
?>