CREATE PROCEDURE [dbo].[usp_LOB_GetYOY1]
	@Year1 nvarchar(4),
	@Year2 nvarchar(4),
	@Year3 nvarchar(4),
	@Grouping nvarchar(255)
AS
BEGIN

SET NOCOUNT ON;

DECLARE @command nvarchar(2000)

set @command = 'SELECT [Division], ' +
	'SUM(Case When [the_year] = ''' + @Year1 + ''' then [spend_to_display] else NULL end) as Spend1, ' +
	'SUM(Case When [the_year] = ''' + @Year2 + ''' and [spend_type] = ''Actual'' then [spend_to_display] else NULL end) as ActualSpend2, ' +
	'SUM(Case When [the_year] = ''' + @Year2 + ''' and [spend_type] = ''Estimated'' then [spend_to_display] else NULL end) as EstimatedSpend2, ' +
	'SUM(Case When [the_year] = ''' + @Year2 + ''' then [spend_to_display] else NULL end) as Spend2, ' +
	'SUM(Case When [the_year] = ''' + @Year3 + ''' then [spend_to_display] else NULL end) as Spend3 ' +
'From v_LOB_OUTPUT_YOY_comparison ' +
'where [LOB] = ''GCSBB'' ' + 
'Group By [' + @Grouping + '] ' +
'Order By [' + @Grouping + '] ASC '

EXEC sp_sqlexec @command

END
GO
