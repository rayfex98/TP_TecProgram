

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
				

if object_id('vista_stock') is not null
  drop view vista_stock;

go

create view vista_stock as 

select 
s.CANTIDAD as 'cantidad',
s.IDPRODUCTOs 'id producto',
p.NOMBRE as 'nombre'

from [dbo].[STOCK] as s
inner join [dbo].[PRODUCTO] as p
on s.IDPRODUCTO = p.IDPRODUCTO;

select *from dbo.CATEGORIA;
select *from dbo.PRODUCTO;
insert into [dbo].[CATEGORIA] (DESCRIPCION,HABILITADO)
values ('licuadora',20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)
values (3,'heladera fachera ',100,200,20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)
values (4,'licuadora ',100,200,20-10-20);
insert into [dbo].[PRODUCTO] (IDCATEGORIA,NOMBRE,PRECIOCOMPRA,PRECIOVENTA,HABILITADO)
values (3,'corta cesped',100,200,20-10-10);
insert into [dbo].[STOCK] (IDPRODUCTO,CANTIDAD,HABILITADO)
values(3,100,10-10-20) ;

SELECT s.IDPRODUCTO, s.IDSTOCK, s.CANTIDAD,p.NOMBRE,p.PRECIOCOMPRA,p.PRECIOVENTA
FROM [dbo].[STOCK] as s 
inner join [dbo].[PRODUCTO] as p
on s.IDPRODUCTO = p.IDPRODUCTO;



exec restarstock @ID = 2 , @stock =1, @cantidad= 1;
exec sumarstock @ID = 2 , @cantidad= 20;
select *from vista_stock;



