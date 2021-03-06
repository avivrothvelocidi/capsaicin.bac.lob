﻿CREATE PROCEDURE [dbo].[usp_LOB_GetMLBreakdown]
	@StartMonth nvarchar(6),
	@EndMonth nvarchar(6)
AS
BEGIN

SET NOCOUNT ON;

SELECT [campaign], SUM([spend_to_display]) as Spend
FROM LOB_OUTPUT_all_spend 
WHERE [LOB] = 'GWIM' 
	and [Division] = 'Merrill Lynch' 
	AND [yearmonth] >= @StartMonth and [yearmonth] <= @EndMonth
Group By [campaign] 
Order By SUM([spend_to_display]) DESC


END
GO
