CREATE PROCEDURE [dbo].[usp_LOB_GetTitle]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6),
	@LOB nvarchar(1000) = '',
	@Campaign nvarchar(1000) = '',
	@Division nvarchar(1000) = ''
AS
BEGIN

SET NOCOUNT ON;

DECLARE @lobClause nvarchar(2000)
SET @lobClause = ''

IF @LOB != ''
BEGIN
	SET @lobClause = ' AND [LOB] IN (' + @LOB + ') '
END

DECLARE @campaignClause nvarchar(2000)
DECLARE @view nvarchar(50)
SET @campaignClause = ''
SET @view  = 'v_LOB_OUTPUT_spend_per_month'

IF @Campaign != ''
BEGIN
	SET @campaignClause = ' AND [Campaign] IN (' + @Campaign + ') '
	SET @view = 'v_LOB_OUTPUT_all_spend'
END

DECLARE @divisionClause nvarchar(2000)
SET @divisionClause = ''

IF @Division != ''
BEGIN
	SET @divisionClause = ' AND [division] IN (' + @Division + ') '
END

DECLARE @command nvarchar(max)

SET @command = 'SELECT SUM([spend_to_display]) as Spend ' + 
	'FROM ' + @view + ' ' +
	'WHERE [yearmonth] >= ''' + @StartMonth + ''' AND [yearmonth] <= ''' + @EndMonth + ''' ' + 
	@lobClause + @campaignClause + @divisionClause

exec sp_sqlexec @command

END

GO
