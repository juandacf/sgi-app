-- Actializarinventario al hacer una compra

CREATE OR REPLACE FUNCTION actualizar_inventario_compra()
RETURNS TRIGGER AS $$
BEGIN
    UPDATE producto
    SET stock = stock + NEW.cantidad
    WHERE id = NEW.id_producto;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;



CREATE TRIGGER trg_actualizar_inventario_compra
AFTER INSERT ON detalle_compra
FOR EACH ROW
EXECUTE FUNCTION actualizar_inventario_compra();



-- Actializarinventario al hacer una venta
CREATE OR REPLACE FUNCTION actualizar_inventario_venta()
RETURNS TRIGGER AS $$
BEGIN
    

    UPDATE producto
    SET stock = stock - NEW.cantidad
    WHERE id = NEW.id_producto;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;



CREATE TRIGGER trg_actualizar_inventario_venta
AFTER INSERT ON detalle_venta
FOR EACH ROW
EXECUTE FUNCTION actualizar_inventario_venta();

