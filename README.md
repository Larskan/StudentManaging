# Managing of Students - Database Schema Migrations

## Introduction

This project is centered around database schema migrations using two different methods:
* EF Code-First(Change-based migrations): Entity Framework Core is used to develop the database throughout new info and requirements for the Models.
* State-based migrations: The final Database is declared through SQL Scripts. Changes happens by making SQL files with versions, eg. V1_InitialSchema.sql. These scripts then update the database.

## GIT and Branching
Each branch will have a naming as such: feat/V#-changes-method.
* V# describes the version, like V1 for version 1.
* changes describe what happened in the code, what was added.
* method describe if EF Code-first(ef) or State-based was used(state)

## Basic Setup of main branch
Initialize Project:
```
dotnet new console -n StudentManaging
```
Ensuring we got the EF-CLI:
```
dotnet tool install --global dotnet-ef
```
Adding the Entire Framework Core:
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
Adding a gitignore:
```
dotnet new gitignore
```


## The Branches
feat/initial-schema
* -ef: Adding the Models: Student, Course, Enrollment and their FK and PK and migrating the database
* -state: Creating the V1_InitialSchema.sql and adding the Models: Student, Course, Enrollment and their FK and PK

feat/StudentMiddleName
* -ef: Update Student to contain Middlename attribute and update database migration
* -state: Creating the V2_AddStudentMiddleName.sql

feat/StudentBirthDate
* -ef: Update Student to contain DateOfBirth attribute and update database migration
* -state: Creating the V3_AddStudentBirthDate.sql

feat/InstructorModel
* -ef: Add Instructor Model with its attributes and add InstructorID FK to Course and update database migration
* -state: Creating the V4_AddInstructorModel.sql

feat/GradeRenaming
* -ef: Rename the Grade attribute in Enrollment to FinalGrade and update database migration
* -state: Creating the V5_GradeRenaming.sql

feat/DepartmentModel
* -ef: Add Department Model with its attributes and add relation to Instructor and update database migration
* -state: Creating the V6_AddDepartmentModel.sql

feat/CourseCreditModify
* -ef: Change attribute type of Credits in Course Model from integer to decimal and update database migration
* -state: Creating the V7_CourseCreditModify.sql