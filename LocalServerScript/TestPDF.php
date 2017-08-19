<?php
	require('fpdf181/fpdf.php');
	
	class PDF extends FPDF{
		function Header(){
			$address1 = "Faculty of Information & Communication Technology";
			$address2 = "Universiti Teknikal Malaysia Melaka";
			$address3 = "Hang Tuah Jaya, 76100 Durian Tunggal";
			$address4 = "Melaka, Malaysia";
			$this->SetFont('Times','B',12);
			$this->Cell(0,5,$address1,0,1,'C');
			$this->Cell(0,5,$address2,0,1,'C');
			$this->Cell(0,5,$address3,0,1,'C');
			$this->Cell(0,5,$address4,0,1,'C');	
		}
		/*function Footer(){
			// Position at 1.5 cm from bottom
			$this->SetY(-15);
			// Arial italic 8
			$this->SetFont('Arial','I',8);
			// Page number
			$this->Cell(0,10,'Page '.$this->PageNo().'/{nb}',0,0,'C');
		}*/
	}
	function genPDF($array ,$fileName,$date,$time){
		$pdf = new PDF();
		//$pdf-> AliasNbPages();
		$pdf->AddPage();
		$total=0.00;
		
		$width =$pdf->GetpageWidth();
		$pdf->Ln(10);
		$pdf->Cell(50,10,'Date : '.$date);
		$pdf->Cell(50);
		$pdf->Cell(50,10,'Time : '.$time);
		$pdf->Ln(10);
		$pdf->Cell(50,10,"Barcode");
		$pdf->Cell(10);
		$pdf->Cell(50,10,"Name");
		$pdf->Cell(50);
		$pdf->Cell(30,10,"Price");
		$pdf->Line(10,57.5,$width-10,57.5);
		$pdf->Ln(7.5);
		
		$pdf->SetFont('Times','',12);
		for($i = 0;$i<sizeof($array);$i++){
			$pdf->Cell(50,10,$array[$i]['barcode']);
			$pdf->Cell(10);
			$pdf->Cell(50,10,$array[$i]['name']);
			$pdf->Cell(50);
			$pdf->Cell(20,10,'RM '.$array[$i]['price']);
			$pdf->Ln(7.5);
			$total+=$array[$i]['price'];
		}
		
		$pdf->Ln(2.5);
		$pdf->setFontSize(12);
		$width =$pdf->GetpageWidth();
		$currY = $pdf->GetY();
		$pdf->Line(10,$currY,$width-10,$currY);
		$pdf->SetFont('Times','B',12);
		$pdf->Cell(100,10,'Total inclusive GST(6%)');
		$pdf->Cell(60);
		$pdf->Cell(20,10,'RM '.$total);
		$pdf->Ln(30);
		$pdf->SetFont('Times','B',14);
		$pdf->Cell(0,5,'Thank You and come again!!',0,1,'C');
		$currY2=$pdf->GetY();
		$path = "pdf/".$fileName.".pdf";
		$pdf->Output("F",$path , true);
	}
	
	/*$pdf = new PDF();
	//$pdf-> AliasNbPages();
	$pdf->AddPage();
	
	$pdf->SetFont('Times','',12);
	
	$pdf->Cell(50,10,'Milo 10kg');
	$pdf->Cell(110);
	$pdf->Cell(20,10,'RM 20.00');
	$pdf->Ln(10);
	
	$pdf->setFontSize(12);
	$width =$pdf->GetpageWidth();
	$currY = $pdf->GetY();
	$pdf->Line(10,$currY,$width-10,$currY);
	$pdf->SetFont('Times','B',12);
	$pdf->Cell(50,10,'Total');
	$pdf->Cell(110);
	$pdf->Cell(20,10,'RM 20.00');
	$pdf->Ln(30);
	$pdf->SetFont('Times','B',14);
	$pdf->Cell(0,5,'Thank You and come again!!',0,1,'C');
	$currY2=$pdf->GetY();
	$path = "pdf/AAA.pdf";
	$pdf->Output("F",$path , true);*/
	
?>