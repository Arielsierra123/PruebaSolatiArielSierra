# PruebaSolatiArielSierra
**Descripción**
Este proyecto es una aplicación que utiliza PostgreSQL como base de datos y Entity Framework Core para la gestión de datos.

**Prerrequisitos**
Antes de empezar, asegúrate de tener lo siguiente instalado:

.NET SDK (versión compatible con el proyecto).
PostgreSQL (deberás tener un servidor PostgreSQL en funcionamiento).
Npgsql (proporciona el proveedor de datos de PostgreSQL para .NET).

**Creacion de base de datos**
Al iniciar la aplicación, se aplicarán automáticamente todas las migraciones pendientes a la base de datos. Esto significa que la estructura de la base de datos se actualizará para coincidir con los últimos cambios definidos en las migraciones sin necesidad de ejecutar manualmente los comandos de migración.
