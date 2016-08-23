CREATE PROCEDURE [dbo].[usp_LOB_GetTotalSpendByMedium]
	@Year nvarchar(6),
	@LOB nvarchar(1000) = '<ALL>',
	@Division nvarchar(1000) = '<ALL>',
	@Campaign nvarchar(1000) = '<ALL>',
	@SpendType nvarchar(6) = '<BOTH>'
AS
BEGIN

SET NOCOUNT ON;

EXEC sp_get_spend_per_medium 
	@p_year = @Year, 
	@p_lob = @LOB, 
	@p_division = @Division,
	@p_campaign = @Campaign,
	@p_spend_type = @SpendType

END
GO
