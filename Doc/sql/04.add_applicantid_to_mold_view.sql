USE [ToolingManDB]
GO

/****** Object:  View [dbo].[MoldView]    Script Date: 10/08/2014 10:57:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[MoldView]
AS
SELECT     dbo.Mold.MoldNR, dbo.Mold.MoldTypeID, dbo.Mold.ProjectID, dbo.Project.Name AS ProjectName, dbo.MoldType.Name AS TypeName, 
                      dbo.MoldCategory.Name AS CateName, dbo.MoldCategory.MoldCateID, dbo.Mold.Name, dbo.Mold.State, dbo.Mold.Cuttedtimes, dbo.Mold.MaxCuttimes, 
                      dbo.Mold.CurrentCuttimes, dbo.Mold.MaxLendHour, dbo.Mold.ReleaseCycle, dbo.Mold.LastReleasedDate, dbo.Mold.MaintainCycle, dbo.Mold.LastMainedDate, 
                      dbo.StorageRecord.Date AS LastRecordDate, dbo.MoldLastRecord.StorageRecordNR, dbo.Mold.Producer, dbo.Mold.Weight, dbo.Mold.Material, 
                      dbo.StorageRecord.Destination, dbo.StorageRecord.OperatorId, dbo.StorageRecord.ApplicantId
FROM         dbo.Mold LEFT OUTER JOIN
                      dbo.MoldType ON dbo.Mold.MoldTypeID = dbo.MoldType.MoldTypeID LEFT OUTER JOIN
                      dbo.MoldCategory ON dbo.MoldType.MoldCateID = dbo.MoldCategory.MoldCateID LEFT OUTER JOIN
                      dbo.Project ON dbo.Mold.ProjectID = dbo.Project.ProjectID LEFT OUTER JOIN
                      dbo.MoldLastRecord ON dbo.Mold.MoldNR = dbo.MoldLastRecord.MoldNR LEFT OUTER JOIN
                      dbo.StorageRecord ON dbo.MoldLastRecord.StorageRecordNR = dbo.StorageRecord.StorageRecordNR

GO


