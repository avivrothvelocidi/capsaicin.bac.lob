CREATE PROCEDURE [dbo].[usp_LOB_GetRollup]
	@Year nvarchar(4)
AS
BEGIN

SET NOCOUNT ON;

Select sum([spend_to_display]) as Spend, 
	sum(case when [market] = 'National' then [spend_to_display] else null end) as NationalSpend, 
	sum(case when [market] != 'National' then [spend_to_display] else null end) as NonNationalSpend 
from v_LOB_Output_Market_Detail 
where [the_year] = @Year

END
GO
