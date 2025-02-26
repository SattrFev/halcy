-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Feb 21, 2025 at 04:40 AM
-- Server version: 8.0.30
-- PHP Version: 8.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `halcy`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `id` int NOT NULL,
  `barcode` varchar(50) NOT NULL,
  `name` varchar(100) NOT NULL,
  `category` varchar(50) NOT NULL,
  `buy_price` decimal(10,2) NOT NULL,
  `sell_price` decimal(10,2) NOT NULL,
  `stock` int NOT NULL DEFAULT '0',
  `unit` varchar(20) NOT NULL,
  `min_stock` int NOT NULL DEFAULT '0',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`id`, `barcode`, `name`, `category`, `buy_price`, `sell_price`, `stock`, `unit`, `min_stock`, `created_at`, `updated_at`) VALUES
(52, '8991001100011', 'Indomie Goreng', 'Makanan', '2500.00', '3000.00', 100, 'pcs', 10, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(53, '8991001100028', 'Indomie Kuah Ayam', 'Makanan', '2500.00', '3000.00', 80, 'pcs', 10, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(54, '8991001100035', 'Mie Sedaap Goreng', 'Makanan', '2400.00', '2900.00', 90, 'pcs', 10, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(55, '8998866200015', 'Bimoli Minyak Goreng 1L', 'Sembako', '15000.00', '17000.00', 50, 'liter', 5, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(56, '8998866200022', 'Tropical Minyak Goreng gg2L', 'Sembako', '28000.00', '32000.00', 30, 'liter', 5, '2025-02-21 03:11:10', '2025-02-21 03:11:18'),
(57, '8998866200039', 'Gulaku 1kg', 'Sembako', '12000.00', '15000.00', 60, 'kg', 6, '2025-02-21 03:11:10', '2025-02-21 03:11:22'),
(58, '8998866200046', 'Beras Ramos 5kg', 'Sembako', '65000.00', '70000.00', 40, 'kg', 5, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(59, '8998866200053', 'Teh Pucuk Harum 350ml', 'Minuman', '3500.00', '5000.00', 100, 'pcs', 10, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(60, '8998866200060', 'Aqua 600ml', 'Minuman', '3000.00', '4000.00', 120, 'pcs', 10, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(61, '8998866200077', 'Coca Cola 1.5L', 'Minuman', '12000.00', '15000.00', 50, 'pcs', 5, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(62, '8998866200084', 'Sprite 390ml', 'Minuman', '5000.00', '7000.00', 80, 'pcs', 10, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(63, '8998866200091', 'Susu UHT Ultra 200ml', 'Minuman', '5000.00', '6500.00', 60, 'pcs', 5, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(70, '8998866200169', 'Baygon Aerosol 600ml', 'Kebutuhan Rumah Tangga', '28000.00', '32000.00', 30, 'pcs', 5, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(71, '8998866200176', 'Tissue Paseo 250 sheets', 'Kebutuhan Rumah Tangga', '15000.00', '18000.00', 60, 'pcs', 5, '2025-02-21 03:11:10', '2025-02-21 03:11:10'),
(72, '123123123', 'asdasd', 'ATK', '123.00', '123.00', 123, 'g', 123, '2025-02-21 03:11:38', '2025-02-21 03:11:38');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int NOT NULL,
  `ctg` varchar(50) NOT NULL,
  `description` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `ctg`, `description`) VALUES
(1, 'Makanan', 'Produk makanan siap makan atau bahan pangan'),
(2, 'Minuman', 'Berbagai jenis minuman kemasan atau botolan'),
(3, 'Sembako', 'Kebutuhan pokok seperti beras, minyak, gula'),
(4, 'Kebutuhan Rumah Tangga', 'Sabun, detergen, alat kebersihan'),
(5, 'Kosmetik & Perawatan', 'Produk kecantikan dan perawatan tubuh'),
(6, 'Obat & Kesehatan', 'Obat bebas, suplemen, alat kesehatan'),
(7, 'Elektronik', 'Peralatan elektronik seperti charger, baterai'),
(8, 'ATK', 'Alat Tulis Kantor, kertas, pensil, pulpen'),
(9, 'Fashion', 'Pakaian, sepatu, tas, aksesoris'),
(10, 'Mainan', 'Mainan anak, boneka, puzzle');

-- --------------------------------------------------------

--
-- Table structure for table `units`
--

CREATE TABLE `units` (
  `id` int NOT NULL,
  `unit` varchar(20) NOT NULL,
  `description` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `units`
--

INSERT INTO `units` (`id`, `unit`, `description`) VALUES
(1, 'pcs', 'Per item atau satuan'),
(2, 'kg', 'Satuan berat kilogram'),
(3, 'g', 'Satuan berat gram'),
(4, 'L', 'Satuan volume liter'),
(5, 'mL', 'Satuan volume mililiter'),
(6, 'pack', 'Satuan per kemasan'),
(7, 'dus', 'Satuan per dus/karton'),
(8, 'rim', 'Satuan untuk kertas (1 rim = 500 lembar)'),
(9, 'roll', 'Satuan gulungan, seperti kain atau lakban'),
(10, 'm', 'Satuan panjang meter');

-- --------------------------------------------------------

--
-- Table structure for table `userlog`
--

CREATE TABLE `userlog` (
  `id` int NOT NULL,
  `executor` varchar(50) NOT NULL,
  `actions` text NOT NULL,
  `time` timestamp NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `userlog`
--

INSERT INTO `userlog` (`id`, `executor`, `actions`, `time`) VALUES
(11, 'Administrator', 'login', '2025-02-21 03:10:50'),
(12, 'Administrator', 'mengedit barang 56', '2025-02-21 03:11:18'),
(13, 'Administrator', 'mengedit barang 57', '2025-02-21 03:11:22'),
(14, 'Administrator', 'menghapus barang Sampo Lifebuoy 170ml) dari db', '2025-02-21 03:11:27'),
(15, 'Administrator', 'menghapus barang Susu Bear Brand 189ml,Kopi Kapal Api 165gr,Good Day Mocca 250ml,Sabun Lifebuoy 85gr,Rinso 800gr) dari db', '2025-02-21 03:11:30'),
(16, 'Administrator', 'menambahkan barang asdasd ke db', '2025-02-21 03:11:38'),
(17, 'Administrator', 'login', '2025-02-21 03:12:29'),
(18, 'Administrator', 'login', '2025-02-21 03:13:31'),
(19, 'Administrator', 'login', '2025-02-21 03:19:38'),
(20, 'Administrator', 'login', '2025-02-21 03:20:11'),
(21, 'Administrator', 'login', '2025-02-21 03:20:52'),
(22, 'Administrator', 'login', '2025-02-21 03:21:41'),
(23, 'Administrator', 'login', '2025-02-21 03:22:22'),
(24, 'Administrator', 'login', '2025-02-21 03:22:53'),
(25, 'Administrator', 'login', '2025-02-21 03:24:37'),
(26, 'Administrator', 'login', '2025-02-21 03:26:04'),
(27, 'Administrator', 'login', '2025-02-21 04:01:21'),
(28, 'Administrator', 'login', '2025-02-21 04:32:11');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int NOT NULL,
  `usn` varchar(50) NOT NULL,
  `psw` varchar(255) NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `role` enum('admin','user') DEFAULT 'user',
  `status` enum('on','off') DEFAULT 'on',
  `last_login` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `usn`, `psw`, `created_at`, `role`, `status`, `last_login`) VALUES
(1, 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', '2025-02-19 02:15:13', 'admin', 'on', '2025-02-21 11:32:12');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `barcode` (`barcode`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ctg` (`ctg`);

--
-- Indexes for table `units`
--
ALTER TABLE `units`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unit` (`unit`);

--
-- Indexes for table `userlog`
--
ALTER TABLE `userlog`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `usn` (`usn`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `barang`
--
ALTER TABLE `barang`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=73;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `units`
--
ALTER TABLE `units`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `userlog`
--
ALTER TABLE `userlog`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
