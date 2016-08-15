CREATE PROCEDURE [dbo].[usp_LOB_GetTitle]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6),
	@AllSpend bit = 0
AS
BEGIN

SET NOCOUNT ON;

IF @AllSpend = 0
BEGIN
	SELECT SUM([spend_to_display]) as Spend
	FROM v_LOB_OUTPUT_spend_per_month
	WHERE [yearmonth] >= @StartMonth AND [yearmonth] <= @EndMonth
END
ELSE
BEGIN
	SELECT SUM([spend_to_display]) as Spend
	FROM v_LOB_OUTPUT_all_spend
	WHERE [yearmonth] >= @StartMonth AND [yearmonth] <= @EndMonth
END

END
GO
