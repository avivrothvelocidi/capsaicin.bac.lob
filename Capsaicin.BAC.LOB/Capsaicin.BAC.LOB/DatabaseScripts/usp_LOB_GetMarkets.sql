SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_LOB_GetMarkets]
	@Year nvarchar(4),
	@Market1 nvarchar(255)='',
	@Market2 nvarchar(255)='',
	@Market3 nvarchar(255)='',
	@Market4 nvarchar(255)='',
	@Market5 nvarchar(255)='',
	@Market6 nvarchar(255)='',
	@Market7 nvarchar(255)='',
	@Market8 nvarchar(255)='',
	@Market9 nvarchar(255)='',
	@Market10 nvarchar(255)='',
	@Market11 nvarchar(255)='',
	@Market12 nvarchar(255)='',
	@Market13 nvarchar(255)='',
	@Market14 nvarchar(255)='',
	@Market15 nvarchar(255)='',
	@Market16 nvarchar(255)=''
AS
BEGIN

SET NOCOUNT ON;

Select [LOB], 
	sum(case when [Market] = @Market1 then [spend_to_display] else null end) as Market1,
	sum(case when [Market] = @Market2 then [spend_to_display] else null end) as Market2,
	sum(case when [Market] = @Market3 then [spend_to_display] else null end) as Market3,
	sum(case when [Market] = @Market4 then [spend_to_display] else null end) as Market4,
	sum(case when [Market] = @Market5 then [spend_to_display] else null end) as Market5,
	sum(case when [Market] = @Market6 then [spend_to_display] else null end) as Market6,
	sum(case when [Market] = @Market7 then [spend_to_display] else null end) as Market7,
	sum(case when [Market] = @Market8 then [spend_to_display] else null end) as Market8,
	sum(case when [Market] = @Market9 then [spend_to_display] else null end) as Market9,
	sum(case when [Market] = @Market10 then [spend_to_display] else null end) as Market10,
	sum(case when [Market] = @Market11 then [spend_to_display] else null end) as Market11,
	sum(case when [Market] = @Market12 then [spend_to_display] else null end) as Market12,
	sum(case when [Market] = @Market13 then [spend_to_display] else null end) as Market13,
	sum(case when [Market] = @Market14 then [spend_to_display] else null end) as Market14,
	sum(case when [Market] = @Market15 then [spend_to_display] else null end) as Market15,
	sum(case when [Market] = @Market16 then [spend_to_display] else null end) as Market16
from v_LOB_Output_Market_Detail 	
where the_year = @Year
group by [LOB] order by [LOB]

END
GO
