/*   SCRIPT SQL  - Tablas que usamos, con Restricciones. Si esta clasificada como necesaria debatir incoherencias con modulo 4 -   */

GO
CREATE TABLE DIRECCION
       (
       IDDIRECCION INT IDENTITY,                              
       ALTURA VARCHAR(6) NOT NULL,                              
       CALLE VARCHAR(30) NOT NULL,                              
       CODIGOPOSTAL VARCHAR(20) NOT NULL,                              
       LOCALIDAD VARCHAR(30) NOT NULL,                              
       PROVINCIA VARCHAR(30) NOT NULL,
	   CONSTRAINT CHK_DIR CHECK (ALTURA >= 0 AND CODIGOPOSTAL >= 0),
       PRIMARY KEY
               (
               IDDIRECCION
               )
       );
GO

GO
CREATE TABLE CATEGORIA /*Necesaria*/
       (
       IDCATEGORIA SMALLINT IDENTITY,                              
       DESCRIPCION VARCHAR(20) UNIQUE NOT NULL,
	   HABILITADO DATETIME NULL,
       PRIMARY KEY
               (
               IDCATEGORIA
               )
       );
GO

GO
CREATE TABLE ROL
       (
       IDROL TINYINT IDENTITY,                              
       DESCRIPCIONROL VARCHAR(20) UNIQUE NOT NULL,                              
       PRIMARY KEY
               (
               IDROL
               )
       );
GO

GO
CREATE TABLE PERSONA
       (
       IDPERSONA INT IDENTITY,                              
       IDDIRECCION INT NULL,                              
       DNI INT NOT NULL UNIQUE CHECK (DNI > 0 AND DNI < 150000000),     /*No sabria donde poner el techo del DNI*/                         
       NOMBRE VARCHAR(30) NOT NULL,                              
       APELLIDO VARCHAR(30) NOT NULL,
	   HABILITADO DATETIME NULL,
       PRIMARY KEY
               (
               IDPERSONA
               ),
       FOREIGN KEY
               (
               IDDIRECCION
               )
          REFERENCES DIRECCION
               (
               IDDIRECCION
               )
       );
GO

GO
CREATE TABLE PROVEEDOR /*Necesaria*/
       (
       IDPROVEEDOR INT IDENTITY,                              
       IDDIRECCION INT NOT NULL,                              
       CUIL VARCHAR(13) UNIQUE NOT NULL,                              
       RAZONSOCIAL VARCHAR(30) NOT NULL,
	   HABILITADO DATETIME NULL,                    
       PRIMARY KEY
               (
               IDPROVEEDOR
               ),
       FOREIGN KEY
               (
               IDDIRECCION
               )
          REFERENCES DIRECCION
               (
               IDDIRECCION
               )
       );
GO

GO
CREATE TABLE USUARIO /*Necesaria(modificar a criterio del resto de modulos)*/
       (
       IDPERSONA INT UNIQUE NOT NULL,    /*Primero instancio persona y en usuario guardo su pk*/                
       IDROL TINYINT NOT NULL,                              
       LEGAJO INT IDENTITY ,    /*Depende si seguimos con numeros autoincremental o cambiamos a string/dni que sea not null*/
	   PASSWORD NVARCHAR(50) NOT NULL,
	   HABILITADO DATETIME NULL,
       PRIMARY KEY
               (
               IDPERSONA
               ),
       FOREIGN KEY
               (
               IDPERSONA
               )
          REFERENCES PERSONA
               (
               IDPERSONA
               ),
       FOREIGN KEY
               (
               IDROL
               )
          REFERENCES ROL
               (
               IDROL
               )
       );
GO

GO
CREATE TABLE ORDEN /*Necesaria(Posiblemente mediar con modulo 3/4)*/
       (
       IDORDEN INT IDENTITY,                              
       IDPERSONA INT NOT NULL,
	   HABILITADO DATETIME NULL,                            
       PRIMARY KEY
               (
               IDORDEN
               ),
       FOREIGN KEY
               (
               IDPERSONA
               )
          REFERENCES USUARIO
               (
               IDPERSONA
               )
       );
GO

GO
CREATE TABLE ORDENCOMPRA /*Necesaria*/
       (
       IDORDEN INT UNIQUE NOT NULL,                              
       IDPROVEEDOR INT NOT NULL,                              
       IDPERSONA INT  NULL,                              
       FECHAAPROVACION DATETIME NULL,                        
       PRIMARY KEY
               (
               IDORDEN
               ),
       FOREIGN KEY
               (
               IDORDEN
               )
          REFERENCES ORDEN
               (
               IDORDEN
               ),
       FOREIGN KEY
               (
               IDPROVEEDOR
               )
          REFERENCES PROVEEDOR
               (
               IDPROVEEDOR
               ),
       FOREIGN KEY
               (
               IDPERSONA
               )
          REFERENCES USUARIO
               (
               IDPERSONA
               )
       );
GO

GO
CREATE TABLE PRODUCTO /*Necesaria (Mediar entre modulo 3/4)*/
       (
       IDPRODUCTO INT IDENTITY,                              
       IDCATEGORIA SMALLINT  NULL,                              
       NOMBRE VARCHAR(50) NOT NULL UNIQUE,    /*UNIQUE Ya que no se hablo de separar nombre y marca*/                          
       PRECIOCOMPRA FLOAT(23) NOT NULL,                           
       PRECIOVENTA FLOAT(23) NOT NULL,    /*Asumiendo que puede variar por diferentes motivos (diferentes porcentajes que no tengan una formula fija para una categoria, redondeos, etc)*/
	   HABILITADO DATETIME NULL,
       CONSTRAINT CHK_PROD CHECK (PRECIOCOMPRA >= 0 AND PRECIOVENTA >= 0),  /*Gratis?*/
	   PRIMARY KEY
               (
               IDPRODUCTO
               ),
       FOREIGN KEY
               (
               IDCATEGORIA
               )
          REFERENCES CATEGORIA
               (
               IDCATEGORIA
               )
       );
GO

GO
CREATE TABLE DETALLEORDEN /*Necesaria(Posiblemente mediar con modulo 3/4)*/ /*Entidad debil, tengo el detalle y le asocio la ultima orden generada*/ 
       (
       IDDETALLE INT IDENTITY,       /*No lo reinicio con cada orden, despues juzgo si tiene la orden asociada*/
       IDORDEN INT NOT NULL,                              
       IDPRODUCTO INT NOT NULL,                              
       CANTIDAD SMALLINT NOT NULL CHECK (CANTIDAD > 0),                              /* Permite vender hasta 32000 del mismo producto */
	   HABILITADO DATETIME NULL, /*Por si quiero eliminar cierto producto, pero sin generar otra orden nueva*/
       PRIMARY KEY
               (
               IDORDEN,
               IDDETALLE
               ),
       FOREIGN KEY
               (
               IDORDEN
               )
          REFERENCES ORDEN
               (
               IDORDEN
               ),
       FOREIGN KEY
               (
               IDPRODUCTO
               )
          REFERENCES PRODUCTO
               (
               IDPRODUCTO
               )
       );
GO

GO
CREATE TABLE STOCK /*Necesaria(Posiblemente mediar con modulo 3/4)*/
       (
       IDSTOCK INT IDENTITY,                              
       IDPRODUCTO INT NOT NULL UNIQUE,                              
       CANTIDAD INT NOT NULL CHECK (CANTIDAD >= 0),
	   HABILITADO DATETIME NULL,                              
       PRIMARY KEY
               (
               IDSTOCK
               ),
       FOREIGN KEY
               (
               IDPRODUCTO
               )
          REFERENCES PRODUCTO
               (
               IDPRODUCTO
               )
       );
GO

GO
CREATE TABLE ALERTA /*Necesaria*/
       (
       IDALERTA INT IDENTITY,                              
       IDSTOCK INT NOT NULL UNIQUE,    /*Una alerta por stock*/                          
       IDPERSONA INT NOT NULL,                              
       CANTIDADMINIMA INT NOT NULL CHECK (CANTIDADMINIMA >= 0),                              
       PRIMARY KEY
               (
               IDALERTA
               ),
       FOREIGN KEY
               (
               IDSTOCK
               )
          REFERENCES STOCK
               (
               IDSTOCK
               ),
       FOREIGN KEY
               (
               IDPERSONA
               )
          REFERENCES USUARIO
               (
               IDPERSONA
               )
       );
GO