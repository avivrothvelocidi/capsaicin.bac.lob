CREATE PROCEDURE [dbo].[usp_LOB_GetMerrillLynch]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6),
	@LOB nvarchar(1000) = '',
	@Division nvarchar(1000) = '',
	@Campaign nvarchar(1000) = '',
	@SpendType nvarchar(50) = '',
	@ResultType int = 1
AS
BEGIN

SET NOCOUNT ON;

DECLARE @lobClause nvarchar(2000)
SET @lobClause = ''

IF @LOB != ''
	SET @lobClause = ' AND [LOB] IN (' + @LOB + ') '

DECLARE @campaignClause nvarchar(2000)
SET @campaignClause = ''

IF @Campaign != ''
	SET @campaignClause = ' AND [Campaign] IN (' + @Campaign + ') '

DECLARE @divisionClause nvarchar(2000)
SET @divisionClause = ''

IF @Division != ''
	SET @divisionClause = ' AND [division] IN (' + @Division + ') '

DECLARE @spendTypeClause nvarchar(1000)
SET @spendTypeClause = ''

IF @SpendType = ''
	SET @spendTypeClause = '[spend_type] IS NOT NULL '
ELSE
	SET @spendTypeClause = '[spend_type] IN (' + @SpendType + ') '

DECLARE @command nvarchar(max)

IF @ResultType = 1
BEGIN
	SET @command = 'SELECT [ML_Group], SUM([spend_to_display]) as Spend ' +
		'FROM v_LOB_OUTPUT_all_spend ' +
		'WHERE ' + @spendTypeClause + 
			'AND [ML_Group] != ''XX'' ' +  
			'AND [yearmonth] >= ''' + @StartMonth + ''' ' +
			'AND [yearmonth] <= ''' + @EndMonth + ''' ' +
			@lobClause + @divisionClause + @campaignClause + 
		'Group By [ML_Group] ' +
		'Order By SUM([spend_to_display]) DESC '
END

IF @ResultType = 2
BEGIN
	SET @command = 'SELECT [Region], SUM([spend_to_display]) as Spend ' +
	'FROM v_LOB_OUTPUT_all_spend ' +
	'WHERE ' + @spendTypeClause + @lobClause + @divisionClause + @campaignClause +
		'AND [yearmonth] >= ''' + @StartMonth + ''' ' +
		'AND [yearmonth] <= ''' + @EndMonth + ''' ' +
	'Group By [Region] ' +
	'Order By SUM([spend_to_display]) DESC '
END

exec sp_sqlexec @command

END

GO
