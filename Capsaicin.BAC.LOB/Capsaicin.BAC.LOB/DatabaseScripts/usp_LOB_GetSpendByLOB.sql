CREATE PROCEDURE [dbo].[usp_LOB_GetSpendByLOB]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6),
	@LOB nvarchar(1000) = '',
	@Division nvarchar(1000) = '',
	@Campaign nvarchar(1000) = '',
	@SpendType nvarchar(50) = '',
	@IsLOBGrouping bit = 1
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

DECLARE @spendTypeClause nvarchar(2000)
SET @spendTypeClause = ' AND [spend_type] IS NOT  NULL '

IF @SpendType != ''
	SET @spendTypeClause = ' AND [spend_type] IN (' + @SpendType + ') '

DECLARE @dim nvarchar(50)
DECLARE @dimWhere nvarchar(50)

IF @IsLOBGrouping = 1
BEGIN
	SET @dim = '[LOB]'
	SET @dimWhere = 'AND [LOB] IS NOT NULL '
END
ELSE 
BEGIN
	SET @dim = '[Division]'
	SET @dimWhere = ' '
END

DECLARE @totalClause nvarchar(200)
SET @totalClause = 'SUM([firm_spend]) as [Total]'

IF @StartMonth < '201501'
	SET @totalClause = 'NULL AS [Null]'

DECLARE @command nvarchar(max)

SET @command = 'SELECT ' + @dim + ' as [Label], ' +
	'SUM( Case When [spend_type] = ''Actual'' Then [spend_to_display] Else Null End) as [Actual], ' +
	'SUM( Case When [spend_type] = ''Estimated'' Then [spend_to_display] Else Null End) as [Estimated], ' +
	@totalClause + ' ' +
'from LOB_OUTPUT_all_spend ' +
'WHERE [yearmonth] >= ''' + @StartMonth + ''' AND [yearmonth] <= ''' + @EndMonth + ''' ' +
	@lobClause + @divisionClause + @campaignClause + @spendTypeClause +
	@dimWhere +
'GROUP BY ' + @dim + ' ' +
'ORDER BY SUM([spend_to_display]) DESC '

print @command
exec sp_sqlexec @command

END

GO
