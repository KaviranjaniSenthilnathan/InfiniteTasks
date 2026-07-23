CREATE DATABASE TrainingDB;
GO

USE TrainingDB;
GO

-- Trainers Table ---
CREATE TABLE Trainers
(
    TrainerID INT IDENTITY(1,1) PRIMARY KEY,
    TrainerName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    ExperienceYears INT
);

--- Courses Table ---
CREATE TABLE Courses
(
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    DurationWeeks INT,
    TrainerID INT,
    CONSTRAINT FK_Courses_Trainers
        FOREIGN KEY (TrainerID)
        REFERENCES Trainers(TrainerID)
);

--- Students Table ---
CREATE TABLE Students
(
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentName VARCHAR(100) NOT NULL,
    Age INT,
    Gender CHAR(1),
    Email VARCHAR(100) UNIQUE
);

--- Enrollments Table ---
CREATE TABLE Enrollments
(
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    EnrollmentDate DATE DEFAULT GETDATE(),

    CONSTRAINT FK_Enrollments_Students
        FOREIGN KEY(StudentID)
        REFERENCES Students(StudentID),

    CONSTRAINT FK_Enrollments_Courses
        FOREIGN KEY(CourseID)
        REFERENCES Courses(CourseID)
);

--------- DAY2 ---------

INSERT INTO Trainers(TrainerName,Email,ExperienceYears)
VALUES
('Ram','ram@training.com',8),
('Suresh','suresh@training.com',6),
('Priya','priya@training.com',5),
('Kiran','kiran@training.com',10);

INSERT INTO Courses(CourseName,DurationWeeks,TrainerID)
VALUES
('SQL Server',6,1),
('.NET Core',8,2),
('LINQ',2,2),
('Azure',6,3),
('Power BI',4,4);

INSERT INTO Students(StudentName,Age,Gender,Email)
VALUES
('Student1',21,'M','s1@mail.com'),
('Student2',22,'F','s2@mail.com'),
('Student3',20,'M','s3@mail.com'),
('Student4',23,'F','s4@mail.com'),
('Student5',24,'M','s5@mail.com'),
('Student6',22,'F','s6@mail.com'),
('Student7',21,'M','s7@mail.com'),
('Student8',20,'F','s8@mail.com'),
('Student9',23,'M','s9@mail.com'),
('Student10',24,'F','s10@mail.com'),
('Student11',22,'M','s11@mail.com'),
('Student12',23,'F','s12@mail.com'),
('Student13',21,'M','s13@mail.com'),
('Student14',20,'F','s14@mail.com'),
('Student15',24,'M','s15@mail.com'),
('Student16',22,'F','s16@mail.com'),
('Student17',21,'M','s17@mail.com'),
('Student18',23,'F','s18@mail.com'),
('Student19',20,'M','s19@mail.com'),
('Student20',22,'F','s20@mail.com');

INSERT INTO Enrollments(StudentID,CourseID)
VALUES
(1,1),(2,1),(3,1),(4,1),(5,1),
(6,2),(7,2),(8,2),(9,2),(10,2),
(11,3),(12,3),(13,3),(14,3),(15,3),
(16,4),(17,4),(18,4),(19,4),(20,4),
(1,2),(2,3),(3,4),(4,5),(5,2),
(6,3),(7,4),(8,5),(9,1),(10,3);

--- All Students ---
SELECT * FROM Students;

--- Students Enrolled in Courses ---
SELECT
    s.StudentName,
    c.CourseName
FROM Students s
INNER JOIN Enrollments e
    ON s.StudentID = e.StudentID
INNER JOIN Courses c
    ON e.CourseID = c.CourseID;

--- Students in SQL Server Course ---
SELECT s.StudentName
FROM Students s
INNER JOIN Enrollments e
ON s.StudentID=e.StudentID
WHERE e.CourseID=1;

--- Select Top 5 Students ---
SELECT TOP 5 *
FROM Students;

    --- Aggregate Queries ---
--- Total Students ---
SELECT COUNT(*) AS TotalStudents
FROM Students;

--- Course-wise Enrollment Count ---
SELECT
    c.CourseName,
    COUNT(*) AS EnrollmentCount
FROM Courses c
INNER JOIN Enrollments e
ON c.CourseID=e.CourseID
GROUP BY c.CourseName;

--- Average Age ---
SELECT AVG(Age) AS AverageAge
FROM Students;

--------- DAY3 ---------

--- Create View ---

CREATE VIEW vw_StudentCourses
AS
SELECT
    s.StudentID,
    s.StudentName,
    c.CourseID,
    c.CourseName,
    e.EnrollmentDate
FROM Students s
INNER JOIN Enrollments e
    ON s.StudentID = e.StudentID
INNER JOIN Courses c
    ON e.CourseID = c.CourseID;
GO
--- Execute view ---
SELECT * FROM vw_StudentCourses;

--- Procedure to Get Students by Course ---
CREATE PROC usp_GetStudentByCourse
    @CourseID INT
AS
BEGIN
    SELECT
        s.StudentID,
        s.StudentName,
        c.CourseName
    FROM Students s
    INNER JOIN Enrollments e
        ON s.StudentID=e.StudentID
    INNER JOIN Courses c
        ON e.CourseID=c.CourseID
    WHERE c.CourseID=@CourseID;
END
GO

--- Execute ---
EXEC usp_GetStudentByCourse 1;

--- User Defined Function ---
CREATE FUNCTION dbo.fn_CalculateGrade
(
    @Marks INT
)
RETURNS VARCHAR(5)
AS
BEGIN

    DECLARE @Grade VARCHAR(5);

    SET @Grade =
    CASE
        WHEN @Marks >= 90 THEN 'A'
        WHEN @Marks >= 80 THEN 'B'
        WHEN @Marks >= 70 THEN 'C'
        WHEN @Marks >= 60 THEN 'D'
        ELSE 'F'
    END;

    RETURN @Grade;

END
GO

--- Test Function ---
SELECT dbo.fn_CalculateGrade(85) AS Grade;

--- Create Indexes ---
CREATE INDEX IX_Student_Name
ON Students(StudentName);

CREATE INDEX IX_Enrollment_StudentID
ON Enrollments(StudentID);

CREATE INDEX IX_Enrollment_CourseID
ON Enrollments(CourseID);

----- Performance Exercise-----
--- Before index ---
SELECT *
FROM Students
WHERE StudentName='Student10';

---- After Index ----
CREATE INDEX X_Student_Name
ON Students(StudentName);

SELECT name
FROM sys.indexes
WHERE object_id = OBJECT_ID('Students');

SELECT name
FROM sys.indexes
WHERE object_id = OBJECT_ID('Enrollments');


