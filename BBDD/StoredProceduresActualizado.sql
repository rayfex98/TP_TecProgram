/*procedimientos de ALERTA, 
EXEC ALERTAPROC @ID = INT,@STOCK = INT,@USUARIO = INT,@MINIMO = INT,@TIPO = NVARCHAR10;
*/ 
if object_id('ALERTAPROC') is not null
  drop procedure ALERTAPROC
go

CREATE PROCEDURE ALERTAPROC	(@ID INT,
							@STOCK INT,
							@USUARIO INT,
							@MINIMO INT,
							@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[alerta]
					   ([IDSTOCK],
					   [IDPERSONA],
					   [CANTIDADMINIMA])
				VALUES
					   (@STOCK,
					   @USUARIO,
					   @MINIMO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT [IDALERTA],
						[IDSTOCK],
						[IDPERSONA],
						[CANTIDADMINIMA]
				FROM [dbo].[alerta]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@STOCK IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET [IDSTOCK] = @STOCK
						WHERE [IDALERTA] = @ID
					END
				IF (@USUARIO IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET	[IDPERSONA] = @USUARIO
						WHERE [IDALERTA] = @ID
					END
				IF (@MINIMO IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET	[CANTIDADMINIMA] = @MINIMO /*Cambiar a minima*/
						WHERE [IDALERTA] = @ID
					END
				
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[alerta]
				WHERE [IDALERTA] = @ID
			END
	END
GO

/*procedimientos de CATEGORIA, 
EXEC CATEGORIAPROC @ID = INT,@DESCRIPCION = VARCHAR30,@HABILITADO = DATETIME,@TIPO = NVARCHAR10;
*/
if object_id('CATEGORIAPROC') is not null
  drop procedure CATEGORIAPROC
go

CREATE PROCEDURE CATEGORIAPROC (@ID SMALLINT,
								@DESCRIPCION VARCHAR(30),
								@HABILITADO DATETIME,
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				INSERT INTO [dbo].[categoria]
					   ([descripcion]
					   ,[habilitado])
				VALUES
					   (@DESCRIPCION
					   ,@HABILITADO)
			END
		IF @TIPO = 'ESTADO'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				UPDATE [dbo].[categoria]
				SET	[habilitado] = @HABILITADO 
				WHERE [IDCATEGORIA] = @ID
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT [IDCATEGORIA],
						[descripcion],
						[habilitado]
				FROM [dbo].[categoria]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DESCRIPCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[categoria]
						SET	[descripcion] = @DESCRIPCION
						WHERE [IDCATEGORIA] = @ID
					END
			END
		IF @TIPO = 'DELETE'
					BEGIN
					UPDATE [dbo].[categoria]
					SET	[HABILITADO] = null
					WHERE [IDCATEGORIA] = @ID
		END
END



/*procedimientos de DIRECCION, 
EXEC DIRECCIONPROC @ID=INT,@ALTURA=VARCHAR20,@CALLE=VARCHAR50,@CP=VARCHAR50,@LOCALIDAD=VARCHAR50,@PROVINCIA=VARCHAR50,@TIPO=NVARCHAR10;
*/
if object_id('DIRECCIONPROC') is not null
  drop procedure DIRECCIONPROC
go

CREATE PROCEDURE DIRECCIONPROC (@ID INT,
								@ALTURA VARCHAR(20),
								@CALLE VARCHAR(50),
								@CP VARCHAR(50),
								@LOCALIDAD VARCHAR(50),
								@PROVINCIA VARCHAR(50),
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[direccion]
					   ([ALTURA],
					   [CALLE],
					   [CODIGOPOSTAL],
					   [LOCALIDAD],
					   [PROVINCIA])
				VALUES
					   (@ALTURA,
					   @CALLE,
					   @CP,
					   @LOCALIDAD,
					   @PROVINCIA)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT [IDDIRECCION],
						[ALTURA],
						[CALLE],
						[CODIGOPOSTAL],
						[LOCALIDAD],
						[PROVINCIA]
				FROM [dbo].[direccion]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@ALTURA IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [altura] = @ALTURA
						WHERE [IDDIRECCION] = @ID
					END
				IF (@CALLE IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [calle] = @CALLE
						WHERE [IDDIRECCION] = @ID
					END
				IF (@CP IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [CODIGOPOSTAL] = @CP
						WHERE [IDDIRECCION] = @ID
					END
				IF (@LOCALIDAD IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [localidad] = @LOCALIDAD
						WHERE [IDDIRECCION] = @ID
					END
				IF (@PROVINCIA IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [provincia] = @PROVINCIA
						WHERE [IDDIRECCION] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[direccion]
				WHERE [IDDIRECCION] = @ID
			END
	END
GO

/*procedimientos de DETALLEORDEN, 
EXEC DETALLEPROC @ID = INT,@ORDEN=INT,@PRODUCTO=INT,@CANTIDAD=NVARCHAR50,@TIPO = '';
*/
if object_id('DETALLEPROC') is not null
  drop procedure DETALLEPROC
go
CREATE PROCEDURE DETALLEPROC	(@ID INT,
								@ORDEN INT,
								@PRODUCTO INT,
								@CANTIDAD INT,
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[DETALLEORDEN]
					   ([IDPRODUCTO],
					   [IDORDEN],
					   [CANTIDAD])
				VALUES
					   (@PRODUCTO,
					   @ORDEN,
					   @CANTIDAD)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[IDDETALLE],
						[IDORDEN],
						[IDPRODUCTO],
						[CANTIDAD]
				FROM [dbo].[DETALLEORDEN]
			END
		IF @TIPO = 'UPDATE' /*No deberia poder asociar detalle a otro idOrden*/
			BEGIN
				IF (@PRODUCTO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[DETALLEORDEN]
						SET	[IDPRODUCTO] = @PRODUCTO
						WHERE [IDDETALLE] = @ID
					END
				IF (@CANTIDAD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[DETALLEORDEN]
						SET	[CANTIDAD] = @CANTIDAD
						WHERE [IDDETALLE] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[DETALLEORDEN]
				WHERE ([IDDETALLE] = @ID AND [IDORDEN] = @ORDEN)
			END
	END
GO
/*procedimientos de ORDEN, EXEC ORDENPROD @ID=INT,@FECHA=DATETIME,@USUARIO=INT,@HABILITADO=DATETIME,@TIPO=NVARCHAR10;*/
if object_id('ORDENPROC') is not null
  drop procedure ORDENPROC
go
CREATE PROCEDURE ORDENPROC	(@ID INT,
							@FECHA DATETIME,
							@USUARIO INT,
							@TIPO NVARCHAR(10))
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN		
			INSERT INTO [dbo].[ORDEN]
					   ([IDPERSONA],
					   [HABILITADO])
				VALUES
					   (@USUARIO,
					   @FECHA)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT [IDORDEN],
						[IDPERSONA],
						[HABILITADO]
				FROM [dbo].[ORDEN]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@USUARIO IS NOT NULL)
					set @FECHA = GETUTCDATE()
					BEGIN
						UPDATE [dbo].[ORDEN]
						SET	[HABILITADO] = @FECHA 
						WHERE [IDORDEN] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[orden]
				WHERE [IDORDEN] = @ID
			END
	END
GO

/*procedimientos de ORDENCOMPRA, 
EXEC ORDENCOMPRAPROC @ID=INT,@PROVEEDOR=INT,@USUARIO=INT,@FECHA=DATETIME,@TIPO=NVARCHAR10;
*/
if object_id('ORDENCOMPRAPROC') is not null
  drop procedure ORDENCOMPRAPROC
go
CREATE PROCEDURE ORDENCOMPRAPROC	(@ID INT,
									@PROVEEDOR INT,
									@USUARIO INT,
									@FECHA DATETIME,
									@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[ORDENCOMPRA]
					   ([IDORDEN],
					   [IDPROVEEDOR],
					   [IDPERSONA],
					   [FECHAAPROVACION])
				VALUES
					   (@ID,
					   @PROVEEDOR,
					   @USUARIO,
					   @FECHA)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[IDORDEN],
						[IDPROVEEDOR],
						[IDPERSONA],
						[FECHAAPROVACION]
				FROM [dbo].[ORDENCOMPRA]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@PROVEEDOR IS NOT NULL)
					BEGIN
						UPDATE [dbo].[ORDENCOMPRA]
						SET	[IDPROVEEDOR] = @PROVEEDOR
						WHERE [IDORDEN] = @ID
					END
				IF (@USUARIO IS NOT NULL AND @FECHA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[ORDENCOMPRA]
						SET	[IDPERSONA] = @USUARIO,
							[FECHAAPROVACION] = @FECHA
						WHERE [IDORDEN] = @ID
					END
			END
		IF @TIPO = 'APROBAR'
			BEGIN
			set @FECHA = GETUTCDATE()
				UPDATE [dbo].[ORDENCOMPRA]
					set [FECHAAPROVACION] = @FECHA
				WHERE [IDORDEN] = @ID
		END

		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[ORDENCOMPRA]
				WHERE [IDORDEN] = @ID
			END
	END
GO

/*procedimientos de PERSONA, 
EXEC PERSONAPROC @ID=INT,@DIRECCION=INT,@DNI=INT,@NOMBRE=VARCHAR50,@APELLIDO=VARCHAR50,@TIPO=NVARCHAR10;
*/
if object_id('PERSONAPROC') is not null
  drop procedure PERSONAPROC
go
CREATE PROCEDURE PERSONAPROC	(@ID INT,
						@DIRECCION INT,
						@DNI INT,
						@NOMBRE VARCHAR(50),
						@APELLIDO VARCHAR(50),
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[PERSONA]
					   ([IDDIRECCION],
					   [DNI],
					   [NOMBRE],
					   [APELLIDO])
				VALUES
					   (@DIRECCION,
					   @DNI,
					   @NOMBRE,
					   @APELLIDO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[IDPERSONA],
						[IDDIRECCION],
						[DNI],
						[NOMBRE],
						[APELLIDO]
				FROM [dbo].[persona]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DIRECCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[IDDIRECCION] = @DIRECCION
						WHERE [IDPERSONA] = @ID
					END
				IF (@DNI IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[DNI] = @DNI
						WHERE [IDPERSONA] = @ID
					END
				IF (@NOMBRE IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[NOMBRE] = @NOMBRE
						WHERE [IDPERSONA] = @ID
					END
				IF (@APELLIDO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[APELLIDO] = @APELLIDO
						WHERE [IDPERSONA] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[persona]
				WHERE [IDPERSONA] = @ID
			END
	END
GO
if object_id('PRODUCTOPROC') is not null
  drop procedure PRODUCTOPROC
go
/*procedimientos de PRODUCTO, EXEC PRODUCTOPROC @ID=INT,@CATEGORIA=INT,@NOMBRE=NVARCHAR50,@COMPRA=FLOAT,@VENTA=FLOAT,@HABILITADO = DATETIME,@TIPO=NVARCHAR10;*/
CREATE PROCEDURE PRODUCTOPROC	(@ID INT,
						@CATEGORIA INT,
						@NOMBRE NVARCHAR(50),
						@VENTA FLOAT,
						@COMPRA FLOAT,
						@HABILITADO datetime,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				INSERT INTO [dbo].[PRODUCTO]
					   ([IDCATEGORIA],
					   [NOMBRE],
					   [PRECIOCOMPRA],
					   [PRECIOVENTA],
					   [HABILITADO])
				VALUES
					   (@CATEGORIA,
					   @NOMBRE,
					   @COMPRA,
					   @VENTA,
					   @HABILITADO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[IDPRODUCTO],
						[IDCATEGORIA],
						[NOMBRE],
						[PRECIOCOMPRA],
						[PRECIOVENTA],
						[HABILITADO]
				FROM [dbo].[producto]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@CATEGORIA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PRODUCTO]
						SET	[IDCATEGORIA] = @CATEGORIA
						WHERE [IDPRODUCTO] = @ID
					END
				IF (@NOMBRE IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PRODUCTO]
						SET	[NOMBRE] = @NOMBRE
						WHERE [IDPRODUCTO] = @ID
					END
				IF (@COMPRA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PRODUCTO]
						SET	[PRECIOCOMPRA] = @COMPRA
						WHERE [IDPRODUCTO] = @ID
					END
				IF (@VENTA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PRODUCTO]
						SET	[PRECIOVENTA] = @VENTA
						WHERE [IDPRODUCTO] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
			UPDATE [dbo].[PRODUCTO]
			SET	[HABILITADO] = null
			WHERE [IDPRODUCTO] = @ID
			
			END
	END
GO

/*procedimientos de PROVEEDOR, 
EXEC PROVEEDORPROC @ID=INT,@DIRECCION=INT,@CUIL=""VARCHAR13,@RAZONSOCIAL=""VARCHAR30,@HABILITADO = ""DATETIME,@TIPO=""NVARCHAR10;
*/
 if object_id('PROVEEDORPROC') is not null
  drop procedure PROVEEDORPROC
go
CREATE PROCEDURE PROVEEDORPROC	(@ID INT,
						@DIRECCION INT,
						@CUIL VARCHAR(13),
						@RAZONSOCIAL VARCHAR(30) ,
						@HABILITADO DATETIME,
						@TIPO NVARCHAR(15) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				INSERT INTO [dbo].[PROVEEDOR]
					   ([IDDIRECCION],
					   [CUIL],
					   [RAZONSOCIAL],
					   [HABILITADO])
				VALUES
					   (@DIRECCION,
					   @CUIL,
					   @RAZONSOCIAL,
					    @HABILITADO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[IDPROVEEDOR],
						[IDDIRECCION],
						[CUIL],
						[RAZONSOCIAL],
						[HABILITADO]
				FROM [dbo].[proveedor]
			END
		IF @TIPO = 'HABILITAR'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				UPDATE [dbo].[proveedor]
				SET	[habilitado] = @HABILITADO 
				WHERE [IDPROVEEDOR] = @ID
			END
		IF @TIPO = 'DESHABILITAR'
			BEGIN
			set @HABILITADO = NULL
				UPDATE [dbo].[proveedor]
				SET	[habilitado] = @HABILITADO 
				WHERE [IDPROVEEDOR] = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DIRECCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	[IDDIRECCION] = @DIRECCION
						WHERE [IDPROVEEDOR] = @ID
					END
				IF (@CUIL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	[cuil] = @CUIL
						WHERE [IDPROVEEDOR] = @ID
					END
				IF (@RAZONSOCIAL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	[razonsocial] = @RAZONSOCIAL
						WHERE [IDPROVEEDOR] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				UPDATE [dbo].[proveedor]
				SET	[HABILITADO] = null
				WHERE [IDPROVEEDOR] = @ID
			END
	END
GO

/*procedimientos de STOCK, 
EXEC STOCKPROC @ID=INT,@PRODUCTO=INT,@CANTIDAD=INT,@HABILITADO = DATETIME,@TIPO=NVARCHAR10;
*/
 if object_id('STOCKPROC') is not null
  drop procedure STOCKPROC
go
CREATE PROCEDURE STOCKPROC	(@ID INT,
						@PRODUCTO INT,
						@CANTIDAD INT,
						@HABILITADO DATETIME,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				INSERT INTO [dbo].[stock]
					   ([IDPRODUCTO],
					   [CANTIDAD],
					   [HABILITADO])
				VALUES
					   (@PRODUCTO,
					   @CANTIDAD,
					   @HABILITADO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[IDSTOCK],
						[IDPRODUCTO],
						[CANTIDAD],
						[HABILITADO]
				FROM [dbo].[stock]
			END
		IF @TIPO = 'ESTADO'
			BEGIN
				UPDATE [dbo].[STOCK]
				SET	[habilitado] = @HABILITADO 
				WHERE [IDSTOCK] = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@PRODUCTO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[stock]
						SET	[IDPRODUCTO] = @PRODUCTO
						WHERE [IDSTOCK] = @ID
					END
				IF (@CANTIDAD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[stock]
						SET	[cantidad] = @CANTIDAD
						WHERE [IDSTOCK] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				UPDATE [dbo].[stock]
				SET	[HABILITADO] = null
				WHERE [IDSTOCK] = @ID
			END
	END
GO

/*procedimientos de USUARIO, 
EXEC USUARIOPROC @ID=INT,@ROL=INT,@PASSWORD=NVARCHAR50,@LEGAJO=INT,@HABILITADO = DATETIME,@TIPO=NVARCHAR10;
*/
 if object_id('USUARIOPROC') is not null
  drop procedure USUARIOPROC
go
CREATE PROCEDURE USUARIOPROC	(@ID INT,
								@ROL INT,
								@PASSWORD NVARCHAR(50),
								@LEGAJO INT,
								@HABILITADO DATETIME,
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				INSERT INTO [dbo].[usuario]
					   ([IDROL],
					   [PASSWORD],
					   [LEGAJO],
					   [HABILITADO])
				VALUES
					   (@ROL,
						@PASSWORD,
						@LEGAJO,
						@HABILITADO)
			END
		IF @TIPO ='SELECT'
			BEGIN
				SELECT  [IDPERSONA],
						[IDROL],
						[PASSWORD],
						[LEGAJO],
						[HABILITADO]
				FROM [dbo].[usuario]
			END
		IF @TIPO = 'HABILITAR'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				UPDATE [dbo].[usuario]
				SET	[HABILITADO] = @HABILITADO 
				WHERE [IDPERSONA] = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@ROL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	[IDROL] = @ROL
						WHERE [IDPERSONA] = @ID
					END
				IF (@PASSWORD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	[password] = @PASSWORD
						WHERE [IDPERSONA] = @ID
					END
				IF (@LEGAJO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	[IDROL] = @ROL
						WHERE [IDPERSONA] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				UPDATE [dbo].[usuario]
				SET	[HABILITADO] = null
				WHERE [IDPERSONA] = @ID
			END
	END
GO
--store procedure de stock 
if object_id('sumarstock') is not null
  drop procedure sumarstock;

go
create procedure sumarstock (@ID INT, @cantidad int)as

BEGIN

	UPDATE [dbo].[STOCK]
	set CANTIDAD = cantidad + @cantidad
	WHERE IDPRODUCTO= @ID				
	
END
if object_id('restarstock') is not null
  drop procedure restarstock;

go

if object_id('restarstock') is not null
  drop procedure restarstock;

create procedure restarstock (@ID INT,@cantidad int)as

BEGIN
	UPDATE [dbo].[STOCK]
    set CANTIDAD = cantidad - @cantidad
	WHERE IDPRODUCTO= @ID						
END



 if object_id('vista_stock') is not null
  drop procedure vista_stock;

go
create procedure vista_stock as 

select 
s.IDSTOCK as 'id stock',
s.CANTIDAD as 'cantidad',
p.NOMBRE as 'nombre',
s.HABILITADO as 'habilitado'

from [dbo].[stock] as s
inner join [dbo].[PRODUCTO] as p
on s.IDPRODUCTO = p.IDPRODUCTO;

--exec vista_stock;



--store procedure de alertas 
 if object_id('VistaAlertasCriticas') is not null
  drop procedure VistaAlertasCriticas;

go
 create procedure VistaAlertasCriticas as 

 select 
  A.IDALERTA as 'id alerta',
 S.IDSTOCK as 'id stock', 
 B.NOMBRE as 'producto',
 P.NOMBRE +' '+P.APELLIDO as 'usuario',
 A.CANTIDADMINIMA as  'cantidad minima',
 S.CANTIDAD as 'cantidad stock'

 from dbo.ALERTA as A
 inner join dbo.STOCK as S 
 on A.IDSTOCK = S.IDSTOCK
 inner join dbo.USUARIO as U
 on A.IDPERSONA= U.IDPERSONA
 inner join dbo.PERSONA as P 
 on U.IDPERSONA = P.IDPERSONA
 inner join dbo.PRODUCTO as B
 on S.IDPRODUCTO = B.IDPRODUCTO
 where S.CANTIDAD <= a.CANTIDADMINIMA

 --exec VistaAlertasCriticas;

 if object_id('VistaAlertas') is not null
  drop procedure VistaAlertas;

go
 create procedure VistaAlertas as 

 select 
  A.IDALERTA as 'id alerta',
 S.IDSTOCK as 'id stock', 
 B.NOMBRE as 'producto',
 P.NOMBRE +' '+P.APELLIDO as 'usuario',
 A.CANTIDADMINIMA as  'cantidad minima',
 S.CANTIDAD as 'cantidad stock'

 from dbo.ALERTA as A
 inner join dbo.STOCK as S 
 on A.IDSTOCK = S.IDSTOCK
 inner join dbo.USUARIO as U
 on A.IDPERSONA= U.IDPERSONA
 inner join dbo.PERSONA as P 
 on U.IDPERSONA = P.IDPERSONA
 inner join dbo.PRODUCTO as B
 on S.IDPRODUCTO = B.IDPRODUCTO
 
 --exec VistaAlertas;




 --store procedure de productos 
  if object_id('ListaProductosHabilitados') is not null
  drop procedure ListaProductosHabilitados;

 create procedure ListaProductosHabilitados as 

 select 
 P.NOMBRE as 'nombre',
 C.DESCRIPCION as 'categoria',
 P.IDPRODUCTO as 'id producto'
 from dbo.PRODUCTO as P
 inner join dbo.CATEGORIA as C 
 on P.IDCATEGORIA = C.IDCATEGORIA
 where P.HABILITADO is not null;

 --exec ListaProductosHabilitados;
 --store procedures de proveedor 
  if object_id('ListaProveedores') is not null
  drop procedure ListaProveedores;

 create procedure ListaProveedores as 

 select 
 P.CUIL as 'cuil',
 P.IDPROVEEDOR as 'id proveedor',
 P.RAZONSOCIAL as 'razon social',
 D.LOCALIDAD +' '+ D.PROVINCIA as 'Localidad y provincia',
 D.IDDIRECCION as 'id direccion'
 from dbo.PROVEEDOR as P 
 inner join dbo.DIRECCION as D
 on P.IDDIRECCION = D.IDDIRECCION;

 --exec ListaProveedores;

 
 
 --store procedures de orden de compra 
  if object_id('OrdenCompraVista') is not null
 drop procedure OrdenCompraVista;


 create procedure OrdenCompraVista as 


 select 
 O.IDORDEN as 'id orden ',
 D.CANTIDAD as 'cantidad',
 P.NOMBRE as 'producto',
 V.RAZONSOCIAL as 'razon social',
 O.FECHAAPROVACION as 'fecha aprobacion'

 from dbo.ORDENCOMPRA AS O
 inner join dbo.DETALLEORDEN AS D
 on  O.IDORDEN =  D.IDORDEN
 inner join dbo.PRODUCTO as P
 on D.IDPRODUCTO = P.IDPRODUCTO
 inner join dbo.PROVEEDOR as V
 on O.IDPROVEEDOR = V.IDPROVEEDOR



--exec OrdenCompraVista;
 
 -- Crea el store procedure para ver las ordenes de compra pendiente 
 if object_id('OrdenCompraPendientes') is not null
  drop procedure OrdenCompraPendientes
go
 create procedure OrdenCompraPendientes as 


 select 
 O.IDORDEN as 'id orden ',
 D.CANTIDAD as 'cantidad',
 P.NOMBRE as 'producto',
 V.RAZONSOCIAL as 'razon social'
 from dbo.ORDENCOMPRA AS O
 inner join dbo.DETALLEORDEN AS D
 on  O.IDORDEN =  D.IDORDEN
 inner join dbo.PRODUCTO as P
 on D.IDPRODUCTO = P.IDPRODUCTO
 inner join dbo.PROVEEDOR as V
 on O.IDPROVEEDOR = V.IDPROVEEDOR
 where O.FECHAAPROVACION = null


--exec OrdenCompraPendientes; 


 --store procedure categoria 
  if object_id('ListaCategorias') is not null
  drop procedure ListaCategorias
go

 create procedure ListaCategorias as 

 select 
 c.DESCRIPCION as 'descripcion',
 c.IDCATEGORIA as 'id categoria'

 from dbo.CATEGORIA as c
 where c.HABILITADO is not null

 --exec ListaCategorias;