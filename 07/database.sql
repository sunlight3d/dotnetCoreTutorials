CREATE DATABASE WinformExam;
USE WinformExam;
--DROP TABLE tblClass;
--DROP TABLE tblStudent;
CREATE TABLE tblClass(
	ClassCode int NOT NULL identity PRIMARY KEY,
	ClassName nvarchar(30),
	NumberOfPeople int,
);
CREATE TABLE tblStudent(
	StudentCode int NOT NULL identity PRIMARY KEY,
	StudentName nvarchar(30),
	Gender bit,
	PlaceOfBirth datetime,
	Address nvarchar(255),
	ClassCode int NOT NULL,
	UserName nvarchar(30),
	Password nvarchar(30),
);
ALTER TABLE tblStudent 
ADD CONSTRAINT FK_ClassStudent
FOREIGN KEY (ClassCode) REFERENCES tblClass(ClassCode);