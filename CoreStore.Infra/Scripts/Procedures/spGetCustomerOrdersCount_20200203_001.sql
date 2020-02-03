CREATE PROCEDURE spGetCustomerOrdersCount
	@Document CHAR(11)
AS
   SELECT
   c.[Id],
   CONCAT(c.[FirstName],' ',c.[LastName]) AS [Name],
   c.[Document],
   Count(o.id) AS [Orders]
   FROM [Customer] c
   inner join 
   [order] o ON o.Id = c.[Id]
   Where c.Document = @Document
   Group by c.Id, c.FirstName, c.LastName, c.Document,o.Id