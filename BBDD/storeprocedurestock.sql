

create procedure restarstock (@ID INT,
								@cantidad int)
			as
					BEGIN
						UPDATE [dbo].[STOCK]
						set CANTIDAD = cantidad - @cantidad
						WHERE IDPRODUCTO= @ID						
					END
create procedure sumarstock (@ID INT,
								@cantidad int)
			as
					BEGIN
						UPDATE [dbo].[STOCK]
						set CANTIDAD = cantidad + @cantidad
						WHERE IDPRODUCTO= @ID						
					END
				



create procedure vista_stock as 

select 
s.IDSTOCK as 'id stock',
s.CANTIDAD as 'cantidad',
s.IDPRODUCTO 'id producto',
p.NOMBRE as 'nombre'

from [dbo].[stock] as s
inner join [dbo].[PRODUCTO] as p
on s.IDPRODUCTO = p.IDPRODUCTO;

select *from dbo.CATEGORIA;
select *from dbo.PRODUCTO;
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)
values ('cocina',20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)
values (4,'cocina ',100,200,20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)
values (5,'batidora',100,200,20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)
values (1,'licuadora ',100,200,20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)
values (3,'corta cesped',100,200,20-10-10);
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO)
values(4,100,10-10-20) ;
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO)
values(16,100,10-10-20) ;

SELECT s.IDPRODUCTO, s.IDSTOCK, s.CANTIDAD,p.NOMBRE,p.PRECIOCOMPRA,p.PRECIOVENTA
FROM [dbo].[STOCK] as s 
inner join [dbo].[PRODUCTO] as p
on s.IDPRODUCTO = p.IDPRODUCTO;



exec restarstock @ID = 4 , @cantidad= 1;
exec sumarstock @ID = 2 , @cantidad= 20;
exec vista_stock;

select *from dbo.direccion;
EXEC DIRECCIONPROC @ID=null,@ALTURA=123,@CALLE=estrada,@CP=12,@LOCALIDAD=ezeiza,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=123,@CALLE=lasheras,@CP=122,@LOCALIDAD=ezeiza,@PROVINCIA=bsas,@TIPO='INSERT';
EXEC DIRECCIONPROC @ID=null,@ALTURA=234,@CALLE=paraguay,@CP=231,@LOCALIDAD=cañuelas,@PROVINCIA=bsas,@TIPO='INSERT';

 EXEC PRODUCTOPROC @ID = null, @CATEGORIA = 1, @NOMBRE = 'lavarropas', @COMPRA =100, @VENTA =200, @HABILITADO = null, @TIPO = 'INSERT'
 insert into dbo.PERSONA(IDDIRECCION,DNI,NOMBRE,APELLIDO)values(1,12342332,'marcelo','tevez');
 insert into dbo.ROL(DESCRIPCIONROL)values('encargado');
 insert into dbo.USUARIO (IDPERSONA,IDROL,PASSWORD,HABILITADO) values(1,1,'1234',20-10-20);
 insert into dbo.ALERTA(IDSTOCK,IDPERSONA,CANTIDADMINIMA) values(1,1,100);
 select *from dbo.ALERTA;
 select *from dbo.PERSONA ;
 select *from dbo.USUARIO;
 select *from dbo.DIRECCION; 
 select *from dbo.ROL;


 if object_id('AlertasList') is not null
  drop procedure AlertasList;

go

 create procedure AlertasList  as

 select 
 A.IDALERTA as 'id alerta',
 S.IDSTOCK as 'id stock', 
 S.IDPRODUCTO as 'id producto',
 a.IDPERSONA as 'id usuario',
 A.CANTIDADMINIMA as  'cantidad minima',
 S.CANTIDAD as 'cantidad stock'
 from dbo.ALERTA as A
 inner join dbo.STOCK as S 
 on A.IDSTOCK = S.IDSTOCK;


 if object_id('VistaAlertasCriticas') is not null
  drop procedure VistaAlertasCriticas;

go
 create procedure VistaAlertasCriticas as 

 select 
  A.IDALERTA as 'id alerta',
 S.IDSTOCK as 'id stock', 
 S.IDPRODUCTO as 'id producto',
 a.IDPERSONA as 'id usuario',
 A.CANTIDADMINIMA as  'cantidad minima',
 S.CANTIDAD as 'cantidad stock'

 from dbo.ALERTA as A
 inner join dbo.STOCK as S 
 on A.IDSTOCK = S.IDSTOCK
 where S.CANTIDAD <= a.CANTIDADMINIMA



 exec AlertasList;
 exec VistaAlertasCriticas;
 
 create procedure ListaProductos as 

 select 
 P.NOMBRE as 'nombre',
 C.DESCRIPCION as 'categoria',
 P.IDPRODUCTO as 'id producto'
 from dbo.PRODUCTO as P
 inner join dbo.CATEGORIA as C 
 on P.IDCATEGORIA = C.IDCATEGORIA;

 exec ListaProductos;


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

 exec ListaProveedores;
 select *from dbo.direccion;
 insert into dbo.PROVEEDOR(IDDIRECCION,CUIL,RAZONSOCIAL) values(2,20302010222,'loma negra');

 insert into dbo.ORDEN(IDPERSONA,HABILITADO) values (1,20-10-10);
 insert into dbo.ORDENCOMPRA(IDORDEN,IDPERSONA,IDPROVEEDOR) values (1,1,2);
 EXEC PROVEEDORPROC @ID=NULL,@DIRECCION=3,@CUIL=3097654123,@RAZONSOCIAL=LaFabrica,@HABILITADO = null,@TIPO = 'INSERT';
  EXEC PROVEEDORPROC @ID=2,@DIRECCION=null,@CUIL=null,@RAZONSOCIAL=null,@HABILITADO = null,@TIPO = 'DELETE';
  select *from ORDEN;
  select *from DETALLEORDEN; 
  select *from ORDENCOMPRA;
  select *from PROVEEDOR;
  cast()
  EXEC ORDENCOMPRAPROC @ID=NULL,@PROVEEDOR=1,@USUARIO=1,@FECHA= ,@TIPO) = 'INSERT';


 if object_id('OrdenCompraVista') is not null
 drop procedure OrdenCompraVista;


 create procedure OrdenCompraVista as 

 select D.CANTIDAD as 'cantidad',
 D.IDPRODUCTO as 'id producto',
 O.IDORDEN as 'id orden '

from dbo.ORDENCOMPRA as O
inner join dbo.DETALLEORDEN AS D
on D.IDORDEN = O.IDORDEN
where D.IDORDEN = O.IDORDEN; 

EXEC DETALLEPROC @ID = 3,@ORDEN=1,@PRODUCTO=null,@CANTIDAD=null,@TIPO = 'DELETE';
exec  OrdenCompraVista;
select *from dbo.DIRECCION;
EXEC DIRECCIONPROC @ID=4,@ALTURA=NULL,@CALLE=NULL,@CP=NULL,@LOCALIDAD=NULL,@PROVINCIA=NULL,@TIPO = 'DELETE';

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

 exec OrdenCompraPendientes;
