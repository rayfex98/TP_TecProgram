--sobre cargas de tablas

--cargo categoria
go
insert into [dbo].[CATEGORIA] (descripcion,habilitado)values ('hogar',20-10-20),
('jardin',20-10-20),('herramientas',20-10-20),('electrodomesticos',20-10-20),('muebles',20-10-20),
('tecnologia',20-10-20),('decoracion',20-10-20),('indumentaria',20-10-20)
go
--cargo producto
go
insert into [dbo].[PRODUCTO] (id_categoria,nombre,precio_compra,precio_venta,HABILITADO)values 
(1,'cocina ',200,400,20-10-20),(2,'corta cesped',400,800,20-10-10),(3,'martillo ',100,200,20-10-20),(4,'batidora',100,150,20-10-20),
(5,'ropero',400,800,20-10-10),(6,'computadora',400,800,20-10-10),(7,'lampara',400,800,20-10-10),(8,'camisa',400,800,20-10-10)
go
--cargo stock
go
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(1,20,10-10-20),(2,50,10-10-20),(3,100,10-10-20),(4,100,10-10-20),(5,10,10-10-20),(6,100,10-10-20),(7,100,10-10-20),(8,100,10-10-20)
go
--cargo direccion
EXEC DIRECCIONPROC @ID=null,@ALTURA=123,@CALLE=estrada,@CP=1122,@LOCALIDAD=ezeiza,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=67,@CALLE=lasheras,@CP=1222,@LOCALIDAD=ezeiza,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=64,@CALLE=paraguay,@CP=1231,@LOCALIDAD=cañuelas,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=13,@CALLE=cabildo,@CP=1823,@LOCALIDAD=capital,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=1323,@CALLE=aveces,@CP=1223,@LOCALIDAD=flores,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=27,@CALLE=uruguay,@CP=1314,@LOCALIDAD=lanus,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=1313,@CALLE=ramos,@CP=1232,@LOCALIDAD=caballito,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=121,@CALLE= alcorta,@CP=1212,@LOCALIDAD=banfield,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=232,@CALLE=brasil,@CP=2331,@LOCALIDAD=cañuelas,@PROVINCIA=bsas,@TIPO='INSERT';
--cargo persona
go
insert into dbo.PERSONA(id_direccion,dni,nombre,apellido)	values
(1,12342332,'marcelo','tevez'),(2,32321412,'roberto','velez'),(3,53342332,'lucas','sanchez'),(6,12342332,'cristian','lugano'),(4,12342332,'marcelo','tevez'),(7,12342332,'facundo','guillot')
go
--cargo rol
go
insert into dbo.ROL(DESCRIPCIONROL)values('encargado'),('gerente')
go
--cargo usuario
 go
 insert into dbo.USUARIO (IDPERSONA,IDROL,PASSWORD,HABILITADO) values(1,1,'1234',20-10-20),(2,2,'1234',20-10-20),(3,1,'1234',20-10-20),(4,1,'1234',20-10-20)
 go
 -- cargo alerta 
 go
 insert into dbo.ALERTA(IDSTOCK,IDPERSONA,CANTIDADMINIMA) values(2,1,100),(3,3,100),(4,4,100),(6,3,100),(3,1,100)
 go
 --carga proveedor 
 go
 insert into dbo.PROVEEDOR(id_direccion,cuil,razonsocial) values(2,20302010222,'loma negra'),(4,3222010222,'molinos cañuelas'),(6,20302010222,'coto'),(1,21321411212,'dia'),(5,30010242122,'sinteplast')
 go
 --carga orden 
 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (1,20-10-10);
 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (2,20-10-10);
 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (3,20-10-10);
 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (4,20-10-10);
 --carga ordencompra 
 go
 insert into dbo.ORDENCOMPRA(IDORDEN,IDPERSONA,IDPROVEEDOR) values (1,1,5),(2,3,1),(3,4,2)
 go
 --carga detalle 
 GO
 insert into dbo.DETALLEORDEN(IDORDEN,IDPRODUCTO,CANTIDAD )values (1,2,30),(5,2,30),(3,2,30),(1,4,30)
 GO

 /*Datos Tabla Direccion*/
USE [dbTecProg]
GO

INSERT INTO [dbo].[direccion]
           ([calle]
           ,[altura]
           ,[localidad]
           ,[codigo_postal]
           ,[provincia])
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