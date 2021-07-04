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

IF OBJECT_ID ('dbo.Bitacora') IS NOT NULL
	DROP TABLE dbo.Bitacora
GO

CREATE TABLE dbo.Bitacora
	(
	idBitacora INT IDENTITY NOT NULL,
	Modulo     NCHAR (40) NULL,
	Detalle    NVARCHAR (300) NULL,
	Usuario    NCHAR (20) NULL,
	Fecha      DATETIME CONSTRAINT DF_Bitacora_Fecha DEFAULT (getdate()) NULL
	)
GO

CREATE CLUSTERED INDEX idxBitacora
	ON dbo.Bitacora (idBitacora)
GO

CREATE INDEX idxModulo
	ON dbo.Bitacora (Modulo)
GO

CREATE INDEX idxUsuario
	ON dbo.Bitacora (Usuario)
GO

CREATE INDEX idxFecha
	ON dbo.Bitacora (Fecha)
GO



IF OBJECT_ID ('dbo.Categorias') IS NOT NULL
	DROP TABLE dbo.Categorias
GO

CREATE TABLE dbo.Categorias
	(
	idCategoria INT NOT NULL,
	Nombre      VARCHAR (30) NOT NULL,
	PRIMARY KEY (idCategoria),
	UNIQUE (idCategoria)
	)
GO

IF OBJECT_ID ('dbo.Clientes') IS NOT NULL
	DROP TABLE dbo.Clientes
GO

CREATE TABLE dbo.Clientes
	(
	Clave       NVARCHAR (10) NOT NULL,
	Nombre      NVARCHAR (80) NULL,
	Comercial   NVARCHAR (50) NULL,
	RFC         NVARCHAR (20) NULL,
	Proveedor   NVARCHAR (10) NULL,
	Calle       NVARCHAR (70) NULL,
	NoExterior  NVARCHAR (10) NULL,
	NoInterior  NVARCHAR (10) NULL,
	Colonia     NVARCHAR (40) NULL,
	Municipio   NVARCHAR (40) NULL,
	Ciudad      NVARCHAR (40) NULL,
	Estado      NVARCHAR (20) NULL,
	Pais        NVARCHAR (20) NULL,
	CP          NVARCHAR (5) NULL,
	Contacto1   NVARCHAR (40) NULL,
	Contacto2   NVARCHAR (40) NULL,
	Telefono    NVARCHAR (20) NULL,
	Telefono2   NVARCHAR (20) NULL,
	Celular     NVARCHAR (20) NULL,
	Fax         NVARCHAR (20) NULL,
	Email       NVARCHAR (150) NULL,
	CondPago    NVARCHAR (10) NULL,
	Cuenta      NVARCHAR (100) NULL,
	FCPago      SMALLINT NULL,
	Dias        NUMERIC (18) NULL,
	Cobro       TINYINT NULL,
	Credito     MONEY NULL,
	TP          SMALLINT NULL,
	Pedidos     BIT NOT NULL,
	Uso         NVARCHAR (3) NULL,
	Addenda     NVARCHAR (10) NULL,
	Observacion NVARCHAR (max) NULL,
	CONSTRAINT PK_Clientes PRIMARY KEY (Clave)
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

IF OBJECT_ID ('dbo.Entregas') IS NOT NULL
	DROP TABLE dbo.Entregas
GO

CREATE TABLE dbo.Entregas
	(
	Lugar     NVARCHAR (40) NULL,
	Cliente   NVARCHAR (10) NULL,
	Ruta      NVARCHAR (10) NULL,
	Domicilio NVARCHAR (50) NULL,
	Tienda    NVARCHAR (13) NULL,
	EmailE    NVARCHAR (50) NULL,
	Lunes     SMALLINT NULL,
	Martes    SMALLINT NULL,
	Miercoles SMALLINT NULL,
	Jueves    SMALLINT NULL,
	Viernes   SMALLINT NULL,
	Sabado    SMALLINT NULL,
	Domingo   SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxLugar
	ON dbo.Entregas (Lugar, Cliente, Ruta)
GO

CREATE INDEX Index_Rutas
	ON dbo.Entregas (Ruta)
GO

IF OBJECT_ID ('dbo.Equipos') IS NOT NULL
	DROP TABLE dbo.Equipos
GO

CREATE TABLE dbo.Equipos
	(
	Eco           NVARCHAR (10) NOT NULL,
	Nombre        NVARCHAR (30) NULL,
	idTipo        SMALLINT NULL,
	idClase       SMALLINT NULL,
	idTransmision TINYINT NULL,
	idAireAcon    BIT NOT NULL,
	Placas        NVARCHAR (10) NULL,
	Modelo        NVARCHAR (10) NULL,
	Color         NVARCHAR (10) NULL,
	Tanque        SMALLINT NULL,
	Costo         MONEY NULL,
	Gas           SMALLINT NULL,
	Kms           MONEY NULL,
	Servicio      MONEY NULL,
	Poliza        NVARCHAR (10) NULL,
	Compania      NVARCHAR (30) NULL,
	TelSeguro     NVARCHAR (20) NULL,
	FechaSeguro   DATETIME NULL,
	FechaVer      DATETIME NULL,
	FechaCompra   DATETIME NULL,
	FechaServicio DATETIME NULL,
	CONSTRAINT PK_Equipos PRIMARY KEY (Eco)
	)
GO

IF OBJECT_ID ('dbo.Estatus') IS NOT NULL
	DROP TABLE dbo.Estatus
GO

CREATE TABLE dbo.Estatus
	(
	idEstatus INT NOT NULL,
	Estatus   NCHAR (20) NOT NULL
	)
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

IF OBJECT_ID ('dbo.Inventario') IS NOT NULL
	DROP TABLE dbo.Inventario
GO

CREATE TABLE dbo.Inventario
	(
	idArticulo  INT IDENTITY NOT NULL,
	Codigo      VARCHAR (15) NOT NULL,
	Categoria   INT NULL,
	Tipo        INT NULL,
	Descripcion VARCHAR (50) NOT NULL,
	ClaveA      VARCHAR (15) NULL,
	Unidad      VARCHAR (5) NULL,
	ClaveSAT    VARCHAR (8) NULL,
	UnidadSAT   VARCHAR (3) NULL,
	Costo       DECIMAL (10, 3) DEFAULT ((0.0)) NULL,
	CostoM      DECIMAL (10, 3) DEFAULT ((0.0)) NULL,
	CostoU      DECIMAL (10, 3) DEFAULT ((0.0)) NULL,
	Bajo        DECIMAL (10, 3) DEFAULT ((0.0)) NULL,
	Medio       DECIMAL (10, 3) DEFAULT ((0.0)) NULL,
	Normal      DECIMAL (10, 3) DEFAULT ((0.0)) NULL,
	Stock       INT DEFAULT ((0)) NULL,
	Caja        DECIMAL (10, 2) NULL,
	NoCaja      INT DEFAULT ((1)) NULL,
	Peso        DECIMAL (10, 3) DEFAULT ((0.0)) NULL,
	Minimo      INT NULL,
	Maximo      INT NULL,
	Lugar       VARCHAR (30) NULL,
	Foto        VARCHAR (40) NULL,
	bIVA        INT NULL,
	bIEPS       INT NULL,
	bComision   INT NULL,
	DiasVig     INT NULL,
	Uso         INT NULL,
	Linea       INT NULL,
	Servicio    INT NULL,
	PorDev      INT NULL,
	CCarga      INT NULL,
	Divisor     DECIMAL (10, 2) DEFAULT ((0.0)) NULL,
	fila        INT DEFAULT ((0)) NULL,
	EAN         VARCHAR (30) NULL,
	PRIMARY KEY (Codigo),
	UNIQUE (Codigo)
	)
GO

IF OBJECT_ID ('dbo.Marcas') IS NOT NULL
	DROP TABLE dbo.Marcas
GO

CREATE TABLE dbo.Marcas
	(
	idMarca SMALLINT NOT NULL,
	Marca   NVARCHAR (30) NULL,
	CONSTRAINT PK_Marcas PRIMARY KEY (idMarca)
	)
GO

IF OBJECT_ID ('dbo.Materiales') IS NOT NULL
	DROP TABLE dbo.Materiales
GO

CREATE TABLE dbo.Materiales
	(
	Producto   VARCHAR (30) NOT NULL,
	Cantidad   DECIMAL (9, 2) NULL,
	Material   VARCHAR (30) NOT NULL,
	Disponible DECIMAL (9, 2) NULL
	)
GO

CREATE CLUSTERED INDEX idxProducto
	ON dbo.Materiales (Producto)
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

IF OBJECT_ID ('dbo.Rutas') IS NOT NULL
	DROP TABLE dbo.Rutas
GO

CREATE TABLE dbo.Rutas
	(
	Ruta       NVARCHAR (10) NOT NULL,
	Detalle    NVARCHAR (50) NULL,
	Supervisor NVARCHAR (15) NULL,
	Repartidor NVARCHAR (15) NULL,
	Eco        NVARCHAR (10) NULL,
	TP         SMALLINT NULL,
	Comision   MONEY NULL,
	AhorroR    MONEY NULL,
	KmsR       SMALLINT NULL,
	Estandar   BIT NOT NULL,
	Mayorista  BIT NOT NULL,
	Pedidos    BIT NOT NULL,
	CONSTRAINT PK_Rutas PRIMARY KEY (Ruta)
	)
GO

IF OBJECT_ID ('dbo.Tipos') IS NOT NULL
	DROP TABLE dbo.Tipos
GO

CREATE TABLE dbo.Tipos
	(
	idTipo    INT NOT NULL,
	Nombre    VARCHAR (30) NOT NULL,
	Categoria INT NOT NULL,
	PRIMARY KEY (idTipo),
	UNIQUE (idTipo)
	)
GO

IF OBJECT_ID ('dbo.TiposEquipos') IS NOT NULL
	DROP TABLE dbo.TiposEquipos
GO

CREATE TABLE dbo.TiposEquipos
	(
	idTipo  SMALLINT NOT NULL,
	Tipo    NVARCHAR (30) NULL,
	idMarca SMALLINT NULL,
	CONSTRAINT PK_TiposEquipos PRIMARY KEY (idTipo)
	)
GO



IF OBJECT_ID ('dbo.Abonos') IS NOT NULL
	DROP TABLE dbo.Abonos
GO

CREATE TABLE dbo.Abonos
	(
	Folio   INT NULL,
	Detalle NVARCHAR (30) NULL,
	Fecha   DATETIME NULL,
	Abono   MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxFolio
	ON dbo.Abonos (Folio)
GO

IF OBJECT_ID ('dbo.Almacen') IS NOT NULL
	DROP TABLE dbo.Almacen
GO

CREATE TABLE dbo.Almacen
	(
	Cantidad MONEY NULL,
	Codigo   NVARCHAR (15) NULL,
	Detalle  NVARCHAR (20) NULL,
	Costo    MONEY NULL,
	Fecha    DATETIME NULL,
	Folio    INT NULL,
	Usuario  NVARCHAR (15) NULL,
	Empleado NVARCHAR (15) NULL,
	Fila     INT NOT NULL
	)
GO

CREATE CLUSTERED INDEX idxCodigo
	ON dbo.Almacen (Codigo)
GO

IF OBJECT_ID ('dbo.Cajas') IS NOT NULL
	DROP TABLE dbo.Cajas
GO

CREATE TABLE dbo.Cajas
	(
	NoCaja  SMALLINT NULL,
	Detalle NVARCHAR (20) NULL,
	Precio  MONEY NULL
	)
GO

IF OBJECT_ID ('dbo.Cargas') IS NOT NULL
	DROP TABLE dbo.Cargas
GO

CREATE TABLE dbo.Cargas
	(
	Reparto   INT NULL,
	Cantidad  SMALLINT NULL,
	Codigo    NVARCHAR (15) NULL,
	RecargaDe INT NULL,
	FilaC     TINYINT NULL
	)
GO

CREATE CLUSTERED INDEX idxReparto
	ON dbo.Cargas (Reparto)
GO

IF OBJECT_ID ('dbo.Certificado') IS NOT NULL
	DROP TABLE dbo.Certificado
GO

CREATE TABLE dbo.Certificado
	(
	Certificado NVARCHAR (25) NULL,
	Serie       NVARCHAR (20) NULL,
	Desde       DATETIME NULL,
	Hasta       DATETIME NULL,
	Certificate NVARCHAR (max) NULL,
	ModCer      NVARCHAR (max) NULL,
	Llave       NVARCHAR (25) NULL,
	Contrasena  NVARCHAR (20) NULL,
	ModKey      NVARCHAR (max) NULL,
	AvisoVence  SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxCertificado
	ON dbo.Certificado (Certificado)
GO

IF OBJECT_ID ('dbo.CFDIRelacionados') IS NOT NULL
	DROP TABLE dbo.CFDIRelacionados
GO

CREATE TABLE dbo.CFDIRelacionados
	(
	NumeroF          INT NULL,
	FolioRelacionado INT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumeroF
	ON dbo.CFDIRelacionados (NumeroF)
GO

IF OBJECT_ID ('dbo.CobrosFacturas') IS NOT NULL
	DROP TABLE dbo.CobrosFacturas
GO

CREATE TABLE dbo.CobrosFacturas
	(
	Numero     INT NULL,
	Referencia NVARCHAR (50) NULL,
	Fecha      DATETIME NULL,
	SaldoAnt   MONEY NULL,
	Cobro      MONEY NULL,
	Tipo       TINYINT NULL,
	Cuenta     NVARCHAR (10) NULL,
	Usuario    NVARCHAR (15) NULL,
	NoPago     SMALLINT NULL,
	NoDoc      INT NULL,
	RFCE       NVARCHAR (13) NULL,
	NomBanE    NVARCHAR (50) NULL,
	NoCuentaE  NVARCHAR (20) NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.CobrosFacturas (Numero)
GO

IF OBJECT_ID ('dbo.CobrosNotas') IS NOT NULL
	DROP TABLE dbo.CobrosNotas
GO

CREATE TABLE dbo.CobrosNotas
	(
	Numero     INT NULL,
	Referencia NVARCHAR (30) NULL,
	Fecha      DATETIME NULL,
	SaldoAnt   MONEY NULL,
	Cobro      MONEY NULL,
	Tipo       TINYINT NULL,
	Cuenta     NVARCHAR (10) NULL,
	Usuario    NVARCHAR (15) NULL,
	NoPago     SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.CobrosNotas (Numero)
GO

IF OBJECT_ID ('dbo.Comisiones') IS NOT NULL
	DROP TABLE dbo.Comisiones
GO

CREATE TABLE dbo.Comisiones
	(
	Producto  NVARCHAR (15) NULL,
	Comision1 MONEY NULL,
	Comision2 MONEY NULL,
	Comision3 MONEY NULL,
	Comision4 MONEY NULL,
	Comision5 MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxProducto
	ON dbo.Comisiones (Producto)
GO

IF OBJECT_ID ('dbo.Compras') IS NOT NULL
	DROP TABLE dbo.Compras
GO

CREATE TABLE dbo.Compras
	(
	Numero    INT NOT NULL,
	Clave     NVARCHAR (15) NULL,
	Pedido    INT NULL,
	Area      SMALLINT NULL,
	SubTipoG  SMALLINT NULL,
	Factura   NVARCHAR (10) NULL,
	Empleado  NVARCHAR (15) NULL,
	Deducible BIT NOT NULL,
	Fecha     DATETIME NULL,
	Vence     DATETIME NULL,
	SubTotal  MONEY NULL,
	Pdes      MONEY NULL,
	IVA       MONEY NULL,
	IEPS      MONEY NULL,
	Saldo     MONEY NULL,
	Cancelado DATETIME NULL,
	Cancelo   NVARCHAR (15) NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.Compras (Numero)
GO

IF OBJECT_ID ('dbo.ControlCajas') IS NOT NULL
	DROP TABLE dbo.ControlCajas
GO

CREATE TABLE dbo.ControlCajas
	(
	Reparto INT NULL,
	NoCaja  SMALLINT NULL,
	Inicial SMALLINT NULL,
	Carga   SMALLINT NULL,
	Regreso SMALLINT NULL,
	Fisico  SMALLINT NULL,
	PrecioR MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxReparto
	ON dbo.ControlCajas (Reparto, NoCaja)
GO

IF OBJECT_ID ('dbo.Costos') IS NOT NULL
	DROP TABLE dbo.Costos
GO

CREATE TABLE dbo.Costos
	(
	Codigo NVARCHAR (15) NULL,
	Clave  NVARCHAR (15) NULL,
	CostoP MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxCodigo
	ON dbo.Costos (Codigo, Clave)
GO

IF OBJECT_ID ('dbo.Cotizaciones') IS NOT NULL
	DROP TABLE dbo.Cotizaciones
GO

CREATE TABLE dbo.Cotizaciones
	(
	Numero   INT NOT NULL,
	Clave    NVARCHAR (10) NULL,
	Contacto NVARCHAR (40) NULL,
	Fecha    DATETIME NULL,
	SubTotal MONEY NULL,
	IVA      MONEY NULL,
	IEPS     MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.Cotizaciones (Numero)
GO

IF OBJECT_ID ('dbo.Cuentas') IS NOT NULL
	DROP TABLE dbo.Cuentas
GO

CREATE TABLE dbo.Cuentas
	(
	Cuenta      NVARCHAR (10) NULL,
	RFCB        NVARCHAR (13) NULL,
	NoCuenta    NVARCHAR (20) NULL,
	Dolar       TINYINT NULL,
	Letra       NVARCHAR (30) NULL,
	Tamano      SMALLINT NULL,
	Negro       BIT NOT NULL,
	Orientacion TINYINT NULL,
	FechaX      SMALLINT NULL,
	FechaY      SMALLINT NULL,
	NombreX     SMALLINT NULL,
	NombreY     SMALLINT NULL,
	ImporteX    SMALLINT NULL,
	ImporteY    SMALLINT NULL,
	LetraX      SMALLINT NULL,
	LetraY      SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxCuenta
	ON dbo.Cuentas (Cuenta)
GO

IF OBJECT_ID ('dbo.DepositosReparto') IS NOT NULL
	DROP TABLE dbo.DepositosReparto
GO

CREATE TABLE dbo.DepositosReparto
	(
	Reparto INT NULL,
	Cuenta  NVARCHAR (10) NULL,
	FechaDC DATETIME NULL,
	Importe MONEY NULL,
	Factura INT NULL
	)
GO

CREATE CLUSTERED INDEX idxReparto
	ON dbo.DepositosReparto (Reparto, Cuenta)
GO

IF OBJECT_ID ('dbo.DetalleCompra') IS NOT NULL
	DROP TABLE dbo.DetalleCompra
GO

CREATE TABLE dbo.DetalleCompra
	(
	Numero    INT NULL,
	Cantidad  MONEY NULL,
	Codigo    NVARCHAR (15) NULL,
	CostoP    MONEY NULL,
	IVA       MONEY NULL,
	IEPS      MONEY NULL,
	Lote      NVARCHAR (15) NULL,
	Caducidad DATETIME NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.DetalleCompra (Numero)
GO

IF OBJECT_ID ('dbo.DetalleCotizacion') IS NOT NULL
	DROP TABLE dbo.DetalleCotizacion
GO

CREATE TABLE dbo.DetalleCotizacion
	(
	Numero      INT NULL,
	Cantidad    MONEY NULL,
	Codigo      NVARCHAR (15) NULL,
	Descripcion NVARCHAR (50) NULL,
	Precio      MONEY NULL,
	IVA         MONEY NULL,
	IEPS        MONEY NULL,
	TP          SMALLINT NULL,
	Entrega     NVARCHAR (10) NULL,
	Item        SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.DetalleCotizacion (Numero)
GO

IF OBJECT_ID ('dbo.DetalleFactura') IS NOT NULL
	DROP TABLE dbo.DetalleFactura
GO

CREATE TABLE dbo.DetalleFactura
	(
	Numero      INT NULL,
	Cantidad    MONEY NULL,
	Codigo      NVARCHAR (15) NULL,
	Descripcion NVARCHAR (50) NULL,
	Precio      MONEY NULL,
	IVA         MONEY NULL,
	IEPS        MONEY NULL,
	TP          INT NULL,
	Item        SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.DetalleFactura (Numero)
GO

IF OBJECT_ID ('dbo.DetalleNomina') IS NOT NULL
	DROP TABLE dbo.DetalleNomina
GO

CREATE TABLE dbo.DetalleNomina
	(
	Folio    INT NULL,
	Producto NVARCHAR (15) NULL,
	Entrega  INT NULL,
	Comision MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxFolio
	ON dbo.DetalleNomina (Folio, Producto)
GO

IF OBJECT_ID ('dbo.DetalleNota') IS NOT NULL
	DROP TABLE dbo.DetalleNota
GO

CREATE TABLE dbo.DetalleNota
	(
	Numero      INT NULL,
	Cantidad    MONEY NULL,
	Codigo      NVARCHAR (15) NULL,
	Descripcion NVARCHAR (50) NULL,
	Precio      MONEY NULL,
	IVA         MONEY NULL,
	IEPS        MONEY NULL,
	TP          SMALLINT NULL,
	Item        SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.DetalleNota (Numero, Codigo)
GO

IF OBJECT_ID ('dbo.DetallePedido') IS NOT NULL
	DROP TABLE dbo.DetallePedido
GO

CREATE TABLE dbo.DetallePedido
	(
	Numero      INT NULL,
	Cantidad    MONEY NULL,
	Codigo      NVARCHAR (15) NULL,
	Descripcion NVARCHAR (50) NULL,
	CostoP      MONEY NULL,
	IVA         MONEY NULL,
	Entrega     NVARCHAR (10) NULL,
	Item        SMALLINT NULL,
	Entregado   MONEY NULL,
	Compra      INT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.DetallePedido (Numero, Codigo)
GO

IF OBJECT_ID ('dbo.DetalleReparto') IS NOT NULL
	DROP TABLE dbo.DetalleReparto
GO

CREATE TABLE dbo.DetalleReparto
	(
	Reparto    INT NULL,
	Codigo     NVARCHAR (15) NULL,
	SobranteC  SMALLINT NULL,
	Carga      SMALLINT NULL,
	RecargaDe  SMALLINT NULL,
	Sobrante   SMALLINT NULL,
	Devolucion SMALLINT NULL,
	Cortesias  SMALLINT NULL,
	Creditos   SMALLINT NULL,
	RecargaA   SMALLINT NULL,
	Precio     MONEY NULL,
	VtaCredito MONEY NULL,
	FilaD      TINYINT NULL
	)
GO

CREATE CLUSTERED INDEX idxReparto
	ON dbo.DetalleReparto (Reparto, Codigo)
GO

IF OBJECT_ID ('dbo.Diversos') IS NOT NULL
	DROP TABLE dbo.Diversos
GO

CREATE TABLE dbo.Diversos
	(
	Reparto  INT NULL,
	Concepto NVARCHAR (30) NULL,
	Importe  MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxReparto
	ON dbo.Diversos (Reparto)
GO

IF OBJECT_ID ('dbo.EdoCuenta') IS NOT NULL
	DROP TABLE dbo.EdoCuenta
GO

CREATE TABLE dbo.EdoCuenta
	(
	Cuenta     NVARCHAR (10) NULL,
	Folio      INT NULL,
	Fecha      DATETIME NULL,
	NoRef      SMALLINT NULL,
	Referencia NVARCHAR (30) NULL,
	Detalle    NVARCHAR (40) NULL,
	Deposito   MONEY NULL,
	Traspaso   BIT NOT NULL,
	Revisado   BIT NOT NULL,
	Cancelado  DATETIME NULL,
	Usuario    NVARCHAR (15) NULL,
	Fila       INT NOT NULL
	)
GO

CREATE CLUSTERED INDEX idxCuenta
	ON dbo.EdoCuenta (Cuenta)
GO

IF OBJECT_ID ('dbo.EdoCuentaEmp') IS NOT NULL
	DROP TABLE dbo.EdoCuentaEmp
GO

CREATE TABLE dbo.EdoCuentaEmp
	(
	Numero     NVARCHAR (15) NULL,
	Fecha      DATETIME NULL,
	Referencia NVARCHAR (20) NULL,
	Deposito   MONEY NULL,
	Cancelado  DATETIME NULL,
	Usuario    NVARCHAR (15) NULL,
	Folio      INT NOT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.EdoCuentaEmp (Numero)
GO

IF OBJECT_ID ('dbo.Empaques') IS NOT NULL
	DROP TABLE dbo.Empaques
GO

CREATE TABLE dbo.Empaques
	(
	Producto   NVARCHAR (15) NULL,
	Cantidad   MONEY NULL,
	Empaque    NVARCHAR (15) NULL,
	Disponible MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxProducto
	ON dbo.Empaques (Producto)
GO

IF OBJECT_ID ('dbo.Facturas') IS NOT NULL
	DROP TABLE dbo.Facturas
GO

CREATE TABLE dbo.Facturas
	(
	Numero           INT NOT NULL,
	Folio            INT NULL,
	Clave            NVARCHAR (10) NULL,
	Pedido           NVARCHAR (15) NULL,
	Empleado         NVARCHAR (15) NULL,
	Fecha            DATETIME NULL,
	FechaVence       DATETIME NULL,
	SubTotalIVA      MONEY NULL,
	SubTotalIEPS     MONEY NULL,
	SubTotal         MONEY NULL,
	IVA              MONEY NULL,
	IEPS             MONEY NULL,
	Costos           MONEY NULL,
	Saldo            MONEY NULL,
	Dolar            TINYINT NULL,
	TipoCambio       MONEY NULL,
	Cancelado        DATETIME NULL,
	Cancelo          NVARCHAR (15) NULL,
	NoRecibo         NVARCHAR (12) NULL,
	Lugar            NVARCHAR (40) NULL,
	Ruta             NVARCHAR (10) NULL,
	FechaVta         DATETIME NULL,
	Detalle          NVARCHAR (max) NULL,
	VtaMostrador     DATETIME NULL,
	Efecto           NVARCHAR (1) NULL,
	FechaCFD         DATETIME NULL,
	NoCertificado    NVARCHAR (20) NULL,
	Aprobacion       INT NULL,
	AnoAprobacion    NVARCHAR (4) NULL,
	FPago            NVARCHAR (2) NULL,
	MPago            NVARCHAR (3) NULL,
	UsoCFDI          NVARCHAR (3) NULL,
	TipoRel          NVARCHAR (2) NULL,
	Cadena           NVARCHAR (max) NULL,
	Sello            NVARCHAR (max) NULL,
	UUID             NVARCHAR (36) NULL,
	FechaTimbrado    NVARCHAR (20) NULL,
	RFCPAC           NVARCHAR (12) NULL,
	NoCertificadoSAT NVARCHAR (20) NULL,
	SelloSAT         NVARCHAR (max) NULL,
	NCredito         NVARCHAR (10) NULL,
	Credito          MONEY NULL,
	NInteres         NVARCHAR (10) NULL,
	Interes          MONEY NULL,
	NCargo           NVARCHAR (10) NULL,
	Cargo            MONEY NULL,
	Motivo           NVARCHAR (30) NULL
	)
GO

CREATE CLUSTERED INDEX idxFacturas
	ON dbo.Facturas (Numero, Folio, Clave)
GO

IF OBJECT_ID ('dbo.FechaContable') IS NOT NULL
	DROP TABLE dbo.FechaContable
GO

CREATE TABLE dbo.FechaContable
	(
	FechaContable DATETIME NULL,
	Contrasena    NVARCHAR (10) NULL
	)
GO

CREATE CLUSTERED INDEX idxFechaContable
	ON dbo.FechaContable (FechaContable)
GO

IF OBJECT_ID ('dbo.Gastos') IS NOT NULL
	DROP TABLE dbo.Gastos
GO

CREATE TABLE dbo.Gastos
	(
	Numero    INT NOT NULL,
	Area      SMALLINT NULL,
	SubTipoG  SMALLINT NULL,
	Concepto  NVARCHAR (50) NULL,
	Detalle   NVARCHAR (max) NULL,
	Eco       NVARCHAR (10) NULL,
	Proveedor NVARCHAR (15) NULL,
	Pedido    INT NULL,
	Nota      TINYINT NULL,
	NoNota    NVARCHAR (10) NULL,
	Empleado  NVARCHAR (15) NULL,
	CajaChica BIT NOT NULL,
	Deducible BIT NOT NULL,
	Fecha     DATETIME NULL,
	Vence     DATETIME NULL,
	SubTotal  MONEY NULL,
	IVA       MONEY NULL,
	IEPS      MONEY NULL,
	RetIVA    MONEY NULL,
	RetISR    MONEY NULL,
	Saldo     MONEY NULL,
	Dolar     TINYINT NULL,
	RefPago   NVARCHAR (30) NULL,
	Cancelado DATETIME NULL,
	Cancelo   NVARCHAR (15) NULL
	)
GO

CREATE CLUSTERED INDEX idxGastos
	ON dbo.Gastos (Numero, Area)
GO

IF OBJECT_ID ('dbo.GastosReparto') IS NOT NULL
	DROP TABLE dbo.GastosReparto
GO

CREATE TABLE dbo.GastosReparto
	(
	Reparto  INT NULL,
	Concepto SMALLINT NULL,
	Importe  MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxReparto
	ON dbo.GastosReparto (Reparto)
GO

IF OBJECT_ID ('dbo.Inspecciones') IS NOT NULL
	DROP TABLE dbo.Inspecciones
GO

CREATE TABLE dbo.Inspecciones
	(
	Folio       INT NOT NULL,
	Equipo      NVARCHAR (10) NULL,
	Inspector   NVARCHAR (15) NULL,
	FechaI      DATETIME NULL,
	Mecanico    TINYINT NULL,
	Hojalateria TINYINT NULL,
	Niveles     TINYINT NULL,
	Revision    NVARCHAR (max) NULL,
	Kms         MONEY NULL,
	Kms2        MONEY NULL,
	Litros      MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxInspecciones
	ON dbo.Inspecciones (Folio, Equipo, Inspector)
GO

IF OBJECT_ID ('dbo.InventarioMP') IS NOT NULL
	DROP TABLE dbo.InventarioMP
GO

CREATE TABLE dbo.InventarioMP
	(
	Semana SMALLINT NULL,
	Stock  MONEY NULL,
	Codigo NVARCHAR (15) NULL,
	Costo  MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxSemana
	ON dbo.InventarioMP (Semana, Codigo)
GO

IF OBJECT_ID ('dbo.Material') IS NOT NULL
	DROP TABLE dbo.Material
GO

CREATE TABLE dbo.Material
	(
	Folio         INT NULL,
	Material      NVARCHAR (15) NULL,
	Anticipo      MONEY NULL,
	CantidadM     MONEY NULL,
	Sobrante      MONEY NULL,
	FolioAnticipo INT NULL,
	Estimado      MONEY NULL,
	CostoMat      MONEY NULL,
	Item          SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxFolio
	ON dbo.Material (Folio)
GO

IF OBJECT_ID ('dbo.Nomina') IS NOT NULL
	DROP TABLE dbo.Nomina
GO

CREATE TABLE dbo.Nomina
	(
	Folio        INT NULL,
	Empleado     NVARCHAR (15) NULL,
	Fecha1       DATETIME NULL,
	Fecha2       DATETIME NULL,
	Fecha        DATETIME NULL,
	Comision     MONEY NULL,
	Faltante     MONEY NULL,
	Abono        MONEY NULL,
	Infonavit    MONEY NULL,
	Inasistencia MONEY NULL,
	Otros        MONEY NULL,
	Ahorro       MONEY NULL,
	OtrosA       MONEY NULL,
	Apoyo        MONEY NULL,
	Concepto     NVARCHAR (30) NULL,
	Siguiente    MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxFolio
	ON dbo.Nomina (Folio, Empleado)
GO

IF OBJECT_ID ('dbo.NoReferencia') IS NOT NULL
	DROP TABLE dbo.NoReferencia
GO

CREATE TABLE dbo.NoReferencia
	(
	NoRef      SMALLINT NOT NULL,
	Referencia NVARCHAR (30) NULL,
	Deposito   TINYINT NULL
	)
GO

CREATE CLUSTERED INDEX idxNoRef
	ON dbo.NoReferencia (NoRef)
GO

IF OBJECT_ID ('dbo.Notas') IS NOT NULL
	DROP TABLE dbo.Notas
GO

CREATE TABLE dbo.Notas
	(
	Numero       INT NOT NULL,
	Clave        NVARCHAR (10) NULL,
	Pedido       NVARCHAR (15) NULL,
	Empleado     NVARCHAR (15) NULL,
	Fecha        DATETIME NULL,
	FechaVence   DATETIME NULL,
	SubTotal     MONEY NULL,
	IVA          MONEY NULL,
	IEPS         MONEY NULL,
	Costos       MONEY NULL,
	Saldo        MONEY NULL,
	Dolar        TINYINT NULL,
	Cancelado    DATETIME NULL,
	Cancelo      NVARCHAR (15) NULL,
	Factura      INT NULL,
	bBot         BIT NOT NULL,
	VtaMostrador DATETIME NULL,
	Lugar        NVARCHAR (40) NULL,
	Ruta         NVARCHAR (10) NULL,
	FechaVta     DATETIME NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.Notas (Numero, Clave)
GO

IF OBJECT_ID ('dbo.Pagos') IS NOT NULL
	DROP TABLE dbo.Pagos
GO

CREATE TABLE dbo.Pagos
	(
	Numero     INT NULL,
	Cuenta     NVARCHAR (10) NULL,
	Referencia NVARCHAR (30) NULL,
	Usuario    NVARCHAR (15) NULL,
	Fecha      DATETIME NULL,
	IVAp       MONEY NULL,
	Pago       MONEY NULL,
	Tipo       TINYINT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.Pagos (Numero, Cuenta)
GO

IF OBJECT_ID ('dbo.PagosGastos') IS NOT NULL
	DROP TABLE dbo.PagosGastos
GO

CREATE TABLE dbo.PagosGastos
	(
	Numero     INT NULL,
	Cuenta     NVARCHAR (10) NULL,
	Referencia NVARCHAR (30) NULL,
	Usuario    NVARCHAR (15) NULL,
	Fecha      DATETIME NULL,
	IVAp       MONEY NULL,
	Pago       MONEY NULL,
	Tipo       TINYINT NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.PagosGastos (Numero, Cuenta)
GO

IF OBJECT_ID ('dbo.Pedidos') IS NOT NULL
	DROP TABLE dbo.Pedidos
GO

CREATE TABLE dbo.Pedidos
	(
	Numero     INT NOT NULL,
	Clave      NVARCHAR (15) NULL,
	Contacto   NVARCHAR (40) NULL,
	Cotizacion NVARCHAR (40) NULL,
	Gasto      INT NULL,
	Fecha      DATETIME NULL,
	SubTotal   MONEY NULL,
	IVA        MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxNumero
	ON dbo.Pedidos (Numero, Clave)
GO

IF OBJECT_ID ('dbo.Precios') IS NOT NULL
	DROP TABLE dbo.Precios
GO

CREATE TABLE dbo.Precios
	(
	Codigo NVARCHAR (15) NULL,
	Clave  NVARCHAR (15) NULL,
	Precio MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxCodigo
	ON dbo.Precios (Codigo, Clave)
GO

IF OBJECT_ID ('dbo.PreciosRuta') IS NOT NULL
	DROP TABLE dbo.PreciosRuta
GO

CREATE TABLE dbo.PreciosRuta
	(
	Codigo    NVARCHAR (15) NULL,
	Ruta      NVARCHAR (10) NULL,
	Lunes     MONEY NULL,
	Martes    MONEY NULL,
	Miercoles MONEY NULL,
	Jueves    MONEY NULL,
	Viernes   MONEY NULL,
	Sabado    MONEY NULL,
	Domingo   MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxCodigo
	ON dbo.PreciosRuta (Codigo, Ruta)
GO

IF OBJECT_ID ('dbo.Prestamos') IS NOT NULL
	DROP TABLE dbo.Prestamos
GO

CREATE TABLE dbo.Prestamos
	(
	Folio    INT NULL,
	Empleado NVARCHAR (15) NULL,
	Fecha    DATETIME NULL,
	NoPagos  SMALLINT NULL,
	Prestamo MONEY NULL,
	Acuenta  MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxFolio
	ON dbo.Prestamos (Folio, Empleado)
GO

IF OBJECT_ID ('dbo.Produccion') IS NOT NULL
	DROP TABLE dbo.Produccion
GO

CREATE TABLE dbo.Produccion
	(
	Folio       INT NULL,
	Empleado    NVARCHAR (15) NULL,
	Fecha       DATETIME NULL,
	Turno       TINYINT NULL,
	Hora        DATETIME NULL,
	CostosP     MONEY NULL,
	CostosM     MONEY NULL,
	Observacion NVARCHAR (100) NULL,
	Porcionado  BIT NOT NULL
	)
GO

CREATE CLUSTERED INDEX idxFolio
	ON dbo.Produccion (Folio, Empleado)
GO

IF OBJECT_ID ('dbo.Producto') IS NOT NULL
	DROP TABLE dbo.Producto
GO

CREATE TABLE dbo.Producto
	(
	Folio     INT NULL,
	Producto  NVARCHAR (15) NULL,
	CantidadP INT NULL,
	CostoPro  MONEY NULL,
	Item      SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxFolio
	ON dbo.Producto (Folio, Producto)
GO

IF OBJECT_ID ('dbo.Proveedores') IS NOT NULL
	DROP TABLE dbo.Proveedores
GO

CREATE TABLE dbo.Proveedores
	(
	Clave       NVARCHAR (15) NOT NULL,
	Nombre      NVARCHAR (80) NULL,
	RFC         NVARCHAR (20) NULL,
	Contacto1   NVARCHAR (40) NULL,
	Contacto2   NVARCHAR (40) NULL,
	Calle       NVARCHAR (70) NULL,
	Ciudad      NVARCHAR (70) NULL,
	Telefono    NVARCHAR (20) NULL,
	Telefono2   NVARCHAR (20) NULL,
	Celular     NVARCHAR (20) NULL,
	Fax         NVARCHAR (20) NULL,
	Email       NVARCHAR (50) NULL,
	CondPago    NVARCHAR (20) NULL,
	Banco       NVARCHAR (50) NULL,
	Observacion NVARCHAR (max) NULL
	)
GO

CREATE CLUSTERED INDEX idxClave
	ON dbo.Proveedores (Clave)
GO

IF OBJECT_ID ('dbo.Repartos') IS NOT NULL
	DROP TABLE dbo.Repartos
GO

CREATE TABLE dbo.Repartos
	(
	Reparto       INT NULL,
	Ruta          NVARCHAR (10) NULL,
	Repartidor    NVARCHAR (15) NULL,
	Eco           NVARCHAR (10) NULL,
	Fecha         DATETIME NULL,
	Hora          DATETIME NULL,
	HoraR         DATETIME NULL,
	HoraV         DATETIME NULL,
	CreditoPzas   SMALLINT NULL,
	VentaEfectivo MONEY NULL,
	Cobranza      MONEY NULL,
	Cajas         MONEY NULL,
	Gastos        MONEY NULL,
	FacturaC      MONEY NULL,
	PorCom        SMALLINT NULL,
	ComisionP     MONEY NULL,
	ComisionR     MONEY NULL,
	Diversos      MONEY NULL,
	Ahorro        MONEY NULL,
	Efectivo      MONEY NULL,
	Deposito      MONEY NULL,
	FechaEfe      DATETIME NULL,
	FechaCta      DATETIME NULL,
	TPR           SMALLINT NULL,
	Pago          INT NULL
	)
GO

CREATE CLUSTERED INDEX idxReparto
	ON dbo.Repartos (Reparto, Ruta, Repartidor, Eco)
GO

IF OBJECT_ID ('dbo.Requerido') IS NOT NULL
	DROP TABLE dbo.Requerido
GO

CREATE TABLE dbo.Requerido
	(
	CantidadR INT NULL,
	ProductoR NVARCHAR (15) NULL,
	DivisorR  MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxCantidadR
	ON dbo.Requerido (CantidadR)
GO

IF OBJECT_ID ('dbo.SubProductos') IS NOT NULL
	DROP TABLE dbo.SubProductos
GO

CREATE TABLE dbo.SubProductos
	(
	Producto    NVARCHAR (15) NOT NULL,
	SubProducto NVARCHAR (25) NULL
	)
GO

CREATE CLUSTERED INDEX idxProducto
	ON dbo.SubProductos (Producto)
GO

IF OBJECT_ID ('dbo.SubTipos') IS NOT NULL
	DROP TABLE dbo.SubTipos
GO

CREATE TABLE dbo.SubTipos
	(
	SubTipo    SMALLINT NULL,
	DetalleSub NVARCHAR (30) NULL,
	Fijo       BIT NOT NULL,
	Tipo       SMALLINT NULL
	)
GO

CREATE CLUSTERED INDEX idxSubTipo
	ON dbo.SubTipos (SubTipo)
GO

IF OBJECT_ID ('dbo.TiposGastos') IS NOT NULL
	DROP TABLE dbo.TiposGastos
GO

CREATE TABLE dbo.TiposGastos
	(
	Tipo        SMALLINT NULL,
	DetalleTipo NVARCHAR (30) NULL
	)
GO

CREATE CLUSTERED INDEX idxTipo
	ON dbo.TiposGastos (Tipo)
GO

IF OBJECT_ID ('dbo.TiposPorArea') IS NOT NULL
	DROP TABLE dbo.TiposPorArea
GO

CREATE TABLE dbo.TiposPorArea
	(
	Area SMALLINT NOT NULL,
	Tipo SMALLINT NOT NULL
	)
GO

CREATE CLUSTERED INDEX idxArea
	ON dbo.TiposPorArea (Area)
GO

IF OBJECT_ID ('dbo.Utilidades') IS NOT NULL
	DROP TABLE dbo.Utilidades
GO

CREATE TABLE dbo.Utilidades
	(
	Semana        SMALLINT NULL,
	Fecha1        DATETIME NULL,
	Fecha2        DATETIME NULL,
	Inventario    MONEY NULL,
	Bancos        MONEY NULL,
	CobranzaF     MONEY NULL,
	CobranzaN     MONEY NULL,
	DeudasC       MONEY NULL,
	DeudasG       MONEY NULL,
	SaldoAnterior MONEY NULL,
	Efectivo      MONEY NULL,
	Depositos     MONEY NULL,
	Facturas      MONEY NULL,
	Notas         MONEY NULL,
	Compras       MONEY NULL,
	Gastos        MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxSemana
	ON dbo.Utilidades (Semana)
GO

IF OBJECT_ID ('dbo.ValorUSD') IS NOT NULL
	DROP TABLE dbo.ValorUSD
GO

CREATE TABLE dbo.ValorUSD
	(
	FechaUSD DATETIME NULL,
	USD      MONEY NULL
	)
GO

CREATE CLUSTERED INDEX idxFechaUSD
	ON dbo.ValorUSD (FechaUSD)
GO
