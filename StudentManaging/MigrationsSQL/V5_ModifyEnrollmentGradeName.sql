-- Contains just the incremental changes for modifying the Grade column in the Enrollments table to FinalGrade.

EXEC sp_rename 'Enrollments.Grade', 'FinalGrade', 'COLUMN';
