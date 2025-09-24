-- Initial database schema for StudentManaging
-- The State-based is written in SQL Server syntax, rather than the SQLite syntax used in the change-based migrations.

-- Transaction is to ensure they all succeed or fail together, easier to rollback if needed
BEGIN TRANSACTION;
CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    EnrollmentDate DATETIME
);

CREATE TABLE Courses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL
);

CREATE TABLE Enrollments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT,
    CourseId INT,
    Grade NVARCHAR(3),
    FOREIGN KEY (StudentId) REFERENCES Students(Id) ON DELETE CASCADE,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE
);

-- Indexes are for the database to quickly find the data, purely for performance optimization
CREATE INDEX "IX_Enrollments_CourseId" ON "Enrollments" ("CourseId");
CREATE INDEX "IX_Enrollments_StudentId" ON "Enrollments" ("StudentId");
COMMIT;