USE [SMART]
GO

/****** Object:  View [dbo].[vw_SAPFinance_Quotes]    Script Date: 02/10/2014 10:11:25 ******/
DROP VIEW [dbo].[vw_SAPFinance_Quotes]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_SAPFinance_Quotes] --WITH SCHEMABINDING
AS
SELECT SQ.[Solicitation_Quotes_ID]
		,SQ.[QuoteRefNo]
		,SQ.[QuoteDate]
		,A.[article_id]
		,A.[article_title]
		,A.[citation]
		,A.[author]
		,J.[display_name] AS [Journal_Title]
		,SP.[Sales_Person_ID]
		,SP.[fullname] AS [Salesperson]
		,SP.[adis_office_id]
		,SC.[SAPAccountID] AS [SAPCRM_Account_ID]
		,SC.[SAPID] AS [SAPCRM_Contact_ID]
		,SC.[Surname] + ', ' + SC.[Firstname] AS [Client]
		,SC.[Company]
		FROM [dbo].[tbl_Solicitation_Quotes] AS SQ
		INNER JOIN [dbo].[tbl_Solicitation_Actions] AS SA ON SQ.[Solicitation_Action_ID] = SA.[Solicitation_Action_ID]
		INNER JOIN [dbo].[tbl_Solicitation_Contact] AS SC ON SA.[Solicitation_Contact_ID] = SC.[Solicitation_Contact_ID]
		INNER JOIN [dbo].[tbl_reprint_opportunity] AS RO ON SA.[Reprint_Opprtunity_ID] = RO.[reprint_opprtunity_id]
		INNER JOIN [dbo].[tbl_article] AS A ON RO.[article_id] = A.[article_id]
		INNER JOIN [dbo].[tbl_temp_journal] AS J ON A.[journal_id] = J.[journal_id]
		INNER JOIN [dbo].[qrySalesPerson] AS SP ON SA.[Sales_Person_ID] = SP.[Sales_Person_ID]
		WHERE ISNULL(SQ.[QuoteOutcomeID],6) = 6 -- Not Won or Lost status quotes

GO




