CREATE PROCEDURE spOrdenes
(@FromDate varchar(8) = '20220101',
 @ToDate varchar(8) = '20221231')
AS
BEGIN

	IF @ToDate IS NULL OR @ToDate = '' BEGIN
		SET @ToDate = CONVERT(varchar, GETDATE(), 101) 
	END

	SELECT 
		od.id,
		od.Fecha,
		od.CustomerId,
		ol.ProductId,
		pr.Name,
		pr.Description,
		pr.Price,
		cu.FirstName,
		cu.LastName
	FROM 
			[Order] od
		inner join OrderDetails ol on
			od.Id = ol.OrderId
		inner join Product pr on
			ol.ProductId = pr.Id
		inner join Customer cu on
			od.CustomerId = cu.Id
	WHERE
		1 = (case 
				when @FromDate IS NULL then 1 
				when @FromDate = '' then 1 
				when od.Fecha >= @FromDate AND od.Fecha < DATEADD(DD,1,@ToDate) then 1 
				else 0 end)

END