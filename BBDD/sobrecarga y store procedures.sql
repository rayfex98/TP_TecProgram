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
EXEC DIRECCIONPROC @ID=null,@ALTURA=64,@CALLE=paraguay,@CP=1231,@LOCALIDAD=cañuelas,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=13,@CALLE=cabildo,@CP=1823,@LOCALIDAD=capital,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=1323,@CALLE=aveces,@CP=1223,@LOCALIDAD=flores,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=27,@CALLE=uruguay,@CP=1314,@LOCALIDAD=lanus,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=1313,@CALLE=ramos,@CP=1232,@LOCALIDAD=caballito,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=121,@CALLE= alcorta,@CP=1212,@LOCALIDAD=banfield,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=232,@CALLE=brasil,@CP=2331,@LOCALIDAD=cañuelas,@PROVINCIA=bsas,@TIPO='INSERT';
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
 insert into dbo.PROVEEDOR(IDDIRECCION,CUIL,RAZONSOCIAL) values(4,3222010222,'molinos cañuelas');
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

 exec ListaProductosHabilitados;
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



exec OrdenCompraVista;
 
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

 exec ListaCategorias;

 select *from dbo.CATEGORIA;