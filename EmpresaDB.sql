-- Creación de la base de datos y tabla Clientes
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'EmpresaDB')
BEGIN
    CREATE DATABASE EmpresaDB;
END
GO

USE EmpresaDB;
GO

-- Crear la tabla Clientes si no existe
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Clientes') AND type = N'U')
BEGIN
    CREATE TABLE dbo.Clientes (
        Id        INT IDENTITY(1,1) PRIMARY KEY,
        Nombre    VARCHAR(100) NOT NULL,
        Apellido  VARCHAR(100) NOT NULL,
        Email     VARCHAR(150) NULL,
        Telefono  VARCHAR(30)  NULL
    );
END
GO

-- Datos de ejemplo
IF NOT EXISTS (SELECT 1 FROM dbo.Clientes)
BEGIN
    INSERT INTO dbo.Clientes (Nombre, Apellido, Email, Telefono)
    VALUES
        ('Juan', 'Pérez', 'juan.perez@correo.com', '0981123456'),
        ('María', 'González', 'maria.gonzalez@correo.com', '0982654321');
END
GO
