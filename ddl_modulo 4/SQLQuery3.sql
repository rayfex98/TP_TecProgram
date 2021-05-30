CREATE TABLE DIRECCION
       (
       IDDIRECCION INT IDENTITY,                              
       ALTURA VARCHAR(6) NOT NULL,                              
       CALLE VARCHAR(30) NOT NULL,                              
       CODIGOPOSTAL INT NOT NULL,                              
       LOCALIDAD VARCHAR(20) NOT NULL,                              
       PROVINCIA VARCHAR(20) NOT NULL,
	   CONSTRAINT CHK_DIR CHECK (ALTURA >= 0 AND CODIGOPOSTAL >= 0),
       PRIMARY KEY
               (
               IDDIRECCION
               )
       );



CREATE TABLE CATEGORIA
       (
       IDCATEGORIA SMALLINT IDENTITY,                              
       DESCRIPCION VARCHAR(20) UNIQUE NOT NULL,                              
       PRIMARY KEY
               (
               IDCATEGORIA
               )
       );



CREATE TABLE ROL
       (
       IDROL TINYINT IDENTITY,                              
       DESCRIPCIONROL VARCHAR(20) UNIQUE NOT NULL,                              
       PRIMARY KEY
               (
               IDROL
               )
       );



CREATE TABLE PERSONA
       (
       IDPERSONA INT IDENTITY,                              
       IDDIRECCION INT NOT NULL,                              
       DNI INT NOT NULL UNIQUE CHECK (DNI > 0 AND DNI < 150000000),     /*No sabria donde poner el techo del DNI*/                         
       NOMBRE VARCHAR(30) NOT NULL,                              
       APELLIDO VARCHAR(30) NOT NULL,                              
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



CREATE TABLE PROVEEDOR
       (
       IDPROVEEDOR INT IDENTITY,                              
       IDDIRECCION INT NOT NULL,                              
       CUIL VARCHAR(13) UNIQUE NOT NULL,                              
       RAZONSOCIAL VARCHAR(30) NOT NULL,      /*No sabria si hacerlo UNIQUE*/                        
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



CREATE TABLE USUARIO
       (
       IDPERSONA INT UNIQUE NOT NULL,    /*Primero instancio persona y en usuario guardo su pk*/                
       IDROL TINYINT NOT NULL,                              
       LEGAJO INT IDENTITY ,    /*Es autoincremental*/
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



CREATE TABLE ORDEN
       (
       IDORDEN INT IDENTITY,                              
       IDPERSONA INT NOT NULL,                              
       FECHA DATETIME NOT NULL,                              
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



CREATE TABLE ORDENCOMPRA
       (
       IDORDEN INT UNIQUE NOT NULL,                              
       IDPROVEEDOR INT NOT NULL,                              
       IDPERSONA INT  NULL,                              
       FECHAAPROVACION SMALLDATETIME NULL,                              
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


CREATE TABLE PRODUCTO
       (
       IDPRODUCTO INT IDENTITY,                              
       IDCATEGORIA SMALLINT NOT NULL,                              
       NOMBRE VARCHAR(50) NOT NULL UNIQUE,    /*Ya que no se hablo de separar nombre y marca*/                          
       PRECIOCOMPRA FLOAT(23) NOT NULL,                           
       PRECIOVENTA FLOAT(23) NOT NULL,    /*Asumiendo que puede variar por diferentes motivos (diferentes porcentajes que no tengan una formula fija para una categoria, redondeos, etc)*/
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



CREATE TABLE DETALLEORDEN
       (
       IDDETALLE SMALLINT IDENTITY,                              /*Tiny me parece chico para manejar la compra, prefiero tener más productos*/
       IDORDEN INT NOT NULL,                              
       IDPRODUCTO INT NOT NULL,                              
       CANTIDAD SMALLINT NOT NULL CHECK (CANTIDAD > 0),                              /* Permite vender hasta 32000 del mismo producto */
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



CREATE TABLE STOCK
       (
       IDSTOCK INT IDENTITY,                              
       IDPRODUCTO INT NOT NULL,                              
       CANTIDAD INT NOT NULL CHECK (CANTIDAD >= 0),                              
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



CREATE TABLE ALERTA
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