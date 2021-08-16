# ProspectosUI

# Software utilizado 

# Visual Studio Community 2019                https://visualstudio.microsoft.com/es/vs/    

# Microsoft SQLServer 2019 Express            https://www.microsoft.com/es-mx/download/details.aspx?id=101064

# Script de base de datos 

Create database Prospectos

Create table prospecto 
(
	Id bigint not null,
	Nombre varchar(80) not null,
	ApellidoPaterno varchar(80) not null,
	ApellidoMaterno varchar(80) null,
	Rfc varchar(13) not null,
	Estatus varchar(30) not null,
	Observaciones varchar(300) null,
	CONSTRAINT PK_Id Primary Key (Id)
)

Create table datosDeContacto
(
	Prospecto bigint not null,
	Calle varchar(50) not null,
	Numero varchar(10) not null,
	Colonia varchar(50) not null,
	CodigoPostal varchar(5) not null,
	Telefono varchar(10) not null,
	CONSTRAINT PK_Prospecto Primary Key (Prospecto),
	CONSTRAINT FK_Prospecto Foreign Key (Prospecto) References prospecto (Id)
	ON UPDATE CASCADE 
	ON DELETE CASCADE 
)

Create table documentos
(
	Id int not null,
	Nombre varchar(50) not null,
	Archivo varchar(255) not null,
	Mime varchar(50) null,
	Prospecto bigint not null,
	CONSTRAINT PK_Id_Prospecto_Doc Primary Key (Id),
	CONSTRAINT FK_Prospecto_Doc Foreign Key (Prospecto) References prospecto (Id)
	ON UPDATE CASCADE 
	ON DELETE CASCADE 
)
