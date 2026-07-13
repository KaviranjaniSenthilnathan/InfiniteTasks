
SELECT DB_NAME() AS CurrentDatabase;

CREATE TABLE Trainers
(
    TrainerID INT IDENTITY(1,1) PRIMARY KEY,
    TrainerName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Specialization VARCHAR(100),
    PhoneNo VARCHAR(15)
);

CREATE TABLE Students
(
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Gender CHAR(1),
    DateOfBirth DATE,
    PhoneNo VARCHAR(15),
    CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Courses
(
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    DurationInDays INT NOT NULL,
    TrainerID INT NOT NULL,

    CONSTRAINT FK_Courses_Trainers
    FOREIGN KEY (TrainerID)
    REFERENCES Trainers(TrainerID)
);

CREATE TABLE Enrollments
(
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    EnrollmentDate DATE DEFAULT GETDATE(),
    Grade CHAR(2),

    CONSTRAINT FK_Enrollments_Students
    FOREIGN KEY(StudentID)
    REFERENCES Students(StudentID),

    CONSTRAINT FK_Enrollments_Courses
    FOREIGN KEY(CourseID)
    REFERENCES Courses(CourseID)
);

USE master;
GO

ALTER DATABASE EmployeeDB
SET SINGLE_USER
WITH ROLLBACK IMMEDIATE;
GO

ALTER DATABASE EmployeeDB
SET MULTI_USER;
GO