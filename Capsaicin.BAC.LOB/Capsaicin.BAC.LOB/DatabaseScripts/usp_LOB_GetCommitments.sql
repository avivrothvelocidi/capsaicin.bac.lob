CREATE PROCEDURE [dbo].[usp_LOB_GetCommitments]
	@Year nvarchar(4)
AS
BEGIN

SET NOCOUNT ON;

SELECT [label], [committed_spend], [lob_allocation], [remaining_spend], [note] 
FROM LOB_OUTPUT_enterprise_commitments 
WHERE [the_year] = @Year
Order By [committed_spend] DESC

END

GO
