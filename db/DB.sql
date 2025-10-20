-- ----------------------------------------------------
-- 1️⃣ Tabla `personas`
-- ----------------------------------------------------
CREATE TABLE `personas` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `nombre` VARCHAR(100) NOT NULL,
    `apellido` VARCHAR(100),
    `dni` VARCHAR(20),
    `telefono` VARCHAR(50),
    `email` VARCHAR(100),
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    UNIQUE KEY `uk_personas_dni` (`dni`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 2️⃣ Tabla `clientes`
-- ----------------------------------------------------
CREATE TABLE `clientes` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `tipo` ENUM('persona','empresa') NOT NULL,
    `persona_id` INT,
    `razon_social` VARCHAR(150),
    `cuit` VARCHAR(20),
    `direccion` VARCHAR(200),
    `telefono` VARCHAR(50),
    `email` VARCHAR(100),
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`persona_id`) REFERENCES `personas`(`id`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 3️⃣ Tabla `proveedores`
-- ----------------------------------------------------
CREATE TABLE `proveedores` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `razon_social` VARCHAR(150) NOT NULL,
    `cuit` VARCHAR(20),
    `direccion` VARCHAR(200),
    `telefono` VARCHAR(50),
    `email` VARCHAR(100),
    `persona_id` INT,
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`persona_id`) REFERENCES `personas`(`id`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 4️⃣ Tabla `usuarios`
-- ----------------------------------------------------
CREATE TABLE `usuarios` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `persona_id` INT NOT NULL,
    `nombre_usuario` VARCHAR(50) NOT NULL UNIQUE,
    `password_hash` VARCHAR(255) NOT NULL,
    `rol` ENUM('admin','empleado') NOT NULL,
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`persona_id`) REFERENCES `personas`(`id`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 5️⃣ Tabla `tipos_productos`
-- ----------------------------------------------------
CREATE TABLE `tipos_productos` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `nombre` VARCHAR(100) NOT NULL,
    `descripcion` VARCHAR(255),
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 6️⃣ Tabla `productos`
-- ----------------------------------------------------
CREATE TABLE `productos` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `codigo` VARCHAR(50) UNIQUE NOT NULL,
    `nombre` VARCHAR(150) NOT NULL,
    `tipo_producto_id` INT NOT NULL,
    `stock` INT DEFAULT 0,
    `precio_costo` DECIMAL(10,2) NOT NULL,
    `precio_venta` DECIMAL(10,2) NOT NULL,
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`tipo_producto_id`) REFERENCES `tipos_productos`(`id`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 7️⃣ Tabla `facturas_compras`
-- ----------------------------------------------------
CREATE TABLE `facturas_compras` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `fecha` DATETIME NOT NULL,
    `proveedor_id` INT NOT NULL,
    `usuario_id` INT NOT NULL,
    `total` DECIMAL(12,2) NOT NULL,
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`proveedor_id`) REFERENCES `proveedores`(`id`),
    FOREIGN KEY (`usuario_id`) REFERENCES `usuarios`(`id`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 8️⃣ Tabla `detalles_facturas_compras`
-- ----------------------------------------------------
CREATE TABLE `detalles_facturas_compras` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `factura_compra_id` INT NOT NULL,
    `producto_id` INT NOT NULL,
    `cantidad` INT NOT NULL,
    `precio_unitario` DECIMAL(10,2) NOT NULL,
    `subtotal` DECIMAL(12,2) NOT NULL,
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`factura_compra_id`) REFERENCES `facturas_compras`(`id`),
    FOREIGN KEY (`producto_id`) REFERENCES `productos`(`id`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 9️⃣ Tabla `facturas_ventas`
-- ----------------------------------------------------
CREATE TABLE `facturas_ventas` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `fecha` DATETIME NOT NULL,
    `cliente_id` INT NOT NULL,
    `usuario_id` INT NOT NULL,
    `total` DECIMAL(12,2) NOT NULL,
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`cliente_id`) REFERENCES `clientes`(`id`),
    FOREIGN KEY (`usuario_id`) REFERENCES `usuarios`(`id`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ----------------------------------------------------
-- 🔟 Tabla `detalles_facturas_ventas`
-- ----------------------------------------------------
CREATE TABLE `detalles_facturas_ventas` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `factura_venta_id` INT NOT NULL,
    `producto_id` INT NOT NULL,
    `cantidad` INT NOT NULL,
    `precio_unitario` DECIMAL(10,2) NOT NULL,
    `subtotal` DECIMAL(12,2) NOT NULL,
    `estado` VARCHAR(20) NOT NULL DEFAULT 'ACTIVO',
    `fecha_creacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `fecha_modificacion` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `creado_por` INT NULL,
    `modificado_por` INT NULL,
    FOREIGN KEY (`factura_venta_id`) REFERENCES `facturas_ventas`(`id`),
    FOREIGN KEY (`producto_id`) REFERENCES `productos`(`id`),
    FOREIGN KEY (`creado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (`modificado_por`) REFERENCES `usuarios`(`id`) ON DELETE SET NULL ON UPDATE CASCADE
);
