CREATE DATABASE MyMusic;
USE MyMusic;

-- Tạo bảng TacGia
CREATE TABLE TacGia (
    IDTacGia NVARCHAR(15) PRIMARY KEY,
    TenTG NVARCHAR(100),
    NS DATE,
    QueQuan NVARCHAR(100),
    TieuSu NVARCHAR(MAX),
    GioiTinh NVARCHAR(10),
    LinkAnh NVARCHAR(255)
);
INSERT INTO TacGia (IDTacGia,TenTG, NS, QueQuan, TieuSu, GioiTinh, LinkAnh) 
VALUES ('TG000001','Alan Walker', '1997-08-24', 'Norway', 'Tieu su cua Alan Walker', 'Nam', 'ab6761610000e5ebbf753c009fd9c2d53351dd3c.jpg'),
       ('TG000002','Đen', '1984-05-13', 'VietNam', 'Tieu su cua Đen', 'Nam', 'ab67706c0000da84e0e8b3fdc5bcc3b1f21b3b19.jpg'),
	   ('TG000003','Imagine Dragons', '2008-01-01', 'America', 'Tieu su cua Imagine Dragons', 'Nam', 'ab67616100005174ab47d8dae2b24f5afe7f9d38.jpg'),
	   ('TG000004','Adele', '1988-05-05', 'UK', 'Tieu su cua Adele', 'Nu', 'aab6761610000e5eb68f6e5892075d7f22615bd17.jpg'),
	   ('TG000005','Taylor Swift', '1989-12-13', 'USA', 'Tieu su cua Taylor Swift', 'Nu', 'ab6761610000e5ebe672b5f553298dcdccb0e676.jpg'),
	   ('TG000006','Ha Anh Tuan', '1984-12-17', 'VietNam', 'Tieu su cua Ha Anh Tuan', 'Nam', 'ab67616100005174e790217ff9f7f2922524b93e.jpg'),
	   ('TG000007','Vũ', '1995-10-03', 'VietNam', 'Tieu su cua Vũ ', 'Nam', 'ab6761610000517405dfcbe06dcf1fd031b02aa8.jpg');





-- Tạo bảng TheLoai
CREATE TABLE TheLoai (
    IDTheLoai NVARCHAR(15) PRIMARY KEY,
    TenTL NVARCHAR(100),
    MoTa NVARCHAR(MAX)
);

INSERT INTO TheLoai (IDTheLoai,TenTL,MoTa)
VALUES ('TL001','Rap','Mo ta Rap'),
       ('TL002','Pop','Mo ta Pop'),
       ('TL003','Rock','Mo ta Rock'),
	   ('TL004','V-pop','Mo ta V-pop'),
	   ('TL005','Jazz','Mo ta Jazz'),
	   ('TL006','Electronica','Mo ta Electronica'),
	   ('TL007','Lo-fi','Mo ta Lo-fi');




-- Tạo bảng Album
CREATE TABLE Album (
    IDAlbum NVARCHAR(15) PRIMARY KEY,
    TenAlbum NVARCHAR(100),
    NgayRaMat DATE,
    LinkAnh NVARCHAR(255),
    IDTacGia NVARCHAR(15),
    FOREIGN KEY (IDTacGia) REFERENCES TacGia(IDTacGia)
);

INSERT INTO Album(IDAlbum,TenAlbum,NgayRaMat,LinkAnh,IDTacGia)
VALUES ('AL000001','World Of Walker','2021-05-15','ab67616d0000b273df9a35baaa98675256b35177.jpg','TG000001'),
       ('AL000002','Show cua Den','2021-05-15','ab67616d00001e024888abe8ee4d110278a67538.jpg','TG000002'),
	   ('AL000003','Mercury','2021-05-15','ab67616d0000b273fc915b69600dce2991a61f13.jpg','TG000003'),
	   ('AL000004','25','2021-05-15','ab67616d0000b27347ce408fb4926d69da6713c2.jpg','TG000004'),
	   ('AL000005','1989','2021-05-15','ab67616d0000b273904445d70d04eb24d6bb79ac.jpg','TG000005'),
	   ('AL000006','Ngay Hat Doi','2021-05-15','ab67616d0000b273bd48f3fbedddb23ed66f860a.jpg','TG000006'),
	   ('AL000007','Mot Van Nam','2021-05-15','ab67616d0000b273824ac9ea17bde4ea1fd09f4f.jpg','TG000007');



-- Tạo bảng BaiHat
CREATE TABLE BaiHat (
    IDBaiHat NVARCHAR(15) PRIMARY KEY,
    TenBaiHat NVARCHAR(100),
    ThoiGian TIME,
    IDTheLoai NVARCHAR(15),
    LinkNhac NVARCHAR(255),
    LinkAnh NVARCHAR(255),
    IDTacGia NVARCHAR(15),
    FOREIGN KEY (IDTheLoai) REFERENCES TheLoai(IDTheLoai),
    FOREIGN KEY (IDTacGia) REFERENCES TacGia(IDTacGia)
);

ALTER TABLE BaiHat
ADD LuotNghe BigINT;

INSERT INTO BaiHat(IDBaiHat,TenBaiHat,ThoiGian,IDTheLoai,LinkNhac,LinkAnh,IDTacGia,LuotNghe)
VALUES ('BH000001','Faded','2018','TL006','y2meta.com - Alan Walker - Faded (128 kbps).mp3','ab67616d00001e02c4d00cac55ae1b4598c9bc90.jpg','TG000001',0),
       ('BH000002','Alone','2021','TL006','y2meta.com - Alan Walker - Alone (128 kbps).mp3','ab67616d0000b273f00ade2f88d8223521bc7f76.jpg','TG000001',0),
	   ('BH000003','On My Way','2021','TL006','y2meta.com - Alan Walker, Sabrina Carpenter & Farruko  - On My Way (128 kbps).mp3','ab67616d0000b273d2aaf635815c265aa1ecdecc.jpg','TG000001',0),
	   ('BH000004','Fire','2020','TL006','y2meta.com - Alan Walker, YUQI of (G)I-DLE, JVKE - Fire! (Official Music Video) (128 kbps).mp3','ab67616d0000b2739bcee2cb961a04d2e5a29f5c.jpg','TG000001',0),
	   ('BH000005','Di ve nha','2020','TL001','1.mp3','ab67616d0000b2732a8efe3bfa6a605fcf863237.jpg','TG000002',0),
	   ('BH000006','Nau an cho em','2023','TL001','2.mp3','ab67616d0000b273bcbd4a38b226dbd8041ac4b2.jpg','TG000002',0),
	   ('BH000007','Cho toi lang thang','2018','TL004','3.mp3','ab67616d0000b273b827c1001f7c9e62ffe61b60.jpg','TG000002',0),
	   ('BH000008','Loi nho','2019','TL004','4.mp3','ab67616d0000b273539ffc79122ccceb066f5340.jpg','TG000002',0),
	   ('BH000009','Demons','2012','TL003','y2meta.com - Imagine Dragons - Demons (Official Music Video) (128 kbps).mp3','ab67616d0000b273b2b2747c89d2157b0b29fb6a.jpg','TG000003',0),
	   ('BH000010','Beliver','2017','TL003','y2meta.com - Imagine Dragons - Believer (Official Music Video) (128 kbps).mp3','ab67616d0000b273156aeddf54ed40b1d9d30c9f.jpg','TG000003',0),
	   ('BH000011','Thunder','2017','TL003','y2meta.com - Imagine Dragons - Thunder (128 kbps).mp3','ab67616d0000b273da2b332af81dde51d61a02bb.jpg','TG000003',0),
	   ('BH000012','Enemy','2022','TL003','y2meta.com - Imagine Dragons x J.I.D - Enemy (from the series Arcane League of Legends) (128 kbps).mp3','ab67616d0000b273fc915b69600dce2991a61f13.jpg','TG000003',0),
	   ('BH000013','Set Fire To The Rain ','2021','TL005','y2meta.com - Adele - Set Fire To The Rain (Live at The Royal Albert Hall) (128 kbps).mp3','ab67616d0000b273ee86592f5e11642b7032d306.jpg','TG000004',0),
	   ('BH000014','Rolling In The Deep','2021','TL005','y2meta.com - Adele - Rolling in the Deep (Official Music Video) (128 kbps).mp3','ab67616d0000b273400d915184024fd9b634da16.jpg','TG000004',0),
	   ('BH000015','Someone Like You','2011','TL005','y2meta.com - Adele - Someone Like You (Official Music Video) (128 kbps).mp3','ab67616d0000b2732118bf9b198b05a95ded6300.jpg','TG000004',0),
	   ('BH000016','Easy On Me','2020','TL006','y2meta.com - Adele - Easy On Me (Official Video) (128 kbps).mp3','ab67616d0000b27350dba34377a595e35f81b0e4.jpg','TG000004',0),
	   ('BH000017','Lover','2019','TL002','y2meta.com - Taylor Swift - Lover (Official Music Video) (128 kbps).mp3','ab67616d0000b273e787cffec20aa2a396a61647.jpg','TG000005',0),
	   ('BH000018','Cruel Summer','2019','TL002','y2meta.com - Taylor Swift - Cruel Summer (Official Audio) (128 kbps).mp3','ab67706c0000da84f46769dd328dfaca3ee7fb23.jpg','TG000005',0),
	   ('BH000019','Style','2014','TL002','y2meta.com - Taylor Swift - Style (128 kbps).mp3','ab67616d0000b27352b2a3824413eefe9e33817a.jpg','TG000005',0),
	   ('BH000020','Thang Tu La Loi Noi Doi Cua Em','2021','TL004','5.mp3','ab67616d0000b273bf7d3058bc206639f626da8b.jpg','TG000006',0),
	   ('BH000021','Xuan Thi','2020','TL007','6.mp3','ab67616d0000b273d85a7ce435c8e184d646002a.jpg','TG000006',0),
	   ('BH000022','Thang May Em Nho Anh?','2021','TL007','7.mp3','ab67616d0000b2739f1b369ada752a358c9bc157.jpg','TG000006',0),
	   ('BH000023','Vi Anh Dau Co Biet','2022','TL004','8.mp3','ab67616d0000b2732461003df8139247949c8a9d.jpg','TG000007',0),
	   ('BH000024','Buoc Qua Nhau','2022','TL007','9.mp3','ab67616d0000b2734eca4595da187b3a25eb9958.jpg','TG000007',0);



	   UPDATE BaiHat
SET TenBaiHat ='Buoc Qua Nhau',
LinkNhac = '9.mp3'
WHERE IDBaiHat = 'BH000024';



-- Tạo bảng CTAlbum
CREATE TABLE CTAlbum (
    IDCTAlbum NVARCHAR(15) PRIMARY KEY,
    IDAlbum NVARCHAR(15),
    IDBaiHat NVARCHAR(15),
    FOREIGN KEY (IDAlbum) REFERENCES Album(IDAlbum),
    FOREIGN KEY (IDBaiHat) REFERENCES BaiHat(IDBaiHat)
);

INSERT INTO CTAlbum(IDCTAlbum,IDAlbum,IDBaiHat)
VALUES ('CTA000001','AL000001','BH000001'),
       ('CTA000002','AL000001','BH000002'),
	   ('CTA000003','AL000001','BH000003'),
	   ('CTA000004','AL000002','BH000005'),
	   ('CTA000005','AL000002','BH000006'),
	   ('CTA000007','AL000003','BH000009'),
	   ('CTA000008','AL000003','BH000010'),
	   ('CTA000009','AL000004','BH000013'),
	   ('CTA000010','AL000004','BH000014'),
	   ('CTA000011','AL000005','BH000017'),
	   ('CTA000012','AL000005','BH000018'),
	   ('CTA000013','AL000006','BH000020'),
	   ('CTA000014','AL000006','BH000021'),
	   ('CTA000015','AL000007','BH000023'),
	   ('CTA000016','AL000007','BH000024');


-- Tạo bảng CamXuc
CREATE TABLE CamXuc (
    IDCamXuc NVARCHAR(15) PRIMARY KEY,
    IDBaiHat NVARCHAR(15),
    CamXuc NVARCHAR(100),
    FOREIGN KEY (IDBaiHat) REFERENCES BaiHat(IDBaiHat)
);

ALTER TABLE CamXuc
ADD IDUser NVARCHAR(15);
ALTER TABLE CamXuc
ADD CONSTRAINT FK_CamXuc_User FOREIGN KEY (IDUser) REFERENCES [User](IDUser);


INSERT INTO CamXuc(IDCamXuc,IDBaiHat,IDUser,CamXuc)
VALUES ('CX000001','BH000001','US000001','Like'),
       ('CX000002','BH000002','US000001','Like'),
	   ('CX000003','BH000003','US000001','Like'),
	   ('CX000004','BH000004','US000001','Like'),
	   ('CX000005','BH000005','US000001','Like'),
	   ('CX000006','BH000001','US000002','Like'),
	   ('CX000007','BH000002','US000002','Like'),
	   ('CX000008','BH000003','US000002','Like'),
	   ('CX000009','BH000004','US000003','Like'),
	   ('CX000010','BH000005','US000004',null);



-- Tạo bảng User
CREATE TABLE [User] (
    IDUser NVARCHAR(15) PRIMARY KEY,
    TenUser NVARCHAR(100),
    GioiTinh NVARCHAR(10),
    QuocTich NVARCHAR(100),
    SDT NVARCHAR(20),
    NgaySinh DATE
);

INSERT INTO [User](IDUser,TenUser,GioiTinh,QuocTich,SDT,NgaySinh)
VALUES ('US000001','Le Tien Nghia','Nam','VietNam','0329266438','2003-10-21'),
       ('US000002','Le Van Anh','Nam','VietNam','0329266438','2003-10-21'),
	   ('US000003','Le Ngoc Huyen','Nu','VietNam','0329278438','2003-10-21'),
	   ('US000004','Le Xuan Nam','Nam','VietNam','0329266938','2003-10-21');



--Tạo bảng TaiKhoan
CREATE TABLE TaiKhoan(
    TenTK NVARCHAR(30) PRIMARY KEY,
	MatKhau NVARCHAR(30),
	IDUser NVARCHAR(15),
	FOREIGN KEY (IDUser) REFERENCES [User](IDUser)
); 

INSERT INTO TaiKhoan(TenTK,MatKhau,IDUser)
VALUES ('nguoidung1','1234','US000001'),
       ('nguoidung2','1234','US000002'),
	   ('nguoidung3','1234','US000003'),
	   ('nguoidung4','1234','US000004');



-- Tạo bảng DSPhat
CREATE TABLE DSPhat (
    IDDSPHAT NVARCHAR(15) PRIMARY KEY,
    TenDSPhat NVARCHAR(100),
    ThoiGian DATETIME,
    IDUser NVARCHAR(15),
    FOREIGN KEY (IDUser) REFERENCES [User](IDUser)
);

INSERT INTO DSPhat(IDDSPHAT,TenDSPhat,ThoiGian,IDUser)
VALUES ('DSP000001','Danh sach 1','2024-05-07 09:30:00','US000001'),
       ('DSP000002','Danh sach 2','2024-05-06 09:30:00','US000001'),
	   ('DSP000003','Danh sach 1','2024-05-05 09:30:00','US000002'),
	   ('DSP000004','Danh sach 3','2024-05-05 09:30:00','US000003'),
	   ('DSP000005','Danh sach 2','2024-05-06 09:30:00','US000003'),
	   ('DSP000006','Danh sach 3','2024-05-07 09:30:00','US000004');


-- Tạo bảng DSGoiY
CREATE TABLE DSGoiY (
    IDDSGoiY NVARCHAR(15) PRIMARY KEY,
    TenDSGoiY NVARCHAR(100),
    IDUser NVARCHAR(15),
    FOREIGN KEY (IDUser) REFERENCES [User](IDUser)
);
INSERT INTO DSGoiY(IDDSGoiY,TenDSGoiY,IDUser)
VALUES ('DSGY000001','Danh sach 1','US000001'),
       ('DSGY000002','Danh sach 2','US000001'),
	   ('DSGY000003','Danh sach 1','US000002'),
	   ('DSGY000004','Danh sach 3','US000003'),
	   ('DSGY000005','Danh sach 2','US000003'),
	   ('DSGY000006','Danh sach 3','US000004');




-- Tạo bảng CTDSPHAT
CREATE TABLE CTDSPHAT (
    IDCTDSPhat NVARCHAR(15) PRIMARY KEY,
    IDDSPhat NVARCHAR(15),
    IDBaiHat NVARCHAR(15),
    FOREIGN KEY (IDDSPhat) REFERENCES DSPhat(IDDSPHAT),
    FOREIGN KEY (IDBaiHat) REFERENCES BaiHat(IDBaiHat)
);
INSERT INTO CTDSPHAT(IDCTDSPhat,IDDSPhat,IDBaiHat)
VALUES ('CTP0000001','DSP000001','BH000001'),
       ('CTP0000002','DSP000001','BH000003'),
	   ('CTP0000003','DSP000001','BH000004'),
	   ('CTP0000004','DSP000001','BH000005'),
	   ('CTP0000005','DSP000002','BH000006'),
	   ('CTP0000006','DSP000002','BH000010'),
	   ('CTP0000007','DSP000002','BH000011'),
	   ('CTP0000008','DSP000002','BH000012');




-- Tạo bảng CTDSDGoiY
CREATE TABLE CTDSDGoiY (
    IDCTDSGoiY NVARCHAR(15) PRIMARY KEY,
    IDDSGoiY NVARCHAR(15),
    IDBaiHat NVARCHAR(15),
    FOREIGN KEY (IDDSGoiY) REFERENCES DSGoiY(IDDSGoiY),
    FOREIGN KEY (IDBaiHat) REFERENCES BaiHat(IDBaiHat)
);


INSERT INTO CTDSDGoiY(IDCTDSGoiY,IDDSGoiY,IDBaiHat)
VALUES ('CTGY0000001','DSGY000001','BH000001'),
       ('CTGY0000002','DSGY000001','BH000002'),
	   ('CTGY0000003','DSGY000001','BH000003'),
	   ('CTGY0000004','DSGY000001','BH000004'),
	   ('CTGY0000005','DSGY000001','BH000009'),
	   ('CTGY0000006','DSGY000001','BH000010');