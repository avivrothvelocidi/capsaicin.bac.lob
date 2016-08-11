CREATE PROCEDURE [dbo].[usp_LOB_GetLOBFilter]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6)
AS
BEGIN

SET NOCOUNT ON;

SELECT DISTINCT([LOB]) 
FROM LOB_OUTPUT_all_spend
WHERE [yearmonth] >= @StartMonth AND [yearmonth] <= @EndMonth
Order By [LOB] ASC

END

GO
