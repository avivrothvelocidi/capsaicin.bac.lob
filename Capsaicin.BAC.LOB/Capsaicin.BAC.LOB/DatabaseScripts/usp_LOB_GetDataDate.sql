﻿CREATE PROCEDURE usp_LOB_GetDataDate
AS
BEGIN

SET NOCOUNT ON;

SELECT MAX([insert_date]) from LOB_OUTPUT_all_spend

END
GO
 