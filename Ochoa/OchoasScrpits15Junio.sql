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

IF OBJECT_ID ('dbo.AreaTrabajo') IS NOT NULL
	DROP TABLE dbo.AreaTrabajo
GO

CREATE TABLE dbo.AreaTrabajo
	(
	idEmpresa INT IDENTITY NOT NULL,
	Nombre    VARCHAR (50) NOT NULL,
	Calle     VARCHAR (30) NULL,
	Colonia   VARCHAR (30) NULL,
	CP        VARCHAR (10) NULL,
	Estado    VARCHAR (20) NULL,
	Ciudad    VARCHAR (20) NULL,
	Numero    VARCHAR (10) NULL,
	Telefono  VARCHAR (15) NULL,
	Telefono2 VARCHAR (15) NULL,
	Encargado VARCHAR (30) NULL,
	PRIMARY KEY (Nombre),
	UNIQUE (Nombre)
	)
GO

IF OBJECT_ID ('dbo.CfgAreaTrabajo') IS NOT NULL
	DROP TABLE dbo.CfgAreaTrabajo
GO

CREATE TABLE dbo.CfgAreaTrabajo
	(
	idCfg    INT IDENTITY NOT NULL,
	IVA      DECIMAL (5, 3) NOT NULL,
	IEPS     DECIMAL (5, 3) NOT NULL,
	Credito  DECIMAL (8, 2) NOT NULL,
	Copias   INT NOT NULL,
	FacRows  INT NOT NULL,
	NotRows  INT NOT NULL,
	StockPos INT NOT NULL,
	Eliminar INT NOT NULL,
	LUSD     INT NOT NULL,
	EBajo    VARCHAR (15) NOT NULL,
	EMedio   VARCHAR (15) NOT NULL,
	ENormal  VARCHAR (15) NOT NULL
	)
GO
INSERT INTO dbo.CfgAreaTrabajo (IVA, IEPS, Credito, Copias, FacRows, NotRows, StockPos, Eliminar, LUSD, EBajo, EMedio, ENormal)
VALUES (20, 30, 5, 1, 23, 33, 0, 0, 1, 'Bajisimo', 'Medio', 'Normalisimo')
GO

INSERT INTO dbo.AreaTrabajo (Nombre, Calle, Colonia, CP, Estado, Ciudad, Numero, Telefono, Telefono2, Encargado)
VALUES ('Tortillas Ochoa', 'Los Pinos', 'Gerneral González', '58114', 'Michoacán', 'Morelia', '256', '4425696885', '4485632545', 'Mario Juarez')
GO



TRUNCATE TABLE	AccesoFunciones;
TRUNCATE TABLE PerfilFunciones;

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (1, 'F000000001', 'Principal', 'PGN', 1, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (2, 'F000000002', 'Archivo', 'PGN', 2, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (3, 'F000000003', 'Almacén', 'PGN', 3, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (4, 'F000000004', 'Producción', 'PGN', 4, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (5, 'F000000005', 'Clientes', 'PGN', 5, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (6, 'F000000006', 'Empleados', 'PGN', 6, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (7, 'F000000007', 'Equipos', 'PGN', 7, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (8, 'F000000008', 'Reparto', 'PGN', 8, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (9, 'F000000009', 'Proveedores', 'PGN', 9, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (10, 'F000000010', 'Reportes', 'PGN', 10, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (11, 'F000000011', 'Configuración', 'PGN', 11, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (12, 'F000000012', 'Ventana', 'PGN', 12, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (13, 'F000000013', 'Ayuda', 'PGN', 13, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (20, 'F000000020', 'Principal', 'GRP', 1, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (21, 'F000000021', 'Archivo', 'GRP', 2, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (22, 'F000000022', 'Almacén', 'GRP', 3, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (23, 'F000000023', 'Producción', 'GRP', 4, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (24, 'F000000024', 'Clientes', 'GRP', 5, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (25, 'F000000025', 'Empleados', 'GRP', 6, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (26, 'F000000026', 'Equipos', 'GRP', 7, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (27, 'F000000027', 'Reparto', 'GRP', 8, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (28, 'F000000028', 'Proveedores', 'GRP', 9, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (29, 'F000000029', 'Reportes', 'GRP', 10, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (30, 'F000000030', 'Configuración', 'GRP', 11, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (31, 'F000000031', 'Ventana', 'GRP', 12, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (32, 'F000000032', 'Ayuda', 'GRP', 13, 0, NULL)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (40, 'F000000040', 'Configurar impresora', 'FUN', 1, 0, 1)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (41, 'F000000041', 'Imprimir', 'FUN', 2, 1, 2)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (42, 'F000000042', 'Salir', 'FUN', 3, 1, 3)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (43, 'F000000043', 'Artículo', 'FUN', 4, 0, 4)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (44, 'F000000044', 'Consulta del inventario', 'FUN', 5, 0, 5)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (45, 'F000000045', 'Productos con caducidad', 'FUN', 6, 0, 6)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (46, 'F000000046', 'Movimientos del almacén', 'FUN', 7, 1, 7)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (47, 'F000000047', 'Movimientos por artículo', 'FUN', 8, 0, 8)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (48, 'F000000048', 'Salidas', 'FUN', 9, 1, 9)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (49, 'F000000049', 'Devoluciones', 'FUN', 10, 0, 10)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (50, 'F000000050', 'Reporte del inventario', 'FUN', 11, 1, 11)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (51, 'F000000051', 'Actualizar el inventario', 'FUN', 12, 0, 12)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (52, 'F000000052', 'Lista de precios', 'FUN', 13, 1, 13)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (53, 'F000000053', 'Materia prima', 'FUN', 14, 0, 14)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (54, 'F000000054', 'Material requerido', 'FUN', 15, 1, 15)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (55, 'F000000055', 'Producción estimada', 'FUN', 16, 0, 16)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (56, 'F000000056', 'Reporte de producción', 'FUN', 17, 1, 17)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (57, 'F000000057', 'Lista de reporte de producción', 'FUN', 18, 0, 18)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (58, 'F000000058', 'Salida de material', 'FUN', 19, 1, 19)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (59, 'F000000059', 'Lista de salidas de material', 'FUN', 20, 0, 20)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (60, 'F000000060', 'Datos del cliente', 'FUN', 21, 0, 21)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (61, 'F000000061', 'Directorio de clientes', 'FUN', 22, 0, 22)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (62, 'F000000062', 'Precios por cliente', 'FUN', 23, 1, 23)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (63, 'F000000063', 'Cotización', 'FUN', 24, 1, 24)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (64, 'F000000064', 'Lista de cotizaciones', 'FUN', 25, 0, 25)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (65, 'F000000065', 'Factura', 'FUN', 26, 1, 26)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (66, 'F000000066', 'Lista de facturas', 'FUN', 27, 0, 27)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (67, 'F000000067', 'Lista de facturas con UUID', 'FUN', 28, 0, 28)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (68, 'F000000068', 'Empleados', 'FUN', 29, 0, 29)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (69, 'F000000069', 'Directorio de empleados', 'FUN', 30, 0, 30)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (70, 'F000000070', 'Bajas de empleados', 'FUN', 31, 0, 31)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (71, 'F000000071', 'Estado de cuenta del empleado', 'FUN', 32, 1, 32)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (72, 'F000000072', 'Comisión por empleado', 'FUN', 33, 1, 33)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (73, 'F000000073', 'Listado de comisiones', 'FUN', 34, 0, 34)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (74, 'F000000074', 'Control de préstamos', 'FUN', 35, 1, 35)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (75, 'F000000075', 'Alta de un equipo', 'FUN', 36, 0, 36)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (76, 'F000000076', 'Catálogo de equipos', 'FUN', 37, 0, 37)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (77, 'F000000077', 'Inspección', 'FUN', 38, 1, 38)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (78, 'F000000078', 'Lista de inspecciones', 'FUN', 39, 0, 39)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (79, 'F000000079', 'Rendimientos de equipos', 'FUN', 40, 1, 40)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (80, 'F000000080', 'Definición de una ruta', 'FUN', 41, 0, 41)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (81, 'F000000081', 'Entregas por día', 'FUN', 42, 0, 42)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (82, 'F000000082', 'Precios por ruta', 'FUN', 43, 0, 43)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (83, 'F000000083', 'Catálogo de rutas', 'FUN', 44, 0, 44)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (84, 'F000000084', 'Salida a reparto', 'FUN', 45, 1, 45)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (85, 'F000000085', 'Recarga de', 'FUN', 46, 0, 46)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (86, 'F000000086', 'Reporte de venta', 'FUN', 47, 0, 47)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (87, 'F000000087', 'Lista de reportes de venta', 'FUN', 48, 0, 48)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (88, 'F000000088', 'Venta créditos por reparto', 'FUN', 49, 1, 49)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (89, 'F000000089', 'Detalle ventas créditos por reparto', 'FUN', 50, 0, 50)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (90, 'F000000090', 'Concentrado detalle de la venta', 'FUN', 51, 0, 51)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (91, 'F000000091', 'Depósitos por reparto', 'FUN', 52, 1, 52)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (92, 'F000000092', 'Cobros por ruta', 'FUN', 53, 0, 53)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (93, 'F000000093', 'Gastos por reparto', 'FUN', 54, 0, 54)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (94, 'F000000094', 'Datos del proveedor', 'FUN', 55, 0, 55)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (95, 'F000000095', 'Directorio de proveedores', 'FUN', 56, 0, 56)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (96, 'F000000096', 'Pedido', 'FUN', 57, 1, 57)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (97, 'F000000097', 'Lista de pedidos', 'FUN', 58, 0, 58)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (98, 'F000000098', 'Pedidos pendientes', 'FUN', 59, 0, 59)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (99, 'F000000099', 'Compra', 'FUN', 60, 1, 60)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (100, 'F000000100', 'Lista de compras', 'FUN', 61, 0, 61)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (101, 'F000000101', 'Captura de gastos', 'FUN', 62, 1, 62)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (102, 'F000000102', 'Lista de gastos caja chica', 'FUN', 63, 0, 63)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (103, 'F000000103', 'Lista de gastos y pagos', 'FUN', 64, 0, 64)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (104, 'F000000104', 'Reporte de ventas por día de la semana', 'FUN', 65, 0, 65)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (105, 'F000000105', 'Concentrado de ventas por semana', 'FUN', 66, 0, 66)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (106, 'F000000106', 'Concentrado de ventas por fechas', 'FUN', 67, 0, 67)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (107, 'F000000107', 'Repartos', 'FUN', 68, 1, 68)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (108, 'F000000108', 'Facturas-Notas por artículo', 'FUN', 69, 1, 69)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (109, 'F000000109', 'Reporte IEPS por cliente', 'FUN', 70, 0, 70)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (110, 'F000000110', 'Reporte IEPS por cliente-producto', 'FUN', 71, 0, 71)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (111, 'F000000111', 'Compras por artículo', 'FUN', 72, 0, 72)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (112, 'F000000112', 'Clientes y proveedores', 'FUN', 73, 1, 73)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (113, 'F000000113', 'Estado de cuenta del proveedor', 'FUN', 74, 0, 74)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (114, 'F000000114', 'Reporte saldo de proveedores', 'FUN', 75, 0, 75)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (115, 'F000000115', 'Detalle de cobros', 'FUN', 76, 1, 76)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (116, 'F000000116', 'Lista complementos pago', 'FUN', 77, 0, 77)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (117, 'F000000117', 'Reporte de facturas e ingresos', 'FUN', 78, 0, 78)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (118, 'F000000118', 'Detalle de pagos', 'FUN', 79, 1, 79)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (119, 'F000000119', 'Concentrado de pagos por semana', 'FUN', 80, 0, 80)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (120, 'F000000120', 'Concentrado de pagos por mes', 'FUN', 81, 0, 81)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (121, 'F000000121', 'Concentrado de pagos por fechas', 'FUN', 82, 0, 82)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (122, 'F000000122', 'Lista de gastos por tipo', 'FUN', 83, 1, 83)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (123, 'F000000123', 'Reporte de producción por día de la semana', 'FUN', 84, 1, 84)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (124, 'F000000124', 'Concentrado producción por semana', 'FUN', 85, 0, 85)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (125, 'F000000125', 'Concentrado producción entre fechas', 'FUN', 86, 0, 86)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (126, 'F000000126', 'Reporte de cargas y producción', 'FUN', 87, 0, 87)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (127, 'F000000127', 'Reporte costo de producción', 'FUN', 88, 0, 88)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (128, 'F000000128', 'Sobrante de material de producción', 'FUN', 89, 0, 89)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (129, 'F000000129', 'Costo del inventario', 'FUN', 90, 1, 90)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (130, 'F000000130', 'Reporte costo del inventario', 'FUN', 91, 0, 91)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (131, 'F000000131', 'Área de trabajo', 'FUN', 92, 0, 92)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (132, 'F000000132', 'Datos CFDI', 'FUN', 93, 0, 93)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (133, 'F000000133', 'Editor de menús', 'FUN', 94, 0, 94)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (134, 'F000000134', 'Candado fecha contable', 'FUN', 95, 0, 95)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (135, 'F000000135', 'USD', 'FUN', 96, 0, 96)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (136, 'F000000136', 'Categorías y tipos', 'FUN', 97, 1, 97)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (137, 'F000000137', 'Orden del inventario', 'FUN', 98, 0, 98)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (138, 'F000000138', 'Caducidad por productos', 'FUN', 99, 0, 99)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (139, 'F000000139', 'Definir subproductos', 'FUN', 100, 0, 100)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (140, 'F000000140', 'Control de cajas', 'FUN', 101, 0, 101)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (141, 'F000000141', 'Áreas', 'FUN', 102, 1, 102)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (142, 'F000000142', 'Tipos de gastos', 'FUN', 103, 0, 103)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (143, 'F000000143', 'Tipos de gastos por área', 'FUN', 104, 0, 104)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (144, 'F000000144', 'Contraseñas de empleados', 'FUN', 105, 0, 105)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (145, 'F000000145', 'Tabla de comisiones', 'FUN', 106, 0, 106)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (146, 'F000000146', 'Marcas y tipos de equipos', 'FUN', 107, 0, 107)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (147, 'F000000147', 'Datos del correo emisor', 'FUN', 108, 1, 108)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (148, 'F000000148', 'Definir tablas de impresión', 'FUN', 109, 1, 109)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (149, 'F000000149', 'Definir facturas', 'FUN', 110, 0, 110)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (150, 'F000000150', 'Restablecer almacén', 'FUN', 111, 1, 111)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (151, 'F000000151', 'Editor', 'FUN', 112, 0, 112)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (152, 'F000000152', 'Perfiles', 'FUN', 113, 0, 113)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (153, 'F000000153', 'Cascada', 'FUN', 114, 0, 114)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (154, 'F000000154', 'Mosaico horizontal', 'FUN', 115, 0, 115)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (155, 'F000000155', 'Mosaico vertical', 'FUN', 116, 0, 116)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (156, 'F000000156', 'Ayuda', 'FUN', 117, 0, 117)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (157, 'F000000157', 'Acerca de', 'FUN', 118, 0, 118)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (158, 'F000000158', 'Exportar a Excel', 'FUN', 119, 1, 119)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (159, 'F000000159', 'Exportar a Word', 'FUN', 120, 0, 120)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (160, 'F000000160', 'Exportar a PDF', 'FUN', 121, 0, 121)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (161, 'F000000161', 'Copiar al Portapapeles', 'FUN', 122, 0, 122)
GO

INSERT INTO dbo.AccesoFunciones (idFuncion, Funcion, Descripcion, Tipo, Orden, BeginGroup, Imagen)
VALUES (162, 'F000000162', 'Puestos de trabajo', 'FUN', 103, 0, 123)
GO


INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (2, 0, 2, 0, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (3, 0, 3, 0, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (4, 0, 4, 0, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (5, 0, 5, 0, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (6, 0, 6, 0, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (7, 0, 7, 0, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (8, 0, 8, 0, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (9, 0, 9, 0, 9, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (10, 0, 10, 0, 10, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (11, 0, 11, 0, 11, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (12, 0, 12, 0, 12, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (13, 0, 13, 0, 13, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (14, 0, 20, 1, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (15, 0, 21, 2, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (16, 0, 22, 3, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (17, 0, 23, 4, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (18, 0, 24, 5, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (19, 0, 25, 6, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (20, 0, 26, 7, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (21, 0, 27, 8, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (22, 0, 28, 9, 9, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (23, 0, 29, 10, 10, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (24, 0, 30, 11, 11, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (25, 0, 31, 12, 12, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (26, 0, 32, 13, 13, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (27, 0, 44, 20, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (28, 0, 46, 20, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (29, 0, 56, 20, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (30, 0, 57, 20, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (31, 0, 58, 20, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (32, 0, 59, 20, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (33, 0, 61, 20, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (34, 0, 63, 20, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (35, 0, 64, 20, 9, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (36, 0, 65, 20, 10, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (37, 0, 66, 20, 11, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (38, 0, 84, 20, 12, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (39, 0, 85, 20, 13, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (40, 0, 86, 20, 14, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (41, 0, 88, 20, 15, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (42, 0, 89, 20, 16, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (43, 0, 95, 20, 17, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (44, 0, 96, 20, 18, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (45, 0, 97, 20, 19, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (46, 0, 99, 20, 20, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (47, 0, 100, 20, 21, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (48, 0, 156, 20, 22, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (49, 0, 40, 21, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (50, 0, 41, 21, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (51, 0, 42, 21, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (52, 0, 43, 22, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (53, 0, 44, 22, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (54, 0, 45, 22, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (55, 0, 46, 22, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (56, 0, 47, 22, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (57, 0, 48, 22, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (58, 0, 49, 22, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (59, 0, 50, 22, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (60, 0, 51, 22, 9, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (61, 0, 52, 22, 10, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (62, 0, 53, 23, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (63, 0, 54, 23, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (64, 0, 55, 23, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (65, 0, 56, 23, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (66, 0, 57, 23, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (67, 0, 58, 23, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (68, 0, 59, 23, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (69, 0, 60, 24, 1, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (70, 0, 61, 24, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (71, 0, 62, 24, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (72, 0, 63, 24, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (73, 0, 64, 24, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (74, 0, 65, 24, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (75, 0, 66, 24, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (76, 0, 67, 24, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (77, 0, 68, 25, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (78, 0, 69, 25, 2, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (79, 0, 70, 25, 3, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (80, 0, 71, 25, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (81, 0, 72, 25, 5, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (82, 0, 73, 25, 6, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (83, 0, 74, 25, 7, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (84, 0, 75, 26, 1, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (85, 0, 76, 26, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (86, 0, 77, 26, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (87, 0, 78, 26, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (88, 0, 79, 26, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (89, 0, 80, 27, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (90, 0, 81, 27, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (91, 0, 82, 27, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (92, 0, 83, 27, 4, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (93, 0, 84, 27, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (94, 0, 85, 27, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (95, 0, 86, 27, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (96, 0, 87, 27, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (97, 0, 88, 27, 9, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (98, 0, 89, 27, 10, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (99, 0, 90, 27, 11, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (100, 0, 91, 27, 12, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (101, 0, 92, 27, 13, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (102, 0, 93, 27, 14, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (103, 0, 94, 28, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (104, 0, 95, 28, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (105, 0, 96, 28, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (106, 0, 97, 28, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (107, 0, 98, 28, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (108, 0, 99, 28, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (109, 0, 100, 28, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (110, 0, 101, 28, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (111, 0, 102, 28, 9, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (112, 0, 103, 28, 10, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (113, 0, 104, 29, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (114, 0, 105, 29, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (115, 0, 106, 29, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (116, 0, 107, 29, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (117, 0, 108, 29, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (118, 0, 109, 29, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (119, 0, 110, 29, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (120, 0, 111, 29, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (121, 0, 112, 29, 9, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (122, 0, 113, 29, 10, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (123, 0, 114, 29, 11, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (124, 0, 115, 29, 12, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (125, 0, 116, 29, 13, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (126, 0, 117, 29, 14, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (127, 0, 118, 29, 15, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (128, 0, 119, 29, 16, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (129, 0, 120, 29, 17, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (130, 0, 121, 29, 18, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (131, 0, 122, 29, 19, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (132, 0, 123, 29, 20, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (133, 0, 124, 29, 21, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (134, 0, 125, 29, 22, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (135, 0, 126, 29, 23, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (136, 0, 127, 29, 24, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (137, 0, 128, 29, 25, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (138, 0, 129, 29, 26, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (139, 0, 130, 29, 27, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (140, 0, 131, 30, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (141, 0, 132, 30, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (142, 0, 133, 30, 3, 0, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (143, 0, 134, 30, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (144, 0, 135, 30, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (145, 0, 136, 30, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (146, 0, 137, 30, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (147, 0, 138, 30, 8, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (148, 0, 139, 30, 9, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (149, 0, 140, 30, 10, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (150, 0, 141, 30, 11, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (151, 0, 142, 30, 12, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (152, 0, 143, 30, 13, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (153, 0, 144, 30, 14, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (154, 0, 145, 30, 15, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (155, 0, 146, 30, 16, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (156, 0, 147, 30, 17, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (157, 0, 148, 30, 18, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (158, 0, 149, 30, 19, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (159, 0, 150, 30, 20, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (160, 0, 151, 30, 21, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (161, 0, 152, 30, 22, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (162, 0, 153, 31, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (163, 0, 154, 31, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (164, 0, 155, 31, 3, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (165, 0, 156, 32, 1, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (166, 0, 157, 32, 2, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (167, 0, 158, 31, 4, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (168, 0, 159, 31, 5, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (169, 0, 160, 31, 6, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (170, 0, 161, 31, 7, 1, 1, 1, 1, 1, 1)
GO

INSERT INTO dbo.PerfilFunciones (idPerfilFunciones, idPerfil, idFuncion, GrupoPadre, Orden, Visible, Activo, Lectura, Escritura, Modificacion, Eliminar)
VALUES (171, 0, 162, 30, 11, 1, 1, 1, 1, 1, 1)
GO
