
IF db_id('EmpProj2') IS NULL CREATE DATABASE EmpProj2 ;
GO

-- if object_id('object_name', 'U') is null -- for table

USE EmpProj2

CREATE TABLE Employees(
	EmpId int NOT NULL,
	EmpName varchar(50) NOT NULL,
	Salary decimal(9,2), 
 CONSTRAINT PK_Employees PRIMARY KEY (EmpId) )

CREATE TABLE Projects(
	ProjId int NOT NULL,
	ProjName varchar(50) NOT NULL,
	Duration int , 
 CONSTRAINT PK_Projects PRIMARY KEY (ProjId) )

CREATE TABLE Assignments(
	EmpId int NOT NULL,
	ProjId int NOT NULL,
	Eval int,
 CONSTRAINT PK_Assignments PRIMARY KEY (EmpId, ProjId), 
 CONSTRAINT FK_Assignments_Employees 
   FOREIGN KEY(EmpId) REFERENCES Employees (EmpId)
   ON DELETE CASCADE
   ON UPDATE CASCADE,
 CONSTRAINT FK_Assignments_Projects 
   FOREIGN KEY(ProjId) REFERENCES Projects (ProjId) 
   ON DELETE NO ACTION
   ON UPDATE CASCADE)
GO

/***********************************************************************/
INSERT Projects (ProjId,  ProjName, Duration) VALUES (100, 'Project 1', 12);
INSERT Projects (ProjId,  ProjName, Duration) VALUES (200, 'Project 2', 18);
INSERT Projects (ProjId,  ProjName, Duration) VALUES (300, 'Project 3', 24);

/***********************************************************************/
INSERT Employees (EmpId, EmpName, Salary) VALUES (1, 'John', 70000.0);
INSERT Employees (EmpId, EmpName, Salary) VALUES (2, 'Mary', 75000.0);
INSERT Employees (EmpId, EmpName, Salary) VALUES (3, 'Paul', 80000.0);
INSERT Employees (EmpId, EmpName, Salary) VALUES (4, 'Bob', 72000.0);
GO
/***********************************************************************/
INSERT Assignments (EmpId, ProjId) VALUES (1, 100);
INSERT Assignments (EmpId, ProjId, Eval) VALUES (2, 100, 90);
INSERT Assignments (EmpId, ProjId) VALUES (2, 200);
INSERT Assignments (EmpId, ProjId, Eval) VALUES (3, 200, 95);
INSERT Assignments (EmpId, ProjId) VALUES (3, 300);
INSERT Assignments (EmpId, ProjId) VALUES (4, 300);
GO
/************************************************************************/

