-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 07, 2022 at 01:27 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `blodbank`
--

-- --------------------------------------------------------

--
-- Table structure for table `blood_units`
--

CREATE TABLE `blood_units` (
  `id` int(11) NOT NULL,
  `donor_id` int(11) NOT NULL,
  `booking_id` int(11) NOT NULL,
  `blood_type` int(11) NOT NULL,
  `is_consumed` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `bookings`
--

CREATE TABLE `bookings` (
  `id` int(11) NOT NULL,
  `donor_id` int(11) NOT NULL,
  `staff_id` int(11) NOT NULL,
  `appointment_date` datetime NOT NULL,
  `is_done` tinyint(4) NOT NULL,
  `donated_amount` int(11) NOT NULL,
  `donor_name` varchar(32) NOT NULL,
  `staff_name` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `donors`
--

CREATE TABLE `donors` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `phone_number` varchar(32) NOT NULL,
  `address` varchar(32) NOT NULL,
  `date_of_birth` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `donors`
--

INSERT INTO `donors` (`id`, `name`, `phone_number`, `address`, `date_of_birth`) VALUES
(1, 'Pelle Paltnacke', '220-9484-78', 'Bondegatan 15 83149 Östersund', '1977-02-23'),
(2, 'Evelyn Elliott', '095-0136-51', 'Storgatan 8 83141 Östersund', '1961-05-29'),
(3, 'Owen Johnston', '854-9063-99', 'Allegatan 8 83143 Östersund', '1960-06-18'),
(4, 'Garry Barnes', '679-3406-15', 'Storgatan 11 83145 Östersund', '1940-05-25'),
(5, 'Luke Fowler', '697-1441-30', 'Rådhusgatan 29 83150 Östersund', '1981-05-27'),
(6, 'Byron Hall', '600-8216-89', 'Rådhusgatan 18 83139 Östersund', '1961-02-25'),
(7, 'Kellan Stevens', '066-4101-74', 'Rådhusgatan 4 83145 Östersund', '1941-10-07'),
(8, 'Amber Turner', '418-5405-99', 'Bondegatan 12 83140 Östersund', '1942-05-27'),
(9, 'Vanessa Thompson', '588-3905-12', 'Prästgatan 15 83141 Östersund', '1981-10-30'),
(10, 'Byron Elliott', '900-9307-83', 'Bondegatan 11 83146 Östersund', '1963-01-22'),
(11, 'Chloe Brown', '555-6157-84', 'Rådhusgatan 2 83150 Östersund', '1940-01-08'),
(12, 'Miranda Scott', '338-3851-08', 'Bondegatan 21 83140 Östersund', '1961-03-11'),
(13, 'Maximilian Russell', '811-4318-74', 'Storgatan 27 83143 Östersund', '1970-06-09'),
(14, 'Eleanor Rogers', '565-7897-99', 'Rådhusgatan 9 83148 Östersund', '1975-09-01'),
(15, 'Andrew Foster', '192-8167-96', 'Bondegatan 19 83141 Östersund', '1944-01-18'),
(16, 'Bruce Cunningham', '390-8786-21', 'Storgatan 8 83148 Östersund', '1980-08-06'),
(17, 'Ned Moore', '144-3442-58', 'Prästgatan 5 83141 Östersund', '1949-07-08'),
(18, 'Lenny Alexander', '733-1135-49', 'Rådhusgatan 27 83149 Östersund', '1942-07-27'),
(19, 'Alissa Higgins', '768-5147-22', 'Prästgatan 25 83147 Östersund', '1956-09-30'),
(20, 'Lilianna Sullivan', '902-3109-56', 'Allegatan 23 83150 Östersund', '1971-10-14'),
(21, 'Isabella Barnes', '517-4947-25', 'Bondegatan 17 83142 Östersund', '1983-11-16'),
(22, 'Jacob Kelly', '589-7497-06', 'Storgatan 8 83149 Östersund', '1956-09-25'),
(23, 'Kristian Morgan', '323-5948-96', 'Bondegatan 7 83142 Östersund', '1977-05-05'),
(24, 'Justin Grant', '002-1973-50', 'Prästgatan 26 83150 Östersund', '1959-02-28'),
(25, 'Alfred Murphy', '497-5859-46', 'Allegatan 14 83145 Östersund', '1943-06-28'),
(26, 'Amanda Mason', '855-9970-83', 'Allegatan 3 83146 Östersund', '1979-05-02'),
(27, 'Anna Hawkins', '444-0567-35', 'Rådhusgatan 29 83144 Östersund', '1953-07-09'),
(28, 'Michelle Hill', '293-5253-36', 'Prästgatan 18 83141 Östersund', '1980-05-18'),
(29, 'Joyce Ellis', '811-2063-61', 'Prästgatan 27 83141 Östersund', '1968-08-01'),
(30, 'Brianna Barnes', '557-3796-72', 'Allegatan 3 83141 Östersund', '1977-05-15'),
(31, 'Thomas Adams', '138-9136-61', 'Rådhusgatan 17 83140 Östersund', '1970-09-28'),
(32, 'David Adams', '459-2774-83', 'Storgatan 27 83142 Östersund', '1985-05-27'),
(33, 'Alfred Montgomery', '095-6714-56', 'Rådhusgatan 10 83145 Östersund', '1974-01-04'),
(34, 'Jordan West', '878-8663-37', 'Allegatan 12 83146 Östersund', '1983-11-13'),
(35, 'Frederick Gray', '137-4287-48', 'Bondegatan 9 83142 Östersund', '1985-09-15'),
(36, 'Annabella Hamilton', '396-9202-01', 'Rådhusgatan 5 83145 Östersund', '1958-12-29'),
(37, 'Kelsey Adams', '384-3285-49', 'Bondegatan 6 83142 Östersund', '1980-09-26'),
(38, 'Max Bailey', '074-2399-91', 'Prästgatan 19 83148 Östersund', '1983-05-13'),
(39, 'Lydia Perry', '436-7864-95', 'Rådhusgatan 16 83148 Östersund', '1977-12-05'),
(40, 'Arthur Mason', '286-2325-55', 'Bondegatan 14 83143 Östersund', '1952-12-29'),
(41, 'Blake Douglas', '492-8846-02', 'Bondegatan 12 83144 Östersund', '1975-06-25'),
(42, 'Justin Owens', '590-8321-73', 'Bondegatan 15 83148 Östersund', '1953-09-30'),
(43, 'Kirsten Edwards', '173-5917-30', 'Storgatan 19 83141 Östersund', '1980-09-29'),
(44, 'Dale Howard', '024-0330-33', 'Rådhusgatan 10 83145 Östersund', '1953-09-08'),
(45, 'Eleanor Thomas', '474-6211-45', 'Bondegatan 6 83142 Östersund', '1976-10-13'),
(46, 'Preston Holmes', '252-5579-09', 'Storgatan 3 83148 Östersund', '1942-09-21'),
(47, 'Evelyn Stevens', '194-6201-09', 'Rådhusgatan 28 83141 Östersund', '1977-02-11'),
(48, 'Gianna Morgan', '804-5697-53', 'Bondegatan 7 83148 Östersund', '1948-01-28'),
(49, 'Ellia Perry', '876-8484-64', 'Prästgatan 5 83140 Östersund', '1977-06-26'),
(50, 'Ryan Adams', '220-0279-72', 'Storgatan 13 83140 Östersund', '1948-06-29');

-- --------------------------------------------------------

--
-- Table structure for table `health_information`
--

CREATE TABLE `health_information` (
  `id` int(11) NOT NULL,
  `donor_id` int(11) NOT NULL,
  `blood_type` int(11) NOT NULL,
  `donor_height` int(11) NOT NULL COMMENT 'cm',
  `donor_weight` int(11) NOT NULL COMMENT 'kg',
  `is_drug_user` tinyint(4) NOT NULL,
  `visited_high_risk_country` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `medicin`
--

CREATE TABLE `medicin` (
  `id` int(11) NOT NULL,
  `health_info_id` int(11) NOT NULL,
  `medicine` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

CREATE TABLE `staff` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `login_name` varchar(32) NOT NULL,
  `hash_password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `blood_units`
--
ALTER TABLE `blood_units`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `donors`
--
ALTER TABLE `donors`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `health_information`
--
ALTER TABLE `health_information`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `medicin`
--
ALTER TABLE `medicin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `blood_units`
--
ALTER TABLE `blood_units`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bookings`
--
ALTER TABLE `bookings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `donors`
--
ALTER TABLE `donors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `health_information`
--
ALTER TABLE `health_information`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `medicin`
--
ALTER TABLE `medicin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `staff`
--
ALTER TABLE `staff`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
