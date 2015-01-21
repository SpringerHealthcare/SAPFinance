USE [SMART]
GO

/****** Object:  View [dbo].[vw_SAPFinance_Terms]    Script Date: 02/10/2014 10:11:25 ******/
DROP VIEW [dbo].[vw_SAPFinance_Terms]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_SAPFinance_Terms] --WITH SCHEMABINDING
AS
SELECT QT.qualified_term_id 
	, A.article_id
	, T.term_id
	, T.term
	, T.qualifier_id
	, Q.qualifer AS [qualifier]
	FROM tbl_article AS A
	INNER JOIN tbl_reprint_opportunity AS RO ON A.article_id = RO.article_id
	INNER JOIN tbl_qualified_term AS QT ON RO.reprint_opprtunity_id = QT.reprint_opprtunity_id
	INNER JOIN tbl_term AS T ON QT.term_id = T.term_id
	INNER JOIN tbl_qualifier AS Q ON T.qualifier_id = Q.qualifier_id

GO








