--store procedure de stock 
if object_id('sumarstock') is not null
  drop procedure sumarstock;

go
create procedure sumarstock (@ID INT, @cantidad int)as

BEGIN

	UPDATE [dbo].[stock]
	set cantidad = cantidad + @cantidad
	WHERE id_producto= @ID				
	
END
--store procedure restar stock
if object_id('restarstock') is not null
  drop procedure restarstock;

go


create procedure restarstock (@ID INT,@cantidad int)as

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
 A.id_alerta as 'id alerta',
 S.id_STOCK as 'id stock', 
 B.nombre as 'producto',
 P.nombre +' '+P.apellido as 'usuario',
 A.cantidad_minima as  'cantidad minima',
 S.cantidad as 'cantidad stock'

 from dbo.alerta as A
 inner join dbo.STOCK as S 
 on A.id_stock = S.id_stock
 inner join dbo.USUARIO as U
 on A.id_persona= U.id_persona
 inner join dbo.PERSONA as P 
 on U.id_persona = P.id
 inner join dbo.producto as B
 on S.id_producto = B.id_producto
 where S.cantidad <= a.cantidad_minima

 go
 --store procedure de alertas 

 if object_id('VistaAlertas') is not null
  drop procedure VistaAlertas;

go
 create procedure VistaAlertas as 

 select 
  A.id_alerta as 'id alerta',
 S.id_stock as 'id stock', 
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
 

 --store procedure de productos 
  if object_id('ListaProductos') is not null
  drop procedure ListaProductos;
go
 create procedure ListaProductos as 

 select 
 P.nombre as 'nombre',
 C.descripcion as 'categoria',
 P.id_producto as 'id producto'
 from dbo.producto as P
 inner join dbo.categoria as C 
 on P.id_categoria = C.id_categoria

go
 --store procedures de proveedor 
  if object_id('ListaProveedores') is not null
  drop procedure ListaProveedores;
  go
 create procedure ListaProveedores as 

 select 
 P.cuil as 'cuil',
 P.id_proveedor as 'id proveedor',
 P.razonsocial as 'razon social',
 D.localidad +' '+ D.provincia as 'Localidad y provincia',
 D.id as 'id direccion',
 P.habilitado as 'habilitado'
 from dbo.proveedor as P 
 inner join dbo.direccion as D
 on P.id_direccion = D.id;
 
 --store procedures de proveedor habilitados

  if object_id('ListaProveedoresHabilitados') is not null
  drop procedure ListaProveedoresHabilitados;
go
 create procedure ListaProveedoresHabilitados as 

 select 
 P.cuil as 'cuil',
 P.id_proveedor as 'id proveedor',
 P.razonsocial as 'razon social',
 D.localidad +' '+ D.provincia as 'Localidad y provincia',
 D.id as 'id direccion',
 P.habilitado as 'habilitado'
 from dbo.proveedor as P 
 inner join dbo.direccion as D
 on P.id_direccion = D.id
 where P.habilitado is not null;


  --store procedures de Buscar proveedor por provincia 
  if object_id('BuscarProveedorProvincia') is not null
  drop procedure BuscarProveedorProvincia;
go
 create procedure BuscarProveedorProvincia(@provincia VARCHAR(50)) as 

 select 
 P.cuil as 'cuil',
 P.id_proveedor as 'id proveedor',
 P.razonsocial as 'razon social',
 D.provincia as  'provincia',
 D.id as 'id direccion'
 from dbo.proveedor as P 
 inner join dbo.direccion as D
 on P.id_direccion = D.id
 where  P.habilitado is not null
 and D.provincia like  @provincia + '%';

 --store procedures de orden de compra lista orden compra 
  if object_id('OrdenCompraVista') is not null
 drop procedure OrdenCompraVista;
go
 create procedure OrdenCompraVista as 

  select DISTINCT
 O.id_orden as 'id orden ',
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

--store procedures para sumar el precio de la compra

 if object_id('sumartotalorden') is not null
 drop procedure sumartotalorden;
go
create procedure sumartotalorden(@orden int) as 

select D.cantidad as 'cantidad',
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
 if object_id('listadirecion') is not null
drop procedure listadirecion
go
 create procedure listadirecion as 
 
 select 
 altura as 'altura',
 calle as 'calle',
 codigo_postal as 'codigo postal',
 localidad as 'localidad',
 provincia as 'provincia'
 --id_direccion as 'id direccion'

 from dbo.DIRECCION;
