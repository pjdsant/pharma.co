USE [C:\USERS\SANTOS.11099\SOURCE\REPOS\SAC.PHARMA.CO\WEB.SAC\APP_DATA\CLIENTES.MDF]
GO

/****** Object:  StoredProcedure [dbo].[ins_Cliente]    Script Date: 2020-08-26 00:10:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





---------------------------------------------------------------------
--Stored Procedure: ins_Cliente
--Creation Date: 25/08/2020
--Written by: Paulo José dos Santos
--Purpose: Insere um novo Cliente na base de dados  
--Input Parameters: 
				--@nome				string
				--@usuario			string
				--@email			string
				--@senha			string
				
--Output Parameters: None  
--Return Status: None  
--Usage: Standard  
--Local Variables: None
--Called By: class ClienteController.cs
--Calls: None  
--Data Modifications:  
--Updates:
-- Date         Author  Review  Purpose  
--  
---------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ins_Cliente]
@nome				nvarchar(100),
@usuario			nvarchar(100),
@email			nvarchar(100),
@senha			nvarchar(100) 
as
INSERT INTO [dbo].[Cliente]
           ([Nome]
           ,[Usuario]
           ,[Email]
           ,[Senha])
     VALUES
           (@nome
           ,@usuario
           ,@email
           ,@senha)

GO

