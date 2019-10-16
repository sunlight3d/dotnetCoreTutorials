CREATE DATABASE WinformExam;
USE WinformExam;
--DROP TABLE tblClass;
--DROP TABLE tblStudent;
CREATE TABLE tblClass(
	ClassCode int NOT NULL identity PRIMARY KEY,
	ClassName nvarchar(30),
	NumberOfPeople int,
);
SELECT * FROM tblClass;
DROP TABLE tblClass;
CREATE TABLE tblStudent(
	StudentCode int NOT NULL identity PRIMARY KEY,
	StudentName nvarchar(30),
	Gender bit,
	DateOfBirth datetime,
	Address nvarchar(255),
	ClassCode int NOT NULL,
	UserName nvarchar(30),
	Password nvarchar(30),
);
SELECT * FROM tblStudent;
DROP TABLE tblStudent;
ALTER TABLE tblStudent 
ADD CONSTRAINT FK_ClassStudent
FOREIGN KEY (ClassCode) REFERENCES tblClass(ClassCode);

SELECT tblClass.ClassName, tblStudent.StudentName, tblStudent.UserName, tblStudent.Address FROM tblClass 
INNER JOIN tblStudent 
ON tblClass.ClassCode=tblStudent.ClassCode 
ORDER BY tblClass.ClassName;

CREATE TRIGGER trg_InsertStudent
ON tblStudent AFTER INSERT AS
DECLARE @ClassCode AS INT
BEGIN
    set @ClassCode=(select ClassCode from inserted)
    UPDATE tblClass
    SET NumberOfPeople = NumberOfPeople+1
    WHERE ClassCode = @ClassCode;
END
DROP TRIGGER trg_InsertStudent;

INSERT INTO tblClass(ClassName, NumberOfPeople) 
VALUES('1A6', 0);
INSERT INTO tblStudent(StudentName, Gender, DateOfBirth, Address, ClassCode, UserName, Password)
VALUES('Nguyen Van A', 1, '1993-10-20', 'Address 1', 1, 'nguyenvana', '123456');


