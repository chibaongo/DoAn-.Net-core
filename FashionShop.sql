USE Classroom
GO

DELETE FROM Classroom;
DBCC CHECKIDENT ('Classroom.dbo.Carts', RESEED, 0);
GO
DELETE FROM Student;
DBCC CHECKIDENT ('Classroom.dbo.InvoiceDetails', RESEED, 0);
GO


