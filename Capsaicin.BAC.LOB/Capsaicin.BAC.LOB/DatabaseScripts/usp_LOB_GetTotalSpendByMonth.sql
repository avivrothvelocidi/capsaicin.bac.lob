CREATE PROCEDURE [dbo].[usp_LOB_GetTotalSpendByMonth]
	@LOB nvarchar(1000) = '',
	@Division nvarchar(1000) = '',
	@Campaign nvarchar(1000) = '',
	@SpendType nvarchar(50) = '',
	@Time1 nvarchar(6),
	@Time2 nvarchar(6),
	@Time3 nvarchar(6),
	@Time4 nvarchar(6),
	@Time5 nvarchar(6),
	@Time6 nvarchar(6),
	@Time7 nvarchar(6),
	@Time8 nvarchar(6),
	@Time9 nvarchar(6),
	@Time10 nvarchar(6),
	@Time11 nvarchar(6),
	@Time12 nvarchar(6)
AS
BEGIN

SET NOCOUNT ON;

DECLARE @view nvarchar(50)
DECLARE @isLOB bit
DECLARE @lobClause nvarchar(2000)

SET @view = 'v_LOB_OUTPUT_spend_per_month'

SET @isLOB = 0
SET @lobClause = ''

IF @LOB != ''
BEGIN
	SET @lobClause = ' [LOB] IN (' + @LOB + ') '
	SET @isLOB = 1
END

DECLARE @isCampaign bit
DECLARE @campaignClause nvarchar(2000)
SET @isCampaign = 0
SET @campaignClause = ''

IF @Campaign != ''
BEGIN
	SET @campaignClause = ' [Campaign] IN (' + @Campaign + ') '
	SET @view = 'v_LOB_Output_All_Spend'
	SET @isCampaign = 1
END

DECLARE @isDivision bit
DECLARE @divisionClause nvarchar(2000)
SET @isDivision = 0
SET @divisionClause = ''

IF @Division != ''
BEGIN
	SET @divisionClause = ' [division] IN (' + @Division + ') '
	SET @isDivision = 1
END

DECLARE @spendTypeClause nvarchar(2000)
SET @spendTypeClause = ' [spend_type] IS NOT  NULL '

IF @SpendType != ''
BEGIN
	SET @spendTypeClause = ' [spend_type] IN (' + @SpendType + ') '
END

DECLARE @command nvarchar(max)

SET @command = 'SELECT [spend_type], SUM(Case When [yearmonth] = ''' + @Time1 + ''' Then [spend_to_display] Else Null End) as Spend1, ' +
	'SUM(Case When [yearmonth] = ''' + @Time2 + ''' Then [spend_to_display] Else Null End) as Spend2, ' +
	'SUM(Case When [yearmonth] = ''' + @Time3 + ''' Then [spend_to_display] Else Null End) as Spend3, ' +
	'SUM(Case When [yearmonth] = ''' + @Time4 + ''' Then [spend_to_display] Else Null End) as Spend4, ' +
	'SUM(Case When [yearmonth] = ''' + @Time5 + ''' Then [spend_to_display] Else Null End) as Spend5, ' +
	'SUM(Case When [yearmonth] = ''' + @Time6 + ''' Then [spend_to_display] Else Null End) as Spend6, ' +
	'SUM(Case When [yearmonth] = ''' + @Time7 + ''' Then [spend_to_display] Else Null End) as Spend7, ' +
	'SUM(Case When [yearmonth] = ''' + @Time8 + ''' Then [spend_to_display] Else Null End) as Spend8, ' +
	'SUM(Case When [yearmonth] = ''' + @Time9 + ''' Then [spend_to_display] Else Null End) as Spend9, ' +
	'SUM(Case When [yearmonth] = ''' + @Time10 + ''' Then [spend_to_display] Else Null End) as Spend10, ' +
	'SUM(Case When [yearmonth] = ''' + @Time11 + ''' Then [spend_to_display] Else Null End) as Spend11, ' +
	'SUM(Case When [yearmonth] = ''' + @Time12 + ''' Then [spend_to_display] Else Null End) as Spend12 ' +
'FROM ' + @view + ' '

SET @command = @command + 'WHERE '
IF @isLOB = 1
	SET @command = @command + @lobClause

IF @isDivision = 1
BEGIN
	IF @isLOB = 1
		SET @command = @command + 'AND'
	SET @command = @command + @divisionClause
END

IF @isCampaign = 1
BEGIN
	IF @isLOB = 1 OR @isDivision = 1
		SET @command = @command + 'AND'
	SET @command = @command + @campaignClause
END

IF @isLOB = 1 OR @isDivision = 1 OR @isCampaign = 1
	SET @command = @command + 'AND'
SET @command = @command + @spendTypeClause

SET @command = @command + 'GROUP BY [spend_type] ' +
'ORDER BY [spend_type] ASC '

exec sp_sqlexec @command

END

GO
