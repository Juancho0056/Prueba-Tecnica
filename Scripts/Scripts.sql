-- 1. Obtener la lista de precios de todos los productos

SELECT *
FROM facturacion.articulos;
--------------------------------------------------------

-- 2.Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo permitido (5 unidades)

SELECT a.id, a.detalle, b.cantdisponible
FROM facturacion.articulos a
LEFT JOIN facturacion.existencias b ON b.articuloid = a.id
WHERE b.Cantdisponible <= 5;
--------------------------------------------------------

-- 3.Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000
SELECT DISTINCT a.id, a.NroDocumento, a.PrimerNombre, a.SegundoNombre,
	   DATEDIFF(YEAR, FechaNacimiento, GETDATE()) as Edad
FROM facturacion.clientes a
LEFT JOIN facturacion.ventas b ON a.id = b.Clienteid
WHERE (b.FechaVenta BETWEEN '2000-02-01 00:00:00' AND '2000-05-25 11:59:59') 
AND DATEDIFF(YEAR, a.FechaNacimiento, GETDATE()) < 35;
--------------------------------------------------------

-- 4. Obtener el valor total vendido por cada producto en el año 2000
SELECT a.id, a.detalle, SUM(b.valor) precio, YEAR(c.FechaVenta) as Anio
FROM facturacion.articulos a
LEFT JOIN facturacion.detalleventas b ON a.id = b.ArticuloId
LEFT JOIN facturacion.ventas c on c.id = b.VentaId
WHERE YEAR(c.Fechaventa) = 2000
GROUP BY a.id, YEAR(c.FechaVenta), a.detalle, b.valor;
--------------------------------------------------------


-- 5.Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar en qué fecha podría volver a comprar.

SELECT clienteid, MIN(fechaventa) AS fechainicio , max(fechaventa) AS fechafin, count(*) AS nrocompras,
(DATEDIFF(day, MIN(Fechaventa), MAX(Fechaventa))/count(v.Id)) as frecuencia,
DATEADD(DAY, (DATEDIFF(DAY, Min(v.Fechaventa), MAX(v.Fechaventa)) / COUNT(v.Id)), MAX(v.Fechaventa)) as proximacompra
FROM facturacion.ventas v 
WHERE clienteid = 1
GROUP BY clienteid

--------------------------------------------------------


