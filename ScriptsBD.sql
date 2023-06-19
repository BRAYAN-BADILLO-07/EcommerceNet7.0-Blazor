CREATE DATABASE EcommerceDB
GO

USE EcommerceDB
GO

/*		Tabla Para las distintas categorias de los productos	*/
CREATE TABLE Categoria(
	IdCategoria INT PRIMARY KEY IDENTITY,
	Nombre VARCHAR(50),
	FechaCreacion DATETIME DEFAULT GETDATE()
)
GO

/*		Tabla para los productos mostrados en el Ecommerce		*/
CREATE TABLE Producto(
	IdProducto INT PRIMARY KEY IDENTITY,
	Nombre VARCHAR(50),
	Descripcion VARCHAR(1000),
	IdCategoria INT REFERENCES Categoria(IdCategoria),
	Precio DECIMAL(10,2),
	PrecioOferta DECIMAL(10,2),
	Cantidad INT,
	Imagen VARCHAR(MAX),
	FechaCreacion DATETIME DEFAULT GETDATE()
)
GO

/*		Tabla para los usuarios registrados		*/
CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	NombreCompleto VARCHAR(50),
	Correo VARCHAR(50),
	Clave VARCHAR(50),
	Rol VARCHAR(50), -- Roles: Administrados - Cliente
	FechaCreacion DATETIME DEFAULT GETDATE()
)
GO

/*		Tabla para el historial del total de ventas vendidas	*/
CREATE TABLE Venta(
	IdVenta INT PRIMARY KEY IDENTITY,
	IdUsuario INT REFERENCES Usuario(IdUsuario),
	Total DECIMAL(10,2),
	FechaCreacion DATETIME DEFAULT GETDATE()
)
GO

/*		Tabla para Detalle de las ventas, nos sirve para el Carrito de compras		*/
CREATE TABLE DetalleVenta
(
	IdDetalleVenta INT PRIMARY KEY IDENTITY,
	IdVenta INT REFERENCES Venta(IdVenta),
	IdProducto INT REFERENCES Producto(IdProducto),
	Cantidad INT,
	Total DECIMAL(10,2)
)
GO

/*			Agregamos Usuario Administrador			*/
INSERT INTO Usuario(NombreCompleto, Correo, Clave, Rol) 
VALUES ('Admin','admin@example.com','12345678*!','Administrador')
GO