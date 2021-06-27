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
								@ALTURA NVARCHAR(20),
								@CALLE NVARCHAR(50),
								@CP NVARCHAR(50),
								@LOCALIDAD NVARCHAR(50),
								@PROVINCIA NVARCHAR(50),
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
					   id_proveedor)
				VALUES
					   (@ID,
					   @PROVEEDOR)
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
			SET @FECHA = GETUTCDATE()
				UPDATE [dbo].orden_compra
					SET fecha_aprobacion = @FECHA,
						id_proveedor = @USUARIO
				WHERE id_orden = @ID
		END

		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].orden_compra
				WHERE id_orden = @ID
			END
	END
GO

if object_id('PRODUCTOPROC') is not null
  drop procedure PRODUCTOPROC
go
/*procedimientos de PRODUCTO, EXEC PRODUCTOPROC @ID=INT,@CATEGORIA=INT,@NOMBRE=NVARCHAR50,@COMPRA=FLOAT,@VENTA=FLOAT,@TIPO=NVARCHAR10;*/
CREATE PROCEDURE PRODUCTOPROC	(@ID INT,
						@CATEGORIA INT,
						@NOMBRE VARCHAR(50),
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
						@CUIL NVARCHAR(13),
						@RAZONSOCIAL NVARCHAR(30) ,
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

--store procedure de stock 
		if object_id('sumarstock') is not null
			drop procedure sumarstock;
		go
		create procedure sumarstock (@ID int, @cantidad int) as
			BEGIN

				UPDATE [dbo].[stock]
				set cantidad = cantidad + @cantidad
				WHERE id_producto= @ID	
			END

--store procedure restar stock
		if object_id('restarstock') is not null
			drop procedure restarstock;
		go
		create procedure restarstock (@ID int,@cantidad int) as
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
				p.id_producto as 'id producto',
				p.nombre as 'producto',
				c.descripcion as 'categoria'
			from [dbo].[stock] as s
				inner join [dbo].producto as p
				on s.id_producto = p.id_producto
				inner join [dbo].[categoria] as C
				on c.id_categoria = p.id_categoria
			where s.habilitado is not null;

--store procedure de alertas criticas 
		if object_id('VistaAlertasCriticas') is not null
			drop procedure VistaAlertasCriticas;
		go
		create procedure VistaAlertasCriticas as 

			select 
				A.id_alerta as 'id alerta',
				C.descripcion as 'Descripcion',
				B.nombre as 'producto',
				P.nombre +' '+P.apellido as 'usuario',
				A.cantidad_minima as  'cantidad minima',
				S.cantidad as 'cantidad stock'
			from dbo.alerta as A
				 inner join dbo.stock as S 
				 on A.id_STOCK = S.id_STOCK
				 inner join dbo.USUARIO as U
				 on A.id_persona= U.id_persona
				 inner join dbo.PERSONA as P 
				 on U.id_persona = P.id
				 inner join dbo.PRODUCTO as B
				 on S.id_producto = B.id_producto
				 inner join dbo.CATEGORIA as C 
				 on B.id_categoria = C.id_categoria
			where S.CANTIDAD <= a.cantidad_minima

 --store procedure de alertas 
		if object_id('VistaAlertas') is not null
			drop procedure VistaAlertas;
		go
		create procedure VistaAlertas as 
			 select 
				 A.id_alerta as 'id alerta',
				 C.DESCRIPCION as 'Descripcion',
				 B.nombre as 'producto',
				 P.nombre +' '+P.apellido as 'usuario',
				 A.cantidad_minima as  'cantidad minima',
				 S.cantidad as 'cantidad stock'
			 from dbo.alerta as A
				 inner join dbo.stock as S 
				 on A.id_stock = S.id_stock
				 inner join dbo.USUARIO as U
				 on A.id_persona= U.id_persona
				 inner join dbo.PERSONA as P 
				 on U.id_persona = P.id
				 inner join dbo.PRODUCTO as B
				 on S.id_producto = B.id_producto
				 inner join dbo.CATEGORIA as C 
				 on B.id_categoria = C.id_categoria

--store procedure de productos 

--listar productos habilitados
		if object_id('ListaProductos') is not null
		drop procedure ListaProductos;
		go
		create procedure ListaProductos as
			 select 
				 P.id_producto as 'id_producto',
				 P.nombre as 'nombre',
				 C.id_categoria as 'idcategoria',
				 C.descripcion as 'categoria',
				 S.CANTIDAD as 'Stock',
				 P.precio_compra as 'Precio de compra',
				 P.precio_venta as 'Precio de venta'
			 from dbo.producto as P
				 inner join dbo.categoria as C 
				 on P.id_categoria = C.id_categoria 
				 inner join dbo.STOCK as S
				 on P.id_producto = S.id_producto 

--store procedures de proveedor 
		if object_id('ListaProveedores') is not null
		drop procedure ListaProveedores;
		go
		create procedure ListaProveedores as 
			 select 
				 P.id_proveedor as 'ID Proveedor',
				 P.razonsocial as 'Razon social',
				 d.id as 'Direccion',
				 D.PROVINCIA as 'Provincia',
				 P.cuil as 'CUIL',
				 D.CALLE as 'Calle',
				 D.altura as 'Altura',
				 D.LOCALIDAD as 'Localidad',
				 D.codigo_postal as 'Codigo postal'
			 from dbo.proveedor as P 
				 inner join dbo.direccion as D
				 on P.id_direccion = D.id;

--ultimo proveedor ingresado 
if object_id('UltimoProveedor') is not null
		drop procedure UltimoProveedor;
		go
		create procedure UltimoProveedor as

			 select 
				 P.id_proveedor as 'ID Proveedor',
				 P.razonsocial as 'Razon social',
				 d.id as 'Direccion',
				 D.PROVINCIA as 'Provincia',
				 P.cuil as 'Cuil',
				 D.CALLE as 'Calle',
				 D.altura as 'Altura',
				 D.LOCALIDAD as 'Localidad',
				 D.codigo_postal as 'Codigo postal'
			 from dbo.proveedor as P 
				 inner join dbo.direccion as D
				 on P.id_direccion = D.id 
			 where P.id_proveedor = MAX(p.id_proveedor)
 
 --store procedures de proveedor habilitados
		if object_id('ListaProveedoresHabilitados') is not null
			drop procedure ListaProveedoresHabilitados;
		go
		create procedure ListaProveedoresHabilitados as 
			select 
				P.id_proveedor as 'ID Proveedor',
				P.razonsocial as 'Razon social',
				d.id as 'Direccion',
				D.PROVINCIA as 'Provincia',
				P.cuil as 'Cuil',
				D.CALLE as 'Calle',
				D.altura as 'Altura',
				D.LOCALIDAD as 'Localidad',
				D.codigo_postal as 'Codigo postal'
			from dbo.proveedor as P 
				 inner join dbo.direccion as D
				 on P.id_direccion = D.id
			where P.habilitado is not null;

  --store procedures de Buscar proveedor por provincia 
		if object_id('BuscarProveedorProvincia') is not null
		  drop procedure BuscarProveedorProvincia;
		go
		create procedure BuscarProveedorProvincia(@provincia NVARCHAR(50)) as
			 select 
				 P.id_proveedor as 'ID Proveedor',
				 P.razonsocial as 'Razon social',
				 d.id as 'Direccion',
				 D.PROVINCIA as 'Provincia',
				 P.cuil as 'Cuil',
				 D.CALLE as 'Calle',
				 D.LOCALIDAD as 'Localidad',
				 D.codigo_postal as 'Codigo postal',
				 P.habilitado as 'Habilitado'
			 from dbo.proveedor as P 
				 inner join dbo.direccion as D
				 on P.id_direccion = D.id
			 where P.habilitado is not null
				and D.provincia like  @provincia + '%';

 --store procedures de orden de compra lista orden compra 
		if object_id('OrdenCompraVista') is not null
			drop procedure OrdenCompraVista;
		go
		create procedure OrdenCompraVista as 
			select DISTINCT
				 O.id_orden as 'id orden',
				 D.CANTIDAD as 'cantidad',
				 P.NOMBRE as 'producto',
				 V.RAZONSOCIAL as 'razon social',
				 O.fecha_aprobacion as 'fecha aprobacion'
			from dbo.orden_compra AS O
				 inner join dbo.detalle_orden AS D
				 on  O.id_orden =  D.id_orden
				 inner join dbo.PRODUCTO as P
				 on D.id_producto = P.id_producto
				 inner join dbo.PROVEEDOR as V
				 on O.id_proveedor = V.id_proveedor
			where O.fecha_aprobacion is not null

--store procedures buscar orden de compra por nombre producto
		  if object_id('OrdenCompraBuscarProducto') is not null
		 drop procedure OrdenCompraBuscarProducto;
		go
		 create procedure OrdenCompraBuscarProducto(@nombre varchar(30)) as 
			 select DISTINCT
				 O.id_orden as 'id orden',
				 D.CANTIDAD as 'cantidad',
				 P.NOMBRE as 'producto',
				 V.RAZONSOCIAL as 'razon social',
				 O.fecha_aprobacion as 'fecha aprobacion'
			from dbo.orden_compra AS O
				 inner join dbo.detalle_orden AS D
				 on  O.id_orden =  D.id_orden
				 inner join dbo.PRODUCTO as P
				 on D.id_producto = P.id_producto
				 inner join dbo.PROVEEDOR as V
				 on O.id_proveedor = V.id_proveedor
			where O.fecha_aprobacion is not null
			 and P.NOMBRE like  @nombre + '%';

--store procedures buscar orden de compra por proveedor
		  if object_id('OrdenCompraBuscarProducto') is not null
		 drop procedure OrdenCompraBuscarProducto;
		go
		 create procedure OrdenCompraBuscarProveedor(@proveedor varchar(30)) as 
			 select DISTINCT
				 O.id_orden as 'id orden',
				 D.CANTIDAD as 'cantidad',
				 P.NOMBRE as 'producto',
				 V.RAZONSOCIAL as 'razon social',
				 O.fecha_aprobacion as 'fecha aprobacion'
			from dbo.orden_compra AS O
				 inner join dbo.detalle_orden AS D
				 on  O.id_orden =  D.id_orden
				 inner join dbo.PRODUCTO as P
				 on D.id_producto = P.id_producto
				 inner join dbo.PROVEEDOR as V
				 on O.id_proveedor = V.id_proveedor
			where O.fecha_aprobacion is not null
			 and V.razonsocial like  @proveedor + '%';

 -- Crea el store procedure para ver las ordenes de compra pendiente 
		 if object_id('OrdenCompraPendientes') is not null
		  drop procedure OrdenCompraPendientes
		go
		 create procedure OrdenCompraPendientes as 
			 select 
			 O.id_orden as 'id orden ',
			 D.CANTIDAD as 'cantidad',
			 P.NOMBRE as 'producto',
			 V.razonsocial as 'razon social'
			 from dbo.orden_compra AS O
			 inner join dbo.detalle_orden AS D
			 on  O.id_orden =  D.id_orden
			 inner join dbo.PRODUCTO as P
			 on D.id_producto = P.id_producto
			 inner join dbo.PROVEEDOR as V
			 on O.id_proveedor = V.id_proveedor
			 where O.fecha_aprobacion is null --ahora uso is null

--store procedures para sumar el precio de la compra
		 if object_id('sumartotalorden') is not null
		 drop procedure sumartotalorden;
		go
		create procedure sumartotalorden(@orden int) as 
			select 
			D.cantidad as 'cantidad',
			P.precio_venta as 'precio venta'

			from detalle_orden as D
			inner join producto as P
			on D.id_producto = P.id_producto
			where d.id_orden = @orden;


--store procedures para quitar y sumar productos de stock (deposito)
		if object_id('quitardestock') is not null
		 drop procedure quitardestock;
		go
		create procedure quitardestock(@orden int) as 
				select 
				D.cantidad as 'cantidad',
				P.id_producto as 'id producto'

				from detalle_orden as D
				inner join PRODUCTO as P
				on D.id_producto = P.id_producto
				where d.id_orden = @orden;

 -- Crea el store procedure para ver las ordenes de compra pendiente 
		 if object_id('OrdenCompraPendientes') is not null
		  drop procedure OrdenCompraPendientes
		go
		 create procedure OrdenCompraPendientes as 
			select 
			O.id_orden as 'id orden ',
			O.fecha_aprobacion as 'fecha aprobacion'

			from dbo.orden_compra AS O
			where O.fecha_aprobacion is null;

 --store procedure categoria muestra todas las categorias 
		if object_id('ListaCategorias') is not null
		drop procedure ListaCategorias
		go
		create procedure ListaCategorias as 
			select 
			c.DESCRIPCION as 'descripcion',
			c.id_categoria as 'id categoria'
			from dbo.CATEGORIA as c
			where c.HABILITADO is not null

--store procedure categoria muestra categorias por descripcion 
		if object_id('ListaCategoriasCondicion') is not null
		drop procedure ListaCategoriasCondicion
		go
		 create procedure ListaCategoriasCondicion(@descripcion VARCHAR(30)) as 
			 select 
			 c.DESCRIPCION as 'descripcion',
			 c.id_categoria as 'id categoria'
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
			from dbo.detalle_orden as D
			inner join dbo.PRODUCTO as P 
			on D.id_producto = P.id_producto
			where D.id_orden = @idorden;

 --store procedure para direccion devuelve lista de direcciones 
		 if object_id('listadireccion') is not null
		drop procedure listadireccion
		go
		create procedure listadireccion as 
			select 
			altura as 'altura',
			calle as 'calle',
			codigo_postal as 'codigo postal',
			localidad as 'localidad',
			provincia as 'provincia'
			--id_direccion as 'id direccion'
			from dbo.DIRECCION;
