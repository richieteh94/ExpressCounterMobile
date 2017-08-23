-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 23, 2017 at 03:35 PM
-- Server version: 5.7.14
-- PHP Version: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `psm`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `username` varchar(15) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `username`, `password`) VALUES
(1, 'admin', 'IQJvEvtlUJ30v+NKpLdHGQ==');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `barcode` varchar(20) NOT NULL,
  `name` varchar(100) NOT NULL,
  `price` double(6,2) NOT NULL,
  `quantity` int(5) NOT NULL,
  `status` varchar(12) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`barcode`, `name`, `price`, `quantity`, `status`) VALUES
('123', 'Milo Ais', 0.88, 1928, 'Unavailable'),
('12345', 'example01', 0.99, 200, 'Available'),
('12346', 'example02', 0.99, 100, 'Available'),
('322', 'dopa2', 0.99, 230, 'Unavailable'),
('4902430650366', 'Dynamo Normal Refill pack 1.6kg', 14.99, 40, 'Available'),
('4902430650465', 'Dynamo Anti-bacteria Refill pack 1.44kg', 14.99, 60, 'Available'),
('4902430650472', 'Dynamo Colorcare Refill pack 1.44kg', 14.99, 0, 'Available'),
('4902430650489', 'Dynamo Downy Refill pack 1.44kg', 14.99, 0, 'Available'),
('7622210638632', 'Chipsmore Original 163.2g', 3.60, 0, 'Available'),
('7622210638656', 'Chipsmore Double Choc 163.2g', 3.60, 0, 'Available'),
('7622210638854', 'Chipsmore Hazelnuts 163.2g', 3.60, 0, 'Available'),
('8886467100031', 'Pringles Cheezy Cheese', 4.00, 0, 'Available'),
('8886467100048', 'Pringles BBQ Flavour', 4.00, 0, 'Available'),
('8886467100055', 'Pringles Hot & Spicy', 4.00, 0, 'Available'),
('8886467100154', 'Pringles Pizza Flavour', 4.00, 0, 'Available'),
('8886467106095', 'Pringles Salt & Vinegar', 4.00, 0, 'Available'),
('8886467106514', 'Pringles Zesty Lime', 4.00, 0, 'Available'),
('95560001601001', 'Maggi Chili Sos 475g', 3.65, 0, 'Available'),
('9556001126528', 'Maggi Kari', 3.59, 0, 'Available'),
('9556001227843', 'Maggi Big Ayam', 5.20, 0, 'Available'),
('9556001235596', 'Maggi Big Tomyam', 5.20, 0, 'Available'),
('9556001236357', 'Nescafe Latte Coconut 15 sticks', 11.90, 0, 'Available'),
('9556001236395', 'Nescafe Latte Mocha 15 sticks', 11.90, 0, 'Available'),
('9556001238238', 'Nescafe Gold Dark Latte 12 sticks', 13.90, 0, 'Available'),
('9556001238269', 'Nescafe Gold Creamy Latte 12 sticks', 13.90, 0, 'Available'),
('9556001600806', 'Maggi Tomato Sos 475g', 3.65, 0, 'Available'),
('9556031090059', 'Glo Dishwash Lime 900ml', 3.99, 0, 'Available'),
('9556031090066', 'Glo Dishwash Lemon 900ml', 3.99, 0, 'Available'),
('9556031090073', 'Glo Dishwash Apple 900ml', 3.99, 0, 'Available'),
('9556031204814', 'Glo Dishwash Rose Lemon 900ml', 3.99, 0, 'Available'),
('9556031206658', 'Glo Dishwash Charcoal Lime 900ml', 3.99, 0, 'Available'),
('9556191010706', 'Kimball Tomato Sauce 500g', 2.99, 0, 'Available'),
('9556191012250', 'Kimball Chili Sauce 500g', 2.99, 0, 'Available'),
('9556196004755', 'Cloud9 Choco Wafer with Choco Cream', 1.99, 0, 'Available'),
('9556196004762', 'Cloud9 Choco Wafer with Vanilla Cream', 1.99, 0, 'Available'),
('9556210020010', 'Ramly Burger Ayam', 4.20, 0, 'Available'),
('9556210100036', 'Ramly Burger Lembu', 5.50, 0, 'Available'),
('9556210200057', 'Ramly Frankfurt Ayam', 5.80, 0, 'Available'),
('9556210250052', 'Ramly Frankfurt Lembu', 5.80, 0, 'Available'),
('9557202025693', 'NutriGold Instant Coffee Rich 3 in 1 25 sticks', 8.80, 0, 'Available'),
('9557205025631', 'NutriGold Instant Coffee Mild 3 in 1 30 sticks', 8.80, 20, 'Available'),
('9557205025662', 'NutriGold Instant Coffee Regular 3 in 1 30 packs', 8.80, 0, 'Available');

-- --------------------------------------------------------

--
-- Table structure for table `purchase`
--

CREATE TABLE `purchase` (
  `id` int(10) NOT NULL,
  `barcode` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `purchase`
--

INSERT INTO `purchase` (`id`, `barcode`) VALUES
(2, '123'),
(2, '322'),
(3, '123'),
(3, '322'),
(4, '123'),
(4, '322'),
(5, '123'),
(5, '322'),
(6, '123'),
(6, '322'),
(7, '123'),
(7, '322'),
(8, '123'),
(8, '322'),
(9, '123'),
(9, '322'),
(10, '123'),
(10, '322'),
(11, '123'),
(11, '322'),
(12, '123'),
(12, '322'),
(13, '123'),
(13, '322'),
(14, '123'),
(14, '322'),
(15, '123'),
(15, '322'),
(16, '123'),
(16, '322'),
(17, '123'),
(17, '322'),
(19, '123'),
(19, '322'),
(20, '123'),
(20, '322'),
(21, '123'),
(21, '322'),
(22, '123'),
(22, '322'),
(23, '123'),
(23, '322'),
(23, '322'),
(24, '322'),
(24, '123'),
(24, '322'),
(25, '123'),
(25, '322'),
(25, '322'),
(27, '322'),
(27, '123'),
(27, '123'),
(28, '123'),
(28, '322'),
(29, '123'),
(29, '322'),
(30, '322'),
(30, '123'),
(31, '322'),
(31, '123'),
(32, '322'),
(32, '123'),
(33, '123'),
(33, '322'),
(34, '123'),
(34, '322'),
(35, '123'),
(35, '322'),
(35, '123'),
(35, '322'),
(35, '123'),
(36, '123'),
(37, '123'),
(38, '123'),
(39, '123'),
(40, '123'),
(40, '123'),
(40, '123'),
(41, '123'),
(41, '123'),
(41, '123'),
(41, '123'),
(41, '123'),
(41, '123'),
(41, '322'),
(41, '123'),
(41, '322'),
(41, '322'),
(42, '9557205025662'),
(42, '9556196004762'),
(42, '9556196004755'),
(43, '9556196004755'),
(44, '9556196004755'),
(44, '9556196004762'),
(44, '9556196004762'),
(44, '9556196004762'),
(45, '9556196004755'),
(45, '9556196004755'),
(45, '9556196004755'),
(45, '9556196004755'),
(45, '9556196004755'),
(45, '9556196004755'),
(45, '9556196004755'),
(45, '9556196004755'),
(45, '9556196004755'),
(45, '9556196004755'),
(46, '123'),
(46, '123'),
(47, '322'),
(47, '322'),
(48, '9556196004762'),
(48, '9556196004762'),
(49, '7622210638632'),
(49, '9556196004762'),
(50, '7622210638632'),
(50, '7622210638632'),
(50, '7622210638632'),
(50, '7622210638632'),
(50, '7622210638632'),
(50, '7622210638632'),
(50, '7622210638632'),
(50, '7622210638632'),
(50, '7622210638632'),
(50, '7622210638632'),
(51, '9556196004762'),
(51, '9556196004762'),
(52, '9556196004755'),
(52, '9556196004755'),
(53, '9556196004755'),
(53, '9556196004755'),
(53, '9556196004755'),
(53, '9556196004755'),
(53, '9556196004755'),
(53, '9556196004755'),
(53, '9556196004755'),
(53, '9556196004755'),
(53, '9556196004755'),
(54, '9556196004762'),
(54, '9556196004755'),
(55, '123'),
(55, '123'),
(56, '123'),
(56, '123'),
(56, '123'),
(56, '123'),
(56, '123'),
(56, '123'),
(56, '123'),
(56, '123'),
(56, '123'),
(56, '123'),
(57, '123'),
(58, '123');

-- --------------------------------------------------------

--
-- Table structure for table `receipt`
--

CREATE TABLE `receipt` (
  `id` int(10) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `receipt`
--

INSERT INTO `receipt` (`id`, `date`, `time`) VALUES
(1, '2017-05-03', '03:10:12'),
(2, '2017-05-03', '15:45:17'),
(3, '2017-05-04', '06:54:52'),
(4, '2017-05-04', '06:57:02'),
(5, '2017-05-10', '13:55:52'),
(6, '2017-05-10', '13:58:00'),
(7, '2017-05-10', '13:59:33'),
(8, '2017-05-10', '14:01:03'),
(9, '2017-05-10', '14:02:47'),
(10, '2017-05-10', '14:03:48'),
(11, '2017-05-10', '14:04:29'),
(12, '2017-05-10', '14:05:15'),
(13, '2017-05-10', '14:05:50'),
(14, '2017-05-10', '14:06:46'),
(15, '2017-05-10', '14:07:12'),
(16, '2017-05-10', '14:07:39'),
(17, '2017-05-10', '14:13:29'),
(18, '2017-05-10', '14:14:21'),
(19, '2017-05-10', '14:14:33'),
(20, '2017-05-10', '14:15:42'),
(21, '2017-05-10', '14:16:05'),
(22, '2017-05-10', '14:16:30'),
(23, '2017-05-10', '14:18:54'),
(24, '2017-05-10', '18:17:56'),
(25, '2017-05-10', '18:33:26'),
(26, '2017-05-10', '18:37:43'),
(27, '2017-05-10', '18:39:34'),
(28, '2017-05-10', '18:43:32'),
(29, '2017-05-10', '18:46:58'),
(30, '2017-05-10', '19:00:42'),
(31, '2017-05-10', '19:06:13'),
(32, '2017-05-13', '05:44:07'),
(33, '2017-05-18', '04:43:21'),
(34, '2017-05-18', '04:44:43'),
(35, '2017-05-18', '07:56:21'),
(36, '2017-05-18', '07:59:37'),
(37, '2017-05-18', '08:01:29'),
(38, '2017-05-18', '08:02:36'),
(39, '2017-05-18', '13:36:12'),
(40, '2017-05-18', '13:45:25'),
(41, '2017-05-18', '22:00:30'),
(42, '2017-05-22', '12:15:26'),
(43, '2017-05-22', '15:37:40'),
(44, '2017-05-22', '15:52:30'),
(45, '2017-05-22', '17:21:00'),
(46, '2017-05-22', '17:31:27'),
(47, '2017-05-22', '17:32:13'),
(48, '2017-05-23', '20:29:07'),
(49, '2017-05-24', '08:33:53'),
(50, '2017-05-24', '10:52:44'),
(51, '2017-05-24', '11:10:14'),
(52, '2017-05-24', '11:52:40'),
(53, '2017-05-24', '11:58:15'),
(54, '2017-05-24', '12:53:05'),
(55, '2017-07-29', '13:02:01'),
(56, '2017-08-10', '15:40:23'),
(57, '2017-08-12', '22:54:03'),
(58, '2017-08-17', '16:06:54');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`barcode`);

--
-- Indexes for table `purchase`
--
ALTER TABLE `purchase`
  ADD KEY `id` (`id`),
  ADD KEY `barcode` (`barcode`) USING BTREE;

--
-- Indexes for table `receipt`
--
ALTER TABLE `receipt`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `receipt`
--
ALTER TABLE `receipt`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `purchase`
--
ALTER TABLE `purchase`
  ADD CONSTRAINT `purchase_barcode` FOREIGN KEY (`barcode`) REFERENCES `product` (`barcode`),
  ADD CONSTRAINT `purchase_id` FOREIGN KEY (`id`) REFERENCES `receipt` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
