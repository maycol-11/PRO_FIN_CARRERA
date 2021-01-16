USE master;
GO

IF EXISTS (SELECT * FROM SysDataBases WHERE name = 'PRO_BD_2019')
BEGIN
	DROP DATABASE PRO_BD_2019
END
GO

CREATE DATABASE PRO_BD_2019
ON
(
	NAME = PRO_BD_2019,
	FILENAME = 'C:\Bases de Datos\PRO_BD_2019\PRO_BD_2019.mdf'
)
GO

USE PRO_BD_2019
GO

CREATE TABLE Entidades
(
	Nombre_Entidad varchar(20) primary key not null,
	Direccion varchar(20) not null
)
GO

CREATE TABLE Telefonos
(
	Nombre_Entidad varchar(20) foreign key references Entidades(Nombre_Entidad),
	Telefono varchar(8),
	primary key (Nombre_Entidad, Telefono)
)
GO

CREATE TABLE Empleados
(
	Cedula int primary key not null,
	Nombre_Empleado varchar(20) not null,
	Contrasenia varchar(20) not null	
)
GO

CREATE TABLE Tramites
(
	Codigo varchar(6) not null,
	Nombre_Entidad varchar(20) foreign key references Entidades(Nombre_Entidad),
	Nombre_Tramite varchar(20) not null,
	Descripcion varchar(30) not null,
	primary key (Codigo, Nombre_Entidad)
)
GO

CREATE TABLE Solicitudes
(
	Numero_Solicitud int primary key IDENTITY(1,1) not null,
	Codigo varchar(6) not null,
	Nombre_Entidad varchar(20) not null,
	foreign key (Codigo, Nombre_Entidad) references Tramites(Codigo, Nombre_Entidad),
	Fecha datetime not null,	
	Nombre_Solicitante varchar(20) not null,	
	Cedula int foreign key references Empleados(Cedula),
	Estado varchar(10) not null
)
GO

INSERT Empleados(Nombre_Empleado, Cedula, Contrasenia) VALUES ('Administrador', 12345678, 'Administrador')
GO

/*** Store Procedure ***/

/*** Buscar Entidad ***/
CREATE PROC sp_BuscarEntidad
--ALTER PROC sp_BuscarEntidad
	@Nombre varchar(20)
AS
BEGIN

	SELECT
	Nombre_Entidad,
	Direccion
	FROM Entidades
	WHERE Nombre_Entidad = @Nombre
	
END
/*
exec sp_BuscarEntidad 'OSE'
*/
GO


/*** Agregat Entidad ***/
CREATE PROC sp_AgregarEntidad
--ALTER PROC sp_AgregarEntidad
	@Nombre varchar(20),
	@Direccion varchar(20)
AS
BEGIN

	IF EXISTS(SELECT Nombre_Entidad, Direccion FROM Entidades WHERE Nombre_Entidad = @Nombre)
	return -1;
	
	DECLARE @Error int
	
	INSERT Entidades (Nombre_Entidad, Direccion) VALUES (@Nombre, @Direccion)
	SET @Error = @@ERROR;
	if @Error <> 0
		return -2
END
/*
exec sp_AgregarEntidad 'IMM', 'Avenida IMM'
*/
GO


/*** Modificar Entidad ***/
CREATE PROC sp_ModificarEntidad
--ALTER PROC sp_ModificarEntidad
	@Nombre varchar(20),
	@Direccion varchar(20)
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Entidades WHERE Nombre_Entidad = @Nombre)
	return -1;
	
	DECLARE @Error int	
	
	UPDATE Entidades SET Direccion = @Direccion WHERE Nombre_Entidad = @Nombre
	SET @Error = @@rowcount;
	if @Error = 0
		return -2
		
END
/*
exec sp_ModificarEntidad 'OSE', 'AVENIDA pepe'
*/
GO

/*** Eliminar Entidad ***/
CREATE PROC  sp_EliminarEntidad
--ALTER PROC sp_EliminarEntidad
	@Nombre varchar(20)
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Entidades WHERE Nombre_Entidad = @Nombre)
	return -1;
	
	IF EXISTS (SELECT * FROM Solicitudes WHERE Nombre_Entidad = @Nombre)
	return -2;
	
	DECLARE @Error int
	BEGIN TRAN
	
	DELETE Tramites WHERE Nombre_Entidad = @Nombre
	SET @Error = @@ERROR;
	if @Error <> 0
		begin
			ROLLBACK TRAN
			return -3
		end
	
	DELETE Telefonos WHERE Nombre_Entidad = @Nombre
	SET @Error = @@ERROR;
	if @Error <> 0
		begin
			ROLLBACK TRAN
			return -4
		end
	
	DELETE Entidades WHERE Nombre_Entidad = @Nombre
	SET @Error = @@ERROR;
	if @Error <> 0
		begin
			ROLLBACK TRAN
			return -5
		end
	
	COMMIT TRAN

END
/*declare @resp int
exec @resp = sp_EliminarEntidad 'OSE'
print 'Eliminar Entidad = ' + CONVERT(varchar, @resp)*/
GO

CREATE PROC sp_ListarEntidad
--ALTER PROC sp_ListarEntidad
AS
BEGIN

	SELECT * FROM Entidades

END
GO

/*** Agregar Telefono ***/
CREATE PROC sp_AgregarTelefono
--ALTER PROC sp_AgregarTelefono
	@Nombre varchar(20),
	@Telefono varchar(8)
AS
BEGIN
	
	IF NOT EXISTS (SELECT * FROM Entidades WHERE Nombre_Entidad = @Nombre)
	return -1
	
	IF EXISTS (SELECT * FROM Telefonos WHERE Nombre_Entidad = @Nombre AND Telefono = @Telefono)
	return -2;	
	
	INSERT Telefonos(Nombre_Entidad, Telefono) VALUES (@Nombre, @Telefono)
	
	if (@@ERROR <> 0)
		return -3
			
END
/*declare @resp int
exec @resp = sp_AgregarTelefono 'OSE', '91528000'
print 'Agregar Telefono = ' + CONVERT(varchar, @resp)*/
GO

/*** Eliminar Telefono ***/
CREATE PROC sp_EliminarTelefono
--ALTER PROC sp_EliminarTelefono
	@Nombre varchar(20)
AS
BEGIN
	
	DELETE Telefonos WHERE Nombre_Entidad = @Nombre
	
	if @@ERROR <> 0
	return -1

END
/*declare @resp int
exec @resp = sp_EliminarTelefono 'OSE'
print 'Eliminar Telefono = ' + CONVERT(varchar, @resp)*/
GO

/*** Listar Telefono ***/
CREATE PROC sp_ListarTelefonos
--ALTER PROC sp_ListarTelefonos
	@Nombre varchar(20)
AS
BEGIN

	SELECT
	Telefono
	FROM Telefonos
	WHERE Nombre_Entidad = @Nombre

END
/*
exec @resp = sp_EliminarTelefono 'OSE'
*/
GO

CREATE PROC sp_BuscarTramite
--ALTER PROC sp_BuscarTramite
	@Codigo varchar(6),
	@Nombre_Entidad varchar(20)
AS
BEGIN

	SELECT *
	FROM Tramites
	WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre_Entidad

END
/*
exec sp_BucarTramite 'OSE' 
*/
GO

/*** Agregar Tramite ***/
CREATE PROC sp_AgregarTramite
--ALTER PROC sp_AgregarTramite
	@Codigo varchar(6),	
	@Nombre_Entidad varchar(20),
	@Nombre_Tramite varchar(20),
	@Descripcion varchar(20)
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Entidades WHERE Nombre_Entidad = @Nombre_Entidad)
	return -1
	
	IF EXISTS (SELECT * FROM Tramites WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre_Entidad)
	return -2;	
	
	INSERT Tramites(Codigo,Nombre_Entidad, Nombre_Tramite, Descripcion) VALUES (@Codigo, @Nombre_Entidad,@Nombre_Tramite, @Descripcion)
	if @@Error <> 0
		return -3	

END
/*declare @resp int
exec @resp = sp_AgregarTramite 'IMM001','IMM', 'Libreta de Conducir', 'Solicitud de Libreta de Conducir'
print 'Agregar Tramite = ' + CONVERT(varchar, @resp)*/
GO

/*** Modificar Tramite ***/
CREATE PROC sp_ModificarTramite
--ALTER PROC sp_ModificarTramite
	@Codigo varchar(6),
	@Nombre_Entidad varchar(20),
	@Nombre_Tramite varchar(20),
	@Descripcion varchar(20)
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Tramites WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre_Entidad)
	return -1;	
	
	UPDATE Tramites SET Nombre_Tramite = @Nombre_Tramite, Descripcion = @Descripcion
	WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre_Entidad
	
	if @@Error <> 0		
		return -2
				
END
/*
exec sp_ModificarTramite 'IMM001','IMM','Contribucion','Pago de Contribucion'
*/
GO

/*** Eliminar Tramite ***/
CREATE PROC sp_EliminarTramite
--ALTER PROC sp_EliminarTramite
	@Codigo varchar(6),
	@Nombre varchar(20)
AS
BEGIN

	IF NOT EXISTS(SELECT * FROM Tramites WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre)
	return -1
	
	IF NOT EXISTS(SELECT * FROM Solicitudes WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre)
	return -2	
	
	Declare @Error int
	
	BEGIN TRAN
		
		DELETE Solicitudes WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre
		SET @Error = @@ERROR
		if @Error <> 0
			begin
				ROLLBACK
				return -3
			end
			
		DELETE Tramites WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre
		SET @Error = @@ERROR
		if @Error <> 0
			begin
				ROLLBACK
				return -4
			end

	COMMIT TRAN
				
END
/*declare @resp int
exec @resp = sp_EliminarTramite '123456', 'ose'
print 'Eliminar Tramite = ' + CONVERT(varchar, @resp)*/
GO

CREATE PROC sp_BuscarEmpleado
--ALTER PROC sp_BuscarEmpleado
	@Cedula int
AS
BEGIN

	SELECT * FROM Empleados WHERE Cedula = @Cedula

END
/*
exec sp_BuscarEmpleado '4810015'
*/
GO

/*** Agregar Empleado ***/
CREATE PROC sp_AgregarEmpleado
--ALTER PROC sp_AgregarEmpleado
	@Nombre varchar(20),
	@Cedula int,
	@Contrasenia varchar(20)
AS
BEGIN

	IF EXISTS (SELECT * FROM Empleados WHERE Cedula = @Cedula)
	return -1;	
	
	INSERT Empleados(Nombre_Empleado, Cedula, Contrasenia) VALUES (@Nombre, @Cedula, @Contrasenia)
	
	if @@Error <> 0
		return -2
			
END
/*declare @resp int
exec @resp = sp_AgregarEmpleado 'Maycol', 48100159, 'Maycol1234'
print 'Agregar Empleado = ' + CONVERT(varchar, @resp)*/
GO

/*** Modificar Empleado ***/
CREATE PROC sp_ModificarEmpleado
--ALTER PROC sp_ModificarEmpleado
	@Nombre varchar(20),
	@Cedula int,
	@Contrasenia varchar(20)
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Empleados WHERE Cedula = @Cedula)
	return -1	
	
	UPDATE Empleados SET Nombre_Empleado = @Nombre, Contrasenia = @Contrasenia WHERE Cedula = @Cedula
	
	if @@Error <> 0		
		return -2
	
END
/*declare @resp int
exec @resp = sp_ModificarEmpleado 'JUAN', 4810018, 'Contrasenia'
print 'Modificar Empleado = ' + CONVERT(varchar, @resp)*/
GO

/*** Eliminar Empleado ***/
CREATE PROC sp_EliminarEmpleado
--ALTER PROC sp_EliminarEmpleado
	@Cedula int
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Empleados WHERE Cedula = @Cedula)
	return -1
	
	IF EXISTS (SELECT * FROM Solicitudes WHERE Cedula = @Cedula)
	return -2	
	
	DELETE Empleados WHERE Cedula = @Cedula
	
	if @@Error <> 0
		return -3
		
END
/*declare @resp int
exec @resp = sp_EliminarEmpleado 4810015
print 'Eliminar Empleado = ' + CONVERT(varchar, @resp)*/
GO

CREATE PROC sp_LoginEmpleado
--ALTER PROC sp_LoginEmpleado
	@Cedula int,
	@Contrasenia varchar(20)
AS
BEGIN

	SELECT *
	FROM Empleados
	WHERE Cedula = @Cedula AND Contrasenia = @Contrasenia

END
/* exec sp_LoginEmpleado 48100159, Maycol1234 */
GO

CREATE PROC sp_AgregarSolicitud
--ALTER PROC sp_AgregarSolicitud
	@Nombre_Entidad varchar (20),
	@Codigo varchar(6),
	@Fecha datetime,	
	@Nombre_Solicitante varchar(20),	
	@Cedula int
AS
BEGIN

	IF NOT EXISTS(SELECT * FROM Tramites WHERE Codigo = @Codigo AND Nombre_Entidad = @Nombre_Entidad)
	return -1
	
	IF NOT EXISTS(SELECT * FROM Empleados WHERE Cedula = @Cedula)
	return -2
	
	INSERT Solicitudes (Nombre_Entidad, Codigo, Fecha, Nombre_Solicitante, Cedula, Estado)
	VALUES (@Nombre_Entidad, @Codigo, @Fecha, @Nombre_Solicitante, @Cedula, 'ALTA')	
	if @@Error <> 0
		return -3
END
/*
exec sp_AgregarSolicitud
*/
GO

CREATE PROC sp_ModificarSolicitud
--ALTER PROC sp_ModificarSolicitud
	@Numero_Solicitud int,
	@Estado varchar(10)
AS
BEGIN
	
	IF NOT EXISTS(SELECT * FROM Solicitudes WHERE Numero_Solicitud = @Numero_Solicitud)
	return -1
	
	if(@Estado = 'EJECUTADA' OR @Estado = 'ANULADA')	
		UPDATE Solicitudes SET Estado = @Estado	WHERE Numero_Solicitud = @Numero_Solicitud
	else
		return -2
END
/*
exec sp_ModificarSolicitud
*/
GO

CREATE PROC sp_BuscarSolicitud
--ALTER PROC sp_EstadoSolicitud
	@Numero_Solicitud int
AS
BEGIN

	SELECT *
	FROM Solicitudes
	WHERE Numero_Solicitud = @Numero_Solicitud

END
GO

CREATE PROC sp_ListadoTramite
--ALTER PROC sp_ListadoTramite
AS
BEGIN

	SELECT * FROM Tramites

END
GO

CREATE PROC sp_ListarTramiteXEntidad
--ALTER PROC sp_ListarTramiteXEntidad
	@Nombre_Entidad varchar(20)
AS
BEGIN
	
	SELECT *
	FROM Tramites
	WHERE Nombre_Entidad = @Nombre_Entidad

END
GO

CREATE PROC sp_ListadoSolicitudesFecha
--ALTER PROC sp_ListadoSolicitudesFecha	
	@Fecha datetime
AS
BEGIN

	SELECT * 
	FROM Solicitudes 
	WHERE Fecha >= @Fecha and Fecha < dateadd(day, 1, @Fecha) AND Estado = 'ALTA'
	ORDER BY Fecha ASC
	
END
GO
/*
exec sp_ListadoSolicitudesFecha '20200608'
*/

CREATE PROC sp_ListarSolicitudAlta
--ALTER PROC sp_ListarSolicitudAlta
AS
BEGIN

	SELECT *
	FROM Solicitudes
	WHERE Estado = 'ALTA'

END
GO

CREATE PROC sp_ListarSolicitud
--ALTER PROC sp_ListarSolicitud
	@Codigo varchar(6),
	@Estado varchar(20)
AS
BEGIN

	if(@Estado = 'TODOS')
		SELECT * FROM Solicitudes
		WHERE Codigo = @Codigo
	else
		SELECT * FROM Solicitudes
		WHERE Codigo = @Codigo AND Estado = @Estado
				
END
GO

/*
exec sp_ListarSolicitud '123454', 'Anulada'
*/

SELECT * FROM Entidades
SELECT * FROM Tramites WHERE Nombre_Entidad = 'OSE'
SELECT * FROM Telefonos
SELECT * FROM Tramites
SELECT * FROM Empleados
SELECT * FROM Solicitudes
DELETE Tramites WHERE Nombre_Entidad = 'OSE'
SELECT * FROM Entidades WHERE Nombre_Entidad = 'ose'