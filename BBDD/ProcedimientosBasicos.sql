/*/*procedimientos de ALERTA, EXEC ALERTAPROC @ID = INT,@STOCK = INT,@USUARIO = INT,@MINIMO = INT,@TIPO = NVARCHAR(10);*/ 
CREATE PROCEDURE ALERTAPROC	(@ID INT,
							@STOCK INT,
							@USUARIO INT,
							@MINIMO INT,
							@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[ALERTA]
					   ([IDSTOCK],
					   [IDPERSONA],
					   [CANTIDADMINIMA])
				VALUES
					   (@STOCK,
					   @USUARIO,
					   @MINIMO)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT [IDALERTA],
						[IDSTOCK],
						[IDPERSONA],
						[CANTIDADMINIMA]
				FROM [dbo].[ALERTA]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT [IDALERTA],
						[IDSTOCK],
					   [IDPERSONA],
					   [CANTIDADMINIMA]
				FROM [dbo].[ALERTA]
				WHERE ([IDALERTA] = @ID OR [IDSTOCK] = @STOCK OR [IDPERSONA] = @USUARIO) 
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT [IDALERTA]
				FROM [dbo].[ALERTA]
				WHERE [IDSTOCK] = @STOCK
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@STOCK IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[ALERTA]
						SET [IDSTOCK] = @STOCK
						WHERE [IDALERTA] = @ID
					END
				IF (@USUARIO IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[ALERTA]
						SET	[IDPERSONA] = @USUARIO
						WHERE [IDALERTA] = @ID
					END
				IF (@MINIMO IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[ALERTA]
						SET	[CANTIDADMINIMA] = @MINIMO
						WHERE [IDALERTA] = @ID
					END
				
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[ALERTA]
				WHERE [IDALERTA] = @ID
			END
	END
GO*/

/*procedimientos de CATEGORIA, EXEC CATEGORIAPROC @ID = INT,@DESCRIPCION = VARCHAR(30),@TIPO = NVARCHAR(10);*/
CREATE PROCEDURE CATEGORIAPROC (@ID INT,
								@DESCRIPCION VARCHAR(30),
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[CATEGORIA]
					   ([DESCRIPCION])
				VALUES
					   (@DESCRIPCION)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT [IDCATEGORIA],
						[DESCRIPCION]
				FROM [dbo].[CATEGORIA]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT	[IDCATEGORIA],
						[DESCRIPCION]
				FROM [dbo].[CATEGORIA]
				WHERE [IDCATEGORIA] = @ID OR [DESCRIPCION] = @DESCRIPCION
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT	[IDCATEGORIA]
				FROM [dbo].[CATEGORIA]
				WHERE [DESCRIPCION] = @DESCRIPCION
			END	
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DESCRIPCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[CATEGORIA]
						SET	[DESCRIPCION] = @DESCRIPCION
						WHERE [IDCATEGORIA] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[CATEGORIA]
				WHERE [IDCATEGORIA] = @ID
			END
	END
GO

/*procedimientos de DIRECCION, EXEC DIRECCIONPROC @ID=INT,@ALTURA=VARCHAR(6),@CALLE=VARCHAR(30),@CP=INT,@LOCALIDAD=VARCHAR(20),@PROVINCIA=VARCHAR(20),@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE DIRECCIONPROC (@ID INT,
								@ALTURA VARCHAR(6),
								@CALLE VARCHAR(30),
								@CP INT,
								@LOCALIDAD VARCHAR(20),
								@PROVINCIA VARCHAR(20),
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[DIRECCION]
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
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT [IDDIRECCION],
						[ALTURA],
						[CALLE],
						[CODIGOPOSTAL],
						[LOCALIDAD],
						[PROVINCIA]
				FROM [dbo].[DIRECCION]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT [IDDIRECCION],
						[ALTURA],
						[CALLE],
						[CODIGOPOSTAL],
						[LOCALIDAD],
						[PROVINCIA]
				FROM [dbo].[DIRECCION]
				WHERE (([IDDIRECCION] = @ID) OR ([CALLE] = @CALLE AND [ALTURA] = @ALTURA AND [LOCALIDAD] = @LOCALIDAD))
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT [IDDIRECCION]
				FROM [dbo].[DIRECCION]
				WHERE ([CALLE] = @CALLE AND [ALTURA] = @ALTURA AND [LOCALIDAD] = @LOCALIDAD AND [CODIGOPOSTAL] = @CP)
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@ALTURA IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[DIRECCION]
						SET [ALTURA] = @ALTURA
						WHERE [IDDIRECCION] = @ID
					END
				IF (@CALLE IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[DIRECCION]
						SET [CALLE] = @CALLE
						WHERE [IDDIRECCION] = @ID
					END
				IF (@CP IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[DIRECCION]
						SET [CODIGOPOSTAL] = @CP
						WHERE [IDDIRECCION] = @ID
					END
				IF (@LOCALIDAD IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[DIRECCION]
						SET [LOCALIDAD] = @LOCALIDAD
						WHERE [IDDIRECCION] = @ID
					END
				IF (@PROVINCIA IS NOT NULL) 
					BEGIN
						UPDATE [dbo].[DIRECCION]
						SET [PROVINCIA] = @PROVINCIA
						WHERE [IDDIRECCION] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[DIRECCION]
				WHERE [IDDIRECCION] = @ID
			END
	END
GO

/*procedimientos de DETALLEORDEN, EXEC DETALLEPROC @ID = SMALLINT,@ORDEN=INT,@PRODUCTO=INT,@CANTIDAD=SMALLINT,@TIPO = '';*/
CREATE PROCEDURE DETALLEPROC	(@ID SMALLINT,
								@ORDEN INT,
								@PRODUCTO INT,
								@CANTIDAD SMALLINT,
								@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[DETALLEORDEN]
					   ([IDPRODUCTO],
					   [CANTIDAD])
				VALUES
					   (@PRODUCTO,
					   @CANTIDAD)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT	[IDDETALLE],
						[IDORDEN],
						[IDPRODUCTO],
						[CANTIDAD]
				FROM [dbo].[DETALLEORDEN]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT	[IDDETALLE],
						[IDORDEN],
						[IDPRODUCTO],
						[CANTIDAD]
				FROM [dbo].[DETALLEORDEN]
				WHERE ([IDORDEN] = @ORDEN AND [IDDETALLE] = @ID)
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT	[IDDETALLE]
				FROM [dbo].[DETALLEORDEN]
				WHERE [IDORDEN] = @ORDEN AND [IDPRODUCTO] = @PRODUCTO /*Ver para que no compren dos veces el mismo producto en una orden, que modifiquen la cantidad del ingresado*/
			END
		IF @TIPO = 'UPDATE'
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
				WHERE (([IDORDEN] = @ORDEN AND [IDDETALLE] = @ID) OR [IDORDEN] = @ORDEN)
			END
	END
GO

/*procedimientos de ORDEN, EXEC ORDENPROD @ID=INT,@USUARIO=INT,@FECHA=DATETIME,@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE ORDENPROC	(@ID INT,
							@USUARIO INT,
							@FECHA DATETIME,
							@TIPO NVARCHAR(10))
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[ORDEN]
					   ([IDPERSONA],
					   [FECHA])
				VALUES
					   (@USUARIO,
					   @FECHA)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT [IDORDEN],
						[IDPERSONA],
						[FECHA]
				FROM [dbo].[ORDEN]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT [IDORDEN],
						[IDPERSONA],
						[FECHA]
				FROM [dbo].[ORDEN]
				WHERE [IDORDEN] = @ID
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@USUARIO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[ORDEN]
						SET	[IDPERSONA] = @USUARIO 
						WHERE [IDORDEN] = @ID
					END
				IF (@FECHA IS NOT NULL)
					BEGIN
						UPDATE [dbo].[ORDEN]
						SET	[FECHA] = @FECHA 
						WHERE [IDORDEN] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[ORDEN]
				WHERE [IDORDEN] = @ID
			END
	END
GO

/*procedimientos de ORDENCOMPRA, EXEC ORDENCOMPRAPROC @ID=INT,@PROVEEDOR=INT,@USUARIO=INT,@FECHA=SMALLDATETIME,@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE ORDENCOMPRAPROC	(@ID INT,
									@PROVEEDOR INT,
									@USUARIO INT,
									@FECHA SMALLDATETIME,
									@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[ORDENCOMPRA]
					   ([IDPROVEEDOR],
					   [IDPERSONA],
					   [FECHAAPROVACION])
				VALUES
					   (@PROVEEDOR,
					   @USUARIO,
					   @FECHA)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT	[IDORDEN],
						[IDPROVEEDOR],
						[IDPERSONA],
						[FECHAAPROVACION]
				FROM [dbo].[ORDENCOMPRA]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT	[IDORDEN],
						[IDPROVEEDOR],
						[IDPERSONA],
						[FECHAAPROVACION]
				FROM [dbo].[ORDENCOMPRA]
				WHERE [IDORDEN] = @ID
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT	[IDORDEN]
				FROM [dbo].[ORDENCOMPRA]
				WHERE [IDPROVEEDOR] = @PROVEEDOR AND [IDPERSONA] = @USUARIO AND [FECHAAPROVACION] = @FECHA
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
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[ORDENCOMPRA]
				WHERE [IDORDEN] = @ID
			END
	END
GO

/*procedimientos de PERSONA, EXEC PERSONAPROC @ID=INT,@DIRECCION=INT,@NOMBRE=VARCHAR(30),@APELLIDO=VARCHAR(30),@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE PERSONAPROC	(@ID INT,
						@DIRECCION INT,
						@DNI INT,
						@NOMBRE VARCHAR(30),
						@APELLIDO VARCHAR(30),
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
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT	[IDPERSONA],
						[IDDIRECCION],
						[DNI],
						[NOMBRE],
						[APELLIDO]
				FROM [dbo].[PERSONA]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT	[IDPERSONA],
						[IDDIRECCION],
						[DNI],
						[NOMBRE],
						[APELLIDO]
				FROM [dbo].[PERSONA]
				WHERE [IDPERSONA] = @ID
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT	[IDPERSONA]
				FROM [dbo].[PERSONA]
				WHERE [DNI] = @DNI
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DIRECCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PERSONA]
						SET	[IDDIRECCION] = @DIRECCION
						WHERE [IDPERSONA] = @ID
					END
				IF (@DNI IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PERSONA]
						SET	[DNI] = @DNI
						WHERE [IDPERSONA] = @ID
					END
				IF (@NOMBRE IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PERSONA]
						SET	[NOMBRE] = @NOMBRE
						WHERE [IDPERSONA] = @ID
					END
				IF (@APELLIDO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PERSONA]
						SET	[APELLIDO] = @APELLIDO
						WHERE [IDPERSONA] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[PERSONA]
				WHERE [IDPERSONA] = @ID
			END
	END
GO
/*procedimientos de PRODUCTO, EXEC PRODUCTOPROC @ID=INT,@CATEGORIA=SMALLINT,@NOMBRE=NVARCHAR(50),@COMPRA REAL,@VENTA REAL,@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE PRODUCTOPROC	(@ID INT,
						@CATEGORIA SMALLINT,
						@NOMBRE NVARCHAR(50),
						@VENTA REAL,
						@COMPRA REAL,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[PRODUCTO]
					   ([IDCATEGORIA],
					   [NOMBRE],
					   [PRECIOCOMPRA],
					   [PRECIOVENTA])
				VALUES
					   (@CATEGORIA,
					   @NOMBRE,
					   @COMPRA,
					   @VENTA)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT	[IDPRODUCTO],
						[IDCATEGORIA],
						[NOMBRE],
						[PRECIOCOMPRA],
						[PRECIOVENTA]
				FROM [dbo].[PRODUCTO]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT	[IDPRODUCTO],
						[IDCATEGORIA],
						[NOMBRE],
						[PRECIOCOMPRA],
						[PRECIOVENTA]
				FROM [dbo].[PRODUCTO]
				WHERE [IDPRODUCTO] = @ID
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT	[IDPRODUCTO]
				FROM [dbo].[PRODUCTO]
				WHERE [NOMBRE] = @NOMBRE AND [CATEGORIA] = @CATEGORIA
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
				DELETE FROM [dbo].[PRODUCTO]
				WHERE [IDPRODUCTO] = @ID
			END
	END
GO

/*procedimientos de PROVEEDOR, EXEC PROVEEDORPROC @ID=INT,@DIRECCION=INT,@CUIL=VARCHAR(13),@RAZONSOCIAL=VARCHAR(30),@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE PROVEEDORPROC	(@ID INT,
						@DIRECCION INT,
						@CUIL VARCHAR(13),
						@RAZONSOCIAL VARCHAR(30) ,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[PROVEEDOR]
					   ([IDDIRECCION],
					   [CUIL],
					   [RAZONSOCIAL])
				VALUES
					   (@DIRECCION,
					   @CUIL,
					   @RAZONSOCIAL)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT	[IDPROVEEDOR],
						[IDDIRECCION],
						[CUIL],
						[RAZONSOCIAL]
				FROM [dbo].[PROVEEDOR]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT	[IDPROVEEDOR],
						[IDDIRECCION],
						[CUIL],
						[RAZONSOCIAL]
				FROM [dbo].[PROVEEDOR]
				WHERE [IDPROVEEDOR] = @ID
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT	[IDPROVEEDOR]
				FROM [dbo].[PROVEEDOR]
				WHERE [CUIL] = @CUIL OR [RAZONSOCIAL] = @RAZONSOCIAL
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DIRECCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PROVEEDOR]
						SET	[IDDIRECCION] = @DIRECCION
						WHERE [IDPROVEEDOR] = @ID
					END
				IF (@CUIL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PROVEEDOR]
						SET	[CUIL] = @CUIL
						WHERE [IDPROVEEDOR] = @ID
					END
				IF (@RAZONSOCIAL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[PROVEEDOR]
						SET	[RAZONSOCIAL] = @RAZONSOCIAL
						WHERE [IDPROVEEDOR] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[PROVEEDOR]
				WHERE [IDPROVEEDOR] = @ID
			END
	END
GO

/*procedimientos de ROL, EXEC ROLPROC @ID=INT,@DESCRIPCION=VARCHAR(20),@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE ROLPROC	(@ID INT,
						@DESCRIPCION VARCHAR(20),
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[ROL]
					   ([DESCRIPCIONROL])
				VALUES
					   (@DESCRIPCION)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT [IDROL],
						[DESCRIPCIONROL]
				FROM [dbo].[ROL]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT [DESCRIPCIONROL]
				FROM [dbo].[ROL]
				WHERE [IDROL] = @ID
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT [DESCRIPCIONROL]
				FROM [dbo].[ROL]
				WHERE [DESCRIPCIONROL] = @DESCRIPCION
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@DESCRIPCION IS NOT NULL)
					BEGIN
						UPDATE [dbo].[ROL]
						SET	[DESCRIPCIONROL] = @DESCRIPCION
						WHERE [IDROL] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[ROL]
				WHERE [IDROL] = @ID
			END
	END
GO

/*procedimientos de STOCK, EXEC STOCKPROC @ID=INT,@PRODUCTO=INT,@CANTIDAD=INT,@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE STOCKPROC	(@ID INT,
						@PRODUCTO INT,
						@CANTIDAD INT,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[STOCK]
					   ([IDPRODUCTO],
					   [CANTIDAD])
				VALUES
					   (@PRODUCTO,
					   @CANTIDAD)
			END
		IF @TIPO = 'SELECTALL'
			BEGIN
				SELECT	[IDSTOCK],
						[IDPRODUCTO],
						[CANTIDAD]
				FROM [dbo].[STOCK]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT	[IDSTOCK],
						[IDPRODUCTO],
						[CANTIDAD]
				FROM [dbo].[STOCK]
				WHERE [IDSTOCK] = @ID
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT	[IDSTOCK]
				FROM [dbo].[STOCK]
				WHERE [IDPRODUCTO] = @PRODUCTO AND [CANTIDAD] = @CANTIDAD
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@PRODUCTO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[STOCK]
						SET	[IDPRODUCTO] = @PRODUCTO
						WHERE [IDSTOCK] = @ID
					END
				IF (@CANTIDAD IS NOT NULL)
					BEGIN
						UPDATE [dbo].[STOCK]
						SET	[CANTIDAD] = @CANTIDAD
						WHERE [IDSTOCK] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[STOCK]
				WHERE [IDSTOCK] = @ID
			END
	END
GO

/*procedimientos de USUARIO, EXEC USUARIOPROC @ID=INT,@ROL=TINYINT,@LEGAJO=INT,@TIPO=NVARCHAR(10);*/
CREATE PROCEDURE USUARIOPROC	(@ID INT,
						@ROL TINYINT,
						@LEGAJO INT,
						@TIPO NVARCHAR(10) = '')
AS
	BEGIN
		IF @TIPO = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[USUARIO]
					   ([IDROL],
					   [LEGAJO])
				VALUES
					   (@ROL,
					   @LEGAJO)
			END
		IF @TIPO ='SELECTALL'
			BEGIN
				SELECT  [IDPERSONA],
						[IDROL],
						[LEGAJO]
				FROM [dbo].[USUARIO]
			END
		IF @TIPO = 'SELECTONE'
			BEGIN
				SELECT  [IDPERSONA],
						[IDROL],
						[LEGAJO]
				FROM [dbo].[USUARIO]
				WHERE [IDPERSONA] = @ID OR [LEGAJO] = @LEGAJO
			END
		IF @TIPO = 'SELECTID'
			BEGIN
				SELECT  [IDPERSONA]
				FROM [dbo].[USUARIO]
				WHERE [LEGAJO] = @LEGAJO
			END
		IF @TIPO = 'UPDATE'
			BEGIN
				IF (@ROL IS NOT NULL)
					BEGIN
						UPDATE [dbo].[USUARIO]
						SET	[IDROL] = @ROL
						WHERE [IDPERSONA] = @ID
					END
				IF (@LEGAJO IS NOT NULL)
					BEGIN
						UPDATE [dbo].[USUARIO]
						SET	[LEGAJO] = @LEGAJO 
						WHERE [IDPERSONA] = @ID
					END
			END
		IF @TIPO = 'DELETE'
			BEGIN
				DELETE FROM [dbo].[USUARIO]
				WHERE [IDPERSONA] = @ID
			END
	END
GO