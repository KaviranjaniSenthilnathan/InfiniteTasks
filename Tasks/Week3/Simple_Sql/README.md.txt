# Student Management System

## Day 1: SQL Server Fundamentals & Database Design

### Database Name
TrainingDB

### Tables Created

#### Students
- StudentID (Primary Key)
- StudentName
- Email
- DateOfBirth
- Gender
- MobileNo
- RegistrationDate

#### Trainers
- TrainerID (Primary Key)
- TrainerName
- Email
- Phone
- ExperienceYears

#### Courses
- CourseID (Primary Key)
- CourseName
- DurationWeeks
- TrainerID (Foreign Key)

#### Enrollments
- EnrollmentID (Primary Key)
- StudentID (Foreign Key)
- CourseID (Foreign Key)
- EnrollmentDate
- Status

---

## Primary Keys

- Students → StudentID
- Trainers → TrainerID
- Courses → CourseID
- Enrollments → EnrollmentID

---

## Foreign Keys

- Courses.TrainerID → Trainers.TrainerID
- Enrollments.StudentID → Students.StudentID
- Enrollments.CourseID → Courses.CourseID

---

## Relationships

### Trainers to Courses
- Relationship Type: One-to-Many (1:M)
- One Trainer can teach multiple Courses.

### Students to Enrollments
- Relationship Type: One-to-Many (1:M)
- One Student can have multiple Enrollment records.

### Courses to Enrollments
- Relationship Type: One-to-Many (1:M)
- One Course can have multiple Enrollment records.

### Students to Courses
- Relationship Type: Many-to-Many (M:N)
- Implemented using the Enrollments table.

---

## ER Diagram

ER Diagram created and saved in SQL Server Management Studio as:

TrainingDB_ERD

---

## Deliverables

- TrainingDB Database Created
- Tables Created
- Primary Keys Defined
- Foreign Keys Defined
- ER Diagram Created
- Relationship Documentation Completed

---

## Status

Day 1 Completed Successfully