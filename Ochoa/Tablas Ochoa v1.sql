IF OBJECT_ID ('dbo.AccesoFunciones') IS NOT NULL
	DROP TABLE dbo.AccesoFunciones
GO

CREATE TABLE dbo.AccesoFunciones
	(
	idFuncion   NUMERIC (18) NOT NULL,
	Funcion     NVARCHAR (10) NOT NULL,
	Descripcion NVARCHAR (200) NULL,
	Tipo        NVARCHAR (5) NULL,
	Orden       INT NULL,
	BeginGroup  INT NULL,
	Imagen      NUMERIC (5) NULL,
	CONSTRAINT PK_AccesoFunciones PRIMARY KEY (idFuncion)
	)
GO

IF OBJECT_ID ('dbo.Areas') IS NOT NULL
	DROP TABLE dbo.Areas
GO

CREATE TABLE dbo.Areas
	(
	idArea INT NOT NULL,
	Area   NVARCHAR (30) NULL,
	CONSTRAINT PK_Areas PRIMARY KEY (idArea)
	)
GO

IF OBJECT_ID ('dbo.Empleados') IS NOT NULL
	DROP TABLE dbo.Empleados
GO

CREATE TABLE dbo.Empleados
	(
	idEmpleado INT NOT NULL,
	Numero     NCHAR (15) NULL,
	Nombre     VARCHAR (100) NOT NULL,
	Login      NVARCHAR (20) NOT NULL,
	Pass       NVARCHAR (20) NOT NULL,
	idArea     INT NULL,
	idPuesto   INT NULL,
	idEstatus  INT NOT NULL,
	Estudios   NVARCHAR (40) NULL,
	RFC        NVARCHAR (20) NULL,
	CURP       NVARCHAR (20) NULL,
	Licencia   NVARCHAR (15) NULL,
	Vigencia   DATETIME NULL,
	Fecha_Alta DATE NULL,
	Fecha_Baja DATETIME NULL,
	Motivo     NVARCHAR (50) NULL,
	NSS        NVARCHAR (15) NULL,
	AltaIMSS   DATETIME NULL,
	BajaIMSS   DATETIME NULL,
	Telefono   NVARCHAR (20) NULL,
	Celular    NVARCHAR (20) NULL,
	Calle      NVARCHAR (40) NULL,
	Colonia    NVARCHAR (40) NULL,
	Ciudad     NVARCHAR (40) NULL,
	Estatura   DECIMAL (18, 2) NULL,
	Peso       DECIMAL (18, 2) NULL,
	Nacimiento DATETIME NULL,
	EMail      VARCHAR (40) NULL,
	Saldo      MONEY NULL,
	idPerfil   INT NULL,
	Foto       VARCHAR (150) NULL,
	Mensaje    VARCHAR (50) NULL,
	Actualizar NVARCHAR (1) NULL,
	Version    NVARCHAR (20) NULL,
	CONSTRAINT Pk_idUsuario PRIMARY KEY (idEmpleado)
	)
GO

CREATE UNIQUE INDEX idx_idUsuario1
	ON dbo.Empleados (idEmpleado)
GO

IF OBJECT_ID ('dbo.Familiares') IS NOT NULL
	DROP TABLE dbo.Familiares
GO

CREATE TABLE dbo.Familiares
	(
	idFamiliar INT NOT NULL,
	idEmpleado INT NOT NULL,
	Nombre     NVARCHAR (100) NULL,
	Parentesco NVARCHAR (50) NULL,
	Edad       INT NULL,
	CONSTRAINT PK_Familiares PRIMARY KEY (idFamiliar)
	)
GO

IF OBJECT_ID ('dbo.Perfiles') IS NOT NULL
	DROP TABLE dbo.Perfiles
GO

CREATE TABLE dbo.Perfiles
	(
	idPerfil    INT NOT NULL,
	Perfil      NVARCHAR (100) NULL,
	Descripcion NVARCHAR (1000) NULL,
	CONSTRAINT PK_Perfiles PRIMARY KEY (idPerfil)
	)
GO

IF OBJECT_ID ('dbo.PerfilFunciones') IS NOT NULL
	DROP TABLE dbo.PerfilFunciones
GO

CREATE TABLE dbo.PerfilFunciones
	(
	idPerfilFunciones NUMERIC (18) NOT NULL,
	idPerfil          NUMERIC (18) NULL,
	idFuncion         NUMERIC (18) NULL,
	GrupoPadre        NUMERIC (18) NULL,
	Orden             NUMERIC (10) NULL,
	Visible           INT NULL,
	Activo            INT NULL,
	Lectura           INT NULL,
	Escritura         INT NULL,
	Modificacion      INT NULL,
	Eliminar          INT NULL,
	CONSTRAINT PK_PerfilFunciones PRIMARY KEY (idPerfilFunciones)
	)
GO

IF OBJECT_ID ('dbo.Puestos') IS NOT NULL
	DROP TABLE dbo.Puestos
GO

CREATE TABLE dbo.Puestos
	(
	idPuesto INT NOT NULL,
	Puesto   NVARCHAR (50) NULL,
	CONSTRAINT PK_Puestos PRIMARY KEY (idPuesto)
	)
GO

IF OBJECT_ID ('dbo.Estatus') IS NOT NULL
	DROP TABLE dbo.Estatus
GO

CREATE TABLE dbo.Estatus
	(
	idEstatus INT NOT NULL,
	Tipo      NCHAR (10) NOT NULL,
	Estatus   NCHAR (20) NOT NULL
	)
GO

CREATE CLUSTERED INDEX [Estatus-Tipo]
	ON dbo.Estatus (idEstatus, Tipo)
GO

