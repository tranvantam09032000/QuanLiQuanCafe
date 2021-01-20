CREATE DATABASE QUANCOFFE
USE QUANCOFFE

--BẢNG NHÂN VIÊN  
CREATE TABLE NHANVIEN(
MaNhanVien INT IDENTITY (1,1)  NOT NULL,
HoTen NVARCHAR (50)NOT NULL,
TenDangNHap NVARCHAR(50) NOT NULL,
MatKhau NVARCHAR (50) NOT NULL,
NgaySinh NVARCHAR (20) NOT NULL,--dd/MM/yyyy H:mm:ss 
GioiTinh NVARCHAR (10) NOT NULL,
SoDienThoai NVARCHAR (15) NOT NULL,
QueQuan NVARCHAR (50) NOT NULL,
DiaChi NVARCHAR (50) NOT NULL,
ChucVu NVARCHAR (50)  NOT NULL, -- 0 là quản lý, 1 nhân viên thu ngân , 2 pha chế
TrangThai INT NOT NULL DEFAULT 1 -- 1 hoạt động , 0 là xóa
)


--BẢNG SẢN PHẨM
CREATE TABLE SANPHAM(
MaSanPham  INT IDENTITY (1,1)  NOT NULL,
TenSanPham NVARCHAR(50) NOT NULL,
Loai INT  NOT NULL,
GiaBan FLOAT NOT NULL,
SoLuongTon int NOT NULL,
NhaSanXuat INT NOT NULL,
TrangThai INT NOT NULL DEFAULT 1 -- 1 hoạt động , 0 là xóa
)
--BẢNG LOẠI SẢN PHẨM
CREATE TABLE LOAISANPHAM(
MaLoaiSP INT IDENTITY (1,1)  NOT NULL,
TenLoaiSP NVARCHAR (50) NOT NULL,
TrangThai INT NOT NULL DEFAULT 1 -- 1 hoạt động , 0 là xóa
)

--BẢNG HÓA ĐƠN BÁN
CREATE TABLE HOADONBAN(
MaHoaDonBan INT IDENTITY (1,1)  NOT NULL,
MaNhanVien INT NOT NULL,
TenNhanVien NVARCHAR (50),
TenKhachHang  NVARCHAR (50) NOT NULL,
NgayLap NVARCHAR (20)  NOT NULL,--dd/MM/yyyy H:mm:ss 
TongTien MONEY NOT NULL,
GhiChu NVARCHAR(100),
TrangThai INT NOT NULL DEFAULT 1  -- 1 hoạt động , 0 là xóa
)

--BẢNG CHI TIẾT HÓA ĐƠN BÁN
CREATE TABLE CTHOADONBAN(
MaCTHoaDonBan INT IDENTITY (1,1)  NOT NULL,
MaHoaDonBan INT NOT NULL,
MaSanPham INT NOT NULL,
SoLuong INT  NOT NULL,
DongGia MONEY  NOT NULL,
ThanhTien MONEY  NOT NULL ,
GhiChu NVARCHAR(100),
TrangThai INT NOT NULL DEFAULT 1 -- 1 hoạt động , 0 là xóa
)

--BẢNG HÓA ĐƠN NHẬP
CREATE TABLE HOADONNHAP(
MaHoaDonNhap  INT IDENTITY (1,1)  NOT NULL,
MaNhanVien INT NOT NULL,
TenNhanVien NVARCHAR(50) NOT NULL,
MaNhaCungCap INT NOT NULL,
NgayLap NVARCHAR(20) NOT NULL ,--dd/MM/yyyy H:mm:ss 
TongTien MONEY NOT NULL,
GhiChu NVARCHAR(100),
TrangThai INT NOT NULL DEFAULT 1 -- 1 hoạt động , 0 là xóa
)

--BẢNG CT HÓA ĐƠN NHẬP
CREATE TABLE CTHOADONNHAP(
MaCTHoaDonNhap INT IDENTITY (1,1)  NOT NULL ,
MaHoaDonNhap  INT,
MaSanPham INT NOT NULL,
SoLuong INT  NOT NULL,
DonGia MONEY  NOT NULL,
ThanhTien MONEY NOT NULL ,
GhiChu NVARCHAR(100),
TrangThai INT NOT NULL DEFAULT 1 -- 1 hoạt động , 0 là xóa
)

--BẢNG NHÀ CUNG CẤP
CREATE TABLE NHACUNGCAP(
MaNhaCungCap  INT IDENTITY (1,1)  NOT NULL ,
TenNhaCungCap NVARCHAR (50),
DiaChi NVARCHAR (50),
SoDienThoai NVARCHAR (15),
TrangThai INT NOT NULL DEFAULT 1 -- 1 hoạt động , 0 là xóa
)


--KHÓA CHÍNH NHÂN VIÊN
ALTER TABLE NHANVIEN
ADD CONSTRAINT PK_MaNhanVien PRIMARY KEY (MaNhanVien);
--KHÓA CHÍNH SẢN PHẨM
ALTER TABLE SANPHAM
ADD CONSTRAINT PK_MaSP PRIMARY KEY (MaSanPham);
--KHÓA CHÍNH LOẠI SẢN PHẨM
ALTER TABLE LOAISANPHAM
ADD CONSTRAINT PK_MaLoaiSP PRIMARY KEY (MaLoaiSP);
--KHÓA CHÍNH HÓA ĐƠN BÁN
ALTER TABLE HOADONBAN
ADD CONSTRAINT PK_MaHoaDonBan PRIMARY KEY (MaHoaDonBan);
--KHÓA CHÍNH CT HÓA ĐƠN BÁN
ALTER TABLE CTHOADONBAN
ADD CONSTRAINT PK_MaCTHoaDonBan PRIMARY KEY (MaHoaDonBan,MaSanPham);
--KHÓA CHÍNH NHÀ CUNG CẤP
ALTER TABLE NHACUNGCAP
ADD CONSTRAINT PK_MaNhaCungCap PRIMARY KEY (MaNhaCungCap);
--KHÓA CHÍNH CT HÓA ĐƠN NHẬP
ALTER TABLE CTHOADONNHAP
ADD CONSTRAINT PK_MaCTHoaDonNhap PRIMARY KEY (MaCTHoaDonNhap,MaSanPham);

--KHÓA CHÍNH HÓA ĐƠN NHẬP
ALTER TABLE HOADONNHAP
ADD CONSTRAINT PK_MaHoaDonNhap PRIMARY KEY (MaHoaDonNhap);
--KHÓA NGOẠI 
ALTER TABLE HOADONBAN 
ADD CONSTRAINT FK_MaNhanVien FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien);

ALTER TABLE CTHOADONBAN 
ADD CONSTRAINT FK_MaCTHoaDonBan FOREIGN KEY (MaHoaDonBan) REFERENCES HOADONBAN(MaHoaDonBan);

ALTER TABLE CTHOADONBAN 
ADD CONSTRAINT FK_MaSanPham FOREIGN KEY (MaSanPham) REFERENCES SANPHAM(MaSanPham);

ALTER TABLE SANPHAM 
ADD CONSTRAINT FK_MaLoaiSanPham FOREIGN KEY (Loai) REFERENCES LOAISANPHAM(MaLoaiSP);

ALTER TABLE SANPHAM 
ADD CONSTRAINT FK_MaNhaSanXuat FOREIGN KEY (NhaSanXuat) REFERENCES NhaCungCap(MaNhaCungCap);

ALTER TABLE HOADONNHAP
ADD CONSTRAINT FK_MaNhaCungCap FOREIGN KEY (MaNhaCungCap) REFERENCES NHACUNGCAP(MaNhaCungCap);

ALTER TABLE CTHOADONNHAP
ADD CONSTRAINT FK_MaCTHoaDonNhap FOREIGN KEY (MaHoaDonNhap) REFERENCES HOADONNHAP(MaHoaDonNhap);

 ALTER TABLE CTHOADONNHAP
ADD CONSTRAINT FK_MaSanPhamNhap FOREIGN KEY (MaSanPham) REFERENCES SANPHAM(MaSanPham);

ALTER TABLE HOADONNHAP
ADD CONSTRAINT FK_MaNhanVienNhap FOREIGN KEY (MaNhanVien) REFERENCES NHANVIEN(MaNhanVien);

-- NHÂN VIÊN
INSERT INTO NHANVIEN(HoTen ,TenDangNHap ,MatKhau ,NgaySinh ,GioiTinh ,SoDienThoai ,QueQuan,DiaChi ,ChucVu ) 
			VALUES ( N'Trần Văn A','tranvana','123','1-1-2000','Nam','0999999999','TP HCM',N'Quận 9',N'Quản Lý')
INSERT INTO NHANVIEN(HoTen ,TenDangNHap ,MatKhau ,NgaySinh ,GioiTinh ,SoDienThoai ,QueQuan,DiaChi ,ChucVu ) 
			VALUES ( N'Nguyễn  Văn B','nguyenvanb','123','2-1-2000','Nam','0999999998','TP HCM',N'Quận 8',N'Nhân Viên Thu Ngân')
INSERT INTO NHANVIEN(HoTen ,TenDangNHap ,MatKhau ,NgaySinh ,GioiTinh ,SoDienThoai ,QueQuan,DiaChi ,ChucVu ) 
			VALUES ( N'Nguyễn Thị C','nguyenthic','123','3-1-2000',N'Nữ','0999999997','TP HCM',N'Quận 6',N'Nhân Viên Thu Ngân')
INSERT INTO NHANVIEN(HoTen ,TenDangNHap ,MatKhau ,NgaySinh ,GioiTinh ,SoDienThoai ,QueQuan,DiaChi ,ChucVu ) 
			VALUES (N'Nguyễn Hoàng D','nguyenhoangd','123','9-1-2000',N'nữ','0999999997','TP HCM',N'Quận 7',N'Nhân Viên Pha Chế')

CREATE PROCEDURE ThemNhanVien
@HoTen NVARCHAR (50),
@TenDangNHap NVARCHAR(50) ,
@MatKhau NVARCHAR (50) ,
@NgaySinh NVARCHAR (20) , 
@GioiTinh NVARCHAR (10) ,
@SoDienThoai NVARCHAR (15),
@QueQuan NVARCHAR (50),
@DiaChi NVARCHAR (50),
@ChucVu NVARCHAR (50)
AS  
BEGIN 
INSERT INTO NHANVIEN(HoTen,TenDangNHap ,MatKhau ,NgaySinh ,GioiTinh ,SoDienThoai ,QueQuan,DiaChi ,ChucVu ) 
			VALUES ( @HoTen,@TenDangNHap,@MatKhau,@NgaySinh,@GioiTinh,@SoDienThoai,@QueQuan,@DiaChi,@ChucVu)
END

--CẬT NHẬT  NHÂN VIÊN
CREATE PROCEDURE CapNhatNhanVien
@MaNhanVien INT ,
@HoTen NVARCHAR (50),
@TenDangNHap NVARCHAR(50) ,
@NgaySinh NVARCHAR (20) , 
@GioiTinh NVARCHAR (10) ,
@SoDienThoai NVARCHAR (15),
@QueQuan NVARCHAR (50),
@DiaChi NVARCHAR (50),
@ChucVu NVARCHAR (50)
AS  
BEGIN 
UPDATE NHANVIEN 
SET  HoTen = @HoTen ,TenDangNHap =@TenDangNHap ,NgaySinh = @NgaySinh ,GioiTinh = @GioiTinh ,SoDienThoai = @SoDienThoai ,QueQuan = @QueQuan,DiaChi = @DiaChi ,ChucVu = @ChucVu
WHERE MaNhanVien = @MaNhanVien
END

--XÓA NHÂN VIÊN
CREATE PROCEDURE XoaNhanVien
@MaNhanVien INT,
@TrangThai int 
AS  
BEGIN 
UPDATE NHANVIEN 
SET  TrangThai = @TrangThai
WHERE MaNhanVien = @MaNhanVien
END

-- NHÀ CUNG CẤP

CREATE PROCEDURE ThemNhaCungCap
@TenNhaCungCap NVARCHAR (50),
@SoDienThoai NVARCHAR(50) ,
@DiaChi NVARCHAR (50) 
AS  
BEGIN 
INSERT INTO NHACUNGCAP(TenNhaCungCap,SoDienThoai,DiaChi ) 
			VALUES (@TenNhaCungCap,@SoDienThoai,@DiaChi)
END	

--CẬP NHẬT NHÀ CUNG CẤP
CREATE PROCEDURE CapNhatNhaCungCap
@MaNhaCungCap INT ,
@TenNhaCungCap NVARCHAR (50),
@DiaChi NVARCHAR(50) ,
@SoDienThoai NVARCHAR (15)
AS  
BEGIN 
UPDATE NHACUNGCAP
SET  TenNhaCungCap = @TenNhaCungCap, SoDienThoai = @SoDienThoai,DiaChi = @DiaChi
WHERE MaNhaCungCap = @MaNhaCungCap
END


--XÓA NHÀ CUNG CẤP
CREATE PROCEDURE XoaNhaCungCap
@MaNhaCungCap NVARCHAR(10),
@TrangThai int 
AS  
BEGIN 
UPDATE NHACUNGCAP 
SET  TrangThai = @TrangThai
WHERE MaNhaCungCap = @MaNhaCungCap
END

--LOẠI SẢN PHẨM
--THÊM LOẠI SẢN PHẨM
CREATE PROCEDURE ThemLoaiSanPham
@TenLoaiSP NVARCHAR (50)
AS 
BEGIN
INSERT INTO LOAISANPHAM(TenLoaiSP) VALUES (@TenLoaiSP)
END
--CẬP NHẬT LOẠI SẢN PHẨM
CREATE PROCEDURE CapNhatLoaiSP
@MaLoaiSP INT,
@TenLoaiSP NVARCHAR (50)
AS  
BEGIN 
UPDATE LOAISANPHAM
SET  TenLoaiSP = @TenLoaiSP
WHERE MaLoaiSP = @MaLoaiSP
END


--XÓA LOẠI SẢN PHẨM
CREATE PROCEDURE XoaLoaiSP
@MaLoaiSP INT,
@TrangThai int 
AS  
BEGIN 
UPDATE LOAISANPHAM
SET  TrangThai = @TrangThai
WHERE MaLoaiSP = @MaLoaiSP
END






----SẢN PHẨM

-- THÊM SẢN PHẨM
CREATE PROCEDURE ThemSanPham 
@TenSanPham NVARCHAR (50),
@Loai nvarchar (10),
@GiaBan  FLOAT,
@NhaSanXuat NVARCHAR (10),
@SoLuongTon INT
AS BEGIN
INSERT INTO SANPHAM (TenSanPham,Loai,GiaBan,NhaSanXuat,SoLuongTon) VALUES (@TenSanPham,@Loai,@GiaBan,@NhaSanXuat,@SoLuongTon)
END

--XÓA SẢN PHẨM
CREATE PROCEDURE XoaSanPham
@MaSanPham NVARCHAR(10),
@TrangThai int 
AS  
BEGIN 
UPDATE SANPHAM 
SET  TrangThai = @TrangThai
WHERE MaSanPham = @MaSanPham
END

--CẬP NHẬT SẢN PHẨM
CREATE PROCEDURE CapNhatSanPham
@MaSanPham NVARCHAR(10) ,
@TenSanPham NVARCHAR (50),
@Loai nvarchar (10),
@GiaBan FLOAT,
@NhaSanXuat NVARCHAR (10),
@SoLuongTon INT
AS  
BEGIN 
UPDATE SANPHAM
SET  TenSanPham = @TenSanPham , Loai =  @Loai , GiaBan = @GiaBan , NhaSanXuat =  @NhaSanXuat,SoLuongTon = @SoLuongTon
WHERE MaSanPham = @MaSanPham
END

--CẬP NHẬT SỐ LƯỢNG TỒN
CREATE PROCEDURE CapNhatSoLuongTon
@MaSanPham NVARCHAR(10) ,
@SoLuongTon INT
AS  
BEGIN 
UPDATE SANPHAM
SET  SoLuongTon = @SoLuongTon
WHERE MaSanPham = @MaSanPham
END

----HÓA ĐƠN BÁN

--TẠO HÓA ĐƠN
CREATE PROCEDURE TaoHoaDonBan
@MaNhanVien INT,
@TenKhachHang  NVARCHAR(50),
@NgayLap NVARCHAR (50),
@TongTien FLOAT,
@GhiChu NVARCHAR(100)
AS 
BEGIN
INSERT INTO HOADONBAN(MaNhanVien,TenKhachHang,NgayLap,TongTien,GhiChu) 
VALUES (@MaNhanVien,@TenKhachHang,@NgayLap,@TongTien,@GhiChu)
END

--CẬP NHẬT HÓA ĐƠN BÁN
CREATE PROCEDURE CapNhatHoaDonBan
@MaHoaDonBan int,
@GhiChu nvarchar (100)
AS
BEGIN
UPDATE HOADONBAN
SET GhiChu = @GhiChu
WHERE MaHoaDonBan = @MaHoaDonBan
END

--THÊM SẢN PHẨM VÀO HÓA ĐƠN BÁN
CREATE PROCEDURE ThemSPHoaDonBan
@MaHoaDonBan INT,
@MaSanPham INT ,
@SoLuong INT  ,
@DongGia FLOAT ,
@ThanhTien FLOAT
AS 
BEGIN
INSERT INTO CTHOADONBAN(MaHoaDonBan,MaSanPham,SoLuong,DongGia,ThanhTien) 
VALUES (@MaHoaDonBan, @MaSanPham,@SoLuong,@DongGia,@ThanhTien)
END

--XÓA SP HÓA ĐƠN BÁN
CREATE PROCEDURE XoaSPHoaDonBan
@MaCTHoaDonBan int,
@TrangThai int 
AS  
BEGIN 
UPDATE CTHOADONBAN
SET  TrangThai = @TrangThai
WHERE  MaCTHoaDonBan= @MaCTHoaDonBan
END

--TỔNG TIỀN HÓA ĐƠN BÁN
CREATE PROCEDURE TongTienHoaDonBan
@MaHoaDonBan INT ,
@TongTien float 
AS 
BEGIN 
UPDATE HOADONBAN SET TongTien = @TongTien
WHERE MaHoaDonBan = @MaHoaDonBan
END

--XÓA HÓA ĐƠN BÁN
CREATE PROCEDURE XoaHoaDon
@MaHoaDonBan INT ,
@TrangThai INT
AS 
BEGIN 
UPDATE HOADONBAN SET TrangThai = @TrangThai
WHERE MaHoaDonBan = @MaHoaDonBan
END

----HÓA ĐƠN NHẬP

--TẠO HÓA ĐƠN NHẬP
CREATE PROCEDURE TaoHoaDonNhap
@MaNhanVien INT,
@TenNhanVien NVARCHAR (50),
@MaNhaCungCap NVARCHAR(50),
@NgayLap NVARCHAR (50),
@TongTien FLOAT,
@GhiChu NVARCHAR(100)
AS 
BEGIN
INSERT INTO HOADONNHAP(MaNhanVien,TenNhanVien,MaNhaCungCap ,NgayLap,TongTien,GhiChu) 
VALUES (@MaNhanVien,@TenNhanVien,@MaNhaCungCap,@NgayLap,@TongTien,@GhiChu)
END

--CẬP NHẬT HÓA ĐƠN NHẬP
CREATE PROCEDURE CapNhatHoaDonNhap
@MaHoaDonNhap int,
@GhiChu nvarchar (100)
AS
BEGIN
UPDATE HOADONNHAP
SET GhiChu = @GhiChu
WHERE MaHoaDonNhap = @MaHoaDonNhap
END

--XÓA SẢN PHẨM TRONG HÓA ĐƠN NHẬP
CREATE PROCEDURE XoaSPHoaDonNhap
@MaCTHoaDonNhap int,
@TrangThai int 
AS  
BEGIN 
UPDATE CTHOADONNHAP
SET  TrangThai = @TrangThai
WHERE  MaCTHoaDonNhap= @MaCTHoaDonNhap
END


--TỔNG TIỀN HÓA ĐƠN NHẬP
CREATE PROCEDURE TongTienHoaDonNhap
@MaHoaDonNhap INT ,
@TongTien float 
AS 
BEGIN 
UPDATE HOADONNHAP SET TongTien = @TongTien
WHERE MaHoaDonNhap = @MaHoaDonNhap
END

--XÓA HÓA ĐƠN NHẬP
CREATE PROCEDURE XoaHoaDonNhap
@MaHoaDonNhap INT ,
@TrangThai INT
AS 
BEGIN 
UPDATE HOADONNHAP SET TrangThai = @TrangThai
WHERE MaHoaDonNhap = @MaHoaDonNhap
END

--THÊM SẢN PHẨM VÀO HÓA ĐƠN NHẬP
CREATE PROCEDURE ThemSPHoaDonNhap
@MaHoaDonNhap INT,
@MaSanPham INT ,
@SoLuong INT  ,
@DongGia FLOAT ,
@ThanhTien FLOAT
AS 
BEGIN
INSERT INTO CTHOADONNHAP(MaHoaDonNhap,MaSanPham,SoLuong,DonGia,ThanhTien) 
VALUES (@MaHoaDonNhap, @MaSanPham,@SoLuong,@DongGia,@ThanhTien)
END
