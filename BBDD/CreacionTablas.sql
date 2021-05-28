/*   SCRIPT SQL  - Tablas con Restricciones -   */

CREATE TABLE DIRECCION
       (
       IDDIRECCION INT IDENTITY,                              
       ALTURA VARCHAR(6) NOT NULL,                              
       CALLE VARCHAR(20) NOT NULL,                              
       CODIGOPOSTAL INT NOT NULL,                              
       LOCALIDAD VARCHAR(20) NOT NULL,                              
       PROVINCIA VARCHAR(20) NOT NULL,                              
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
       DNI INT NOT NULL UNIQUE,                              
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
       RAZONSOCIAL VARCHAR(30) NOT NULL,                              
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
       IDPERSONA INT IDENTITY,                              
       IDROL TINYINT NOT NULL,                              
       LEGAJO INT NOT NULL UNIQUE,                              
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
       IDORDEN INT IDENTITY,                              
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
       NOMBRE VARCHAR(30) NOT NULL,                              
       PRECIOCOMPRA FLOAT(23) NOT NULL,                              
       PRECIOVENTA FLOAT(23) NOT NULL,                              /* Asumiendo que puede variar por diferentes motivos */
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
       IDDETALLE SMALLINT IDENTITY,                              
       IDORDEN INT NOT NULL,                              
       IDPRODUCTO INT NOT NULL,                              
       CANTIDAD SMALLINT NOT NULL,                              /* Permite vender hasta 32000 del mismo producto */
       PRIMARY KEY
               (
               IDDETALLE,
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
       CANTIDAD INT NOT NULL,                              
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
       IDSTOCK INT NOT NULL UNIQUE,                              
       IDPERSONA INT NOT NULL,                              
       CANTIDADMINIMA INT NOT NULL,                              
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