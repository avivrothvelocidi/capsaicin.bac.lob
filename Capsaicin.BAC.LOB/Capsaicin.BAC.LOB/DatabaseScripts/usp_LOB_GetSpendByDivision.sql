SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_LOB_GetSpendByDivision]
	@QueryType bit = 0,
	@StartMonth nvarchar(6) = '',
	@EndMonth nvarchar(6) = '',
	@LOB nvarchar(1000) = '',
	@Division nvarchar(1000) = '',
	@Campaign nvarchar(1000) = '',
	@SpendType nvarchar(50) = null,
	@Year nvarchar(4) = ''
AS
BEGIN

SET NOCOUNT ON;

DECLARE @command nvarchar(max)

IF @QueryType = 1
BEGIN
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

	IF @Division =1
		SET @divisionClause = ' AND [division] != ''Merrill Lynch'' '

	DECLARE @spendTypeClause nvarchar(2000)
	SET @spendTypeClause = ''

	IF @SpendType = ''
		SET @spendTypeClause = ' AND [spend_type] IS NOT  NULL '
	ELSE IF @SpendType is not null
		SET @spendTypeClause = ' AND [spend_type] IN (' + @SpendType + ') '

	SET @command = 'SELECT [division], SUM([spend_to_display]) as Spend ' +
	'FROM LOB_OUTPUT_all_spend ' +
	'WHERE 1=1 ' + @spendTypeClause + @lobClause + @divisionClause + @campaignClause +
		'AND [yearmonth] >= ''' + @StartMonth + ''' AND [yearmonth] <= ''' + @EndMonth + ''' ' +
	'Group By [division] ' +
	'Order By SUM([spend_to_display]) DESC '

	print @command
	EXEC sp_sqlexec @command
END
ELSE
BEGIN
	IF @SpendType = '' OR @SpendType IS NULL
		SET @SpendType = '<BOTH>'
	print 'Spend Type: ' + @SpendType

	IF @LOB = '' OR @LOB IS NULL
		SET @LOB = '<ALL>'
	print 'LOB: ' + @LOB

	IF @Campaign = '' OR @Campaign IS NULL
		SET @Campaign = '<ALL>'

	print 'Campaign: ' + @Campaign

	EXEC sp_get_spend_per_medium @p_LOB = @LOB, @p_campaign = @Campaign, @p_year = @Year

	--SET @command = 'EXEC sp_get_spend_per_medium @p_LOB = ' + @LOB + ', @p_campaign = ' + @Campaign + ', @p_year = ' + @Year

	--print @command
	--exec sp_sqlexec @command
END

END

GO
