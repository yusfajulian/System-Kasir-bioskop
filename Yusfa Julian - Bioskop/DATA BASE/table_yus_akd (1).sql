/*
SQLyog Professional v13.1.1 (64 bit)
MySQL - 10.4.11-MariaDB : Database - yus_akd
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`yus_akd` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `yus_akd`;

/*Table structure for table `yus_mstjurusan` */

DROP TABLE IF EXISTS `yus_mstjurusan`;

CREATE TABLE `yus_mstjurusan` (
  `yus_kodejurusan` char(2) NOT NULL,
  `yus_namajurusan` varchar(50) NOT NULL,
  PRIMARY KEY (`yus_kodejurusan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `yus_mstjurusan` */

insert  into `yus_mstjurusan`(`yus_kodejurusan`,`yus_namajurusan`) values 
('01','S1 Manajemen'),
('02','S1 Akuntansi'),
('03','S1 Teknik Informatika'),
('04','D3 Manajemen Informatika'),
('05','S1 Sastra Jepang'),
('06','D3 Bahasa Inggris'),
('07','S1 Psikologi'),
('08','S1 Teknik Industri');

/*Table structure for table `yus_mstmahasiswa` */

DROP TABLE IF EXISTS `yus_mstmahasiswa`;

CREATE TABLE `yus_mstmahasiswa` (
  `yus_nim` char(12) NOT NULL,
  `yus_nama` varchar(50) NOT NULL,
  `yus_kodejurusan` varchar(50) NOT NULL,
  PRIMARY KEY (`yus_nim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `yus_mstmahasiswa` */

insert  into `yus_mstmahasiswa`(`yus_nim`,`yus_nama`,`yus_kodejurusan`) values 
('020310001','Aled','01'),
('020310002','Alfiansyah Halomoan Siregar','01'),
('020310003','Purnama Cahya Rahayu','02'),
('020310004','Moch. Danar Ardiyusaga','02'),
('020310005','Suryana Wibowo','02'),
('020310006','Dian Kurnia Irawan','03'),
('020310007','Asep Ramdan Nurdiansyah','03'),
('020310008','Aji Kholis Sirojudin','04'),
('020310009','Randy Setyawan','04'),
('020310010','Irpan M','04'),
('020310011','Kiswari Adi Permadi','05'),
('020310012','Aliyah Nur Salamah','05'),
('020310013','Santi Santika Wahyuni','05'),
('020310014','Fitri Iswari','06'),
('020310015','Yogie Avilino','06'),
('020310016','Rohendi','06'),
('020310017','Ahmad Saefulloh','06'),
('020310018','M Rifky Nugraha Al','07'),
('020310019','Jaenal Mustofa','07'),
('020310020','Lianawaty','07'),
('020310021','Wenda Murdani','08'),
('020310022','Yusup Efendi','08'),
('020310023','Mumun Mansyur','01'),
('020310024','Jaya Nugraha','01'),
('020310025','Ahmad Royani','01');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
