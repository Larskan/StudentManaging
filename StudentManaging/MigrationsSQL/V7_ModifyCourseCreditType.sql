-- Contains just the incremental changes for modifying the Credits column in the Courses table to be of type Decimal.
BEGIN TRANSACTION;
-- Change Credits column in Courses table from INT to DECIMAL(5,2)
ALTER TABLE Courses
ALTER COLUMN Credits DECIMAL(5, 2) NOT NULL;
GO

COMMIT;