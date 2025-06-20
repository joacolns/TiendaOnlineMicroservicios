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
- Docker & Docker Compose
- Swagger (documentación de APIs)


## Configuración y ejecución

1. **Requisitos previos**
   - [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado y en ejecución.

2. **Construcción y despliegue**
   - Desde la raíz del proyecto, ejecuta:
     ```sh
     docker-compose up --build
     ```
   - Esto levantará todos los microservicios y sus bases de datos asociadas.

3. **Acceso a los servicios**
   - Los servicios estarán disponibles en los siguientes puertos:
     - UsuariosService: [http://localhost:5001](http://localhost:5001)
     - ProductosService: [http://localhost:5002](http://localhost:5002)
     - CarritoService: [http://localhost:5003](http://localhost:5003)
     - PagoService: [http://localhost:5004](http://localhost:5004)
     - PedidosService: [http://localhost:5005](http://localhost:5005)

4. **Swagger**
   - Cada microservicio expone su documentación Swagger en `/swagger` (por ejemplo, [http://localhost:5001/swagger](http://localhost:5001/swagger)).

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
- Las migraciones de base de datos deben ejecutarse al construir los contenedores (puedes agregar lógica para aplicar migraciones automáticamente si lo deseas).
- Para detener y eliminar los contenedores y volúmenes:
`docker-compose down-v`