--sobre cargas de tablas

--cargo categoria
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)values ('hogar',20-10-20);
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)values ('jardin',20-10-20);
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)values ('herramientas',20-10-20);
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)values ('electrodomesticos',20-10-20);
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)values ('muebles',20-10-20);
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)values ('tecnologia',20-10-20);
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)values ('decoracion',20-10-20);
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)values ('indumentaria',20-10-20);
--cargo producto
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)values (1,'cocina ',200,400,20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)values (2,'corta cesped',400,800,20-10-10);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO) values (3,'martillo ',100,200,20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO) values (4,'batidora',100,150,20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO) values (5,'ropero',400,800,20-10-10);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO) values (6,'computadora',400,800,20-10-10);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO) values (7,'Lampara',400,800,20-10-10);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO) values (8,'camisa',400,800,20-10-10);
--cargo stock
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(1,20,10-10-20) ;
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(2,50,10-10-20) ;
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(3,100,10-10-20) ;
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(4,100,10-10-20) ;
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(5,10,10-10-20) ;
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(6,100,10-10-20) ;
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(7,100,10-10-20) ;
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO) values(8,100,10-10-20) ;
--cargo direccion
EXEC DIRECCIONPROC @ID=null,@ALTURA=123,@CALLE=estrada,@CP=1122,@LOCALIDAD=ezeiza,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=67,@CALLE=lasheras,@CP=1222,@LOCALIDAD=ezeiza,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=64,@CALLE=paraguay,@CP=1231,@LOCALIDAD=ca�uelas,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=13,@CALLE=cabildo,@CP=1823,@LOCALIDAD=capital,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=1323,@CALLE=aveces,@CP=1223,@LOCALIDAD=flores,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=27,@CALLE=uruguay,@CP=1314,@LOCALIDAD=lanus,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=1313,@CALLE=ramos,@CP=1232,@LOCALIDAD=caballito,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=121,@CALLE= alcorta,@CP=1212,@LOCALIDAD=banfield,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=232,@CALLE=brasil,@CP=2331,@LOCALIDAD=ca�uelas,@PROVINCIA=bsas,@TIPO='INSERT';
--cargo persona
insert into dbo.PERSONA(IDDIRECCION,DNI,NOMBRE,APELLIDO)values(1,12342332,'marcelo','tevez');
insert into dbo.PERSONA(IDDIRECCION,DNI,NOMBRE,APELLIDO)values(2,32321412,'roberto','velez');
insert into dbo.PERSONA(IDDIRECCION,DNI,NOMBRE,APELLIDO)values(3,53342332,'lucas','sanchez');
insert into dbo.PERSONA(IDDIRECCION,DNI,NOMBRE,APELLIDO)values(6,12342332,'cristian','lugano');
insert into dbo.PERSONA(IDDIRECCION,DNI,NOMBRE,APELLIDO)values(4,12342332,'marcelo','tevez');
insert into dbo.PERSONA(IDDIRECCION,DNI,NOMBRE,APELLIDO)values(7,12342332,'facundo','guillot');
--cargo rol
insert into dbo.ROL(DESCRIPCIONROL)values('encargado');
insert into dbo.ROL(DESCRIPCIONROL)values('gerente');
--cargo usuario
 insert into dbo.USUARIO (IDPERSONA,IDROL,PASSWORD,HABILITADO) values(1,1,'1234',20-10-20);
 insert into dbo.USUARIO (IDPERSONA,IDROL,PASSWORD,HABILITADO) values(2,2,'1234',20-10-20);
 insert into dbo.USUARIO (IDPERSONA,IDROL,PASSWORD,HABILITADO) values(3,1,'1234',20-10-20);
 insert into dbo.USUARIO (IDPERSONA,IDROL,PASSWORD,HABILITADO) values(4,1,'1234',20-10-20);
 -- cargo alerta 
 insert into dbo.ALERTA(IDSTOCK,IDPERSONA,CANTIDADMINIMA) values(2,1,100);
 insert into dbo.ALERTA(IDSTOCK,IDPERSONA,CANTIDADMINIMA) values(3,3,100);
 insert into dbo.ALERTA(IDSTOCK,IDPERSONA,CANTIDADMINIMA) values(4,4,100);
 insert into dbo.ALERTA(IDSTOCK,IDPERSONA,CANTIDADMINIMA) values(6,3,100);
 insert into dbo.ALERTA(IDSTOCK,IDPERSONA,CANTIDADMINIMA) values(3,1,100);
 --carga proveedor 
 insert into dbo.PROVEEDOR(IDDIRECCION,CUIL,RAZONSOCIAL) values(2,20302010222,'loma negra');
 insert into dbo.PROVEEDOR(IDDIRECCION,CUIL,RAZONSOCIAL) values(4,3222010222,'molinos ca�uelas');
 insert into dbo.PROVEEDOR(IDDIRECCION,CUIL,RAZONSOCIAL) values(6,20302010222,'coto');
 insert into dbo.PROVEEDOR(IDDIRECCION,CUIL,RAZONSOCIAL) values(1,21321411212,'dia');
 insert into dbo.PROVEEDOR(IDDIRECCION,CUIL,RAZONSOCIAL) values(5,30010242122,'sinteplast');
 --carga orden 
 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (1,20-10-10);
 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (2,20-10-10);
 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (3,20-10-10);
 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (4,20-10-10);
 --carga ordencompra 
 insert into dbo.ORDENCOMPRA(IDORDEN,IDPERSONA,IDPROVEEDOR) values (1,1,5);
 insert into dbo.ORDENCOMPRA(IDORDEN,IDPERSONA,IDPROVEEDOR) values (2,3,1);
 insert into dbo.ORDENCOMPRA(IDORDEN,IDPERSONA,IDPROVEEDOR) values (3,4,2);
 --carga detalle 
 insert into dbo.DETALLEORDEN(IDORDEN,IDPRODUCTO,CANTIDAD )values (1,2,30);
 insert into dbo.DETALLEORDEN(IDORDEN,IDPRODUCTO,CANTIDAD )values (5,2,30);
 insert into dbo.DETALLEORDEN(IDORDEN,IDPRODUCTO,CANTIDAD )values (3,2,30);
 insert into dbo.DETALLEORDEN(IDORDEN,IDPRODUCTO,CANTIDAD )values (1,4,30);