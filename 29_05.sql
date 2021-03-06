/*
CREATE PROCEDURE GetServices  @deleted int 
AS  
BEGIN  
   SELECT *
   FROM testdb.dbo.Services
   WHERE deleted = @deleted
   return  
END
*/
/*
CREATE FUNCTION GetUser (@hiddenId int)
RETURNS TABLE
AS 
RETURN (
SELECT firstName, lastName
FROM testdb.dbo.Users 
-- Filtramos el resultado para el cliente que pedimos
WHERE hiddenId = @hiddenId);
GO
select * from GetUser(184);
*/
--drop procedure GetUser
--execute GetServices 0
--execute GetUser 184, @firstName output, @lastName output

--select distinct(deleted) from Services;

select * from Services order by id
select * from ServiceImages order by id
select COUNT(*), deleted from Services
group by deleted;

select count(*), deleted, isAdmin, email, lastName 
from users
where hiddenId > 168 and firstName like '%e%'
group by deleted, isAdmin, email, lastName
order by lastName desc


select *
	from Services S
	inner join ServiceImages Si
	on S.id = Si.idService

select count(*)
	from Services S
	inner join ServiceImages Si
	on S.id = Si.idService

select S.*
	from Services S
	inner join ServiceImages Si
	on S.id = Si.idService
--solo muestra los resultados que tengan valor

select S.id, s.name, si.imageUrl, COUNT(*)
	from Services S
	inner join ServiceImages Si
	on S.id = Si.idService
	group by S.id, s.name, si.imageUrl

select S.id, s.name, si.imageUrl, COUNT(*)
	from Services S
	inner join ServiceImages Si
	on S.id = Si.idService
	group by S.id, s.name, si.imageUrl
	having si.imageUrl like '%_2.png'

select S.id, s.name, si.imageUrl, COUNT(*)
	from Services S
	left join ServiceImages Si
	on S.id = Si.idService
	group by S.id, s.name, si.imageUrl
	having si.imageUrl like '%_2.png'
	
-- CONSULTA PARA INSERCIONES MASIVAS INSERT - SELECT de los datos que obtengo luego son los datos que yo inserto
INSERT INTO ServiceImages (idService, imageUrl)
SELECT idService, imageUrl FROM ServiceImages

-- CREAR UNA TABLA A PARTIR DE UNA SELECT
SELECT * into ServicesImagesTemporal FROM ServiceImages
	
