# Mayorista El Brujo
Proyecto final para la asignatura "Laboratorio II" de la carrera Tec. En desarrollo de Software. Universidad de La Punta Universidad 
Sistema de gestión desarrollado en **ASP.NET Core MVC**  para una tienda mayorista.  
Permite administrar stock de productos, ventas.

---

## Tabla de contenidos
1. [Descripción general](#descripción-general)
2. [Análisis de entidades y casos de uso](#análisis-de-entidades-y-casos-de-uso)
3. [Características principales](#características-principales)
4. [Requisitos del sistema](#requisitos-del-sistema)
5. [Instalación y ejecución](#instalación-y-ejecución)
6. [Uso del sistema](#uso-del-sistema)
7. [Tecnologías utilizadas](#tecnologías-utilizadas)
8. [Capturas de pantalla](#capturas-de-pantalla)
9. [Contribuciones](#contribuciones)
10. [Licencia](#licencia)

---

## Descripción general

**Mayorista El Brujo** es una aplicación web orientada a la gestión comercial de una tienda mayorista.  
Su objetivo principal es simplificar las tareas administrativas relacionadas con:
- Registro de compras a proveedores
- Registro de ventas a clientes
- Control de stock
- Gestión de usuarios que operan la plataforma    


---

## Análisis de entidades y casos de uso

### Entidades principales

**Persona**  
Representa contactos individuales, empleados o personas físicas asociadas a clientes o proveedores.

**Cliente**  
Puede ser una persona o una empresa que realiza compras. Se almacena información relevante para facturación y contacto.

**Proveedor**  
Empresas que suministran productos al mayorista. Se registra información de la empresa y, opcionalmente, un contacto asociado.

**Usuario**  
Representa empleados o administradores del sistema que realizan operaciones, con acceso controlado mediante login y roles.

**TipoProducto**  
Clasificación de productos disponibles en el sistema.

**Producto**  
Artículos que se compran y venden. Contienen información de stock, precios y tipo de producto.

**FacturaCompra**  
Registra las compras de productos a proveedores. Cada factura está asociada a un proveedor y a un usuario que la registró.

**DetalleFacturaCompra**  
Contiene los productos, cantidades y precios de cada factura de compra.

**FacturaVenta**  
Registra las ventas a clientes. Cada factura está asociada a un cliente y a un usuario que la registró.

**DetalleFacturaVenta**  
Contiene los productos, cantidades y precios de cada factura de venta.


### Relaciones entre entidades

- Un **usuario** puede registrar muchas facturas (1:N).  
- Cada **factura de compra** está asociada a un **proveedor**, y cada **factura de venta** a un **cliente**.  
- Los **detalles de factura** vinculan cada producto con la factura correspondiente.  
- Los **productos** están clasificados por **tipo de producto**, y su stock se actualiza según compras y ventas.  
 

### Casos de uso principales

**Registro de compra**
- Crear una factura de compra con su detalle de productos.  
- Actualizar stock de los productos comprados.  

**Registro de venta**
- Crear una factura de venta con su detalle de productos.  
- Disminuir stock de los productos vendidos.  

**Gestión de clientes y proveedores**
- Registrar, actualizar y consultar información de clientes y proveedores.  

**Gestión de usuarios**
- Crear usuarios con roles (admin, empleado) y asociarlos a personas.  
- Control de acceso a funcionalidades del sistema.  

**Consultas y reportes**
- Historial de compras y ventas.  
- Stock de productos disponible.  
- Facturas registradas por usuario. |

---

## Características principales

- Gestión completa de productos, clientes y ventas.  
- Control de acceso mediante usuario y contraseña.  
- Interfaz gráfica desarrollada con **ASP.Net Core**.  
- Validaciones y manejo de excepciones.  

---

## Requisitos del sistema

- **Visual Studio 2022 o VS Code**
- **.NET 8.0 SDK**
- **MySQL Server 8.0+**
- **Git**

---

## Instalación y ejecución

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/usuario/mayorista-el-brujo.git
