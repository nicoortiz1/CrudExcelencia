# CrudExcelencia

CrudExcelencia es una aplicación web basada en **ASP.NET MVC** diseñada para administrar registros de pacientes. La aplicación permite realizar operaciones CRUD (crear, leer, actualizar y eliminar) sobre pacientes y utiliza **MySQL** como sistema de gestión de base de datos.

---

## Tabla de Contenidos

- [Descripción](#descripción)
- [Características](#características)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Requisitos](#requisitos)
- [Instalación](#instalación)
- [Uso](#uso)
- [Problemas Conocidos](#problemas-conocidos)
- [Contribuciones](#contribuciones)
- [Licencia](#licencia)
- [Contacto](#contacto)

---

## Descripción

CrudExcelencia es una aplicación CRUD desarrollada en **ASP.NET MVC** con el objetivo de gestionar información de pacientes. Permite a los usuarios crear, editar, listar y eliminar registros de pacientes de forma sencilla y con una interfaz amigable y responsiva. El modelo de datos incluye campos como **Nombre**, **Apellido**, **DNI**, **Fecha de Nacimiento**, **Teléfono**, **Email** y **Dirección**.

---

## Características

- **Crear Paciente:** Agrega nuevos registros con validación de campos.
- **Listar Pacientes:** Muestra la lista de pacientes registrados con opciones para editar o eliminar.
- **Editar Paciente:** Permite actualizar la información de un paciente existente.
- **Eliminar Paciente:** Confirma y elimina el registro de un paciente.
- **Interfaz Responsiva:** Basada en Bootstrap, se adapta a diferentes dispositivos.
- **Validación de Datos:** Uso de atributos de datos en el modelo para asegurar la integridad de la información.

---

## Tecnologías Utilizadas

- **Backend:** ASP.NET MVC, C#
- **Frontend:** HTML, CSS, Bootstrap, Razor Views
- **Base de Datos:** MySQL
- **Gestión de Paquetes:** NuGet (incluye paquetes como EntityFramework y Microsoft.CodeDom.Providers.DotNetCompilerPlatform)

---

## Requisitos

- **Visual Studio 2019** o superior (o Visual Studio Code)
- **.NET Framework 4.8** o superior
- **MySQL Server**
- **NuGet Package Manager**

---

## Instalación

### 1. Clonar el Repositorio

https://github.com/nicoortiz1/CrudExcelencia.git

### 2. Crear la base de datos

En la carpeta Docs se encuentra el script para la creacion de la base de datos

## Configurar la Conexión a la Base de Datos

### En el archivo web.config, actualiza la cadena de conexión en la sección <connectionStrings>:

<connectionStrings>
    <add name="DefaultConnection" 
         connectionString="server=localhost;port=3306;database=excelenciabd;uid=tu_usuario;password=tu_contraseña;" 
         providerName="MySql.Data.MySqlClient" />
</connectionStrings>

### Restaurar Paquetes NuGet
Abre la solución en Visual Studio y restaura los paquetes NuGet necesarios:

Haz clic derecho en la solución y selecciona "Restaurar paquetes NuGet"

### Compilar y Ejecutar
Compila la solución y ejecuta el proyecto desde Visual Studio.

---

## Uso

Página Principal: Accede a la lista de pacientes registrados.
Crear Paciente: Haz clic en el botón "Crear nuevo" para agregar un paciente.
Editar Paciente: Selecciona "Editar" en el registro correspondiente para actualizar la información.
Eliminar Paciente: Selecciona "Eliminar" y confirma la acción para remover el registro.

---

## Problemas Conocidos

Configuración del CodeDom:
  Si aparece un error relacionado con Microsoft.CodeDom.Providers.DotNetCompilerPlatform, verifica que el paquete esté instalado y actualizado.
Cadena de Conexión:
  Asegúrate de que la cadena de conexión en el web.config esté correctamente configurada según tu entorno de MySQL.

