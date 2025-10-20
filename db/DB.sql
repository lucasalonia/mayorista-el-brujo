-- ----------------------------------------------------
-- 1️⃣ Tabla persona
-- ----------------------------------------------------
CREATE TABLE `persona` (
    `id_persona` INT AUTO_INCREMENT PRIMARY KEY,
    `nombre` VARCHAR(100) NOT NULL,
    `apellido` VARCHAR(100),
    `dni` VARCHAR(20),
    `telefono` VARCHAR(50),
    `email` VARCHAR(100)
);

-- ----------------------------------------------------
-- 2️⃣ Tabla cliente
-- ----------------------------------------------------
CREATE TABLE `cliente` (
    `id_cliente` INT AUTO_INCREMENT PRIMARY KEY,
    `tipo` ENUM('persona','empresa') NOT NULL,
    `id_persona` INT,
    `razon_social` VARCHAR(150),
    `cuit` VARCHAR(20),
    `direccion` VARCHAR(200),
    `telefono` VARCHAR(50),
    `email` VARCHAR(100),
    FOREIGN KEY (`id_persona`) REFERENCES `persona`(`id_persona`)
);

-- ----------------------------------------------------
-- 3️⃣ Tabla proveedor
-- ----------------------------------------------------
CREATE TABLE `proveedor` (
    `id_proveedor` INT AUTO_INCREMENT PRIMARY KEY,
    `razon_social` VARCHAR(150) NOT NULL,
    `cuit` VARCHAR(20),
    `direccion` VARCHAR(200),
    `telefono` VARCHAR(50),
    `email` VARCHAR(100),
    `id_contacto` INT,
    FOREIGN KEY (`id_contacto`) REFERENCES `persona`(`id_persona`)
);

-- ----------------------------------------------------
-- 4️⃣ Tabla usuario
-- ----------------------------------------------------
CREATE TABLE `usuario` (
    `id_usuario` INT AUTO_INCREMENT PRIMARY KEY,
    `id_persona` INT NOT NULL,
    `nombre_usuario` VARCHAR(50) NOT NULL UNIQUE,
    `password_hash` VARCHAR(255) NOT NULL,
    `rol` ENUM('admin','empleado') NOT NULL,
    FOREIGN KEY (`id_persona`) REFERENCES `persona`(`id_persona`)
);

-- ----------------------------------------------------
-- 5️⃣ Tabla tipo_producto
-- ----------------------------------------------------
CREATE TABLE `tipo_producto` (
    `id_tipo_producto` INT AUTO_INCREMENT PRIMARY KEY,
    `nombre` VARCHAR(100) NOT NULL,
    `descripcion` VARCHAR(255)
);

-- ----------------------------------------------------
-- 6️⃣ Tabla producto
-- ----------------------------------------------------
CREATE TABLE `producto` (
    `id_producto` INT AUTO_INCREMENT PRIMARY KEY,
    `codigo` VARCHAR(50) UNIQUE NOT NULL,
    `nombre` VARCHAR(150) NOT NULL,
    `id_tipo_producto` INT NOT NULL,
    `stock` INT DEFAULT 0,
    `precio_costo` DECIMAL(10,2) NOT NULL,
    `precio_venta` DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (`id_tipo_producto`) REFERENCES `tipo_producto`(`id_tipo_producto`)
);

-- ----------------------------------------------------
-- 7️⃣ Tabla factura_compra
-- ----------------------------------------------------
CREATE TABLE `factura_compra` (
    `id_factura_compra` INT AUTO_INCREMENT PRIMARY KEY,
    `fecha` DATETIME NOT NULL,
    `id_proveedor` INT NOT NULL,
    `id_usuario` INT NOT NULL,
    `total` DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (`id_proveedor`) REFERENCES `proveedor`(`id_proveedor`),
    FOREIGN KEY (`id_usuario`) REFERENCES `usuario`(`id_usuario`)
);

-- ----------------------------------------------------
-- 8️⃣ Tabla detalle_factura_compra
-- ----------------------------------------------------
CREATE TABLE `detalle_factura_compra` (
    `id_detalle_compra` INT AUTO_INCREMENT PRIMARY KEY,
    `id_factura_compra` INT NOT NULL,
    `id_producto` INT NOT NULL,
    `cantidad` INT NOT NULL,
    `precio_unitario` DECIMAL(10,2) NOT NULL,
    `subtotal` DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (`id_factura_compra`) REFERENCES `factura_compra`(`id_factura_compra`),
    FOREIGN KEY (`id_producto`) REFERENCES `producto`(`id_producto`)
);

-- ----------------------------------------------------
-- 9️⃣ Tabla factura_venta
-- ----------------------------------------------------
CREATE TABLE `factura_venta` (
    `id_factura_venta` INT AUTO_INCREMENT PRIMARY KEY,
    `fecha` DATETIME NOT NULL,
    `id_cliente` INT NOT NULL,
    `id_usuario` INT NOT NULL,
    `total` DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (`id_cliente`) REFERENCES `cliente`(`id_cliente`),
    FOREIGN KEY (`id_usuario`) REFERENCES `usuario`(`id_usuario`)
);

-- ----------------------------------------------------
-- 🔟 Tabla detalle_factura_venta
-- ----------------------------------------------------
CREATE TABLE `detalle_factura_venta` (
    `id_detalle_venta` INT AUTO_INCREMENT PRIMARY KEY,
    `id_factura_venta` INT NOT NULL,
    `id_producto` INT NOT NULL,
    `cantidad` INT NOT NULL,
    `precio_unitario` DECIMAL(10,2) NOT NULL,
    `subtotal` DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (`id_factura_venta`) REFERENCES `factura_venta`(`id_factura_venta`),
    FOREIGN KEY (`id_producto`) REFERENCES `producto`(`id_producto`)
);
