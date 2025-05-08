-- Script instalación PostgreSQL

DROP SCHEMA public CASCADE;
CREATE SCHEMA public;


CREATE TABLE IF NOT EXISTS pais(
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100) UNIQUE
);

CREATE TABLE IF NOT EXISTS region(
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100),
    id_pais INTEGER,
    FOREIGN KEY(id_pais) REFERENCES pais(id)
);

CREATE TABLE IF NOT EXISTS ciudad(
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100),
    id_region INTEGER,
    FOREIGN KEY (id_region) REFERENCES region(id)
);

CREATE TABLE IF NOT EXISTS empresa(
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100),
    ciudad_id INTEGER,
    fecha_registro DATE
);

CREATE TABLE IF NOT EXISTS eps(
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS arl(
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS tipo_tercero(
    id SERIAL PRIMARY KEY,
    descripcion VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS tipo_documento(
    id SERIAL PRIMARY KEY,
    descripcion VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS tercero (
    id VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    email VARCHAR(150) UNIQUE,
    id_tipo_documento INTEGER,
    id_tipo_tercero INTEGER,
    id_ciudad INTEGER,
    FOREIGN KEY(id_tipo_documento) REFERENCES tipo_documento(id),
    FOREIGN KEY(id_tipo_tercero) REFERENCES tipo_tercero(id),
    FOREIGN KEY(id_ciudad) REFERENCES ciudad(id)
);

CREATE TABLE IF NOT EXISTS empleado(
    id SERIAL PRIMARY KEY,
    fecha_ingreso DATE,
    salario_base DECIMAL(9,2),
    id_tercero VARCHAR(20),
    id_eps INTEGER,
    id_arl INTEGER,
    FOREIGN KEY(id_tercero) REFERENCES tercero(id),
    FOREIGN KEY(id_eps) REFERENCES eps(id),
    FOREIGN KEY(id_arl) REFERENCES arl(id)
);

CREATE TABLE IF NOT EXISTS proveedor(
    id SERIAL PRIMARY KEY,
    descuento DECIMAL(5,2) CHECK(descuento < 100),
    dia_pago INTEGER,
    id_tercero VARCHAR(20),
    FOREIGN KEY(id_tercero) REFERENCES tercero(id)
);

CREATE TABLE IF NOT EXISTS cliente(
    id SERIAL PRIMARY KEY,
    id_tercero VARCHAR(20),
    fecha_nacimiento DATE,
    fecha_ultima_compra DATE,
    FOREIGN KEY(id_tercero) REFERENCES tercero(id)
);

CREATE TABLE IF NOT EXISTS tercero_telefono (
    id SERIAL PRIMARY KEY,
    numero DECIMAL(10),
    tipo_telefono VARCHAR(50),
    id_tercero VARCHAR(20),
    FOREIGN KEY(id_tercero) REFERENCES tercero(id)
);

CREATE TABLE IF NOT EXISTS producto(
    id VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(100),
    stock INT,
    stock_min INT,
    stock_mac INT,
    created_at DATE,
    updated_at DATE,
    barcode VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS producto_proveedor(
    id SERIAL PRIMARY KEY,
    id_proveedor INT,
    id_producto VARCHAR(20),
    FOREIGN KEY(id_proveedor) REFERENCES proveedor(id),
    FOREIGN KEY(id_producto) REFERENCES producto(id)
);

CREATE TABLE IF NOT EXISTS plan(
    id SERIAL,
    nombre VARCHAR(30),
    fecha_inicio DATE,
    fecha_fin DATE,
    dcto DECIMAL(3) CHECK(dcto<100),
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS plan_producto(
    id SERIAL,
    id_plan INTEGER,
    id_producto VARCHAR(20),
    PRIMARY KEY(id),
    FOREIGN KEY(id_plan) REFERENCES plan(id),
    FOREIGN KEY(id_producto) REFERENCES producto(id)
);

CREATE TABLE IF NOT EXISTS tipo_movimiento_caja(
    id SERIAL,
    nombre VARCHAR(50),
    tipo BOOLEAN, -- TRUE ES ENTRADA Y FALSE ES SALIDA
    PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS movimiento_caja(
    id SERIAL,
    fecha DATE,
    id_tipo_movimiento_caja INTEGER,
    valor DECIMAL(14,2),
    concepto VARCHAR,
    PRIMARY KEY(id),
    FOREIGN KEY(id_tipo_movimiento_caja) REFERENCES tipo_movimiento_caja(id)
);

CREATE TABLE IF NOT EXISTS facturacion( 
    id INTEGER,
    fecha_resolucion DATE,
    numero_inicio INTEGER,
    numero_final INTEGER,
    factura_actual INTEGER,
    PRIMARY KEY(id)
); -- A esta tabla no se le crea constructor. sólo debe tener una instancia.

CREATE TABLE IF NOT EXISTS venta(
    id_factura INTEGER,
    fecha DATE,
    id_tercero_empleado INT,
    id_tercero_cliente INT,
    PRIMARY key(id_factura),
    FOREIGN KEY(id_tercero_empleado) REFERENCES empleado(id),
    FOREIGN KEY(id_tercero_cliente) REFERENCES cliente(id)
);

CREATE TABLE IF NOT EXISTS compra(
    id SERIAL,
    id_tercero_proveedor INT,
    id_tercero_empleado INT,
    fecha DATE,
    documento_compra VARCHAR,
    PRIMARY KEY(id),
    FOREIGN KEY(id_tercero_proveedor) REFERENCES proveedor(id),
    FOREIGN KEY(id_tercero_empleado) REFERENCES empleado(id)
);

CREATE TABLE IF NOT EXISTS detalle_compra(
    id SERIAL,
    fecha DATE,
    id_producto VARCHAR(20),
    id_compra INTEGER,
    cantidad INTEGER,
    valor INTEGER,
    PRIMARY KEY(id),
    FOREIGN KEY(id_producto) REFERENCES producto(id),
    FOREIGN KEY(id_compra) REFERENCES compra(id)
);

CREATE TABLE IF NOT EXISTS detalle_venta(
    id SERIAL,
    id_facturacion INTEGER,
    id_producto VARCHAR(20),
    cantidad INTEGER,
    valor INTEGER,
    PRIMARY KEY(id),
    FOREIGN KEY(id_facturacion) REFERENCES venta(id_factura),
    FOREIGN KEY(id_producto) REFERENCES producto(id)

);