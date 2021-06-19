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

 --exec ListaProductosHabilitados;
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



--exec OrdenCompraVista;
 
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

 --exec ListaCategorias;



