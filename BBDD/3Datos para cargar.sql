--sobre cargas de tablas

--cargo direccion
	USE [dbTecProg]
	GO

	INSERT INTO [dbo].[direccion] ([calle],[altura],[localidad],[codigo_postal],[provincia])
		 VALUES
			   ('Las Rosas', '3245','Monte Grande','1842','Buenos Aires'),
			   ('Malvinas', '464','Luis Guillon','1200','Buenos Aires'),
			   ('Las Heras', '4556','Lomas de Zamora','1800','Buenos Aires'),
			   ('Fair', '123','Ezeiza','1111','Buenos Aires'),
			   ('Oliver', '3454','Monte Grande','1842','Buenos Aires'),
			   ('9 de Julio', '355','Monte Grande','1842','Buenos Aires'),
			   ('Las Rosas', '34','Monte Grande','1842','Buenos Aires'),
			   ('25 de Mayo', '34','Ezeiza','1333','Buenos Aires')

	GO
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
			('indumentaria',20-10-20)
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
			(8,'short',150,600)
	go
--cargo stock
	go
	insert into [dbo].[STOCK] (id_producto,cantidad,habilitado) 
	values	(1,20,10-10-20),
			(2,50,10-10-20),
			(3,100,10-10-20),
			(4,100,10-10-20),
			(5,10,10-10-20),
			(6,100,10-10-20),
			(7,100,10-10-20),
			(8,100,10-10-20)
	go
--cargo direccion
	go
	insert into dbo.direccion (altura,calle,codigo_postal,localidad,provincia)
	values	(123,'estrada',1122,'ezeiza','bsas'),
			(67,'paraguay',1231,'temperley','bsas'),
			(64,'belgrano',1823,'capital','bsas'),
			(13,'cabildo',1823,'capital','bsas'),
			(1323,'uruguay',1823,'flores','bsas'),
			(27,'ramos',1823,'lanus','bsas'),
			(1313,'alcorta',1823,'caballito','bsas'),
			(121,'cabildo',1823,'banfield','bsas'),
			(232,'brasil',1823,'temperley','bsas')
	go
--cargo persona
	go
	insert into dbo.PERSONA(id_direccion,dni,nombre,apellido)	
	values	(1,12342332,'marcelo','tevez'),
			(2,32321412,'roberto','velez'),
			(3,53342332,'lucas','sanchez'),
			(6,12345621,'cristian','lugano'),
			(4,21345789,'marcelo','tevez'),
			(7,45612378,'facundo','guillot')
	
--cargo rol
	go
	insert into dbo.ROL(descripcion)
	values	('encargado'),
			('gerente')
	go
--cargo usuario
	 go
	 insert into dbo.USUARIO (id_persona,id_rol,password,legajo,deshabilitado) 
	 values	 (1,1,'1234',1,20-10-20),
			 (2,2,'1234',2,20-10-20),
			 (3,1,'1234',3,20-10-20),
			 (4,1,'1234',4,20-10-20)
	 go
 -- cargo alerta 
	 go
	 insert into dbo.ALERTA(id_stock,id_persona,cantidad_minima) 
	 values		(2,1,100),
				(3,3,100),
				(4,2,100),
				(2,3,100),
				(3,1,100)
	 go
--carga proveedor 
	 go
	 insert into dbo.PROVEEDOR(id_direccion,cuil,razonsocial) 
	 values		(2,20302010222,'loma negra'),
				(4,32220102224,'molinos cañuelas'),
				(6,20364587586,'coto'),
				(1,21321411212,'dia'),
				(5,30010242122,'sinteplast')
	 go
--carga orden 
	 go
	 insert into dbo.orden(id_persona,fecha) 
	 values		(1,20-10-10),
				(2,20-10-10),
				(3,20-10-10),
				(4,20-10-10);
	 go
--carga ordencompra 
	 go
	 insert into dbo.orden_compra (id_orden,id_persona,id_proveedor) 
	 values		(1,1,5),
				(2,3,1),
				(3,4,2),
				(4,1,1)
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
