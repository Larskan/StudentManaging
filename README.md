# Managing of Students - Database Schema Migrations

## Introduction

This project is centered around database schema migrations using two different methods:
* EF Code-First(Change-based migrations): Entity Framework Core is used to develop the database throughout new info and requirements for the Models.
* State-based migrations: The final Database is declared through SQL Scripts. Changes happens by making SQL files with versions, eg. V1_InitialSchema.sql. These scripts then update the database.

## GIT and Branching
Each branch will have a naming as such: feat/changes-method.
* feat stands for Feature.
* changes describe what happened in the code, what was added or changed.
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
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
Adding a gitignore:
```
dotnet new gitignore
```

## My approach to Change-based migrations
I decided to work in SQLite, mostly because I want to get better at using it, but also because I think it made sense for this kind of project.
Since the database is just a single file, it makes it easy to version-control, move, or reset. 
SQLite was in my opinion, ideal for an incremental change approach, which change-based migrations are.
It allowed me to easily apply dotnet ef migrations add and dotnet ef database update.

This choice however, had the consequence that it became difficult to use the generation of migration artifacts for change-based migrations.
SQLite's syntax differs from SQL Server.
I did a similar approach instead using my branches, ensuring that each new branch only contained the migrations of the former branches and its own.
Until finally merging everything into Main, without any merge errors.

## My approach to State-based migrations
Since State-based migrations are all about creating the final version of a database, I used full schema sql files that can be run as query on any PC and create identical databases.
* This is useful for a full redeployment or a new database in a new environment.
For Version 2, 3, 5 and 7: I created another partial migration, it is instead an incremental change to an existing database.
* This is useful for developing environments or testing environments, without having to recreate the entire database.
* It is worth noting, these partial ones are not fully state-based, since they don't represent the entire database schema, they are there for some added flexibility.




## The Branches
feat/initial-schema
* -ef: Adding the Models: Student, Course, Enrollment and their FK and PK and migrating the database
* -state: Creating the V1_InitialSchema.sql and adding the Models: Student, Course, Enrollment and their FK and PK

feat/StudentMiddleName
* -ef: Update Student to contain Middlename attribute and update database migration
* -state: Creating the V2_AddStudentMiddleName.sql and V2_FullSchemaWithStudentMiddleName.sql

feat/StudentBirthDate
* -ef: Update Student to contain DateOfBirth attribute and update database migration
* -state: Creating the V3_AddStudentBirthdate.sql and V3_FullSchemaWithStudentBirthdate.sql

feat/InstructorModel
* -ef: Add Instructor Model with its attributes and add InstructorID FK to Course and update database migration
* -state: Creating the V4_FullSchemaWithInstructorModel.sql

feat/GradeRenaming
* -ef: Rename the Grade attribute in Enrollment to FinalGrade and update database migration
* -state: Creating the V5_ModifyEnrollmentGradeName.sql and V5_FullSchemaWithEnrollmentGradeRename.sql

feat/DepartmentModel
* -ef: Add Department Model with its attributes and add relation to Instructor and update database migration
* -state: Creating the V6_FullSchemaWithDepartmentModel.sql

feat/CourseCreditModify
* -ef: Change attribute type of Credits in Course Model from integer to decimal and update database migration
* -state: Creating the V7_ModifyCourseCreditType.sql and V7_FullSchemaWithCourseCreditTypeChange.sql

## For Change Based: Why Destructive Approach in 5. Rename Grade Attribute to FinalGrade in Enrollment-EF
For Sqlite the destructive approach is common, where it creates a copy of the table and drops the original, keeping the copied table with the changed attributes.
Of course the risk with destructive is it might cause a loss of data, where non destructive preserves all existing data.
But that is the reality of using SQLite, it doesnt support direct column renames in EF migrations, so EF uses destructive approach. 
For this particular project, I decided the risk was worth it, the schema itself is simple and no production data is at risk and the migration steps preserves values by copying them into the new tables.
In worst case scenarios, the earlier versions still got the data, so it would become a matter of rolling back to an earlier migration.

## For Change Based: Why Destructive Approach in 7. Modify the Course Credits Relation-EF
Since I am going from int to decimal, it isn't as destructive, as decimal to int would have been.
If I had gone from decimal to int I would have lost precision in the data, combined with the EF on SQLite rebuilding the data, there is a risk of data loss.
However since I am going from int to decimal, that particular risk is a non-issue.
I still have some risk due to the original table being dropped in the conversion, but it is an acceptable risk because the project is simple and I got the data preserved through earlier iterations.

## For State Based: Why Non-Destructive approach for 5. Rename Grade Attribute to FinalGrade in Enrollment-State
I am directly changing the Grade property to FinalGrade, because I can get away with it.
If I had scripts and stored procedures, there would be a risk of them breaking if I changed a propertys name.
However since I dont have those, I can get away with it with minimal risk, making it a valid approach.

## For State Based: Why Non-Destructive approach in 7. Modify the Course Credits Relation-State
The new type of decimal will not change anything already there, since the former type is integer. It will just allow more precision.
There is of course risk if certain stored procedures are setup to only work with integer, however since this project has no stored procedures, it is relatively risk-free to change the type from integer to decimal.
And in the worst case scenario, I do still have the earlier versions of the database, should it be necessary.