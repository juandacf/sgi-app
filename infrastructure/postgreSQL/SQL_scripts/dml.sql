-- INSERTS PARA TABLAS MAESTRAS Y DATOS INICIALES

-- Tipo de tercero
INSERT INTO tipo_tercero (descripcion) VALUES 
('Proveedor'), 
('Empleado'), 
('Cliente');

-- Tipo de documento
INSERT INTO tipo_documento (descripcion) VALUES 
('Cédula de Ciudadanía'), 
('Cédula de Extranjería'), 
('NIT');

-- Países
INSERT INTO pais (nombre) VALUES 
('Colombia'), 
('México');

-- Regiones
INSERT INTO region (nombre, id_pais) VALUES 
('Cundinamarca', 1), 
('Antioquia', 1), 
('Jalisco', 2);

-- Ciudades
INSERT INTO ciudad (nombre, id_region) VALUES 
('Bogotá', 1), 
('Medellín', 2), 
('Guadalajara', 3);

-- EPS
INSERT INTO eps (nombre) VALUES 
('Sura'), 
('Sanitas');

-- ARL
INSERT INTO arl (nombre) VALUES 
('Colpatria'), 
('Bolívar');

-- EMPRESAS
INSERT INTO empresa (nombre, ciudad_id, fecha_registro) VALUES 
('Tech Solutions S.A.', 1, '2024-01-15'),
('Distribuciones Latinoamérica', 3, '2023-11-22');

-- TERCEROS
INSERT INTO tercero (id, nombre, apellido, email, id_tipo_documento, id_tipo_tercero, id_ciudad) VALUES 
('123', 'Carlos', 'Pérez', 'carlos.perez@example.com', 1, 2, 1), -- Empleado
('456', 'Laura', 'Gómez', 'laura.gomez@example.com', 2, 3, 2),   -- Cliente
('789', 'Importadora', 'Global', 'importadora@example.com', 3, 1, 3); -- Proveedor

-- TELÉFONOS DE TERCEROS
INSERT INTO tercero_telefono (numero, tipo_telefono, id_tercero) VALUES 
(3001234567, 'Móvil', '123'),
(3107654321, 'Móvil', '456'),
(6014567890, 'Fijo', '789');

-- EMPLEADO
INSERT INTO empleado (fecha_ingreso, salario_base, id_tercero, id_eps, id_arl) VALUES 
('2023-06-01', 3500000.00, '123', 1, 1);

-- CLIENTE
INSERT INTO cliente (id_tercero, fecha_nacimiento, fecha_ultima_compra) VALUES 
('456', '1990-04-20', '2024-12-01');

-- PROVEEDOR
INSERT INTO proveedor (descuento, dia_pago, id_tercero) VALUES 
(10.00, 15, '789');

-- PRODUCTOS
INSERT INTO producto (id, nombre, stock, stock_min, stock_mac, created_at, updated_at, barcode) VALUES 
('P001', 'Laptop Lenovo', 50, 5, 100, '2024-01-01', '2024-05-01', 'LNVP001'),
('P002', 'Mouse Logitech', 200, 20, 500, '2024-02-01', '2024-05-01', 'LTGM002');

-- PRODUCTO-PROVEEDOR
INSERT INTO producto_proveedor (id_proveedor, id_producto) VALUES 
(1, 'P001'),
(1, 'P002');

-- PLANES DE DESCUENTO
INSERT INTO plan (nombre, fecha_inicio, fecha_fin, dcto) VALUES 
('Black Friday', '2024-11-20', '2024-11-30', 15),
('Navidad', '2024-12-15', '2024-12-25', 20);

-- PLANES Y PRODUCTOS
INSERT INTO plan_producto (id_plan, id_producto) VALUES 
(1, 'P001'),
(2, 'P002');
