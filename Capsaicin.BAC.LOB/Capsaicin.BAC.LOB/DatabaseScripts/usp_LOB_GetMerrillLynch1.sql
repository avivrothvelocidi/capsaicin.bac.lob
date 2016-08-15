CREATE PROCEDURE [dbo].[usp_LOB_GetMerrillLynch1]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6),
	@Campaigns nvarchar(1000) = '',
	@SpendType nvarchar(50) = null
AS
BEGIN

SET NOCOUNT ON;

DECLARE @campaignClause nvarchar(1100)

SET @campaignClause = ''

IF @Campaigns != ''
BEGIN
	SET @campaignClause = ' AND Campaign IN (' + @Campaigns + ') '
END

DECLARE @spendTypeClause nvarchar(1000)

SET @spendTypeClause = ''

IF @SpendType = ''
BEGIN
	SET @spendTypeClause = '[spend_type] IS NOT NULL AND '
END
ELSE
BEGIN
	IF @SpendType = 'estimated'
	BEGIN
		SET @spendTypeClause = '[spend_type] = ''Estimated'' AND '
	END
	ELSE
	BEGIN
		IF @SpendType = 'actual'
		BEGIN
			SET @spendTypeClause = '[spend_type] = ''Actual'' AND '
		END
	END
END


DECLARE @command nvarchar(max)

SET @command = 'SELECT [ML_Group], SUM([spend_to_display]) as Spend ' +
	'FROM v_LOB_OUTPUT_all_spend ' +
	'WHERE ' + @spendTypeClause + 
		'[ML_Group] != ''XX'' ' +  
		'AND [yearmonth] >= ''' + @StartMonth + ''' ' +
		'AND [yearmonth] <= ''' + @EndMonth + ''' ' +
		@campaignClause + 
	'Group By [ML_Group] ' +
	'Order By SUM([spend_to_display]) DESC '

exec sp_sqlexec @command


END
GO
