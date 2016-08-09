CREATE PROCEDURE [dbo].[usp_LOB_GetTotalSpendByMonth]
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

SELECT [spend_type], SUM(Case When [yearmonth] = @Time1 Then [spend_to_display] Else Null End) as Spend1, 
	SUM(Case When [yearmonth] = @Time2 Then [spend_to_display] Else Null End) as Spend2, 
	SUM(Case When [yearmonth] = @Time3 Then [spend_to_display] Else Null End) as Spend3, 
	SUM(Case When [yearmonth] = @Time4 Then [spend_to_display] Else Null End) as Spend4, 
	SUM(Case When [yearmonth] = @Time5 Then [spend_to_display] Else Null End) as Spend5, 
	SUM(Case When [yearmonth] = @Time6 Then [spend_to_display] Else Null End) as Spend6, 
	SUM(Case When [yearmonth] = @Time7 Then [spend_to_display] Else Null End) as Spend7, 
	SUM(Case When [yearmonth] = @Time8 Then [spend_to_display] Else Null End) as Spend8, 
	SUM(Case When [yearmonth] = @Time9 Then [spend_to_display] Else Null End) as Spend9, 
	SUM(Case When [yearmonth] = @Time10 Then [spend_to_display] Else Null End) as Spend10, 
	SUM(Case When [yearmonth] = @Time11 Then [spend_to_display] Else Null End) as Spend11, 
	SUM(Case When [yearmonth] = @Time12 Then [spend_to_display] Else Null End) as Spend12
FROM v_LOB_OUTPUT_spend_per_month 
GROUP BY [spend_type] 
ORDER BY [spend_type] ASC

END

GO
