-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 01, 2016 at 10:45 PM
-- Server version: 10.1.13-MariaDB
-- PHP Version: 5.6.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `evo`
--

-- --------------------------------------------------------

--
-- Table structure for table `devices`
--

CREATE TABLE `devices` (
  `id` int(11) NOT NULL,
  `Name` varchar(11) NOT NULL,
  `Type` varchar(11) NOT NULL,
  `Options` tinytext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `devices`
--

INSERT INTO `devices` (`id`, `Name`, `Type`, `Options`) VALUES
(114, '1', '1', 'True,True,False,True,True,True,False,False,False,True,True,True,False,False,False,0,True,True,True,False,True,True,True,True,True,True,True,False,True');

-- --------------------------------------------------------

--
-- Table structure for table `deviceslog`
--

CREATE TABLE `deviceslog` (
  `id` int(11) NOT NULL,
  `DeviceId` int(11) NOT NULL,
  `StartDate` timestamp NULL DEFAULT NULL,
  `EndDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `InActive` varchar(40) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'true',
  `Bill` double NOT NULL,
  `PlayBill` double NOT NULL DEFAULT '0',
  `TimeLimit` int(11) NOT NULL DEFAULT '0',
  `PlayStation` varchar(11) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'true',
  `SpeciesOrderCheck` varchar(1000) COLLATE utf8_unicode_ci NOT NULL,
  `User` varchar(100) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Admin',
  `DeviceLogChanges` varchar(10000) COLLATE utf8_unicode_ci DEFAULT '(0)',
  `DeviceType` varchar(40) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'none',
  `Time_MinutePrice` varchar(40) COLLATE utf8_unicode_ci NOT NULL DEFAULT '0,0',
  `offers` varchar(100) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'none',
  `ControllersCount` int(10) NOT NULL DEFAULT '0',
  `AdditionalBill` varchar(100) COLLATE utf8_unicode_ci NOT NULL DEFAULT '0,0',
  `TotalBill` double NOT NULL DEFAULT '0',
  `PaidBill` double NOT NULL DEFAULT '0',
  `SheduleID` varchar(50) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'none',
  `Deleted` tinyint(1) NOT NULL DEFAULT '0',
  `DeletedBy` varchar(100) COLLATE utf8_unicode_ci DEFAULT 'none'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `deviceslog`
--

INSERT INTO `deviceslog` (`id`, `DeviceId`, `StartDate`, `EndDate`, `InActive`, `Bill`, `PlayBill`, `TimeLimit`, `PlayStation`, `SpeciesOrderCheck`, `User`, `DeviceLogChanges`, `DeviceType`, `Time_MinutePrice`, `offers`, `ControllersCount`, `AdditionalBill`, `TotalBill`, `PaidBill`, `SheduleID`, `Deleted`, `DeletedBy`) VALUES
(1344, 114, '2016-11-01 21:43:09', '2016-11-01 21:43:09', 'true', 42, 0.166666666666667, 0, 'True', '0', 'admin', '(0)', 'none', '0,0', 'none', 2, '0,0', 0, 0, 'none', 0, 'none');

-- --------------------------------------------------------

--
-- Table structure for table `deviceslogdata`
--

CREATE TABLE `deviceslogdata` (
  `id` int(11) NOT NULL,
  `LogId` int(100) NOT NULL,
  `SpeciesId` int(11) NOT NULL,
  `OrgPrice` double NOT NULL,
  `Active` varchar(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'false',
  `Removed` varchar(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'false',
  `Date` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `deviceslogdata`
--

INSERT INTO `deviceslogdata` (`id`, `LogId`, `SpeciesId`, `OrgPrice`, `Active`, `Removed`, `Date`) VALUES
(1461, 1344, 162, 6, 'true', 'false', '2016-11-01 23:44:06'),
(1462, 1344, 162, 6, 'true', 'false', '2016-11-01 23:44:09'),
(1463, 1344, 162, 6, 'true', 'false', '2016-11-01 23:44:09'),
(1464, 1344, 162, 6, 'true', 'false', '2016-11-01 23:44:10'),
(1465, 1344, 162, 6, 'true', 'false', '2016-11-01 23:44:11'),
(1466, 1344, 162, 6, 'true', 'false', '2016-11-01 23:44:11'),
(1467, 1344, 162, 6, 'true', 'false', '2016-11-01 23:44:12');

-- --------------------------------------------------------

--
-- Table structure for table `devicetype`
--

CREATE TABLE `devicetype` (
  `id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `devicetype`
--

INSERT INTO `devicetype` (`id`, `Name`) VALUES
(1, 'playstation3'),
(14, 'playstation4'),
(0, '[TABLE]');

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `ID` int(11) NOT NULL,
  `DATA` text NOT NULL,
  `Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`ID`, `DATA`, `Date`) VALUES
(1, 'System.Data   01/11/2016 11:43:43 ?   at System.Data.RBTree`1.GetNodeByIndex(Int32 userIndex)\r\n   at System.Data.DataRowCollection.get_Item(Int32 index)\r\n   at EVO.species..ctor(Int32 SpecieId) in C:ElkonsolProjects[Other] ProjectsEVOEVOSystemSpeciesspecies.vb:line 12\r\n   at EVO.Device.addSpecies(Int32 spid) in C:ElkonsolProjects[Other] ProjectsEVOEVOSystemDeviceDevice.vb:line 811\r\nThere is no row at position 0.\r\n', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `schedule`
--

CREATE TABLE `schedule` (
  `id` int(11) NOT NULL,
  `Type` varchar(100) NOT NULL,
  `ObjectID` varchar(100) NOT NULL,
  `StartDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `EndDate` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `WarnBefore` varchar(1000) DEFAULT '0',
  `Client` varchar(100) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `User` varchar(100) NOT NULL,
  `Objectname` varchar(100) NOT NULL,
  `Paid` varchar(100) NOT NULL,
  `SpectialGetById` varchar(1000) NOT NULL,
  `phone` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `species`
--

CREATE TABLE `species` (
  `id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `Price` double NOT NULL,
  `Type` int(100) NOT NULL,
  `IsAvailabel` varchar(10) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'true'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `species`
--

INSERT INTO `species` (`id`, `Name`, `Price`, `Type`, `IsAvailabel`) VALUES
(128, 'شاي', 4, 1, 'true'),
(129, 'قهوه', 6, 1, 'true'),
(130, 'ينسون', 5, 1, 'true'),
(131, 'كركديه', 5, 1, 'true'),
(132, 'شاي اخضر', 5, 1, 'true'),
(133, 'نعناع', 5, 1, 'true'),
(134, 'شاي نعناع', 5, 1, 'true'),
(135, 'بيبسي', 5, 1, 'true'),
(136, 'بوريو', 12, 1, 'true'),
(137, 'adel', 4.99, 2, 'True'),
(139, '8099', 8, 17, '1'),
(143, '9', 0, 13, '1'),
(150, '980', 6.45, 2, 'True'),
(151, '989aa', 17, 2, '1'),
(152, 'opk', 4, 2, '1'),
(155, 'jskk', 2, 13, '1'),
(156, 'مشروب', 6, 2, '1'),
(157, 'جدييييييد', 14, 18, '1'),
(158, '768769', 9, 18, '1'),
(159, 'newSpecies', 7, 19, '1'),
(160, 'بيبسي', 6, 20, '1'),
(161, 'km', 26, 2, '1'),
(162, 'بيبسي', 6, 21, '1');

-- --------------------------------------------------------

--
-- Table structure for table `time`
--

CREATE TABLE `time` (
  `id` int(11) NOT NULL,
  `Minutes` int(11) NOT NULL,
  `Devicetype` int(11) NOT NULL,
  `Price` double NOT NULL,
  `TimeRolles` varchar(100) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `time`
--

INSERT INTO `time` (`id`, `Minutes`, `Devicetype`, `Price`, `TimeRolles`) VALUES
(1, 60, 1, 10, '1,2,3'),
(3, 60, 12, 20, '0'),
(5, 60, 14, 15, '0');

-- --------------------------------------------------------

--
-- Table structure for table `timeroles`
--

CREATE TABLE `timeroles` (
  `id` int(11) NOT NULL,
  `Name` varchar(10) NOT NULL,
  `MinutesStart` int(50) NOT NULL,
  `MinutesEnd` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `timeroles`
--

INSERT INTO `timeroles` (`id`, `Name`, `MinutesStart`, `MinutesEnd`) VALUES
(1, '15', 0, 15),
(2, '15', 15, 30),
(3, '15', 30, 45),
(4, '15', 45, 60);

-- --------------------------------------------------------

--
-- Table structure for table `types`
--

CREATE TABLE `types` (
  `id` int(11) NOT NULL,
  `Name` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `types`
--

INSERT INTO `types` (`id`, `Name`) VALUES
(21, 'مشروبات');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `USER` varchar(50) NOT NULL,
  `PASS` varchar(50) NOT NULL,
  `DATA` longtext,
  `Active` varchar(100) DEFAULT 'false',
  `LastLogin` varchar(100) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `USER`, `PASS`, `DATA`, `Active`, `LastLogin`) VALUES
(21, 'admin', 'admin', 'AAEAAAD/////AQAAAAAAAAAMAgAAADpFVk8sIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsDAMAAABRU3lzdGVtLkRyYXdpbmcsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iMDNmNWY3ZjExZDUwYTNhBQEAAAAIRVZPLlVTRVIdAAAACFVzZXJOYW1lCFBhc3N3b3JkEkRldmljZUNvbnRyb2xQYW5lbA9EZXZpY2VUeXBlUGFuZWwQRGV2aWNlTG9nSGlzdG9yeQdzY2hkdWxlDlBsYXlTdGF0aW9uVGFiFlNwZWNpZXNDb250cm9sbGVyUGFuZWwQQ2FuRWRpdFRvdGFsQmlsbBRDYW5BZGRBZGRpdGlvbmFsQ2FzaBRDYW5TdGFydENsb3NlU2Vzc2lvbg9DYW5DcmVhdGVEZXZpY2UPQ2FuRGVsZXRlRGV2aWNlD0NhblVwZGF0ZURldmljZRJDYW5EZWxldGVEZXZpY2VMb2cRQ2FuU3RhcnREZXZpY2VMb2cKQ2FuQWRkVGltZQ1DYW5SZW1vdmVUaW1lDUNhbkFkZFNwZWNpZXMQQ2FuUmVtb3ZlU3BlY2llcxJDYW5VcGRhdGVTdGFydFRpbWUQQ2FuQ2hhbmdlZERldmljZQxDYW5TZXRPZmZlcnMRQ2FuQ3JlYXRlU2NoZWR1bGURQ2FuRGVsZXRlU2NoZWR1bGUFQWRtaW4GTm9ybWFsBVRoZW1lClRoZW1lQ29sb3IBAQICAgICAgICAgICAgICAgICAgICAgICAgICAgIAAAAGBAAAAAVhZG1pbgkEAAAACAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEBCAEACAgIAAAACQUAAAAFBQAAABRTeXN0ZW0uRHJhd2luZy5Db2xvcgQAAAAEbmFtZQV2YWx1ZQprbm93bkNvbG9yBXN0YXRlAQAAAAkHBwMAAAAKYUAk/wAAAAAAAAIACw==', 'false', '0'),
(22, 'abdo11', 'abdo', 'AAEAAAD/////AQAAAAAAAAAMAgAAADpFVk8sIFZlcnNpb249MS4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1udWxsBQEAAAAIRVZPLlVTRVIdAAAACFVzZXJOYW1lCFBhc3N3b3JkEkRldmljZUNvbnRyb2xQYW5lbA9EZXZpY2VUeXBlUGFuZWwQRGV2aWNlTG9nSGlzdG9yeQdzY2hkdWxlDlBsYXlTdGF0aW9uVGFiFlNwZWNpZXNDb250cm9sbGVyUGFuZWwQQ2FuRWRpdFRvdGFsQmlsbBRDYW5BZGRBZGRpdGlvbmFsQ2FzaBRDYW5TdGFydENsb3NlU2Vzc2lvbg9DYW5DcmVhdGVEZXZpY2UPQ2FuRGVsZXRlRGV2aWNlD0NhblVwZGF0ZURldmljZRJDYW5EZWxldGVEZXZpY2VMb2cRQ2FuU3RhcnREZXZpY2VMb2cKQ2FuQWRkVGltZQ1DYW5SZW1vdmVUaW1lDUNhbkFkZFNwZWNpZXMQQ2FuUmVtb3ZlU3BlY2llcxJDYW5VcGRhdGVTdGFydFRpbWUQQ2FuQ2hhbmdlZERldmljZQxDYW5TZXRPZmZlcnMRQ2FuQ3JlYXRlU2NoZWR1bGURQ2FuRGVsZXRlU2NoZWR1bGUFQWRtaW4GTm9ybWFsBVRoZW1lClRoZW1lQ29sb3IBAQICAgICAgICAgICAgICAgICAgICAgICAgICAgIAAAAGAwAAAAZhYmRvMTEGBAAAAARhYmRvCAEBCAEACAEACAEBCAEBCAEACAEACAEBCAEACAEACAEACAEACAEACAEACAEBCAEBCAEBCAEBCAEACAEBCAEBCAEBCAEBCAEBCAEBCgoL', 'false', '0');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `devices`
--
ALTER TABLE `devices`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Indexes for table `deviceslog`
--
ALTER TABLE `deviceslog`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `deviceslogdata`
--
ALTER TABLE `deviceslogdata`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `devicetype`
--
ALTER TABLE `devicetype`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `schedule`
--
ALTER TABLE `schedule`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `species`
--
ALTER TABLE `species`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `time`
--
ALTER TABLE `time`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `timeroles`
--
ALTER TABLE `timeroles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `types`
--
ALTER TABLE `types`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `USER` (`USER`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `devices`
--
ALTER TABLE `devices`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=115;
--
-- AUTO_INCREMENT for table `deviceslog`
--
ALTER TABLE `deviceslog`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1345;
--
-- AUTO_INCREMENT for table `deviceslogdata`
--
ALTER TABLE `deviceslogdata`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1468;
--
-- AUTO_INCREMENT for table `devicetype`
--
ALTER TABLE `devicetype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `schedule`
--
ALTER TABLE `schedule`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=129;
--
-- AUTO_INCREMENT for table `species`
--
ALTER TABLE `species`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=163;
--
-- AUTO_INCREMENT for table `time`
--
ALTER TABLE `time`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `timeroles`
--
ALTER TABLE `timeroles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `types`
--
ALTER TABLE `types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
