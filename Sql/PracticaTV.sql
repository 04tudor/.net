	--setam formatul de data  day-mouth-year
	set dateformat dmy
	--acest cod este folosit ca sa verifice daca exista aceasta baza de date,sa o stearga si sa o creeze din nou
	use master
	go
	if exists (select *from sys.databases where name='TV') 
	--comanda de ștergere a bazei de date înainte de a fi actualizată
	begin
	alter database TV set single_user with rollback immediate
	drop database TV
	end
	go
	create database TV --comanda de crearea a bazei de date
	go
	use TV
	go
	--cream tabelul Canal pentru a stoca date despre canalele tv 
	CREATE TABLE CANALTV(
	IdCanal int PRIMARY KEY,
	Denumire varchar(30),
	Tematica varchar(50)
	)
	--inseram in tabelul canalTV cateva canale 

	INSERT INTO CANALTV (IdCanal, Denumire, Tematica)
	VALUES (1, 'HBO', 'Filme si seriale'),
	(2, 'Discovery', 'Documentare'),
	(3, 'Antena 1', 'Stiri si divertisment'),
	 (4, 'National Geographic', 'Documentare si educatie'),
	 (5, 'Pro TV', 'Stiri si divertisment'),
	 (6, 'Disney Channel', 'Desene animate'),
	 (7, 'Animal Planet', 'Documentare despre animale'),
	 (8, 'MTV', 'Muzica si divertisment'),
	 (9, 'Eurosport', 'Sport si competiti'),
	 (10, 'History Channel', 'Documentare despre istorie'),
	 (11, 'TVR 1', 'Stiri si emisiuni culturale'),
	 (12, 'Cartoon Network', 'Desene animate'),
	 (13, 'Euforia Lifestyle', 'Emisiuni despre viata sanatoasa si sport'),
	 (14, 'Digi Sport', 'Canal sportiv'),
	 (15, 'Realitatea Plus', 'Stiri si emisiuni politice')

	 SELECT * from CANALTV
	 --cream tabelul Emisiuni pentru a stoca datele despre emisiunile noastre tv

	CREATE TABLE EMISIUNITV(
	IdEmisiune int PRIMARY KEY,
	IdCanal int FOREIGN KEY REFERENCES CANALTV(IdCanal),
	Denumire varchar(30),
	Limba varchar(30),
	Ora time,
	DurataMin int,
	Tip varchar(50),
	audienta int 
	)

	--in acest tabel vom insera emisiunile noastre anulate
	CREATE TABLE EMISIUNIANULATE(
	IdEmisiune int ,
	Denumire varchar(30),
	Ora time,

	)


	--DROP TABLE EMISIUNIANULATE
	--inseram date in tabelul nostru emisiuni TV
	INSERT INTO EMISIUNITV (IdEmisiune, IdCanal, Denumire, Limba, Ora, DurataMin, Tip, audienta)
	VALUES (1, 1, 'Game of Thrones', 'Engleza', '20:00', 60, 'Serial', 1000000),
	(2, 1, 'Westworld', 'Engleza', '21:00', 60, 'Serial', 800000),
	(3, 2, 'Planeta Pamant', 'Romana', '18:00', 30, 'Documentar', 50000),
	(4, 2, 'Universul Cunoasterii', 'Romana', '19:00', 60, 'Documentar', 70000),
	(5, 3, 'Observator', 'Romana', '19:00', 30, 'Stiri', 2000000),
	(6, 3, 'X Factor', 'Romana', '20:00', 120, 'Divertisment', 1500000),
	(7, 4, 'Viata in salbaticie', 'Engleza', '18:30', 60, 'Documentar', 50000),
	(8, 5, 'Stiri de seara', 'Romana', '20:00', 30, 'Stiri', 1800000),
	(9, 5, 'The Voice', 'Engleza', '21:00', 120, 'Divertisment', 1000000),
	(10, 6, 'Curiosul George', 'Romana', '19:45', 90, 'Desene animate', 500000),
	(11, 6, 'Stiri sportive', 'Romana', '22:00', 15, 'Stiri', 400000),
	(12, 7, 'Top Gear', 'Engleza', '20:00', 60, 'Divertisment', 300000),
	(13, 7, 'Serial American Horror Story', 'Engleza', '22:00', 60, 'Serial', 200000),
	(14, 8, 'The Big Bang Theory', 'Engleza', '19:30', 30, 'Serial', 500000),
	(16, 9, 'Mireasa', 'Romana', '19:00', 90, 'Reality Show', 1000000),
	 (17, 9, 'Masterchef', 'Romana', '21:00', 120, 'Divertisment', 800000),
	 (18, 10, 'Talk Show', 'Engleza', '20:30', 60, 'Interviu', 400000),
	 (19, 10, 'Tiruri cu experienta', 'Romana', '22:00', 30, 'Documentar', 300000),
	 (20, 11, 'Emisiunea lui Capatos', 'Romana', '23:00', 90, 'Talk Show', 700000),
	 (21, 11, 'Filme de actiune', 'Engleza', '01:00', 120, 'Filme', 500000),
	 (22, 12, 'Emisiunea lui Badea', 'Romana', '19:00', 120, 'Desene animate', 900000),
	(24, 2, 'Vremea', 'Romana', '20:00', 15, 'Stiri', 100000),
	(25, 3, 'Romanii au talent', 'Romana', '20:30', 120, 'Divertisment', 2000000),
	(26, 4, 'Discovery Channel', 'Engleza', '19:00', 60, 'Documentar', 300000),
	(27, 4, 'Echipa de interventii', 'Romana', '21:00', 60, 'Reality Show', 400000),
	(28, 5, 'Campionatul European de Fotbal', 'Engleza', '21:00', 120, 'Sport', 800000),
	(29, 6, 'Henry', 'Engleza', '17:00', 180, 'Desene animate', 500000),
	(30, 7, 'Serial Sopranos', 'Engleza', '22:00', 60, 'Serial', 150000),
	(31, 8, 'Emisiunea lui Jimmy Fallon', 'Engleza', '23:00', 60, 'Talk Show', 200000),
	(32, 9, 'Romanias Next Top Model', 'Romana', '20:00', 90, 'Reality Show', 300000),
	(33, 10, 'Circul Globus', 'Romana', '19:30', 120, 'Spectacol', 100000),
	(34, 11, 'Filme romantice', 'Engleza', '23:00', 120, 'Filme', 400000),
	(35, 12, 'Exatlon', 'Romana', '21:00', 90, 'Desene animate', 600000),
	(36, 1, 'Formula 1', 'Engleza', '18:00', 120, 'Sport', 500000),
	(37, 2, 'Stiri locale', 'Romana', '19:00', 30, 'Stiri', 50000),
	(38, 3, 'Jocuri Olimpice', 'Engleza', '20:00', 120, 'Sport', 700000),
	(39, 4, 'Animal Planet', 'Engleza', '21:00', 60, 'Documentar', 200000),
	(40, 5, 'The Bachelor', 'Engleza', '22:00', 90, 'Reality Show', 400000),
	(41, 6, 'Romanias Got Talent', 'Romana', '20:00', 120, 'Divertisment', 1800000),
	(42, 7, 'Emisiunea lui Dan Negru', 'Romana', '22:00', 60, 'Talk Show', 300000),
	(43, 8, 'Emisiunea lui Ellen Degeneres', 'Engleza', '18:00', 60, 'Talk Show', 150000),
	(44, 6, 'Oraselul Vesel', 'Romana', '15:30', 90, 'Desene animate', 500000),
	(45, 6, 'Ninja', 'Engleza', '17:00', 60, 'Desene animate', 800000),
	(46, 12, 'Power Rangers', 'Engleza', '18:00', 50, 'Desene animate', 400000)
	--cream tabelul publicitate in care vom insera datele despre publicitatea dintre emisiuni
	CREATE TABLE PUBLICITATETV(
	IdPublicitate int ,
	IdCanal int FOREIGN KEY REFERENCES CANALTV(IdCanal),
	Denumire varchar(30),
	durataSec int
	)

	SELECT * FROM EMISIUNITV;
	--inseram date despre publicitate
	INSERT INTO PUBLICITATETV (IdPublicitate, IdCanal, Denumire, durataSec)
	VALUES (1, 1, 'Coca-Cola', 30),
	(2, 2, 'Pepsi', 20),
	(3, 3, 'McDonalds', 40),
	(4, 4, 'BMW', 15),
	(5, 5, 'Nivea', 25),
	(6, 6, 'Samsung', 35),
	(7, 7, 'Gucci', 20),
	(8, 8, 'Apple', 30),
	(9, 9, 'Ford', 15),
	(10, 10, 'Viorica Cosmetics', 20),
	(2, 3, 'Pepsi', 20),
	(2, 7, 'Pepsi', 20),
	(2, 9, 'Pepsi', 20),
		(8, 8, 'Apple', 30),
			(8, 9, 'Apple', 30),
				(8, 15, 'Apple', 30),
					(5, 5, 'Nivea', 25),
						(5, 3, 'Nivea', 25),
							(5, 2, 'Nivea', 25)


	GO 
	CREATE TABLE users ( --crearea tabelului pentru utilizatorii din aplicație
	username char(50) PRIMARY KEY
	,pass char(50) 
	)
	insert into users (username,pass) values
	('admin','admin')

	--in aceasta vedere se stocheaza cea mai vizionata emisiune dupa audienta
	CREATE VIEW EmisiuneVizionata as(
	SELECT c.IdCanal, e.Denumire AS 'Cea mai vizionata emisiune',e.audienta
FROM CANALTV c
JOIN EMISIUNITV e ON c.IdCanal = e.IdCanal
WHERE e.audienta = (
    SELECT MAX(audienta) 
    FROM EMISIUNITV 
    WHERE IdCanal = c.IdCanal

)
)
--in aceasta vedere se stocheaza date despre durata publicitatii pe fiecare canal
CREATE VIEW duratapublicitate as(
SELECT IdCanal, SUM(durataSec) as DurataTotalaSecunde
FROM PUBLICITATETV
GROUP BY IdCanal
)
--in aceasta vedere se stocheaza daate despre numarul de emisiuni ale fiecarui canal
CREATE VIEW numarmax as (SELECT c.Denumire, COUNT(*) as NumarEmisiuni
FROM CANALTV c
JOIN EMISIUNITV e ON c.IdCanal = e.IdCanal
GROUP BY c.Denumire
) 
--aceasta procedura afiseaza toate canalele dupa tematica dorita
CREATE PROCEDURE AfisareCanalTematica
    @Tip VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM CANALTV 
    INNER JOIN EMISIUNITV ON CANALTV.IdCanal = EMISIUNITV.IdCanal 
    WHERE EMISIUNITV.Tip = @Tip
END

EXEC AfisareCanalTematica 'Serial'
--in aceasta procedura afiseaza top 10 emisiuni dupa suma audientei emisiunilor sale
CREATE PROCEDURE top10
AS
BEGIN
    SELECT TOP 10 CanalTV.Denumire, SUM(EMISIUNITV.audienta) AS TotalViews
    FROM CANALTV
    INNER JOIN EMISIUNITV ON CANALTV.IdCanal = EMISIUNITV.IdCanal
    GROUP BY CanalTV.Denumire
    ORDER BY TotalViews DESC;
END
EXEC top10

--aceasta procedura calculeaza numarul de emisiuni si afiseaza descrescator
CREATE PROCEDURE NumarEmisiuniCanalTV
AS
BEGIN
    SELECT CANALTV.Denumire, COUNT(EMISIUNITV.IdEmisiune) AS 'NumarEmisiuni'
    FROM CANALTV
    LEFT JOIN EMISIUNITV ON CANALTV.IdCanal = EMISIUNITV.IdCanal
    GROUP BY CANALTV.Denumire
    ORDER BY COUNT(EMISIUNITV.IdEmisiune) DESC
END
EXEC NumarEmisiuniCanalTV
	--CREATE LOGIN Coretchi
	--with password ='Coretchi'
	--CREATE USER Tudor for login Coretchi