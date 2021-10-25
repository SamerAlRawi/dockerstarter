USE [master]
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'WebApi')
  BEGIN
    CREATE DATABASE [WebApi]
END

-- add any additional setup here
