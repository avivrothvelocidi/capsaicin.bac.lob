CREATE PROCEDURE [dbo].[usp_LOB_GetCampaignFilter]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6),
	@LOB nvarchar(255) = '',
	@Division nvarchar(255) = ''
AS
BEGIN

SET NOCOUNT ON;

IF @LOB = '' and @Division = ''
BEGIN
	SELECT DISTINCT(Campaign) 
	FROM LOB_OUTPUT_all_spend
	WHERE [yearmonth] >= @StartMonth AND [yearmonth] <= @EndMonth
	Order By Campaign ASC
END
ELSE
BEGIN
	IF @Division = ''
	BEGIN
		SELECT DISTINCT(Campaign) 
		FROM LOB_OUTPUT_all_spend
		WHERE [yearmonth] >= @StartMonth AND [yearmonth] <= @EndMonth
			AND LOB = @LOB
		Order By Campaign ASC
	END
	ELSE
	BEGIN
		SELECT DISTINCT(Campaign) 
		FROM LOB_OUTPUT_all_spend a
		WHERE [yearmonth] >= @StartMonth AND [yearmonth] <= @EndMonth
			AND LOB = @LOB AND a.division = @Division
		Order By Campaign ASC
	END
END

END

GO
