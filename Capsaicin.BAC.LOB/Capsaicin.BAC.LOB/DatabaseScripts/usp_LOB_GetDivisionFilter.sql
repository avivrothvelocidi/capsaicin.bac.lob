CREATE PROCEDURE [dbo].[usp_LOB_GetDivisionFilter]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6),
	@LOB nvarchar(255) = ''
AS
BEGIN

SET NOCOUNT ON;

IF @LOB = ''
BEGIN
	SELECT DISTINCT([division]) 
	FROM LOB_OUTPUT_all_spend
	WHERE [yearmonth] >= @StartMonth AND [yearmonth] <= @EndMonth
	Order By [division] ASC
END
ELSE
BEGIN
	SELECT DISTINCT([division]) 
	FROM LOB_OUTPUT_all_spend
	WHERE [yearmonth] >= @StartMonth AND [yearmonth] <= @EndMonth
		AND LOB = @LOB
	Order By [division] ASC
END

END

GO
