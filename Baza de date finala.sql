if not exists(SELECT* from sys.databases where name = 'CatalogueNew')
BEGIN
	create database CatalogueNew
END

use CatalogueNew

if not exists(Select * from sys.tables where name='Student')
begin
create table Student(
	id int primary key identity(1,1),
	CNP VARCHAR(10),
	sex VARCHAR(1),
	Nume VARCHAR(20),
	Prenume VARCHAR (20),
	Clasa VARCHAR(20)
)
end

if not exists (Select * from sys.tables where name='Profesor')
begin
create table Profesor(
	id int primary key identity(1,1),
	CNP VARCHAR(10),
	sex VARCHAR(1),
	Nume VARCHAR(20),
	Prenume VARCHAR (20)
)
end

if not exists (Select * from sys.tables where name='Materie')
begin
create table Materie(
	id int primary key identity(1,1),
	nume VARCHAR(30),
	ProfesorID int foreign key references Profesor(id),
)
end

if not exists (Select * from sys.tables where name='Nota')
begin
create table Nota(
	id int primary key identity(1,1),
	StudentID int foreign key references Student(id),
	MaterieID int foreign key references Materie(id),
	Data_nota date,
	Valoare int,
	Teza BIT not null
)
end

if not exists (Select * from sys.tables where name='Medie')
begin
Create table Medie(
	id int primary key identity(1,1),
	StudentID int foreign key references Student(id),
	MaterieID int foreign key references Materie(id),
	valoare int
)
end

If not exists (Select * from sys.tables where name='Absenta')
begin
Create table Absenta(
	id int primary key identity(1,1),
	StudentID int foreign key references Student(id),
	MaterieID int foreign key references Materie(id),
	Data_absenta date
	)
end

If not exists (Select * from sys.tables where name='Specializare')
begin
Create table Specializare(
	id int primary key identity(1,1),
	Nume varchar(30)
	)
end

If not exists (Select * from sys.tables where name='An_studiu')
begin
Create table An_studiu(
	id int primary key identity(1,1),
	an int
	)
end

If not exists (Select * from sys.tables where name='Clasa')
begin
Create table Clasa(
	id int primary key identity(1,1),
	DiriginteID int foreign key references Profesor(id),
	An_StudiuID int foreign key references An_studiu(id),
	SpecializareID int foreign key references Specializare(id),
	Nume Varchar(30)
	)
end

if not exists (Select * from sys.tables where name='Materie_clasa')
begin
Create table Materie_clasa(
	id int primary key identity(1,1),
	MaterieID int foreign key references Materie(id),
	ClasaID int foreign key references Clasa(id),
	AreTeza BIT not null
	)
end

CREATE PROCEDURE [dbo].[AddStudent]
	@CNP varchar(10),
	@sex VARCHAR(1),
	@Nume VARCHAR(20),
	@Prenume VARCHAR (20),
	@Clasa VARCHAR(20),
	@Id int output
AS
BEGIN
	insert into Student([CNP], [sex],[Nume],[Prenume],[Clasa]) values(@CNP, @sex,@Nume,@Prenume,@Clasa)
	select @Id = scope_identity()
END

CREATE PROCEDURE [dbo].[DeleteStudent]
	@id int
AS
BEGIN
	delete from Student
	where id = @id
END

drop  procedure [dbo].[GetAllStudents]
CREATE PROCEDURE [dbo].[GetAllStudents]
AS
BEGIN
	select [id],[CNP], [sex],[Nume],[Prenume],[Clasa] from Student
END


CREATE PROCEDURE [dbo].[ModifyStudent] 
	@ID int,
	@CNP varchar(10),
	@sex VARCHAR(1),
	@Nume VARCHAR(20),
	@Prenume VARCHAR (20),
	@Clasa VARCHAR (20)
AS
BEGIN
	update	Student
	set		[CNP] = @CNP, 
			[sex] = @sex,
			[Nume]= @Nume,
			[Prenume]=Prenume,
			[Clasa]= Clasa
	where	id = @ID;
END

CREATE PROCEDURE [dbo].[AddProfesor]
	@CNP VARCHAR(10),
	@sex VARCHAR(1),
	@Nume VARCHAR(20),
	@Prenume VARCHAR (20),
	@Id int output
AS
BEGIN
	insert into Profesor([CNP], [sex],[Nume],[Prenume]) values(@CNP, @sex,@Nume,@Prenume)
	select @Id = scope_identity()
END

CREATE PROCEDURE [dbo].[GetAllProfesori]
AS
BEGIN
	select [CNP], [sex],[Nume],[Prenume] from Profesor
END

CREATE PROCEDURE [dbo].[ModifyProfesor] 
	@ID int,
	@CNP varchar(10),
	@sex VARCHAR(1),
	@Nume VARCHAR(20),
	@Prenume VARCHAR (20)
AS
BEGIN
	update	Student
	set		[CNP] = @CNP, 
			[sex] = @sex,
			[Nume]= @Nume,
			[Prenume]=Prenume
	where	id = @ID
END

CREATE PROCEDURE [dbo].[DeleteProfesor]
	@id int
AS
BEGIN
	delete from Profesor
	where id = @id
END

CREATE PROCEDURE [dbo].[AddMaterie]
	@profesor int,
	@Nume VARCHAR(20),
	@Id int output
AS
BEGIN
	insert into Materie([nume], [ProfesorID]) values(@Nume,@profesor)
	select @Id = scope_identity()
END

Create Procedure [dbo].[GetAllMaterii]
as begin
	SELECT M.nume AS MaterieName, P.nume AS ProfesorName
FROM Materie M
JOIN Profesor P ON M.ProfesorID = P.id;
end

CREATE PROCEDURE [dbo].[ModifyMaterie] 
	@ID int,
	@Nume VARCHAR(20),
	@Profesor int
AS
BEGIN
	update	Materie
	set		[Nume]= @Nume,
			[ProfesorID]=@Profesor
	where	id = @ID
END

CREATE PROCEDURE [dbo].[DeleteMaterie]
	@id int
AS
BEGIN
	delete from Materie
	where id = @id
END

CREATE PROCEDURE [dbo].[AddNota]
	@StudentID int, 
	@MaterieID int,
	@Data_nota date,
	@Valoare int,
	@Teza BIT ,
	@id int output
AS
BEGIN
	insert into Nota([StudentID], [MaterieID],[Data_nota],[Valoare],[Teza]) 
	values(@StudentID,@MaterieID,@Data_nota,@Valoare,@Teza)
	select @Id = scope_identity()
END

Create Procedure [dbo].[GetAllNote]
as begin
	SELECT M.Data_nota AS Data_Nota, M.Valoare as Valoarem, M.Teza as Teza, P.nume AS StudentName,C.nume as MaterieNume
FROM Nota M
JOIN Student P ON M.StudentID = P.id
Join Materie C on M.MaterieID= C.id;
end

CREATE PROCEDURE [dbo].[ModifyNota] 
	@notaID int,
	@studentId int,
	@materieID int,
	@dataNota date,
	@valoare int,
	@teza BIT
AS
BEGIN
	update	Nota
	set		[StudentID]= @studentId,
			[MaterieID]=@materieID,
			[Data_nota]=@dataNota,
			[valoare]=@valoare,
			[Teza]= @teza
	where	id = @notaID
END

CREATE PROCEDURE [dbo].[DeleteNota]
	@id int
AS
BEGIN
	delete from Nota
	where id = @id
END

CREATE PROCEDURE [dbo].[AddMedie]
	@StudentID int, 
	@MaterieID int,
	@Valoare int,
	@id int output
AS
BEGIN
	insert into Medie([StudentID], [MaterieID],[Valoare]) 
	values(@StudentID,@MaterieID,@Valoare)
	select @Id = scope_identity()
END

Create Procedure [dbo].[GetAllMedii]
as begin
	SELECT M.Valoare as Valoarem, P.nume AS StudentName,C.nume as MaterieNume
FROM Medie M
JOIN Student P ON M.StudentID = P.id
Join Materie C on M.MaterieID= C.id;
end

CREATE PROCEDURE [dbo].[ModifyMedie] 
	@notaID int,
	@studentId int,
	@materieID int,
	@valoare int
AS
BEGIN
	update	Nota
	set		[StudentID]= @studentId,
			[MaterieID]=@materieID,
			[valoare]=@valoare
	where	id = @notaID
END

CREATE PROCEDURE [dbo].[DeleteMedie]
	@id int
AS
BEGIN
	delete from Medie
	where id = @id
END

CREATE PROCEDURE [dbo].[AddAbsenta]
	@StudentID int, 
	@MaterieID int,
	@data_absenta date,
	@id int output
AS
BEGIN
	insert into Absenta([StudentID], [MaterieID],[Data_absenta]) 
	values(@StudentID,@MaterieID,@data_absenta)
	select @Id = scope_identity()
END

Create Procedure [dbo].[GetAllAbsente]
as begin
	SELECT M.data_absenta AS Data_absenta, P.nume AS StudentName,C.nume as MaterieNume
FROM Absenta M
JOIN Student P ON M.StudentID = P.id
Join Materie C on M.MaterieID= C.id;
end

CREATE PROCEDURE [dbo].[ModifyAbsenta] 
	@absentaID int,
	@studentId int,
	@materieID int,
	@data_absenta date
AS
BEGIN
	update	Absenta
	set		[StudentID]= @studentId,
			[MaterieID]=@materieID,
			[data_absenta]=@data_absenta
	where	id = @absentaID
END

CREATE PROCEDURE [dbo].[DeleteAbsenta]
	@id int
AS
BEGIN
	delete from Absenta
	where id = @id
END

Create procedure  [dbo].[AddAnStudiu]
	@an int,
	@specId int output
	as begin
	insert into An_studiu([an]) 
	values(@an)
	select @specId = scope_identity()
end

Create procedure [dbo].[GetAllAnStudiu]
as begin
	Select an from An_studiu;
end

Create procedure [dbo].[ModifyAnStudiu]
@specID int,
@an int
as begin
	Update An_studiu
	set [an]=@an
	where [id]=@specID
end

Create procedure [dbo].[DeleteAnStudiu]
@id int
AS
BEGIN
	delete from An_studiu
	where id = @id
END


Create procedure  [dbo].[AddSpecializare]
	@nume varchar(30),
	@specId int output
	as begin
	insert into Specializare([Nume]) 
	values(@nume)
	select @specId = scope_identity()
end

Create procedure [dbo].[GetAllSpecializari]
as begin
	Select nume from Specializare;
end

Create procedure [dbo].[ModifySpecializare]
@specID int,
@nume varchar(30)
as begin
	Update Specializare
	set [Nume]=@nume
	where [id]=@specID
end

Create procedure [dbo].[DeleteSpecializare]
@id int
AS
BEGIN
	delete from Specializare
	where id = @id
END

CREATE PROCEDURE [dbo].[AddClasa]
	@DiriginteID int ,
	@An_StudiuID int ,
	@SpecializareID int,
	@Nume Varchar(30),
	@id int output
AS
BEGIN
	insert into Clasa([DiriginteID], [An_StudiuID],[SpecializareID],[Nume]) 
	values(@DiriginteID,@An_StudiuID,@SpecializareID,@Nume)
	select @Id = scope_identity()
END

Create Procedure [dbo].[GetAllClasa]
as begin
	SELECT M.Nume AS Data_Nota, P.nume AS DirigntaName,C.Nume as SpecializarezNume
FROM Clasa M
JOIN Profesor P ON M.id = P.id
Join Specializare C on M.id= C.id;
end

Create procedure [dbo].[GetClaseBySpecializare]
@specializareID int
as begin
Select nume from Clasa where Clasa.SpecializareID =@specializareID
end

CREATE PROCEDURE [dbo].[ModifyClasa] 
	@ClasaID int,
	@DiriginteID int ,
	@An_StudiuID int ,
	@SpecializareID int,
	@Nume Varchar(30)
AS
BEGIN
	update	Clasa
	set		[DiriginteID]= @DiriginteID,
			[An_StudiuID]=@An_StudiuID,
			[SpecializareID]=@SpecializareID
	where	id = @ClasaID
END

CREATE PROCEDURE [dbo].[DeleteClasa]
	@id int
AS
BEGIN
	delete from Clasa
	where id = @id
END


drop procedure [dbo].[GetAllProfesori]
CREATE PROCEDURE [dbo].[GetAllProfesori]
AS
BEGIN
	select [id], [CNP], [sex],[Nume],[Prenume] from Profesor

END

Drop procedure [dbo].[GetAllMaterii]
Create Procedure [dbo].[GetAllMaterii]
as begin
	SELECT M.id as MaterieID, M.nume AS MaterieName, P.nume AS ProfesorName
FROM Materie M
JOIN Profesor P ON M.ProfesorID = P.id;
end

drop Procedure [dbo].[GetAllNote]
Create Procedure [dbo].[GetAllNote]
as begin
	SELECT M.id as NotaID, M.Data_nota AS Data_Nota, M.Valoare as Valoarem, M.Teza as Teza, P.nume AS StudentName,C.nume as MaterieNume
FROM Nota M
JOIN Student P ON M.StudentID = P.id
Join Materie C on M.MaterieID= C.id;
end

Drop Procedure [dbo].[GetAllMedii]
Create Procedure [dbo].[GetAllMedii]
as begin
	SELECT M.id AS Medieid, M.Valoare as Valoarem, P.nume AS StudentName,C.nume as MaterieNume
FROM Medie M
JOIN Student P ON M.StudentID = P.id
Join Materie C on M.MaterieID= C.id;
end

Drop procedure [dbo].[GetAllAbsente]
Create Procedure [dbo].[GetAllAbsente]
as begin
	SELECT M.id as AbsentaID, M.data_absenta AS Data_absenta, P.nume AS StudentName,C.nume as MaterieNume
FROM Absenta M
JOIN Student P ON M.StudentID = P.id
Join Materie C on M.MaterieID= C.id;
end

drop procedure [dbo].[GetAllAnStudiu]
Create procedure [dbo].[GetAllAnStudiu]
as begin
	Select [id] ,[an] from An_studiu;
end

drop procedure [dbo].[GetAllSpecializari]
Create procedure [dbo].[GetAllSpecializari]
as begin
	Select [id],[nume] from Specializare;
end

drop Procedure [dbo].[GetAllClasa]
Create Procedure [dbo].[GetAllClasa]
as begin
	SELECT M.id as MedieID, M.Nume AS Data_Nota, P.nume AS DirigntaName,C.Nume as SpecializarezNume
FROM Clasa M
JOIN Profesor P ON M.id = P.id
Join Specializare C on M.id= C.id;
end

drop procedure [dbo].[GetClaseBySpecializare]
Create procedure [dbo].[GetClaseBySpecializare]
@specializareID int
as begin
Select [id],[nume] from Clasa where Clasa.SpecializareID =@specializareID
end

Drop Procedure [dbo].[ModifyStudent]
CREATE PROCEDURE [dbo].[ModifyStudent] 
	@ID int,
	@CNP varchar(10),
	@sex VARCHAR(1),
	@Nume VARCHAR(20),
	@Prenume VARCHAR (20),
	@Clasa VARCHAR (20)
AS
BEGIN
	update	Student
	set		[CNP] = @CNP, 
			[sex] = @sex,
			[Nume]= @Nume,
			[Prenume]=@Prenume,
			[Clasa]=@Clasa
	where	id = @ID
END

Drop Procedure [dbo].[ModifyProfesor]
CREATE PROCEDURE [dbo].[ModifyProfesor] 
	@ID int,
	@CNP varchar(10),
	@sex VARCHAR(1),
	@Nume VARCHAR(20),
	@Prenume VARCHAR (20)
AS
BEGIN
	update	Profesor
	set		[CNP] = @CNP, 
			[sex] = @sex,
			[Nume]= @Nume,
			[Prenume]=@Prenume
	where	id = @ID
END



drop Procedure [dbo].[GetAllClasa]
Create Procedure [dbo].[GetAllClasa]
as begin
	SELECT M.id as ClasaID, M.Nume AS Nume, P.nume AS DirigintaName,C.Nume as SpecializarezNume,D.an as AnStudiu
FROM Clasa M
JOIN Profesor P ON M.DiriginteID = P.id
Join Specializare C on M.SpecializareID= C.id
Join An_Studiu D on M.An_StudiuID=D.id;
end

Delete from Clasa 

Create Procedure [dbo].[GetClaseByStudent]
@CNP varchar(10)
as begin
Select clasa from Student where @CNP =CNP
end

Create procedure [dbo].[GetAbsentebyStudent]
	@StudentCNP VARCHAR(10)
AS
BEGIN
	SELECT Absenta.Data_absenta, Materie.nume
	FROM Absenta
	INNER JOIN Student ON Absenta.StudentID = Student.id
	INNER JOIN Materie ON Absenta.MaterieID = Materie.id
	WHERE Student.CNP = @StudentCNP;
END

CREATE PROCEDURE [dbo].[GetNotebyStudent]
	@StudentCNP VARCHAR(10)
AS
BEGIN
	SELECT Nota.Data_nota, Materie.nume, Nota.Valoare, Nota.Teza
	FROM Nota
	INNER JOIN Student ON Nota.StudentID = Student.id
	INNER JOIN Materie ON Nota.MaterieID = Materie.id
	WHERE Student.CNP = @StudentCNP;
END

select * from Profesor

select * from Specializare

select * from An_studiu