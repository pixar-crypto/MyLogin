/*Nama	: Rifqih Syahrial Anwar
  NIM	: 0320200023*/


CREATE DATABASE MyPractice

USE MyPractice

CREATE TABLE TB_M_USER (ID int Primary Key Not Null, Username nvarchar(20) not null, password nvarchar(20) not null)
CREATE TABLE TB_M_PRODUCT (ID int Primary Key Not Null, itemName nvarchar(20) not null, design nvarchar(20) null, color nvarchar(20) null,
expiredDate datetime null)


SELECT * FROM TB_M_PRODUCT