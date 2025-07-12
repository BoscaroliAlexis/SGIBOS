
CREATE DATABASE IF NOT EXISTS TiendaDB; 
USE TiendaDB;


CREATE TABLE Clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    telefono VARCHAR(21),
    correo VARCHAR(100),
    direccion VARCHAR(100),
    fecha_registro DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    contrasena VARCHAR(64) NOT NULL
);

CREATE TABLE Roles (
    id_rol INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(50) NOT NULL,
    descripcion VARCHAR(100),
    permisos VARCHAR(100)
);


CREATE TABLE Categorias (
    id_categoria INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL
);

CREATE TABLE Proveedores (
    id_proveedor INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    contacto VARCHAR(50),
    telefono VARCHAR(21),
    correo VARCHAR(100),
    direccion VARCHAR(100),
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Usuarios_roles (
    id_usuario_rol INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT,
    id_rol INT,
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario),
    FOREIGN KEY (id_rol) REFERENCES Roles(id_rol)
);


CREATE TABLE Productos (
    id_producto INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(100),
    precio DECIMAL(10,2),
    cantidad_stock INT,
    id_categoria INT,
    id_proveedor INT,
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);


CREATE TABLE Ventas (
    id_venta INT AUTO_INCREMENT PRIMARY KEY,
    fecha_venta DATETIME DEFAULT CURRENT_TIMESTAMP,
    id_cliente INT,
    total_venta DECIMAL(10,2),
    metodo_pago VARCHAR(30),
    id_usuario INT,
    descuento DECIMAL(10,2), 
    recargo DECIMAL(10,2),  
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente),
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario)
);


CREATE TABLE Detalle_ventas (
    id_detalle_ventas INT AUTO_INCREMENT PRIMARY KEY,
    id_venta INT,
    id_producto INT,
    cantidad INT,
    precio_unitario DECIMAL(10,2),
    subtotal DECIMAL(10,2),
    FOREIGN KEY (id_venta) REFERENCES Ventas(id_venta) ON DELETE CASCADE,
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);


INSERT INTO Categorias (nombre) VALUES ('Sin categoría');
INSERT INTO Proveedores (nombre) VALUES ('Sin proveedor');


INSERT INTO Clientes (nombre, telefono, correo, direccion) VALUES
('Juan Perez', '123456789', 'juan@example.com', 'Calle 123'),
('Maria Lopez', '987654321', 'maria@example.com', 'Avenida 456'),
('Carlos Gómez', '111222333', 'carlos@example.com', 'Calle Norte 1'),
('Ana Torres', '444555666', 'ana@example.com', 'Av. Sur 2'),
('Luis Herrera', '777888999', 'luis@example.com', 'Pje. Oeste 3'),
('Claudia Ruiz', '000111222', 'claudia@example.com', 'Diagonal Este 4'),
('Sergio Vidal', '333444555', 'sergio@example.com', 'Calle 5'),
('Lucía Fernández', '666777888', 'lucia@example.com', 'Avenida 6'),
('Martín Cabrera', '999000111', 'martin@example.com', 'Barrio 7'),
('Sofía Romero', '222333444', 'sofia@example.com', 'Calle 8');

INSERT INTO Usuarios (nombre, contrasena) VALUES
('admin', 'admin123');



INSERT INTO Roles (titulo, descripcion, permisos) VALUES
('Administrador', 'Acceso total', 'ALL'),
('Vendedor', 'Acceso limitado', 'LIMITED'),
('Reportes', 'Solo generar reportes', 'REPORTS_ONLY'),
('Manager', 'Puede hacer ABM de Clientes, Ventas, Proveedores e inventario', 'ABM_CLIENTES_VENTAS_PROVEEDORES_PRODUCTOS');


INSERT INTO Usuarios_roles (id_usuario, id_rol) VALUES
(1, 1); -- admin -> Administrador



INSERT INTO Categorias (nombre) VALUES
('Electrónica'),
('Ropa'),
('Hogar'),
('Juguetes'),
('Herramientas'),
('Libros'),
('Deportes'),
('Oficina'),
('Mascotas');


INSERT INTO Proveedores (nombre, contacto, telefono, correo, direccion) VALUES
('Proveedor 1', 'Carlos', '555111222', 'proveedor1@example.com', 'Calle 789'),
('Proveedor 2', 'Ana', '555333444', 'proveedor2@example.com', 'Avenida 101'),
('Proveedor 3', 'Luis', '555555555', 'proveedor3@example.com', 'Calle Falsa 123'),
('Proveedor 4', 'Lucía', '555666777', 'proveedor4@example.com', 'Av. Siempre Viva 742'),
('Proveedor 5', 'José', '555888999', 'proveedor5@example.com', 'Calle Sol 456'),
('Proveedor 6', 'Sofía', '555777666', 'proveedor6@example.com', 'Avenida Luna 321'),
('Proveedor 7', 'Pedro', '555444333', 'proveedor7@example.com', 'Diagonal 110'),
('Proveedor 8', 'Laura', '555222111', 'proveedor8@example.com', 'Pje. Estrella 222'),
('Proveedor 9', 'Martín', '555999000', 'proveedor9@example.com', 'Calle Azul 789');


INSERT INTO Productos (nombre, descripcion, precio, cantidad_stock, id_categoria, id_proveedor) VALUES
('Laptop', 'Laptop de alta gama', 1200.99, 10, 2, 2),
('Camisa', 'Camisa de algodón', 25.50, 50, 3, 3),
('Silla', 'Silla ergonómica', 89.99, 20, 4, 4),
('Auto RC', 'Auto a control remoto', 45.00, 15, 5, 5),
('Taladro', 'Taladro eléctrico', 65.00, 30, 6, 6),
('Novela', 'Libro de ficción', 12.90, 100, 7, 7),
('Bicicleta', 'Bici de montaña', 300.00, 5, 8, 8),
('Escritorio', 'Mesa de oficina', 150.00, 8, 9, 9),
('Juguete perro', 'Pelota para perros', 8.99, 60, 10, 10),
('Tablet', 'Tablet 10 pulgadas', 250.00, 12, 2, 2);
