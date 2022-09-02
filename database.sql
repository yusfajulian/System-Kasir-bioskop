/*
SQLyog Professional v13.1.1 (64 bit)
MySQL - 10.4.20-MariaDB : Database - db_bioskop
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_bioskop` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `db_bioskop`;

/*Data for the table `tb_film` */

insert  into `tb_film`(`Id_film`,`Judul`,`Id_jadwal`,`Genre`,`Nama_studio`,`Id_tiket`,`Harga`,`Durasi`,`Tgl_mulai`,`Tgl_berakhir`) values 
('f001','Cars 1','j001','Animasi','A','t001','35000','120','12/3/2021','12/8/2021');

/*Data for the table `tb_jadwal` */

insert  into `tb_jadwal`(`id_jadwal`,`jam_mulai`,`status`) values 
('j001','10:00,12:00,14:00,16:00,18:00','true'),
('j002','10:00,12:30,15:00,17:30,20:00','false'),
('j003','10:00,13:00,16:00,19:00','false');

/*Data for the table `tb_kategori` */

insert  into `tb_kategori`(`Nama_Kategori`) values 
('Action'),
('Animasi'),
('Documenter'),
('Drama'),
('Fantasi'),
('Horror'),
('Komedi'),
('Misteri'),
('Musikal'),
('Petualangan'),
('Romantis'),
('Thriller');

/*Data for the table `tb_kursi` */

insert  into `tb_kursi`(`no_kursi`,`nama_studio`,`status`) values 
('A1','A','DIPESAN'),
('A10','A','BELUM DIPESAN'),
('A11','A','BELUM DIPESAN'),
('A12','A','BELUM DIPESAN'),
('A13','A','BELUM DIPESAN'),
('A14','A','BELUM DIPESAN'),
('A15','A','BELUM DIPESAN'),
('A16','A','BELUM DIPESAN'),
('A17','A','BELUM DIPESAN'),
('A18','A','BELUM DIPESAN'),
('A19','A','BELUM DIPESAN'),
('A2','A','DIPESAN'),
('A20','A','BELUM DIPESAN'),
('A21','A','BELUM DIPESAN'),
('A22','A','BELUM DIPESAN'),
('A23','A','BELUM DIPESAN'),
('A24','A','BELUM DIPESAN'),
('A25','A','BELUM DIPESAN'),
('A26','A','BELUM DIPESAN'),
('A27','A','BELUM DIPESAN'),
('A28','A','BELUM DIPESAN'),
('A29','A','BELUM DIPESAN'),
('A3','A','BELUM DIPESAN'),
('A30','A','BELUM DIPESAN'),
('A31','A','BELUM DIPESAN'),
('A32','A','BELUM DIPESAN'),
('A33','A','BELUM DIPESAN'),
('A34','A','BELUM DIPESAN'),
('A35','A','BELUM DIPESAN'),
('A36','A','BELUM DIPESAN'),
('A37','A','BELUM DIPESAN'),
('A38','A','BELUM DIPESAN'),
('A39','A','BELUM DIPESAN'),
('A4','A','DIPESAN'),
('A40','A','BELUM DIPESAN'),
('A41','A','BELUM DIPESAN'),
('A42','A','BELUM DIPESAN'),
('A43','A','BELUM DIPESAN'),
('A44','A','BELUM DIPESAN'),
('A45','A','BELUM DIPESAN'),
('A46','A','BELUM DIPESAN'),
('A47','A','DIPESAN'),
('A48','A','BELUM DIPESAN'),
('A49','A','BELUM DIPESAN'),
('A5','A','BELUM DIPESAN'),
('A50','A','BELUM DIPESAN'),
('A6','A','BELUM DIPESAN'),
('A7','A','BELUM DIPESAN'),
('A8','A','BELUM DIPESAN'),
('A9','A','BELUM DIPESAN'),
('B1','B','BELUM DIPESAN'),
('B10','B','DIPESAN'),
('B11','B','BELUM DIPESAN'),
('B12','B','BELUM DIPESAN'),
('B13','B','BELUM DIPESAN'),
('B14','B','BELUM DIPESAN'),
('B15','B','BELUM DIPESAN'),
('B16','B','BELUM DIPESAN'),
('B17','B','BELUM DIPESAN'),
('B18','B','BELUM DIPESAN'),
('B19','B','BELUM DIPESAN'),
('B2','B','BELUM DIPESAN'),
('B20','B','BELUM DIPESAN'),
('B21','B','BELUM DIPESAN'),
('B22','B','BELUM DIPESAN'),
('B23','B','BELUM DIPESAN'),
('B24','B','BELUM DIPESAN'),
('B25','B','BELUM DIPESAN'),
('B26','B','BELUM DIPESAN'),
('B27','B','BELUM DIPESAN'),
('B28','B','BELUM DIPESAN'),
('B29','B','BELUM DIPESAN'),
('B3','B','BELUM DIPESAN'),
('B30','B','BELUM DIPESAN'),
('B31','B','BELUM DIPESAN'),
('B32','B','BELUM DIPESAN'),
('B33','B','BELUM DIPESAN'),
('B34','B','BELUM DIPESAN'),
('B35','B','BELUM DIPESAN'),
('B36','B','BELUM DIPESAN'),
('B37','B','BELUM DIPESAN'),
('B38','B','BELUM DIPESAN'),
('B39','B','BELUM DIPESAN'),
('B4','B','BELUM DIPESAN'),
('B40','B','BELUM DIPESAN'),
('B41','B','BELUM DIPESAN'),
('B42','B','BELUM DIPESAN'),
('B43','B','BELUM DIPESAN'),
('B44','B','BELUM DIPESAN'),
('B45','B','BELUM DIPESAN'),
('B46','B','BELUM DIPESAN'),
('B47','B','BELUM DIPESAN'),
('B48','B','BELUM DIPESAN'),
('B49','B','BELUM DIPESAN'),
('B5','B','BELUM DIPESAN'),
('B50','B','BELUM DIPESAN'),
('B6','B','BELUM DIPESAN'),
('B7','B','BELUM DIPESAN'),
('B8','B','BELUM DIPESAN'),
('B9','B','BELUM DIPESAN'),
('C1','C','BELUM DIPESAN'),
('C10','C','BELUM DIPESAN'),
('C11','C','BELUM DIPESAN'),
('C12','C','BELUM DIPESAN'),
('C13','C','BELUM DIPESAN'),
('C14','C','BELUM DIPESAN'),
('C15','C','BELUM DIPESAN'),
('C16','C','BELUM DIPESAN'),
('C17','C','BELUM DIPESAN'),
('C18','C','BELUM DIPESAN'),
('C19','C','BELUM DIPESAN'),
('C2','C','BELUM DIPESAN'),
('C20','C','BELUM DIPESAN'),
('C21','C','BELUM DIPESAN'),
('C22','C','BELUM DIPESAN'),
('C23','C','BELUM DIPESAN'),
('C24','C','BELUM DIPESAN'),
('C25','C','BELUM DIPESAN'),
('C26','C','BELUM DIPESAN'),
('C27','C','BELUM DIPESAN'),
('C28','C','BELUM DIPESAN'),
('C29','C','BELUM DIPESAN'),
('C3','C','BELUM DIPESAN'),
('C30','C','BELUM DIPESAN'),
('C31','C','BELUM DIPESAN'),
('C32','C','BELUM DIPESAN'),
('C33','C','BELUM DIPESAN'),
('C34','C','BELUM DIPESAN'),
('C35','C','BELUM DIPESAN'),
('C36','C','BELUM DIPESAN'),
('C37','C','BELUM DIPESAN'),
('C38','C','BELUM DIPESAN'),
('C39','C','BELUM DIPESAN'),
('C4','C','BELUM DIPESAN'),
('C40','C','BELUM DIPESAN'),
('C41','C','BELUM DIPESAN'),
('C42','C','BELUM DIPESAN'),
('C43','C','BELUM DIPESAN'),
('C44','C','BELUM DIPESAN'),
('C45','C','BELUM DIPESAN'),
('C46','C','BELUM DIPESAN'),
('C47','C','BELUM DIPESAN'),
('C48','C','BELUM DIPESAN'),
('C49','C','BELUM DIPESAN'),
('C5','C','BELUM DIPESAN'),
('C50','C','BELUM DIPESAN'),
('C6','C','BELUM DIPESAN'),
('C7','C','BELUM DIPESAN'),
('C8','C','BELUM DIPESAN'),
('C9','C','BELUM DIPESAN');

/*Data for the table `tb_laporan` */

insert  into `tb_laporan`(`no_pesan`,`judul`,`pesan`) values 
(5,'Studio','Studio yang berjalan baru studio A saja ');

/*Data for the table `tb_studio` */

insert  into `tb_studio`(`nama_studio`,`sisa_kursi`) values 
('A',41),
('B',48),
('C',50);

/*Data for the table `tb_tiket` */

insert  into `tb_tiket`(`id_tiket`,`stok`) values 
('t001',40),
('t002',48),
('t003',50);

/*Data for the table `tb_transaksi` */

insert  into `tb_transaksi`(`id_transaksi`,`id_film`,`nama_studio`,`no_kursi`,`id_tiket`,`harga`,`tanggal_transaksi`,`status`,`metode_pembayaran`) values 
(39,'f001','A','A1','t001',35000,'12/5/2021','Lunas','Cash'),
(40,'f001','A','A2','t001',35000,'12/5/2021','Belum Lunas','');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
