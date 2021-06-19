/*procedimientos de ALERTA, 
EXEC ALERTAPROC @ID = INT,@STOCK = INT,@USUARIO = INT,@MINIMO = INT,@TIPO = NVARCHAR10;
*/ 
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
					   ([id_stock],
					   [id_persona],
					   [cantidad_minima]) /*Cambiar a minima*/
				VALUES
					   (@STOCK,
					   @USUARIO,
					   @MINIMO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT [id_alerta],
						[id_stock],
						[id_persona],
						[cantidad_minima] /*Cambiar a minima*/
				FROM [dbo].[alerta]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@STOCK IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET [id_stock] = @STOCK
						WHERE [id_alerta] = @ID
					END
				IF (@USUARIO IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET	[id_persona] = @USUARIO
						WHERE [id_alerta] = @ID
					END
				IF (@MINIMO IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET	[cantidad_minima] = @MINIMO /*Cambiar a minima*/
						WHERE [id_alerta] = @ID
					END
				
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[alerta]
				WHERE [id_alerta] = @ID
			END
	END
GO

/*procedimientos de CATEGORIA, 
EXEC CATEGORIAPROC @ID = INT,@DESCRIPCION = VARCHAR30,@HABILITADO = DATETIME,@TIPO = NVARCHAR10;
*/
CREATE PROCEDURE CATEGORIAPROC (@ID SMALLINT,
								@DESCRIPCION VARCHAR(30),
								@HABILITADO DATETIME,
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[categoria]
					   ([descripcion]
					   ,[habilitado])
				VALUES
					   (@DESCRIPCION
					   ,@HABILITADO)
			END
		IF @TIPO = 'ESTADO'
			BEGIN
				UPDATE [dbo].[categoria]
				SET	[habilitado] = @HABILITADO 
				WHERE [id_categoria] = @ID
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT [id_categoria],
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
						WHERE [id_categoria] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[categoria]
				WHERE [id_categoria] = @ID
			END
	END
GO

/*procedimientos de DIRECCION, 
EXEC DIRECCIONPROC @ID=INT,@ALTURA=VARCHAR20,@CALLE=VARCHAR50,@CP=VARCHAR50,@LOCALIDAD=VARCHAR50,@PROVINCIA=VARCHAR50,@TIPO=NVARCHAR10;
*/
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
					   ([altura],
					   [calle],
					   [codigo_postal],
					   [localidad],
					   [provincia])
				VALUES
					   (@ALTURA,
					   @CALLE,
					   @CP,
					   @LOCALIDAD,
					   @PROVINCIA)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT [id],
						[altura],
						[calle],
						[codigo_postal],
						[localidad],
						[provincia]
				FROM [dbo].[direccion]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@ALTURA IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [altura] = @ALTURA
						WHERE [id] = @ID
					END
				IF (@CALLE IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [calle] = @CALLE
						WHERE [id] = @ID
					END
				IF (@CP IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [codigo_postal] = @CP
						WHERE [id] = @ID
					END
				IF (@LOCALIDAD IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [localidad] = @LOCALIDAD
						WHERE [id] = @ID
					END
				IF (@PROVINCIA IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [provincia] = @PROVINCIA
						WHERE [id] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[direccion]
				WHERE [id] = @ID
			END
	END
GO

/*procedimientos de DETALLEORDEN, 
EXEC DETALLEPROC @ID = INT,@ORDEN=INT,@PRODUCTO=INT,@CANTIDAD=NVARCHAR50,@TIPO = '';
*/
CREATE PROCEDURE DETALLEPROC	(@ID INT,
								@ORDEN INT,
								@PRODUCTO INT,
								@CANTIDAD INT,
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[detalle_orden]
					   ([id_producto],
					   [id_orden],
					   [cantidad])
				VALUES
					   (@PRODUCTO,
					   @ORDEN,
					   @CANTIDAD)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[id_detalle_orden],
						[id_orden],
						[id_producto],
						[cantidad]
				FROM [dbo].[detalle_orden]
			END
		IF @TIPO = 'UPDATE' /*No deberia poder asociar detalle a otro idOrden*/
			BEGIN
				IF (@PRODUCTO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[detalle_orden]
						SET	[id_producto] = @PRODUCTO
						WHERE [id_detalle_orden] = @ID
					END
				IF (@CANTIDAD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[detalle_orden]
						SET	[cantidad] = @CANTIDAD
						WHERE [id_detalle_orden] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[detalle_orden]
				WHERE ([id_detalle_orden] = @ID AND [id_orden] = @ORDEN)
			END
	END
GO

/*procedimientos de ORDEN, EXEC ORDENPROD @ID=INT,@FECHA=DATETIME,@USUARIO=INT,@HABILITADO=DATETIME,@TIPO=NVARCHAR10;*/
CREATE PROCEDURE ORDENPROC	(@ID INT,
							@FECHA DATETIME,
							@USUARIO INT,
							@TIPO NVARCHAR(10))
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[orden]
					   ([id_persona],
					   [fecha])
				VALUES
					   (@USUARIO,
					   @FECHA)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT [id],
						[id_persona],
						[fecha],
						[habilitado]
				FROM [dbo].[orden]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@USUARIO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[orden]
						SET	[id_persona] = @USUARIO 
						WHERE [id] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[orden]
				WHERE [id] = @ID
			END
	END
GO

/*procedimientos de ORDENCOMPRA, 
EXEC ORDENCOMPRAPROC @ID=INT,@PROVEEDOR=INT,@USUARIO=INT,@FECHA=DATETIME,@TIPO=NVARCHAR10;
*/
CREATE PROCEDURE ORDENCOMPRAPROC	(@ID INT,
									@PROVEEDOR INT,
									@USUARIO INT,
									@FECHA DATETIME,
									@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[orden_compra]
					   ([id_proveedor],
					   [id_persona],
					   [fecha_aprobacion])
				VALUES
					   (@PROVEEDOR,
					   @USUARIO,
					   @FECHA)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[id_orden],
						[id_proveedor],
						[id_persona],
						[fecha_aprobacion]
				FROM [dbo].[orden_compra]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@PROVEEDOR IS NOT NULL)
					BEGIN
						UPDATE [dbo].[orden_compra]
						SET	[id_proveedor] = @PROVEEDOR
						WHERE [id_orden] = @ID
					END
				IF (@USUARIO IS NOT NULL AND @FECHA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[orden_compra]
						SET	[id_persona] = @USUARIO,
							[fecha_aprobacion] = @FECHA
						WHERE [id_orden] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[orden_compra]
				WHERE [id_orden] = @ID
			END
	END
GO

/*procedimientos de PERSONA, 
EXEC PERSONAPROC @ID=INT,@DIRECCION=INT,@DNI=INT,@NOMBRE=VARCHAR50,@APELLIDO=VARCHAR50,@TIPO=NVARCHAR10;
*/
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
				INSERT INTO [dbo].[persona]
					   ([id_direccion],
					   [dni],
					   [nombre],
					   [apellido])
				VALUES
					   (@DIRECCION,
					   @DNI,
					   @NOMBRE,
					   @APELLIDO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[id],
						[id_direccion],
						[dni],
						[nombre],
						[apellido]
				FROM [dbo].[persona]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DIRECCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[id_direccion] = @DIRECCION
						WHERE [id] = @ID
					END
				IF (@DNI IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[dni] = @DNI
						WHERE [id] = @ID
					END
				IF (@NOMBRE IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[nombre] = @NOMBRE
						WHERE [id] = @ID
					END
				IF (@APELLIDO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[apellido] = @APELLIDO
						WHERE [id] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[persona]
				WHERE [id] = @ID
			END
	END
GO

/*procedimientos de PRODUCTO, EXEC PRODUCTOPROC @ID=INT,@CATEGORIA=INT,@NOMBRE=NVARCHAR50,@COMPRA=FLOAT,@VENTA=FLOAT,@HABILITADO = DATETIME,@TIPO=NVARCHAR10;*/
CREATE PROCEDURE PRODUCTOPROC	(@ID INT,
						@CATEGORIA INT,
						@NOMBRE NVARCHAR(50),
						@VENTA FLOAT,
						@COMPRA FLOAT,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[producto]
					   ([id_categoria],
					   [nombre],
					   [precio_compra],
					   [precio_venta])
				VALUES
					   (@CATEGORIA,
					   @NOMBRE,
					   @COMPRA,
					   @VENTA)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[id_producto],
						[id_categoria],
						[nombre],
						[precio_compra],
						[precio_venta]
				FROM [dbo].[producto]
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@CATEGORIA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[producto]
						SET	[id_categoria] = @CATEGORIA
						WHERE [id_producto] = @ID
					END
				IF (@NOMBRE IS NOT NULL)
					BEGIN
						UPDATE [dbo].[producto]
						SET	[nombre] = @NOMBRE
						WHERE [id_producto] = @ID
					END
				IF (@COMPRA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[producto]
						SET	[precio_compra] = @COMPRA
						WHERE [id_producto] = @ID
					END
				IF (@VENTA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[producto]
						SET	[precio_venta] = @VENTA
						WHERE [id_producto] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[producto]
				WHERE [id_producto] = @ID OR ([nombre] = @NOMBRE AND [id_categoria] = @CATEGORIA)
			END
	END
GO

/*procedimientos de PROVEEDOR, 
EXEC PROVEEDORPROC @ID=INT,@DIRECCION=INT,@CUIL=""VARCHAR13,@RAZONSOCIAL=""VARCHAR30,@HABILITADO = ""DATETIME,@TIPO=""NVARCHAR10;
*/
CREATE PROCEDURE PROVEEDORPROC	(@ID INT,
						@DIRECCION INT,
						@CUIL VARCHAR(13),
						@RAZONSOCIAL VARCHAR(30) ,
						@HABILITADO DATETIME,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[proveedor]
					   ([id_direccion],
					   [cuil],
					   [razonsocial],
					   [habilitado])
				VALUES
					   (@DIRECCION,
					   @CUIL,
					   @RAZONSOCIAL,
					   @HABILITADO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[id_proveedor],
						[id_direccion],
						[cuil],
						[razonsocial],
						[habilitado]
				FROM [dbo].[proveedor]
			END
		IF @TIPO = 'ESTADO'
			BEGIN
				UPDATE [dbo].[proveedor]
				SET	[habilitado] = @HABILITADO 
				WHERE [id_proveedor] = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DIRECCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	[id_direccion] = @DIRECCION
						WHERE [id_proveedor] = @ID
					END
				IF (@CUIL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	[cuil] = @CUIL
						WHERE [id_proveedor] = @ID
					END
				IF (@RAZONSOCIAL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	[razonsocial] = @RAZONSOCIAL
						WHERE [id_proveedor] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[proveedor]
				WHERE [id_proveedor] = @ID
			END
	END
GO

/*procedimientos de STOCK, 
EXEC STOCKPROC @ID=INT,@PRODUCTO=INT,@CANTIDAD=INT,@HABILITADO = DATETIME,@TIPO=NVARCHAR10;
*/
CREATE PROCEDURE STOCKPROC	(@ID INT,
						@PRODUCTO INT,
						@CANTIDAD INT,
						@HABILITADO DATETIME,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[stock]
					   ([id_producto],
					   [cantidad],
					   [habilitado])
				VALUES
					   (@PRODUCTO,
					   @CANTIDAD,
					   @HABILITADO)
			END
		IF @TIPO = 'SELECT'
			BEGIN
				SELECT	[id_stock],
						[id_producto],
						[cantidad],
						[habilitado]
				FROM [dbo].[stock]
			END
		IF @TIPO = 'ESTADO'
			BEGIN
				UPDATE [dbo].[stock]
				SET	[habilitado] = @HABILITADO 
				WHERE [id_stock] = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@PRODUCTO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[stock]
						SET	[id_producto] = @PRODUCTO
						WHERE [id_stock] = @ID
					END
				IF (@CANTIDAD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[stock]
						SET	[cantidad] = @CANTIDAD
						WHERE [id_stock] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[stock]
				WHERE [id_stock] = @ID
			END
	END
GO

/*procedimientos de USUARIO, 
EXEC USUARIOPROC @ID=INT,@ROL=INT,@PASSWORD=NVARCHAR50,@LEGAJO=INT,@HABILITADO = DATETIME,@TIPO=NVARCHAR10;
*/
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
				INSERT INTO [dbo].[usuario]
					   ([id_rol],
					   [password],
					   [legajo],
					   [deshabilitado])
				VALUES
					   (@ROL,
						@PASSWORD,
						@LEGAJO,
						@HABILITADO)
			END
		IF @TIPO ='SELECT'
			BEGIN
				SELECT  [id_persona],
						[id_rol],
						[password],
						[legajo],
						[deshabilitado]
				FROM [dbo].[usuario]
			END
		IF @TIPO = 'ESTADO'
			BEGIN
				UPDATE [dbo].[usuario]
				SET	[deshabilitado] = @HABILITADO 
				WHERE [id_persona] = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@ROL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	[id_rol] = @ROL
						WHERE [id_persona] = @ID
					END
				IF (@PASSWORD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	[password] = @PASSWORD
						WHERE [id_persona] = @ID
					END
				IF (@LEGAJO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	[id_rol] = @ROL
						WHERE [id_persona] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[usuario]
				WHERE [id_persona] = @ID
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