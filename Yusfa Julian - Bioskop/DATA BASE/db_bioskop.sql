-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 05 Des 2021 pada 13.55
-- Versi server: 10.4.20-MariaDB
-- Versi PHP: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_bioskop`
--

DELIMITER $$
--
-- Prosedur
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `tampil_harga` (`id` CHAR(5))  BEGIN
		SELECT harga FROM tb_film where id_film = id;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_film`
--

CREATE TABLE `tb_film` (
  `Id_film` char(5) NOT NULL,
  `Judul` varchar(35) NOT NULL,
  `Id_jadwal` char(5) NOT NULL,
  `Genre` varchar(20) NOT NULL,
  `Nama_studio` varchar(4) NOT NULL,
  `Id_tiket` char(5) NOT NULL,
  `Harga` varchar(50) NOT NULL,
  `Durasi` varchar(15) NOT NULL,
  `Tgl_mulai` varchar(50) NOT NULL,
  `Tgl_berakhir` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_film`
--

INSERT INTO `tb_film` (`Id_film`, `Judul`, `Id_jadwal`, `Genre`, `Nama_studio`, `Id_tiket`, `Harga`, `Durasi`, `Tgl_mulai`, `Tgl_berakhir`) VALUES
('f001', 'Cars 1', 'j001', 'Animasi', 'A', 't001', '35000', '120', '12/3/2021', '12/8/2021');

--
-- Trigger `tb_film`
--
DELIMITER $$
CREATE TRIGGER `hapus_film` AFTER DELETE ON `tb_film` FOR EACH ROW BEGIN
	UPDATE `db_bioskop`.`tb_jadwal` 
	SET `db_bioskop`.`tb_jadwal`.`status` = 'false' WHERE `db_bioskop`.`tb_jadwal`.`id_jadwal`=old.id_jadwal;
    END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `status_jadwal` AFTER INSERT ON `tb_film` FOR EACH ROW BEGIN
	UPDATE tb_jadwal SET status = 'true' WHERE id_jadwal=new.id_jadwal;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_jadwal`
--

CREATE TABLE `tb_jadwal` (
  `id_jadwal` char(5) NOT NULL,
  `jam_mulai` varchar(50) NOT NULL,
  `status` char(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_jadwal`
--

INSERT INTO `tb_jadwal` (`id_jadwal`, `jam_mulai`, `status`) VALUES
('j001', '10:00,12:00,14:00,16:00,18:00', 'true'),
('j002', '10:00,12:30,15:00,17:30,20:00', 'false'),
('j003', '10:00,13:00,16:00,19:00', 'false');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_kategori`
--

CREATE TABLE `tb_kategori` (
  `Nama_Kategori` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_kategori`
--

INSERT INTO `tb_kategori` (`Nama_Kategori`) VALUES
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

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_kursi`
--

CREATE TABLE `tb_kursi` (
  `no_kursi` varchar(4) NOT NULL,
  `nama_studio` varchar(4) NOT NULL,
  `status` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_kursi`
--

INSERT INTO `tb_kursi` (`no_kursi`, `nama_studio`, `status`) VALUES
('A1', 'A', 'DIPESAN'),
('A10', 'A', 'BELUM DIPESAN'),
('A11', 'A', 'BELUM DIPESAN'),
('A12', 'A', 'BELUM DIPESAN'),
('A13', 'A', 'BELUM DIPESAN'),
('A14', 'A', 'BELUM DIPESAN'),
('A15', 'A', 'BELUM DIPESAN'),
('A16', 'A', 'BELUM DIPESAN'),
('A17', 'A', 'BELUM DIPESAN'),
('A18', 'A', 'BELUM DIPESAN'),
('A19', 'A', 'BELUM DIPESAN'),
('A2', 'A', 'DIPESAN'),
('A20', 'A', 'BELUM DIPESAN'),
('A21', 'A', 'BELUM DIPESAN'),
('A22', 'A', 'BELUM DIPESAN'),
('A23', 'A', 'BELUM DIPESAN'),
('A24', 'A', 'BELUM DIPESAN'),
('A25', 'A', 'BELUM DIPESAN'),
('A26', 'A', 'BELUM DIPESAN'),
('A27', 'A', 'BELUM DIPESAN'),
('A28', 'A', 'BELUM DIPESAN'),
('A29', 'A', 'BELUM DIPESAN'),
('A3', 'A', 'BELUM DIPESAN'),
('A30', 'A', 'BELUM DIPESAN'),
('A31', 'A', 'BELUM DIPESAN'),
('A32', 'A', 'BELUM DIPESAN'),
('A33', 'A', 'BELUM DIPESAN'),
('A34', 'A', 'BELUM DIPESAN'),
('A35', 'A', 'BELUM DIPESAN'),
('A36', 'A', 'BELUM DIPESAN'),
('A37', 'A', 'BELUM DIPESAN'),
('A38', 'A', 'BELUM DIPESAN'),
('A39', 'A', 'BELUM DIPESAN'),
('A4', 'A', 'DIPESAN'),
('A40', 'A', 'BELUM DIPESAN'),
('A41', 'A', 'BELUM DIPESAN'),
('A42', 'A', 'BELUM DIPESAN'),
('A43', 'A', 'BELUM DIPESAN'),
('A44', 'A', 'BELUM DIPESAN'),
('A45', 'A', 'BELUM DIPESAN'),
('A46', 'A', 'BELUM DIPESAN'),
('A47', 'A', 'DIPESAN'),
('A48', 'A', 'BELUM DIPESAN'),
('A49', 'A', 'BELUM DIPESAN'),
('A5', 'A', 'BELUM DIPESAN'),
('A50', 'A', 'BELUM DIPESAN'),
('A6', 'A', 'BELUM DIPESAN'),
('A7', 'A', 'BELUM DIPESAN'),
('A8', 'A', 'BELUM DIPESAN'),
('A9', 'A', 'BELUM DIPESAN'),
('B1', 'B', 'BELUM DIPESAN'),
('B10', 'B', 'DIPESAN'),
('B11', 'B', 'BELUM DIPESAN'),
('B12', 'B', 'BELUM DIPESAN'),
('B13', 'B', 'BELUM DIPESAN'),
('B14', 'B', 'BELUM DIPESAN'),
('B15', 'B', 'BELUM DIPESAN'),
('B16', 'B', 'BELUM DIPESAN'),
('B17', 'B', 'BELUM DIPESAN'),
('B18', 'B', 'BELUM DIPESAN'),
('B19', 'B', 'BELUM DIPESAN'),
('B2', 'B', 'BELUM DIPESAN'),
('B20', 'B', 'BELUM DIPESAN'),
('B21', 'B', 'BELUM DIPESAN'),
('B22', 'B', 'BELUM DIPESAN'),
('B23', 'B', 'BELUM DIPESAN'),
('B24', 'B', 'BELUM DIPESAN'),
('B25', 'B', 'BELUM DIPESAN'),
('B26', 'B', 'BELUM DIPESAN'),
('B27', 'B', 'BELUM DIPESAN'),
('B28', 'B', 'BELUM DIPESAN'),
('B29', 'B', 'BELUM DIPESAN'),
('B3', 'B', 'BELUM DIPESAN'),
('B30', 'B', 'BELUM DIPESAN'),
('B31', 'B', 'BELUM DIPESAN'),
('B32', 'B', 'BELUM DIPESAN'),
('B33', 'B', 'BELUM DIPESAN'),
('B34', 'B', 'BELUM DIPESAN'),
('B35', 'B', 'BELUM DIPESAN'),
('B36', 'B', 'BELUM DIPESAN'),
('B37', 'B', 'BELUM DIPESAN'),
('B38', 'B', 'BELUM DIPESAN'),
('B39', 'B', 'BELUM DIPESAN'),
('B4', 'B', 'BELUM DIPESAN'),
('B40', 'B', 'BELUM DIPESAN'),
('B41', 'B', 'BELUM DIPESAN'),
('B42', 'B', 'BELUM DIPESAN'),
('B43', 'B', 'BELUM DIPESAN'),
('B44', 'B', 'BELUM DIPESAN'),
('B45', 'B', 'BELUM DIPESAN'),
('B46', 'B', 'BELUM DIPESAN'),
('B47', 'B', 'BELUM DIPESAN'),
('B48', 'B', 'BELUM DIPESAN'),
('B49', 'B', 'BELUM DIPESAN'),
('B5', 'B', 'BELUM DIPESAN'),
('B50', 'B', 'BELUM DIPESAN'),
('B6', 'B', 'BELUM DIPESAN'),
('B7', 'B', 'BELUM DIPESAN'),
('B8', 'B', 'BELUM DIPESAN'),
('B9', 'B', 'BELUM DIPESAN'),
('C1', 'C', 'BELUM DIPESAN'),
('C10', 'C', 'BELUM DIPESAN'),
('C11', 'C', 'BELUM DIPESAN'),
('C12', 'C', 'BELUM DIPESAN'),
('C13', 'C', 'BELUM DIPESAN'),
('C14', 'C', 'BELUM DIPESAN'),
('C15', 'C', 'BELUM DIPESAN'),
('C16', 'C', 'BELUM DIPESAN'),
('C17', 'C', 'BELUM DIPESAN'),
('C18', 'C', 'BELUM DIPESAN'),
('C19', 'C', 'BELUM DIPESAN'),
('C2', 'C', 'BELUM DIPESAN'),
('C20', 'C', 'BELUM DIPESAN'),
('C21', 'C', 'BELUM DIPESAN'),
('C22', 'C', 'BELUM DIPESAN'),
('C23', 'C', 'BELUM DIPESAN'),
('C24', 'C', 'BELUM DIPESAN'),
('C25', 'C', 'BELUM DIPESAN'),
('C26', 'C', 'BELUM DIPESAN'),
('C27', 'C', 'BELUM DIPESAN'),
('C28', 'C', 'BELUM DIPESAN'),
('C29', 'C', 'BELUM DIPESAN'),
('C3', 'C', 'BELUM DIPESAN'),
('C30', 'C', 'BELUM DIPESAN'),
('C31', 'C', 'BELUM DIPESAN'),
('C32', 'C', 'BELUM DIPESAN'),
('C33', 'C', 'BELUM DIPESAN'),
('C34', 'C', 'BELUM DIPESAN'),
('C35', 'C', 'BELUM DIPESAN'),
('C36', 'C', 'BELUM DIPESAN'),
('C37', 'C', 'BELUM DIPESAN'),
('C38', 'C', 'BELUM DIPESAN'),
('C39', 'C', 'BELUM DIPESAN'),
('C4', 'C', 'BELUM DIPESAN'),
('C40', 'C', 'BELUM DIPESAN'),
('C41', 'C', 'BELUM DIPESAN'),
('C42', 'C', 'BELUM DIPESAN'),
('C43', 'C', 'BELUM DIPESAN'),
('C44', 'C', 'BELUM DIPESAN'),
('C45', 'C', 'BELUM DIPESAN'),
('C46', 'C', 'BELUM DIPESAN'),
('C47', 'C', 'BELUM DIPESAN'),
('C48', 'C', 'BELUM DIPESAN'),
('C49', 'C', 'BELUM DIPESAN'),
('C5', 'C', 'BELUM DIPESAN'),
('C50', 'C', 'BELUM DIPESAN'),
('C6', 'C', 'BELUM DIPESAN'),
('C7', 'C', 'BELUM DIPESAN'),
('C8', 'C', 'BELUM DIPESAN'),
('C9', 'C', 'BELUM DIPESAN');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_laporan`
--

CREATE TABLE `tb_laporan` (
  `no_pesan` int(5) NOT NULL,
  `judul` text NOT NULL,
  `pesan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_laporan`
--

INSERT INTO `tb_laporan` (`no_pesan`, `judul`, `pesan`) VALUES
(5, 'Studio', 'Studio yang berjalan baru studio A saja ');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_studio`
--

CREATE TABLE `tb_studio` (
  `nama_studio` varchar(4) NOT NULL,
  `sisa_kursi` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_studio`
--

INSERT INTO `tb_studio` (`nama_studio`, `sisa_kursi`) VALUES
('A', 41),
('B', 48),
('C', 50);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_tiket`
--

CREATE TABLE `tb_tiket` (
  `id_tiket` char(5) NOT NULL,
  `stok` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_tiket`
--

INSERT INTO `tb_tiket` (`id_tiket`, `stok`) VALUES
('t001', 40),
('t002', 48),
('t003', 50);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_transaksi`
--

CREATE TABLE `tb_transaksi` (
  `id_transaksi` int(5) NOT NULL,
  `id_film` char(5) NOT NULL,
  `nama_studio` char(5) NOT NULL,
  `no_kursi` varchar(4) NOT NULL,
  `id_tiket` char(5) NOT NULL,
  `harga` int(11) NOT NULL,
  `tanggal_transaksi` varchar(15) NOT NULL,
  `status` varchar(15) DEFAULT NULL,
  `metode_pembayaran` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_transaksi`
--

INSERT INTO `tb_transaksi` (`id_transaksi`, `id_film`, `nama_studio`, `no_kursi`, `id_tiket`, `harga`, `tanggal_transaksi`, `status`, `metode_pembayaran`) VALUES
(39, 'f001', 'A', 'A1', 't001', 35000, '12/5/2021', 'Lunas', 'Cash'),
(40, 'f001', 'A', 'A2', 't001', 35000, '12/5/2021', 'Belum Lunas', '');

--
-- Trigger `tb_transaksi`
--
DELIMITER $$
CREATE TRIGGER `hapus_transaksi` AFTER DELETE ON `tb_transaksi` FOR EACH ROW BEGIN
	UPDATE `db_bioskop`.`tb_kursi`
	SET `db_bioskop`.`tb_kursi`.`status` = 'BELUM DIPESAN' WHERE `db_bioskop`.`tb_kursi`.`no_kursi`=old.no_kursi;
    END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `kurang_stok` AFTER INSERT ON `tb_transaksi` FOR EACH ROW BEGIN
	UPDATE tb_tiket SET stok = stok - 1 WHERE id_tiket=new.id_tiket;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `kurangi_stok_studio` AFTER INSERT ON `tb_transaksi` FOR EACH ROW BEGIn
	declare tipe char(20);
	set tipe = ( select a.nama_studio from tb_kursi a join tb_transaksi b on a.no_kursi = b.no_kursi where a.no_kursi = new.no_kursi );
	Update tb_studio set sisa_kursi = sisa_kursi - 1 where nama_studio = tipe;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `status_kursi` AFTER INSERT ON `tb_transaksi` FOR EACH ROW BEGIN
	UPDATE tb_kursi SET status = 'DIPESAN' WHERE no_kursi=new.no_kursi;
END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tb_film`
--
ALTER TABLE `tb_film`
  ADD PRIMARY KEY (`Id_film`),
  ADD KEY `fk_jadwal` (`Id_jadwal`),
  ADD KEY `fk_kategori` (`Genre`),
  ADD KEY `fk_tiket` (`Id_tiket`),
  ADD KEY `fk_studio` (`Nama_studio`);

--
-- Indeks untuk tabel `tb_jadwal`
--
ALTER TABLE `tb_jadwal`
  ADD PRIMARY KEY (`id_jadwal`);

--
-- Indeks untuk tabel `tb_kategori`
--
ALTER TABLE `tb_kategori`
  ADD PRIMARY KEY (`Nama_Kategori`);

--
-- Indeks untuk tabel `tb_kursi`
--
ALTER TABLE `tb_kursi`
  ADD PRIMARY KEY (`no_kursi`),
  ADD KEY `fk_stud` (`nama_studio`);

--
-- Indeks untuk tabel `tb_laporan`
--
ALTER TABLE `tb_laporan`
  ADD KEY `no_pesan` (`no_pesan`);

--
-- Indeks untuk tabel `tb_studio`
--
ALTER TABLE `tb_studio`
  ADD PRIMARY KEY (`nama_studio`);

--
-- Indeks untuk tabel `tb_tiket`
--
ALTER TABLE `tb_tiket`
  ADD PRIMARY KEY (`id_tiket`);

--
-- Indeks untuk tabel `tb_transaksi`
--
ALTER TABLE `tb_transaksi`
  ADD PRIMARY KEY (`id_transaksi`),
  ADD KEY `fk_kursi` (`no_kursi`),
  ADD KEY `fk_tikett` (`id_tiket`),
  ADD KEY `fk_filmm` (`id_film`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tb_laporan`
--
ALTER TABLE `tb_laporan`
  MODIFY `no_pesan` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT untuk tabel `tb_transaksi`
--
ALTER TABLE `tb_transaksi`
  MODIFY `id_transaksi` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `tb_film`
--
ALTER TABLE `tb_film`
  ADD CONSTRAINT `fk_jadwal` FOREIGN KEY (`Id_jadwal`) REFERENCES `tb_jadwal` (`id_jadwal`),
  ADD CONSTRAINT `fk_kategori` FOREIGN KEY (`Genre`) REFERENCES `tb_kategori` (`Nama_Kategori`),
  ADD CONSTRAINT `fk_studio` FOREIGN KEY (`Nama_studio`) REFERENCES `tb_studio` (`nama_studio`),
  ADD CONSTRAINT `fk_tiket` FOREIGN KEY (`Id_tiket`) REFERENCES `tb_tiket` (`id_tiket`);

--
-- Ketidakleluasaan untuk tabel `tb_kursi`
--
ALTER TABLE `tb_kursi`
  ADD CONSTRAINT `fk_stud` FOREIGN KEY (`nama_studio`) REFERENCES `tb_studio` (`nama_studio`);

--
-- Ketidakleluasaan untuk tabel `tb_transaksi`
--
ALTER TABLE `tb_transaksi`
  ADD CONSTRAINT `fk_filmm` FOREIGN KEY (`id_film`) REFERENCES `tb_film` (`Id_film`),
  ADD CONSTRAINT `fk_kursi` FOREIGN KEY (`no_kursi`) REFERENCES `tb_kursi` (`no_kursi`),
  ADD CONSTRAINT `fk_tikett` FOREIGN KEY (`id_tiket`) REFERENCES `tb_tiket` (`id_tiket`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
