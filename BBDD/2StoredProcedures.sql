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
					   (id_stock,
					   id_persona,
					   cantidad_minima)
				VALUES
					   (@STOCK,
					   @USUARIO,
					   @MINIMO)
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@STOCK IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET id_stock = @STOCK
						WHERE id_alerta = @ID
					END
				IF (@USUARIO IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET	id_persona = @USUARIO
						WHERE id_alerta = @ID
					END
				IF (@MINIMO IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[alerta]
						SET	cantidad_minima = @MINIMO /*Cambiar a minima*/
						WHERE id_alerta = @ID
					END
				
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[alerta]
				WHERE id_alerta = @ID
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
				WHERE id_categoria = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DESCRIPCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[categoria]
						SET	[descripcion] = @DESCRIPCION
						WHERE id_categoria = @ID
					END
			END
		IF @TIPO = 'DELETE'
					BEGIN
					UPDATE [dbo].[categoria]
					SET	[HABILITADO] = null
					WHERE id_categoria = @ID
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
					   codigo_postal,
					   [LOCALIDAD],
					   [PROVINCIA])
				VALUES
					   (@ALTURA,
					   @CALLE,
					   @CP,
					   @LOCALIDAD,
					   @PROVINCIA)
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@ALTURA IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [altura] = @ALTURA
						WHERE id = @ID
					END
				IF (@CALLE IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [calle] = @CALLE
						WHERE id = @ID
					END
				IF (@CP IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET codigo_postal = @CP
						WHERE id = @ID
					END
				IF (@LOCALIDAD IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [localidad] = @LOCALIDAD
						WHERE id = @ID
					END
				IF (@PROVINCIA IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[direccion]
						SET [provincia] = @PROVINCIA
						WHERE id = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[direccion]
				WHERE id = @ID
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
				INSERT INTO [dbo].detalle_orden
					   (id_producto,
					   id_orden,
					   [CANTIDAD])
				VALUES
					   (@PRODUCTO,
					   @ORDEN,
					   @CANTIDAD)
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@PRODUCTO IS NOT NULL)
					BEGIN
						UPDATE [dbo].detalle_orden
						SET	id_producto = @PRODUCTO
						WHERE id_detalle_orden = @ID
					END
				IF (@CANTIDAD IS NOT NULL)
					BEGIN
						UPDATE [dbo].detalle_orden
						SET	[CANTIDAD] = @CANTIDAD
						WHERE id_detalle_orden = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].detalle_orden
				WHERE (id_detalle_orden = @ID AND id_orden = @ORDEN) OR id_orden = @ORDEN
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
			set @FECHA = GETUTCDATE()
			INSERT INTO [dbo].[ORDEN]
					   (id_persona,
					   fecha)
				VALUES
					   (@USUARIO,
					   @FECHA)
			END
		IF @TIPO = 'DESHABILITA'
			BEGIN
				IF (@USUARIO IS NOT NULL)			
					BEGIN
						SET @FECHA = NULL
						SET	@USUARIO = NULL	
						UPDATE [dbo].[ORDEN]
						SET	fecha = @FECHA
						WHERE id = @ID
					END
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@USUARIO IS NOT NULL)
					set @FECHA = GETUTCDATE()
					BEGIN
						UPDATE [dbo].[ORDEN]
						SET	fecha = @FECHA 
						WHERE id = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[orden]
				WHERE id = @ID
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
				INSERT INTO [dbo].orden_compra
					   (id_orden,
					   id_proveedor,
					   id_persona,
					   fecha_aprobacion)
				VALUES
					   (@ID,
					   @PROVEEDOR,
					   @USUARIO,
					   @FECHA)
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@PROVEEDOR IS NOT NULL)
					BEGIN
						UPDATE [dbo].orden_compra
						SET	id_proveedor = @PROVEEDOR
						WHERE id_orden = @ID
					END
				IF (@USUARIO IS NOT NULL AND @FECHA IS NOT NULL)
					BEGIN
						UPDATE [dbo].orden_compra
						SET	id_proveedor = @USUARIO,
							fecha_aprobacion = @FECHA
						WHERE id_orden = @ID
					END
			END
		IF @TIPO = 'APROBAR'
			BEGIN
			set @FECHA = GETUTCDATE()
				UPDATE [dbo].orden_compra
					set fecha_aprobacion = @FECHA
				WHERE id_orden = @ID
		END

		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].orden_compra
				WHERE id_orden = @ID
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
					   (id_direccion,
					   [DNI],
					   [NOMBRE],
					   [APELLIDO])
				VALUES
					   (@DIRECCION,
					   @DNI,
					   @NOMBRE,
					   @APELLIDO)
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DIRECCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	id_direccion = @DIRECCION
						WHERE id = @ID
					END
				IF (@DNI IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[DNI] = @DNI
						WHERE id = @ID
					END
				IF (@NOMBRE IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[NOMBRE] = @NOMBRE
						WHERE id = @ID
					END
				IF (@APELLIDO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[persona]
						SET	[APELLIDO] = @APELLIDO
						WHERE id = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[persona]
				WHERE id = @ID
			END
	END
GO
if object_id('PRODUCTOPROC') is not null
  drop procedure PRODUCTOPROC
go
/*procedimientos de PRODUCTO, EXEC PRODUCTOPROC @ID=INT,@CATEGORIA=INT,@NOMBRE=NVARCHAR50,@COMPRA=FLOAT,@VENTA=FLOAT,@TIPO=NVARCHAR10;*/
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
				INSERT INTO [dbo].producto
					   (id_categoria,
					   nombre,
					   precio_compra,
					   precio_venta)
				VALUES
					   (@CATEGORIA,
					   @NOMBRE,
					   @COMPRA,
					   @VENTA)
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@CATEGORIA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PRODUCTO]
						SET	id_categoria = @CATEGORIA
						WHERE id_producto = @ID
					END
				IF (@NOMBRE IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PRODUCTO]
						SET	nombre = @NOMBRE
						WHERE id_producto = @ID
					END
				IF (@COMPRA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PRODUCTO]
						SET	precio_compra = @COMPRA
						WHERE id_producto = @ID
					END
				IF (@VENTA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PRODUCTO]
						SET	precio_venta = @VENTA
						WHERE id_producto = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
			DELETE [dbo].[PRODUCTO]
			WHERE id_producto = @ID
			
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
					   (id_direccion,
					   [CUIL],
					   [RAZONSOCIAL],
					   [HABILITADO])
				VALUES
					   (@DIRECCION,
					   @CUIL,
					   @RAZONSOCIAL,
					    @HABILITADO)
			END
		IF @TIPO = 'HABILITAR'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				UPDATE [dbo].[proveedor]
				SET	[habilitado] = @HABILITADO 
				WHERE id_proveedor = @ID
			END
		IF @TIPO = 'DESHABILITAR'
			BEGIN
			set @HABILITADO = NULL
				UPDATE [dbo].[proveedor]
				SET	[habilitado] = @HABILITADO 
				WHERE id_proveedor = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DIRECCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	id_direccion = @DIRECCION
						WHERE id_proveedor = @ID
					END
				IF (@CUIL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	[cuil] = @CUIL
						WHERE id_proveedor = @ID
					END
				IF (@RAZONSOCIAL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[proveedor]
						SET	[razonsocial] = @RAZONSOCIAL
						WHERE id_proveedor = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				UPDATE [dbo].[proveedor]
				SET	[HABILITADO] = null
				WHERE id_proveedor = @ID
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
					   (id_producto,
					   [CANTIDAD],
					   [HABILITADO])
				VALUES
					   (@PRODUCTO,
					   @CANTIDAD,
					   @HABILITADO)
			END
		IF @TIPO = 'ESTADO'
			BEGIN
				UPDATE [dbo].[STOCK]
				SET	[habilitado] = @HABILITADO 
				WHERE id_stock = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@PRODUCTO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[stock]
						SET	id_producto = @PRODUCTO
						WHERE id_stock = @ID
					END
				IF (@CANTIDAD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[stock]
						SET	[cantidad] = @CANTIDAD
						WHERE id_stock = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				UPDATE [dbo].[stock]
				SET	[HABILITADO] = null
				WHERE id_stock = @ID
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
					   (id_rol,
					   [PASSWORD],
					   [LEGAJO],
					   deshabilitado)
				VALUES
					   (@ROL,
						@PASSWORD,
						@LEGAJO,
						@HABILITADO)
			END
		IF @TIPO = 'HABILITAR'
			BEGIN
			set @HABILITADO = GETUTCDATE()
				UPDATE [dbo].[usuario]
				SET	deshabilitado = @HABILITADO 
				WHERE id_persona = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@ROL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	id_rol = @ROL
						WHERE id_persona = @ID
					END
				IF (@PASSWORD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	[password] = @PASSWORD
						WHERE id_persona = @ID
					END
				IF (@LEGAJO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[usuario]
						SET	legajo = @LEGAJO
						WHERE id_persona = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				UPDATE [dbo].[usuario]
				SET	deshabilitado = null
				WHERE id_persona = @ID
			END
	END
GO

--store procedure de stock 
		if object_id('sumarstock') is not null
		drop procedure sumarstock;
		go
		create procedure sumarstock (@ID INT, @cantidad int) as
			BEGIN

				UPDATE [dbo].[stock]
				set cantidad = cantidad + @cantidad
				WHERE id_producto= @ID	
			END

--store procedure restar stock
		if object_id('restarstock') is not null
		drop procedure restarstock;
		go
		create procedure restarstock (@ID INT,@cantidad int) as
			BEGIN
				UPDATE [dbo].[stock]
				set cantidad = cantidad - @cantidad
				WHERE id_producto= @ID						
			END

--store procedure lista de stock
		if object_id('vista_stock') is not null
		drop procedure vista_stock;
		go
		create procedure vista_stock as
			select 
			s.id_stock as 'id stock',
			s.cantidad as 'cantidad',
			p.nombre as 'nombre',
			s.habilitado as 'habilitado'
			from [dbo].[stock] as s
			inner join [dbo].producto as p
			on s.id_producto = p.id_producto
			where s.habilitado is not null;

--store procedure de alertas criticas 
		if object_id('VistaAlertasCriticas') is not null
		drop procedure VistaAlertasCriticas;
		go
		create procedure VistaAlertasCriticas as 
			select 
			A.IDALERTA as 'id alerta',
			 C.DESCRIPCION as 'Descripcion',
			 B.nombre as 'producto',
			 P.nombre +' '+P.apellido as 'usuario',
			 A.CANTIDADMINIMA as  'cantidad minima',
			 S.cantidad as 'cantidad stock'
			 from dbo.alerta as A
			 inner join dbo.stock as S 
			 on A.IDSTOCK = S.IDSTOCK
			 inner join dbo.USUARIO as U
			 on A.IDPERSONA= U.IDPERSONA
			 inner join dbo.PERSONA as P 
			 on U.IDPERSONA = P.IDPERSONA
			 inner join dbo.PRODUCTO as B
			 on S.IDPRODUCTO = B.IDPRODUCTO
			 inner join dbo.CATEGORIA as C 
			 on B.IDCATEGORIA = C.IDCATEGORIA
			where S.CANTIDAD <= a.CANTIDADMINIMA

 --store procedure de todas las alertas 

		if object_id('VistaAlertas') is not null
		drop procedure VistaAlertas;
		go
		create procedure VistaAlertas as 
			 select 
			 A.IDALERTA as 'id alerta',
			 C.DESCRIPCION as 'Descripcion',
			 B.nombre as 'producto',
			 P.nombre +' '+P.apellido as 'usuario',
			 A.CANTIDADMINIMA as  'cantidad minima',
			 S.cantidad as 'cantidad stock'
			 from dbo.alerta as A
			 inner join dbo.stock as S 
			 on A.IDSTOCK = S.IDSTOCK
			 inner join dbo.USUARIO as U
			 on A.IDPERSONA= U.IDPERSONA
			 inner join dbo.PERSONA as P 
			 on U.IDPERSONA = P.IDPERSONA
			 inner join dbo.PRODUCTO as B
			 on S.IDPRODUCTO = B.IDPRODUCTO
			 inner join dbo.CATEGORIA as C 
			 on B.IDCATEGORIA = C.IDCATEGORIA


--Buscar Alerta por nombre de producto 
	if object_id('AlertaNombre') is not null
		drop procedure AlertaNombre;
		go
		create procedure AlertaNombre(@nombre varchar(30)) as 
			 select 
			 A.IDALERTA as 'id alerta',
			 C.DESCRIPCION as 'Descripcion',
			 B.nombre as 'producto',
			 P.nombre +' '+P.apellido as 'usuario',
			 A.CANTIDADMINIMA as  'cantidad minima',
			 S.cantidad as 'cantidad stock'
			 from dbo.alerta as A
			 inner join dbo.stock as S 
			 on A.IDSTOCK = S.IDSTOCK
			 inner join dbo.USUARIO as U
			 on A.IDPERSONA= U.IDPERSONA
			 inner join dbo.PERSONA as P 
			 on U.IDPERSONA = P.IDPERSONA
			 inner join dbo.PRODUCTO as B
			 on S.IDPRODUCTO = B.IDPRODUCTO
			 inner join dbo.CATEGORIA as C 
			 on B.IDCATEGORIA = C.IDCATEGORIA
			 where  B.NOMBRE like  @nombre + '%';

--Buscar Alerta por categoria(descripcion) de producto 
	if object_id('AlertaCategoria') is not null
		drop procedure AlertaCategoria;
		go
		create procedure AlertaCategoria(@nombre varchar(30)) as 
			 select 
			 A.IDALERTA as 'id alerta',
			 C.DESCRIPCION as 'Descripcion',
			 B.nombre as 'producto',
			 P.nombre +' '+P.apellido as 'usuario',
			 A.CANTIDADMINIMA as  'cantidad minima',
			 S.cantidad as 'cantidad stock'
			 from dbo.alerta as A
			 inner join dbo.stock as S 
			 on A.IDSTOCK = S.IDSTOCK
			 inner join dbo.USUARIO as U
			 on A.IDPERSONA= U.IDPERSONA
			 inner join dbo.PERSONA as P 
			 on U.IDPERSONA = P.IDPERSONA
			 inner join dbo.PRODUCTO as B
			 on S.IDPRODUCTO = B.IDPRODUCTO
			 inner join dbo.CATEGORIA as C 
			 on B.IDCATEGORIA = C.IDCATEGORIA
			 where  C.DESCRIPCION like  @nombre + '%'; 
			 
 --store procedure de productos 
 --listar productos habilitados
		if object_id('ListaProductos') is not null
		drop procedure ListaProductos;
		go
		create procedure ListaProductos as
			 select 
			 P.nombre as 'nombre',
			 C.descripcion as 'categoria',
			 S.CANTIDAD as 'Stock',
			 P.PRECIOCOMPRA as 'Precio de compra',
			 P.PRECIOVENTA as 'Precio de venta'
			 from dbo.producto as P
			 inner join dbo.categoria as C 
			 on P.IDCATEGORIA = C.IDCATEGORIA 
			 inner join dbo.STOCK as S
			 on P.IDPRODUCTO = S.IDPRODUCTO 
			 where  P.HABILITADO is not null 

--busca un producto por su nombre 
		if object_id('BuscarProductoNombre') is not null
		drop procedure BuscarProductoNombre;
		go
		create procedure BuscarProductoNombre(@nombre varchar(30) ) as
			 select 
			 P.nombre as 'nombre',
			 C.descripcion as 'categoria',
			 S.CANTIDAD as 'Stock',
			 P.PRECIOCOMPRA as 'Precio de compra',
			 P.PRECIOVENTA as 'Precio de venta'
			 from dbo.producto as P
			 inner join dbo.categoria as C 
			 on P.IDCATEGORIA = C.IDCATEGORIA 
			 inner join dbo.STOCK as S
			 on P.IDPRODUCTO = S.IDPRODUCTO 
			 where  P.HABILITADO is not null 
			 and P.NOMBRE like  @nombre + '%';

--busca un producto por su descripcion(categoria) 
		if object_id('BuscarProductoCategoria') is not null
		drop procedure BuscarProductoCategoria;
		go
		create procedure BuscarProductoCategoria(@nombre varchar(30) ) as
			 select 
			 P.nombre as 'nombre',
			 C.descripcion as 'categoria',
			 S.CANTIDAD as 'Stock',
			 P.PRECIOCOMPRA as 'Precio de compra',
			 P.PRECIOVENTA as 'Precio de venta'
			 from dbo.producto as P
			 inner join dbo.categoria as C 
			 on P.IDCATEGORIA = C.IDCATEGORIA 
			 inner join dbo.STOCK as S
			 on P.IDPRODUCTO = S.IDPRODUCTO 
			 where  P.HABILITADO is not null 
			 and C.DESCRIPCION like  @nombre + '%';

--store procedures de proveedor 
		if object_id('ListaProveedores') is not null
		drop procedure ListaProveedores;
		go
		create procedure ListaProveedores as 
			 select 
			 P.razonsocial as 'Razon social',
			 d.IDDIRECCION as 'Direccion',
			 D.PROVINCIA as 'Provincia',
			 P.cuil as 'Cuil',
			 D.CALLE as 'Calle',
			 D.LOCALIDAD as 'Localidad',
			 D.CODIGOPOSTAL as 'Codigo postal',
			 P.habilitado as 'Habilitado'
			 from dbo.proveedor as P 
			 inner join dbo.direccion as D
			 on P.IDDIRECCION = D.IDDIRECCION;

--ultimo proveedor ingresado 
if object_id('UltimoProveedor') is not null
		drop procedure UltimoProveedor;
		go
		create procedure UltimoProveedor(@id int) as

			 select 
			 P.razonsocial as 'Razon social',
			 d.IDDIRECCION as 'Direccion',
			 D.PROVINCIA as 'Provincia',
			 P.cuil as 'Cuil',
			 D.CALLE as 'Calle',
			 D.LOCALIDAD as 'Localidad',
			 D.CODIGOPOSTAL as 'Codigo postal',
			 P.habilitado as 'Habilitado'
			 from dbo.proveedor as P 
			 inner join dbo.direccion as D
			 on P.IDDIRECCION = D.IDDIRECCION 
			 where P.IDPROVEEDOR = MAX(p.IDPROVEEDOR)
 
 --store procedures de proveedor habilitados
		if object_id('ListaProveedoresHabilitados') is not null
		drop procedure ListaProveedoresHabilitados;
		go
		create procedure ListaProveedoresHabilitados as 
			select 
			 P.razonsocial as 'Razon social',
			 d.IDDIRECCION as 'Direccion',
			 D.PROVINCIA as 'Provincia',
			 P.cuil as 'Cuil',
			 D.CALLE as 'Calle',
			 D.LOCALIDAD as 'Localidad',
			 D.CODIGOPOSTAL as 'Codigo postal',
			 P.habilitado as 'Habilitado'
			 from dbo.proveedor as P 
			 inner join dbo.direccion as D
			 on P.IDDIRECCION = D.IDDIRECCION
			 where P.habilitado is not null;

  --store procedures de Buscar proveedor por provincia 
		  if object_id('BuscarProveedorProvincia') is not null
		  drop procedure BuscarProveedorProvincia;
		go
		 create procedure BuscarProveedorProvincia(@provincia VARCHAR(50)) as
			 select 
			 P.razonsocial as 'Razon social',
			 d.IDDIRECCION as 'Direccion',
			 D.PROVINCIA as 'Provincia',
			 P.cuil as 'Cuil',
			 D.CALLE as 'Calle',
			 D.LOCALIDAD as 'Localidad',
			 D.CODIGOPOSTAL as 'Codigo postal',
			 P.habilitado as 'Habilitado'
			 from dbo.proveedor as P 
			 inner join dbo.direccion as D
			 on P.IDDIRECCION = D.IDDIRECCION
			 where P.habilitado is not null
			 and D.provincia like  @provincia + '%';

 --store procedures de orden de compra lista orden compra 
		  if object_id('OrdenCompraVista') is not null
		 drop procedure OrdenCompraVista;
		go
		 create procedure OrdenCompraVista as 
			 select DISTINCT
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
			 where O.FECHAAPROVACION is not null

--store procedures buscar orden de compra por nombre producto
		  if object_id('OrdenCompraBuscarProducto') is not null
		 drop procedure OrdenCompraBuscarProducto;
		go
		 create procedure OrdenCompraBuscarProducto(@nombre varchar(30)) as 
			 select DISTINCT
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
			 where O.FECHAAPROVACION is not null 
			 and P.NOMBRE like  @nombre + '%';

 -- Crea el store procedure para ver las ordenes de compra pendiente 
		 if object_id('OrdenCompraPendientes') is not null
		  drop procedure OrdenCompraPendientes
		go
		 create procedure OrdenCompraPendientes as 
			 select 
			 O.IDORDEN as 'id orden ',
			 D.CANTIDAD as 'cantidad',
			 P.NOMBRE as 'producto',
			 V.RAZONSOCIAL as 'razon social',
			 V.RAZONSOCIAL as 'razon social'
			 from dbo.ORDENCOMPRA AS O
			 inner join dbo.DETALLEORDEN AS D
			 on  O.IDORDEN =  D.IDORDEN
			 inner join dbo.PRODUCTO as P
			 on D.IDPRODUCTO = P.IDPRODUCTO
			 inner join dbo.PROVEEDOR as V
			 on O.IDPROVEEDOR = V.IDPROVEEDOR
			 where O.FECHAAPROVACION = null

--store procedures para sumar el precio de la compra
		 if object_id('sumartotalorden') is not null
		 drop procedure sumartotalorden;
		go
		create procedure sumartotalorden(@orden int) as 
			select 
			D.CANTIDAD as 'cantidad',
			P.PRECIOCOMPRA as 'precio venta'

			from DETALLEORDEN as D
			inner join producto as P
			on D.IDPRODUCTO = P.IDPRODUCTO
			where d.IDORDEN = @orden;


--store procedures para quitar y sumar productos de stock (deposito)
		if object_id('quitardestock') is not null
		 drop procedure quitardestock;
		go
		create procedure quitardestock(@orden int) as 
				select 
				D.CANTIDAD as 'cantidad',
				P.IDPRODUCTO as 'id producto'

				from DETALLEORDEN as D
				inner join PRODUCTO as P
				on D.IDPRODUCTO = P.IDPRODUCTO
				where d.IDORDEN = @orden;

 -- Crea el store procedure para ver las ordenes de compra pendiente 
		 if object_id('OrdenCompraPendientes') is not null
		  drop procedure OrdenCompraPendientes
		go
		 create procedure OrdenCompraPendientes as 
			select 
			O.IDORDEN as 'id orden ',
			O.FECHAAPROVACION as 'fecha aprobacion'

			from dbo.ORDENCOMPRA AS O
			where O.FECHAAPROVACION is null;

 --store procedure categoria muestra todas las categorias 
		if object_id('ListaCategorias') is not null
		drop procedure ListaCategorias
		go
		create procedure ListaCategorias as 
			select 
			c.DESCRIPCION as 'descripcion',
			c.IDCATEGORIA as 'id categoria'
			from dbo.CATEGORIA as c
			where c.HABILITADO is not null

--store procedure categoria muestra categorias por descripcion 
		if object_id('ListaCategoriasCondicion') is not null
		drop procedure ListaCategoriasCondicion
		go
		 create procedure ListaCategoriasCondicion(@descripcion VARCHAR(30)) as 
			 select 
			 c.DESCRIPCION as 'descripcion',
			 c.IDCATEGORIA as 'id categoria'
			 from dbo.CATEGORIA as c
			 where c.HABILITADO is not null
			 and
			 c.DESCRIPCION like @descripcion + '%';

 -- store procedure de detalle lista los detalles de una orden 
		if object_id('listadetalle') is not null
		drop procedure listadetalle
		go
		create procedure listadetalle(@idorden int) as 
			select 
			D.cantidad as 'cantidad',
			P.NOMBRE as 'producto'
			from dbo.DETALLEORDEN as D
			inner join dbo.PRODUCTO as P 
			on D.IDPRODUCTO = P.IDPRODUCTO
			where D.IDORDEN = @idorden;

 --store procedure para direccion devuelve lista de direcciones 
		 if object_id('listadirecion') is not null
		drop procedure listadirecion
		go
		create procedure listadirecion as 
			select 
			altura as 'altura',
			calle as 'calle',
			CODIGOPOSTAL as 'codigo postal',
			localidad as 'localidad',
			provincia as 'provincia'
			--id_direccion as 'id direccion'
			from dbo.DIRECCION;
