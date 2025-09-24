-- Full Schema with Department Model
-- The State-based is written in SQL Server syntax, rather than the SQLite syntax used in the change-based migrations.

-- Transaction is to ensure they all succeed or fail together, easier to rollback if needed
BEGIN TRANSACTION;
CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    MiddleName NVARCHAR(100) NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    DateOfBirth DATETIME NULL,
    EnrollmentDate DATETIME
);

CREATE TABLE Courses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    InstructorId INT NULL,
    FOREIGN KEY (InstructorId) REFERENCES Instructors(Id) ON DELETE SET NULL -- If an instructor is deleted, set to NULL, since course still exists.
);

CREATE TABLE Enrollments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT,
    CourseId INT,
    FinalGrade NVARCHAR(3),
    FOREIGN KEY (StudentId) REFERENCES Students(Id) ON DELETE CASCADE,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE
);

CREATE TABLE Instructors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    HireDate DATETIME
);

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Budget DECIMAL(18, 2) NOT NULL,
    StartDate DATETIME NOT NULL,
    DepartmentHeadId INT NULL,
    FOREIGN KEY (DepartmentHeadId) REFERENCES Instructors(Id) ON DELETE SET NULL -- If a Department Head is deleted, set to NULL, since department still exists.
);

-- Indexes are for the database to quickly find the data, purely for performance optimization, usually for foreign keys
CREATE INDEX "IX_Enrollments_CourseId" ON "Enrollments" ("CourseId");
CREATE INDEX "IX_Enrollments_StudentId" ON "Enrollments" ("StudentId");
CREATE INDEX "IX_Courses_InstructorId" ON "Courses" ("InstructorId");
CREATE INDEX "IX_Departments_InstructorId" ON "Departments" ("InstructorId");
COMMIT;