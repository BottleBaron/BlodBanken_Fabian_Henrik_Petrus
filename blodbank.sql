-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 07 nov 2022 kl 14:28
-- Serverversion: 10.4.25-MariaDB
-- PHP-version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `blodbank`
--

-- --------------------------------------------------------

--
-- Tabellstruktur `blood_units`
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
-- Tabellstruktur `bookings`
--

CREATE TABLE `bookings` (
  `id` int(11) NOT NULL,
  `donor_id` int(11) NOT NULL,
  `staff_id` int(11) NOT NULL,
  `appointment_date` datetime NOT NULL,
  `is_done` tinyint(4) NOT NULL,
  `donated_amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellstruktur `donors`
--

CREATE TABLE `donors` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `address` varchar(32) NOT NULL,
  `phone_number` varchar(32) NOT NULL,
  `date_of_birth` date NOT NULL,
  `blood_type` smallint(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellstruktur `health_information`
--

CREATE TABLE `health_information` (
  `id` int(11) NOT NULL,
  `donor_id` int(11) NOT NULL,
  `donor_height` int(11) NOT NULL COMMENT 'cm',
  `donor_weight` int(11) NOT NULL COMMENT 'kg',
  `is_drug_user` tinyint(4) NOT NULL,
  `visited_high_risk_country` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellstruktur `medicin`
--

CREATE TABLE `medicin` (
  `id` int(11) NOT NULL,
  `health_info_id` int(11) NOT NULL,
  `medicine` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellstruktur `staff`
--

CREATE TABLE `staff` (
  `id` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `login_name` varchar(32) NOT NULL,
  `hash_password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Index för dumpade tabeller
--

--
-- Index för tabell `blood_units`
--
ALTER TABLE `blood_units`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `fk_bloodunits_donor_id` (`donor_id`),
  ADD KEY `fk_bloodunits_booking_id` (`booking_id`);

--
-- Index för tabell `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `fk_bookings_donor_id` (`donor_id`),
  ADD KEY `fk_bookings_staff_id` (`staff_id`);

--
-- Index för tabell `donors`
--
ALTER TABLE `donors`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Index för tabell `health_information`
--
ALTER TABLE `health_information`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `fk_health_information_donor_id` (`donor_id`);

--
-- Index för tabell `medicin`
--
ALTER TABLE `medicin`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`),
  ADD KEY `fk_medicin_health_information_id` (`health_info_id`);

--
-- Index för tabell `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT för dumpade tabeller
--

--
-- AUTO_INCREMENT för tabell `blood_units`
--
ALTER TABLE `blood_units`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT för tabell `bookings`
--
ALTER TABLE `bookings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT för tabell `donors`
--
ALTER TABLE `donors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT för tabell `health_information`
--
ALTER TABLE `health_information`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT för tabell `medicin`
--
ALTER TABLE `medicin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT för tabell `staff`
--
ALTER TABLE `staff`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restriktioner för dumpade tabeller
--

--
-- Restriktioner för tabell `blood_units`
--
ALTER TABLE `blood_units`
  ADD CONSTRAINT `fk_bloodunits_booking_id` FOREIGN KEY (`booking_id`) REFERENCES `bookings` (`id`),
  ADD CONSTRAINT `fk_bloodunits_donor_id` FOREIGN KEY (`donor_id`) REFERENCES `donors` (`id`);

--
-- Restriktioner för tabell `bookings`
--
ALTER TABLE `bookings`
  ADD CONSTRAINT `fk_bookings_donor_id` FOREIGN KEY (`donor_id`) REFERENCES `donors` (`id`),
  ADD CONSTRAINT `fk_bookings_staff_id` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`id`);

--
-- Restriktioner för tabell `health_information`
--
ALTER TABLE `health_information`
  ADD CONSTRAINT `fk_health_information_donor_id` FOREIGN KEY (`donor_id`) REFERENCES `donors` (`id`);

--
-- Restriktioner för tabell `medicin`
--
ALTER TABLE `medicin`
  ADD CONSTRAINT `fk_medicin_health_information_id` FOREIGN KEY (`health_info_id`) REFERENCES `health_information` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
