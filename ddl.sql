/*USE carrental
GO
/****** Object:  Table [dbo].[Coches]    Script Date: 31/05/2017 19:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coches](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[matricula] [nvarchar](10) NOT NULL,
	[idMarca] [bigint] NOT NULL,
	[idTipoCombustible] [bigint] NOT NULL,
	[color] [nvarchar](20) NULL,
	[cilindrada] [decimal](4, 2) NULL,
	[nPlazas] [smallint] NOT NULL,
	[fechaMatriculacion] [date] NULL,
 CONSTRAINT [PK_Coches] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 31/05/2017 19:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiposCombustible]    Script Date: 31/05/2017 19:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposCombustible](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposCombustible] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[V_N_COCHES_POR_MARCA]    Script Date: 31/05/2017 19:37:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_N_COCHES_POR_MARCA] AS
SELECT M.denominacion as Marca, count(C.id) as nCoches
FROM Marcas M
		LEFT JOIN Coches C on M.id = C.idMarca
GROUP BY M.denominacion
GO
SET IDENTITY_INSERT [dbo].[Coches] ON 

INSERT [dbo].[Coches] ([id], [matricula], [idMarca], [idTipoCombustible], [color], [cilindrada], [nPlazas], [fechaMatriculacion]) VALUES (2, N'TF-1000-BG', 1, 1, N'Negro', CAST(1.80 AS Decimal(4, 2)), 5, CAST(N'1996-10-12' AS Date))
INSERT [dbo].[Coches] ([id], [matricula], [idMarca], [idTipoCombustible], [color], [cilindrada], [nPlazas], [fechaMatriculacion]) VALUES (3, N'GC-4587-CC', 1, 2, N'Rojo', CAST(2.00 AS Decimal(4, 2)), 2, CAST(N'2001-01-23' AS Date))
INSERT [dbo].[Coches] ([id], [matricula], [idMarca], [idTipoCombustible], [color], [cilindrada], [nPlazas], [fechaMatriculacion]) VALUES (4, N'BBD6998', 2, 2, N'Amarillo', CAST(1.50 AS Decimal(4, 2)), 4, CAST(N'2003-05-14' AS Date))
SET IDENTITY_INSERT [dbo].[Coches] OFF
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([id], [denominacion]) VALUES (1, N'Seat')
INSERT [dbo].[Marcas] ([id], [denominacion]) VALUES (2, N'Toyota')
INSERT [dbo].[Marcas] ([id], [denominacion]) VALUES (3, N'Ferrari')
INSERT [dbo].[Marcas] ([id], [denominacion]) VALUES (4, N'Mercedes-Benz')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
SET IDENTITY_INSERT [dbo].[TiposCombustible] ON 

INSERT [dbo].[TiposCombustible] ([id], [denominacion]) VALUES (1, N'Gasolina')
INSERT [dbo].[TiposCombustible] ([id], [denominacion]) VALUES (2, N'Diésel')
INSERT [dbo].[TiposCombustible] ([id], [denominacion]) VALUES (3, N'Híbrido')
INSERT [dbo].[TiposCombustible] ([id], [denominacion]) VALUES (4, N'Eléctrico')
INSERT [dbo].[TiposCombustible] ([id], [denominacion]) VALUES (5, N'Hidrógeno')

SET IDENTITY_INSERT [dbo].[TiposCombustible] OFF
/*añado al campo nPlazas valor por defecto 5 
INSERT [dbo].[Coches] ([matricula], [idMarca], [idTipoCombustible], [color], [cilindrada], [fechaMatriculacion]) 
VALUES (N'BBD6998', 2, 2, N'Amarillo2', CAST(1.50 AS Decimal(4, 2)),  CAST(N'2003-05-14' AS Date))

no lo añado en el value y así no tengo que poner ningún valor para nPlazas
*/
ALTER TABLE [dbo].[Coches] ADD  DEFAULT ((5)) FOR [nPlazas]
GO
ALTER TABLE [dbo].[Coches]  
WITH CHECK ADD  
CONSTRAINT [FK_Coches_Marcas] FOREIGN KEY([idMarca])
REFERENCES [dbo].[Marcas] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Coches] CHECK CONSTRAINT [FK_Coches_Marcas]
GO
ALTER TABLE [dbo].[Coches]  WITH CHECK ADD  
CONSTRAINT [FK_Coches_TiposCombustible] 
FOREIGN KEY([idTipoCombustible])
REFERENCES [dbo].[TiposCombustible] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Coches] 
CHECK CONSTRAINT [FK_Coches_TiposCombustible]
GO
*/

SELECT * FROM V_N_COCHES_POR_MARCA;  
GO
/*
IDENT_CURRENT,donde se le pasa por parámetro el nombre de la tabla y nos devuelve el ultimo 
valor identity generado para esta tabla, sin importar el scope.
*/
/*
select IDENT_CURRENT('Coches') as 'último identity';
go
INSERT [dbo].[Coches] ([matricula], [idMarca], [idTipoCombustible], [color], [cilindrada], [fechaMatriculacion]) 
VALUES (N'BBD6998', 2, 2, N'Amarillo2', CAST(1.50 AS Decimal(4, 2)),  CAST(N'2003-05-14' AS Date))
go
*//*
-- CREAMOS UN PROCEDIMIENTO ALMACENADO
create PROCEDURE GET_COCHE_POR_MARCA
AS
BEGIN
	SELECT Coches.*, Marcas.denominacion as denominacionMarca
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
	--PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'
END

exec GET_COCHE_POR_MARCA;

CREATE PROCEDURE GET_COCHE_POR_MARCA_MATRICULA_PLAZAS
AS
BEGIN
    SELECT 
         M.denominacion as Marca
        ,C.matricula
        ,C.nPlazas
    FROM Marcas M
        INNER JOIN Coches C ON M.id = C.idMarca
    GROUP BY 
         M.denominacion
        ,C.matricula
        ,C.nPlazas
    ORDER BY nPlazas
END

alter PROCEDURE GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2
	@marca nvarchar(50) = null,
	@nPlazas smallint = null
AS
BEGIN
    SELECT 
         M.denominacion as Marca
        ,C.matricula
        ,C.nPlazas
    FROM Marcas M
        INNER JOIN Coches C ON M.id = C.idMarca
	Where 
		(M.denominacion like '%' + @marca + '%' 
		or @marca is null)
		and (C.nPlazas >= @nPlazas or @nPlazas is null)
    GROUP BY 
         M.denominacion
        ,C.matricula
        ,C.nPlazas
    ORDER BY nPlazas
END;

SELECT * FROM V_N_COCHES_POR_MARCA;  
GO

exec GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2
   @marca = 'toyota'
   ,@nPlazas = 2

select * from coches where id=2;

CREATE PROCEDURE GET_COCHE_POR_ID
	@iD bigint = null
AS
BEGIN
    SELECT * FROM Coches C
	Where (C.id = @iD  or @iD is null)
END;

CREATE PROCEDURE [dbo].[GET_COCHE_POR_MARCA_ID]
	@id bigint
AS
BEGIN
SELECT 
	  Marcas.denominacion as denominacionMarca
	, TiposCombustible.denominacion as denominacionTipoCombustible
	, Coches.idMarca
	, Coches.idTipoCombustible
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, Coches.cilindrada
FROM Marcas
	INNER JOIN Coches on Marcas.id = Coches.idMarca
	INNER JOIN TiposCombustible on Coches.idTipoCombustible = TiposCombustible.id
--WHERE Coches.id = @id
GROUP BY 
	  Marcas.denominacion
	, TiposCombustible.denominacion
	, Coches.idMarca
	, Coches.idTipoCombustible
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, Coches.cilindrada
ORDER BY Marcas.denominacion
END

exec GET_COCHE_POR_MARCA_ID 2;


  ---Procedimientos para listar las marcas
  create procedure Get_Marcas
  as
  Begin
	select id, denominacion from Marcas
  end;

  exec Get_Marcas;
  */
    ---Procedimientos para listar las marcas
  alter procedure Get_Marcas_ID
  	@id bigint   as
  Begin
	select id, denominacion from Marcas
	WHERE Marcas.id = @id 
  end;

  exec Get_Marcas_ID 2;

 create procedure Get_TiposCombustible
  as
  Begin
	select id, denominacion from TiposCombustible
  end;
  
  exec Get_TiposCombustible;

 create procedure Get_TipoCombustible_ID
  	@id bigint   as
  Begin
	select id, denominacion from TiposCombustible
	WHERE TiposCombustible.id = @id 
  end;

  exec  Get_TipoCombustible_ID 2;

 alter PROCEDURE GET_COCHE_POR_MARCA
AS
BEGIN
	SELECT Coches.*, Marcas.denominacion as denominacionMarca, TiposCombustible.denominacion
	FROM Marcas
		INNER JOIN Coches on Marcas.id = Coches.idMarca
		inner join TiposCombustible on Marcas.id = TiposCombustible.id
	--PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'
END
/*
SET NOCOUNT 
Evita que se devuelva el mensaje que muestra el recuento del número de filas afectadas por una instrucción o 
un procedimiento almacenado de Transact-SQL como parte del conjunto de resultados.

Si se establece SET NOCOUNT en ON, no se devuelve el recuento. Cuando SET NOCOUNT es OFF, sí se devuelve ese número.
El @@ROWCOUNT función se actualiza incluso cuando SET NOCOUNT es ON.
SET NOCOUNT ON impide el envío al cliente de mensajes DONE_IN_PROC por cada instrucción de un procedimiento almacenado. 
En los procedimientos almacenados que contengan varias instrucciones que no devuelven mucha información real o en los
procedimientos que contengan bucles de Transact-SQL, establecer SET NOCOUNT en ON puede suponer una mejora significativa 
del rendimiento, ya que el tráfico de la red se reduce en gran medida.
La configuración especificada por SET NOCOUNT está activa en tiempo de ejecución, no en tiempo de análisis.
Para ver la configuración actual de este valor, ejecute la consulta siguiente.


create PROCEDURE Insertar_Marcas
	@denominacion nvarchar(50)
   --,@msg AS VARCHAR(100) NULL OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
Begin Tran TinsertMarca
Begin Try
	INSERT [dbo].[Marcas] ( [denominacion]) VALUES (@denominacion)
	--SET @msg = 'La Marca '+ @denominacion + ' se registro correctamente.'
	COMMIT TRAN
End Try
Begin Catch
	--Set @msg = 'Error: ' + ERROR_MESSAGE() + ' en la línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + '.'
	Rollback TRAN TinsertMarca
End Catch
END

DECLARE @msg AS VARCHAR(100);
EXEC Insertar_Marcas 'Nissan',@msg OUTPUT
SELECT @msg AS msg

create PROCEDURE Insertar_Marcas2
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT [dbo].[Marcas] ( [denominacion]) VALUES (@denominacion)
END

create PROCEDURE Insertar_Tipo_Combustible
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT [dbo].[TiposCombustible] ( [denominacion]) VALUES (@denominacion)
END

exec Insertar_Tipo_Combustible 'cerveza';

-- PROCEDIMIENTO PARA ELIMINAR UNA MARCA
CREATE PROCEDURE EliminarMarca
    @id bigint
AS
BEGIN
    DELETE FROM Marcas WHERE id = @id 
END

exec EliminarMarca 17;


create procedure Actualizarmarca
	@id bigint,
	@denominacion nvarchar(50)
as
begin
	UPDATE Marcas SET denominacion = @denominacion where id = @id
end;

exec Actualizarmarca 13, 'Honda';

*/

