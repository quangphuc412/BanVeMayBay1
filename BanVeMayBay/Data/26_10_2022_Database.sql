create database QUANLYCHUYENBAY
go
use QUANLYCHUYENBAY
go
create table SANBAY(
MaSanBay char(20) primary key,
TenSanBay nvarchar(45) not null,
ViTri nvarchar(50) not null
)
go

create table TUYENBAY(
MaTuyenBay char(20) primary key,
SANBAYDI_MaSanBay char(20) REFERENCES SANBAY(MaSanBay),
SANBAYDEN_MaSanBay char(20) REFERENCES SANBAY(MaSanBay),
SANBAYTRUNGGIAN_MaSanBay char(20) REFERENCES SANBAY(MaSanBay)
)
go

create table NHANVIEN(
MaNV char(20) primary key,
CMND char(20) not null,
TenNV nvarchar(45),
GioiTinh   nvarchar(20),
NgaySinh date,
SDT  char(20),
Diachi nvarchar(100)
)
go
select * from NHANVIEN
------
create table TAIKHOAN(
 TenTaiKhoan char(20) primary key,
 MatKhau char (20) not null,
 ID_NhanVien CHAR(20) references NHANVIEN(MaNV) null,
 PHANLOAI char(20)
)
go

create table KHACHHANG(
CMND char(20) primary key,
TenKH nvarchar(45),
SDT  char(20),
GioiTinh   nvarchar(20),
Diachi nvarchar(100),
NgaySinh date
)
go

create table MAYBAY(
MaMayBay CHAR(20) primary key,
LoaiMayBay nvarchar(45),
SoGhe int
)
go

CREATE TABLE CHUYENBAY(
MaChuyenBay char(20) PRIMARY KEY,
NgayBay Date,
GioKhoiHanh TIME,
ThoiGianBay TIME,
ThoiGianDuKienDen TIME,
SoGheHang1 INT,
SoGheHang2 INT,
TUYENBAY_MaTuyenBay char(20) REFERENCES TUYENBAY(MaTuyenBay),
MaMayBay CHAR(20) references MAYBAY(MaMayBay)
------Chuyến bay đã bỏ Khối lượng
)
go
select * from CHUYENBAY
CREATE TABLE HANGVE(
MaHangVe char(30) PRIMARY KEY,
VECHUYENBAY char(20) REFERENCES CHUYENBAY(MaChuyenBay), -- ví dụ như tuyến tân sơn nhất nội bài ,
KhoiLuongToiDa int, -----Thêm Khối Lượng tối đa vào HangVe
DonGia Money
)
go

CREATE TABLE PHIEUDATCHO(
MaPhieu char(20) PRIMARY KEY,
ThoiGianDat DATETIME,
SoGhe char(5),
HangGhe char(5),
CHUYENBAY_MaChuyenBay char(20) REFERENCES CHUYENBAY(MaChuyenBay),
KHACHHANG_CMND CHAR(20) REFERENCES KHACHHANG(CMND),
MAHANGVE CHAR(30) REFERENCES HANGVE(MaHangVe),
KHOILUONGHANHLI int
)
GO

CREATE TABLE HOADON(
MaHD char(20) PRIMARY KEY,
MaPhieuDatCho char(20) references PHIEUDATCHO(MaPhieu),
ThanhTien MONEY,
NgayLap DATETIME,
NHANVIEN_MaNV CHAR(20) REFERENCES NHANVIEN(MaNV),
KHACHHANG_CMND CHAR(20) REFERENCES KHACHHANG(CMND)
)
go

CREATE TABLE VECHUYENBAY(
MaVeChuyenBay char(20)PRIMARY KEY,
CHUYENBAY_MaChuyenBay char(20) REFERENCES CHUYENBAY(MaChuyenBay),
SoLuongVe int,
TinhTrangVe nvarchar(10),
)

GO
select * from VECHUYENBAY
go

CREATE FUNCTION AUTO_IDNV()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MANV) FROM NHANVIEN) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MANV, 3)) FROM NHANVIEN
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'NV00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'NV0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO

CREATE FUNCTION AUTO_IDHD()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaHD) FROM HOADON) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MAHD, 3)) FROM HOADON
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'HD00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'HD0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
create table HD(
	MAHD char(5) primary key CONSTRAINT IDHD DEFAULT DBO.AUTO_IDHD(),
	TenHD char(20)
)
insert into HD(TenHD) values('1')
insert into HD(TenHD) values('2')


CREATE FUNCTION AUTO_IDPDC()
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)
	IF (SELECT COUNT(MaPhieu) FROM PHIEUDATCHO) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhieu, 3)) FROM PHIEUDATCHO
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'PDC00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'PDC0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO

create table PDC(
	MaPhieu char(6) primary key CONSTRAINT IDPDC DEFAULT DBO.AUTO_IDPDC(),
	TenPhieu char(20)
)
select * from PDC
insert into PDC(TenPhieu) values('1')
insert into PDC(TenPhieu) values('2')
insert into PDC(TenPhieu) values('3')
insert into PDC(TenPhieu) values('4')
insert into PDC(TenPhieu) values('5')
insert into PDC(TenPhieu) values('6')
insert into PDC(TenPhieu) values('7')
insert into PDC(TenPhieu) values('8')
insert into PDC(TenPhieu) values('9')
insert into PDC(TenPhieu) values('10')
insert into PDC(TenPhieu) values('11')