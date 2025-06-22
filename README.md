# Microservicios para tienda online

Este proyecto implementa una tienda online utilizando una arquitectura de microservicios desarrollada en .NET 8. Cada microservicio es responsable de una funcionalidad específica y cuenta con su propia base de datos MySQL. El despliegue y la orquestación de los servicios se realiza mediante Docker Compose.

## Microservicios

- **UsuariosService**: Gestión de usuarios y autenticación.
- **ProductosService**: Administración de productos.
- **CarritoService**: Manejo de carritos de compra y sus ítems.
- **PedidosService**: Gestión de pedidos realizados por los usuarios.
- **PagoService**: Procesamiento de pagos.

## Tecnologías

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core + Pomelo MySQL
- MySQL 8
- Docker
- Swagger (documentación de APIs)


## Configuración y ejecución

### 1. Requisitos Previos

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado y en ejecución.
- MySQL 8 disponible (puedes usar un contenedor Docker para cada base de datos

2. **Construcción y despliegue**
   
- Cada microservicio tiene su propio `Dockerfile`. Para construir ejecutar cada uno:
			
	``
	docker build -t <nombre-servicio> . docker run -d -p <puerto-local>:<puerto-contenedor> --env-file .env <nombre-servicio>
    ``

Ejemplo para UsuariosService:

	cd UsuariosService docker build -t usuarios-service . docker run -d -p 5001:80 --env-file .env usuarios-service

> **Nota:** Asegúrate de tener la base de datos MySQL correspondiente corriendo y accesible para cada microservicio (hay un script para cada uno).

Repite el proceso para cada microservicio cambiando el nombre del contenedor, la base de datos y el puerto.


## Variables de entorno y cadenas de conexión

Cada microservicio utiliza su propia base de datos MySQL, definida en `docker-compose.yml` y configurada mediante variables de entorno:

Ejemplo para UsuariosService:

``
ConnectionStrings__DefaultConnection=server=localhost;port=3306;database=usuarios_db;user=root;password=2634
``

Asegúrate de que las cadenas de conexión en los archivos `appsettings.json` permitan la sobreescritura por variables de entorno.

## Endpoints principales

### UsuariosService
- `GET /api/usuarios` - Listar usuarios
- `POST /api/usuarios` - Registrar usuario

### ProductosService
- `GET /api/productos` - Listar productos
- `GET /api/productos/{id}` - Obtener producto por ID
- `POST /api/productos` - Crear producto
- `DELETE /api/productos/{id}` - Eliminar producto

### CarritoService
- `GET /api/carritos/{usuarioId}` - Obtener carrito de usuario
- `POST /api/carritos/{usuarioId}/items` - Agregar ítem al carrito
- `DELETE /api/carritos/{usuarioId}/items/{itemId}` - Eliminar ítem del carrito

### PedidosService
- `GET /api/pedidos` - Listar pedidos
- `GET /api/pedidos/{id}` - Obtener pedido por ID
- `POST /api/pedidos` - Crear pedido
- `DELETE /api/pedidos/{id}` - Eliminar pedido

### PagoService
- `GET /api/pagos` - Listar pagos
- `GET /api/pagos/{id}` - Obtener pago por ID
- `POST /api/pagos` - Crear pago
- `DELETE /api/pagos/{id}` - Eliminar pago

## Notas

- Cada microservicio es independiente y puede ser escalado o modificado sin afectar a los demás.
- Las migraciones de base de datos deben ejecutarse al construir los contenedores (puedes agregar lógica para aplicar migraciones automáticamente).