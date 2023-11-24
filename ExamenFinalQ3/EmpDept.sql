IF db_id('EmpDept') IS NULL CREATE DATABASE EmpDept;
GO

USE EmpDept;


CREATE TABLE Departments (
  DeptId INT NOT NULL PRIMARY KEY,
  Name VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Employees (
  EmpId INT NOT NULL PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
  Salary DECIMAL(10,2) NOT NULL,
  DeptId INT NOT NULL,
  CONSTRAINT FK_Employees_DeptId FOREIGN KEY (DeptId) REFERENCES Departments (DeptId) ON UPDATE CASCADE ON DELETE NO ACTION
);
GO


INSERT INTO Departments (DeptId, Name)
VALUES 
	(1, 'Marketing'),
	(2, 'Accounting'),
	(3, 'Finance'),
	(4, 'IT');
GO

INSERT INTO Employees (EmpId, Name, Salary, DeptId)
VALUES (1, 'Mary', 90000, 3),
       (3, 'John', 90000, 1),
       (7, 'Brian', 80000, 2),
       (14, 'Anne', 95000, 4),
       (32, 'James', 85000, 1);
GO