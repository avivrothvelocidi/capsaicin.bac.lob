CREATE PROCEDURE [dbo].[usp_LOB_GetTotalSpendByMedium]
	@Year nvarchar(6),
	@LOB nvarchar(50)
AS
BEGIN

SET NOCOUNT ON;

EXEC sp_get_spend_per_medium @p_year = @Year, @p_lob = @LOB

END

GO
