CREATE PROCEDURE [dbo].[GetOrdersForCompany]
AS
BEGIN
	SELECT c.name, o.description, o.order_id 
	FROM company c 
	INNER JOIN [order] o 
	ON c.company_id=o.company_id
END
