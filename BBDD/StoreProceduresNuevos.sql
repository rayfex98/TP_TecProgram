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
--store procedure restar stock
if object_id('restarstock') is not null
  drop procedure restarstock;

go


create procedure restarstock (@ID INT,@cantidad int)as

BEGIN
	UPDATE [dbo].[STOCK]
    set CANTIDAD = cantidad - @cantidad
	WHERE IDPRODUCTO= @ID						
END

--store procedure lista de stock

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
on s.IDPRODUCTO = p.IDPRODUCTO
where s.HABILITADO is not null;


--store procedure de alertas criticas 
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

 --store procedure de alertas 

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


 --store procedures de proveedor 
  if object_id('ListaProveedores') is not null
  drop procedure ListaProveedores;

 create procedure ListaProveedores as 

 select 
 P.CUIL as 'cuil',
 P.IDPROVEEDOR as 'id proveedor',
 P.RAZONSOCIAL as 'razon social',
 D.LOCALIDAD +' '+ D.PROVINCIA as 'Localidad y provincia',
 D.IDDIRECCION as 'id direccion',
 P.HABILITADO as 'habilitado'
 from dbo.PROVEEDOR as P 
 inner join dbo.DIRECCION as D
 on P.IDDIRECCION = D.IDDIRECCION;


 --store procedures de proveedor habilitados
  if object_id('ListaProveedoresHabilitados') is not null
  drop procedure ListaProveedoresHabilitados;

 create procedure ListaProveedoresHabilitados as 

 select 
 P.CUIL as 'cuil',
 P.IDPROVEEDOR as 'id proveedor',
 P.RAZONSOCIAL as 'razon social',
 D.LOCALIDAD +' '+ D.PROVINCIA as 'Localidad y provincia',
 D.IDDIRECCION as 'id direccion',
 P.HABILITADO as 'habilitado'
 from dbo.PROVEEDOR as P 
 inner join dbo.DIRECCION as D
 on P.IDDIRECCION = D.IDDIRECCION
 where P.HABILITADO is not null;


  --store procedures de Buscar proveedor por provincia 
  if object_id('BuscarProveedorProvincia') is not null
  drop procedure BuscarProveedorProvincia;

 create procedure BuscarProveedorProvincia(@provincia VARCHAR(50)) as 

 select 
 P.CUIL as 'cuil',
 P.IDPROVEEDOR as 'id proveedor',
 P.RAZONSOCIAL as 'razon social',
 D.PROVINCIA as  'provincia',
 D.IDDIRECCION as 'id direccion'
 from dbo.PROVEEDOR as P 
 inner join dbo.DIRECCION as D
 on P.IDDIRECCION = D.IDDIRECCION
 where  P.HABILITADO is not null
 and D.PROVINCIA like  @provincia + '%';

 --store procedures de orden de compra lista orden compra 
  if object_id('OrdenCompraVista') is not null
 drop procedure OrdenCompraVista;


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

--store procedures para sumar el precio de la compra

 if object_id('sumartotalorden') is not null
 drop procedure sumartotalorden;

create procedure sumartotalorden(@orden int) as 

select D.CANTIDAD as 'cantidad',
P.PRECIOVENTA as 'precio venta'

from DETALLEORDEN as D
inner join PRODUCTO as P
on D.IDPRODUCTO = P.IDPRODUCTO
where d.IDORDEN = @orden;


--store procedures para quitar y sumar productos de stock (deposito)
if object_id('quitardestock') is not null
 drop procedure quitardestock;


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
 D.CANTIDAD as 'cantidad',
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
 ALTURA as 'altura',
 CALLE as 'calle',
 CODIGOPOSTAL as 'codigo postal',
 LOCALIDAD as 'localidad',
 PROVINCIA as 'provincia'
 --IDDIRECCION as 'iddireccion'

 from dbo.DIRECCION;
