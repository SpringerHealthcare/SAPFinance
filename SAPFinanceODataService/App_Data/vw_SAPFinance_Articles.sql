USE [SMART]
GO

/****** Object:  View [dbo].[vw_SAPFinance_Articles]    Script Date: 02/10/2014 10:11:25 ******/
DROP VIEW [dbo].[vw_SAPFinance_Articles]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_SAPFinance_Articles] --WITH SCHEMABINDING
AS
SELECT DISTINCT A.[article_id]
		,AT.[article_type_id]
		,AT.[article_type_desc]
		,A.[article_title]
		,A.[citation]
		,A.[author]
		,J.[journal_id]
		,J.[display_name] AS [journal_title]
		,P.[publisher_id]
		,P.[publisher_name] AS [publisher]
		,A.[Volume] AS [volume]
		,A.[Issue] AS [issue]
		,A.[No_of_Pages] AS [no_of_pages]
		,A.[Start_Page] AS [start_page]
		,A.[End_Page] AS [end_page]
		,YEAR(A.[date]) AS [pub_year]
		,MONTH(A.[date]) AS [pub_month]
		,A.[Medcomms]
		,A.[PMID]
		,A.[DOI]
		,A.[CCBY]
		,A.[CCBY-NC]
		,J.[ISBN_hardcover]
		,J.[ISBN_softcover]
		,J.[ISBN_ebook]
		,J.[ISSN_print]
		,J.[ISSN_electronic]
		,JT.[JournalTypeID] AS [product_type_id]
		,JT.[JournalTypeName] AS [product_type] 
--		,ROT.[drugs]
--		,ROT.[therapy_areas]
		FROM [dbo].[tbl_article] AS A
--		INNER JOIN [dbo].[tbl_reprint_opportunity] AS RO ON A.[article_id] = RO.[article_id]
--		INNER JOIN [dbo].[tbl_reprint_opportunity_terms] AS ROT ON RO.[reprint_opprtunity_id] = ROT.[reprint_opprtunity_id]
		INNER JOIN [dbo].[tbl_article_type] AS AT ON A.[article_type_id] = AT.[article_type_id]
		INNER JOIN [dbo].[tbl_temp_journal] AS J ON A.[journal_id] = J.[journal_id]
		INNER JOIN [dbo].[tbl_publisher] AS P ON P.[publisher_id] = J.[publisher_id]
		INNER JOIN [dbo].[tblJournalType] AS JT ON J.[JournalTypeID] = JT.[JournalTypeID]

GO










