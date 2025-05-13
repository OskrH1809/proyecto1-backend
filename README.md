# 📦 Configuración

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/proyecto1-backend.git
   cd proyecto1-backend
   ```

2. Asegúrate de tener instalado el CLI de Entity Framework Core:

   ```bash
   dotnet tool install --global dotnet-ef
   ```

3. Ajusta la cadena de conexión en `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=proyecto1db;Username=postgres;Password=tu_password"
   }
   ```

4. La migración ya está incluida en el repositorio, solo inicia el proyecto:

   En Visual Studio:

   ```
   Ejecutar Proyecto1.API
   ```

   O desde terminal:

   ```bash
   dotnet run --project Proyecto1.API
   ```

   ✅ Las tablas de la base de datos se crearán automáticamente al iniciar.

# 📥 Cargar datos de prueba (opcional)

Si quieres poblar la base de datos con autores y libros de ejemplo, ejecuta este script:

**Archivo:** `SAMPLE_DATA.sql`

## Ejecuta el script:

### En PgAdmin:

1. Abre tu base de datos `proyecto1db`.
2. Usa la herramienta **Query Tool**.
3. Ejecuta el script `SAMPLE_DATA.sql`.

  Con esto, tu base de datos estará llena de datos de prueba listos para usar.




# 🔐 Autenticación

Para obtener un token, usa el endpoint:

```
POST /api/auth/login
```

Body:

```json
{
  "username": "admin",
  "password": "1234"
}
```

# 📚 Endpoints principales

## Autores

* `GET /api/autores`
* `GET /api/autores/{id}`
* `POST /api/autores`
* `PUT /api/autores/{id}`
* `DELETE /api/autores/{id}`

## Libros

* `GET /api/libros`
* `GET /api/libros/{id}`
* `POST /api/libros`
* `PUT /api/libros/{id}`
* `DELETE /api/libros/{id}`

# 🌐 Uso con Swagger

1. Levanta la aplicación.
2. Navega a:

   ```
   https://localhost:{puerto}/swagger/index.html
   ```
3. Prueba los endpoints directamente desde la interfaz.
