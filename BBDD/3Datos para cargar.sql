--sobre cargas de tablas

--cargo categoria
	go
	insert into [dbo].[CATEGORIA] (descripcion,habilitado)	
	values	('hogar',20-10-20),
			('jardin',20-10-20),
			('herramientas',20-10-20),
			('electrodomesticos',20-10-20),
			('muebles',20-10-20),
			('tecnologia',20-10-20),
			('decoracion',20-10-20),
			('indumentaria',20-10-20),
			('camping',20-10-20),
			('deportes',20-10-20),
			('instrumentos',20-10-20),
			('iluminaria',20-10-20)
	go
--cargo producto
	go
	insert into [dbo].[PRODUCTO] (id_categoria,nombre,precio_compra,precio_venta)
	values	(1,'cocina ',2000,4000),
			(2,'corta cesped',1400,8000),
			(3,'martillo ',200,600),
			(4,'batidora',1000,3500),
			(5,'ropero',1400,5800),
			(6,'computadora',10000,3000),
			(7,'lampara',400,800),
			(8,'camisa',400,800),
			(6,'dvd',2000,5000),
			(8,'short',150,600),
			(9'carpa',2000,5000),
			(10,'pelota',800,1000),
			(11,'guitarra',1000,2000),
			(12,'Lampara',1000,2000)
	go
--cargo stock
	go
	insert into [dbo].[STOCK] (id_producto,cantidad,habilitado) 
	values	(1,20,GETDATE()),
			(2,50,GETDATE()),
			(3,100,GETDATE()),
			(4,100,GETDATE()),
			(5,10,GETDATE()),
			(6,100,GETDATE()),
			(7,100,GETDATE()),
			(8,100,GETDATE()),
			(10,50,GETDATE()),
			(11,10,GETDATE()),
			(13,100,GETDATE()),
			(14,10,GETDATE())
	go
--cargo direccion
	go
	INSERT INTO [dbo].[direccion] ([calle],[altura],[localidad],[codigo_postal],[provincia])
     VALUES
           ('las rosas', '3245','monte grande','1842','buenos aires'),
		   ('malvinas', '464','luis guillon','1200','buenos aires'),
		   ('las heras', '4556','lomas de zamora','1800','buenos aires'),
		   ('fair', '123','ezeiza','1111','buenos aires'),
		   ('oliver', '3454','monte grande','1842','buenos aires'),
		   ('9 de julio', '355','monte grande','1842','buenos aires'),
		   ('las rosas', '34','monte grande','1842','buenos aires'),
		   ('25 de mayo', '34','ezeiza','1333','buenos aires')
	go
	insert into dbo.direccion (altura,calle,codigo_postal,localidad,provincia)
	values	(123,'estrada','1122','ezeiza','buenos aires'),
			(67,'paraguay','1231','temperley','buenos aires'),
			(64,'belgrano','1823','capital','buenos aires'),
			(13,'cabildo','1823','capital','buenos aires'),
			(1323,'uruguay','1823','flores','buenos aires'),
			(27,'ramos','1823','lanus','buenos Aires'),
			(1313,'alcorta','1823','caballito','buenos aires'),
			(121,'cabildo','1823','banfield','buenos aires'),
			(232,'brasil','1823','temperley','buenos aires'),
			(156,'yrigoyen','5641','rio cuarto','cordoba'),
			(4245,'san martin','1823','temperley','buenos aires'),
			(21,'belgrano','1254','rio cuarto','cordoba'),
			(456,'jacaranda','1234','monte grande','buenos aires'),
			(416,'santa fe','1124','monte grande','la pampa'),
			(1456,'aaaaaaaa','15634','rio cuarto','santa fe'),
			(4356,'25 mayo','1244','monte grande','san luis'),
			(46,'guarani','1412','rio hondo','mendoza'),
			(463,'general peron','1123','los horneros','rio negro')
	go
--cargo persona
	go
	INSERT INTO [dbo].[persona] ([apellido],[nombre],[dni],[id_direccion])
     VALUES
		   ('morrone','mlorencia','22333444', 1),
		   ('solohaga','braian','22333111', 2),
		   ('ovejero','jorge','33444666', 3),
           ('ramirez','martin','33444555', 4),
           ('santos','mario','33666999', 5),
           ('medina','gabriel','11333999', 6),
           ('lampone','pablo','11222999', 7),
           ('ravenna','emilio','11555999', 8),
		   ('contretas','elias','1212321321', 9),
		   ('castillo','claudia','1521421221', 10),
		   ('martelli','mario','1132112421', 11)
	go
	insert into dbo.PERSONA(id_direccion,dni,nombre,apellido)	
	values	(9,12342332,'marcelo','tevez'),
			(10,32321412,'roberto','velez'),
			(11,53342332,'martin','perez'),
			(12,12345621,'cristian','lugano'),
			(13,21345789,'marcelo','tevez'),
			(14,45612378,'facundo','guillot')
	go
	
--cargo rol
	go
	insert into dbo.ROL(descripcion)
	values	('encargado'),
			('gerente'),
			('vendedor')
	go
--cargo usuario
	 go
	 insert into dbo.USUARIO (id_persona,id_rol,password,legajo,deshabilitado) 
	 values	 (1,1,'1234',1,GETDATE()),
			 (2,2,'1234',2,GETDATE()),
			 (3,1,'1234',3,GETDATE()),
			 (4,1,'1234',4,GETDATE()),
			 (5,1,'1234',5,GETDATE())
	 go
 -- cargo alerta 
	 go
	 insert into dbo.ALERTA(id_stock,id_persona,cantidad_minima) 
	 values		(1,1,100),
				(2,3,100),
				(3,2,100),
				(4,3,100),
				(5,1,100)
	 go
--carga proveedor 
	 go
	 insert into dbo.PROVEEDOR(id_direccion,cuil,razonsocial,habilitado) 
	 values		(15,20302010222,'loma negra',GETDATE()),
				(16,32220102224,'molinos cañuelas',GETDATE()),
				(17,20364587586,'coto',GETDATE()),
				(18,21321411212,'dia',GETDATE()),
				(19,30010242122,'sinteplast',GETDATE()),
				(20,80102123122,'la redonda',GETDATE()),
				(21,11210242122,'carrefour',GETDATE()),
				(22,68010242122,'zara',GETDATE())
	 go

--carga orden 
	 go
	 insert into dbo.orden(id_persona,fecha) 
	 values		(10,GETDATE()),
				(11,GETDATE()),
				(10,GETDATE()),
				(12,GETDATE()),
				(13,GETDATE()),
				(14,GETDATE()),
				(12,GETDATE())
	 go
--carga detalleorden
	go
	INSERT INTO [dbo].[detalle_orden]
			   ([cantidad]
			   ,[id_orden]
			   ,[id_producto])
		 VALUES
			   (10,1,2),
			   (5,1,1),
			   (20,1,3),
			   (10,2,6),
			   (5,2,4),
			   (20,3,5),
			   (10,3,5),
			   (30,4,7),
			   (50,5,10),
			   (40,5,11),
			   (54,6,12),
			   (30,7,8)
	GO
--carga ordencompra 
	 go
	 insert into dbo.orden_compra (id_orden,id_persona,id_proveedor) 
	 values		(1,9,5),
				(2,10,1),
				(3,11,2),
				(4,12,1)
	 go
--carga detalle 
	 GO
	 insert into dbo.detalle_orden (id_orden,id_producto,cantidad)
	 values	 (1,2,30),
			 (4,2,30),
			 (2,2,30),
			 (2,1,30),
			 (2,3,30),
			 (3,2,30),
			 (1,4,30)
	 GO
