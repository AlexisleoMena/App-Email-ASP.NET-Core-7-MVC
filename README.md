# AppEmail

Esta es una aplicación sencilla de inicio de sesión construida con ASP.NET Core 6.

## Capturas de Pantalla

Aquí tienes algunas capturas de pantalla de la aplicación:

**Inicio de Sesión:**
![Login](https://i.ibb.co/rbZQGLr/Login.jpg)

**Registro:**
![Register](https://i.ibb.co/kHZQFS2/Register.jpg)

**Home:**
![Home](https://i.ibb.co/VmvyJ85/Home.jpg)

## Cómo Iniciar la Aplicación
Sigue estos pasos para iniciar la aplicación en tu entorno local:

1. **Configuración de la Base de Datos:**

  Crea una base de datos de SQL Server utilizando el archivo `SQLQuery.sql` proporcionado en el repositorio. El contenido del archivo es el siguiente:

  ```sql
  CREATE DATABASE DBEmail;
  GO

  USE DBEmail;
  GO

  CREATE TABLE [User] (
      Id int primary key identity(1,1),
      Name varchar(50),
      Email varchar(50),
      Password varchar(100)
  );
  GO
  ```
  Ejecuta este script en tu instancia de SQL Server para crear la base de datos y la tabla necesarias.

2. **Configura la Cadena de Conexión:**

  En el archivo `appsettings.json`, asegúrate de que la cadena de conexión en la sección `"ConnectionStrings"` coincida con la configuración de tu base de datos SQL Server:
  ```json
  "ConnectionStrings": {
    "StringSQL": "Tu_CadenaSQL"
  }
  ```

3. **Ejecuta la Aplicación:**
  Ejecuta la aplicación y abre tu navegador en http://localhost:5123 para acceder a la aplicación.

