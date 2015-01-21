USE [SMART]
GO

/****** Object:  View [dbo].[vw_SAPFinance_QuoteLines]    Script Date: 02/10/2014 10:11:25 ******/
DROP VIEW [dbo].[vw_SAPFinance_QuoteLines]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_SAPFinance_QuoteLines] WITH SCHEMABINDING
AS
SELECT QQ.[Quantity_ID]
	, QQ.[Quantity]
	, C.[Currency]
	, QQ.[PricePerReprintLocal]
	, QQ.[TotalPriceLocal]
	, QQ.[TotalPriceUS] AS [TotalPriceEUR]
	, QQ.[Translated]
	, QQ.[Covered]
	, QQ.[TranslatedLanguage]
	, SQ.[Solicitation_Quotes_ID]
	, SQ.[QuoteRefNo]
FROM [dbo].[tbl_Quote_Quantities] QQ 
INNER JOIN [dbo].[tbl_Solicitation_Quotes] SQ ON SQ.[Solicitation_Quotes_ID] = QQ.[Solicitation_Quotes_ID]
INNER JOIN [dbo].[tbl_Currency_SMS] C ON C.[Currency_ID] = QQ.[Currency_ID]

GO

CREATE UNIQUE CLUSTERED INDEX IDX_vw_SAPFinance_QuoteLines ON [dbo].[vw_SAPFinance_QuoteLines] (Quantity_ID);

GO





