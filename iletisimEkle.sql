CREATE PROC iletisimEkle
@name NCHAR(20),
@surname NCHAR(20),
@phone VARCHAR(20),
@message NTEXT,
@email CHAR(100)
AS
BEGIN
INSERT INTO dbo.iletisim
(
isim,
soyisim,
telefon,
mesaj,
email
)
VALUES
(
@name,
@surname,
@phone,
@message,
@email
)
END

