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
