--/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT TOP (1000) [firstName]
--      ,[lastName]
--      ,[genger]
--      ,[dateOfBirth]
--      ,[mobile]
--      ,[email]
--      ,[joinDate]
--      ,[adress]
--      ,[membershipDuration]
--  FROM [the_gymD].[dbo].[NEW_CUSTMER]
--SELECT FROM * NEW_CUSTMER ;
SELECT   *     
FROM            NEW_CUSTMER 
WHERE firstName = 'ahmed' and lastName ='amin' and mobile='011';