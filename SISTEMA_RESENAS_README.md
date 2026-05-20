# Sistema de Reseñas - Catálogo de Videojuegos

## 🎮 Funcionalidades Implementadas

### 1. Sistema de Autenticación
- **Registro de usuarios**: Los usuarios pueden crear una cuenta con username, email y contraseña
- **Inicio de sesión**: Autenticación mediante username y contraseña
- **Gestión de sesiones**: Manejo de sesiones de usuario con ASP.NET Core Session
- **Cierre de sesión**: Funcionalidad para cerrar sesión de forma segura

### 2. Sistema de Reseñas
- **Calificación de 1 a 5 estrellas**: Sistema de puntuación estándar
- **Comentarios de usuarios**: Los usuarios pueden dejar comentarios detallados
- **Restricción de acceso**: Solo usuarios autenticados pueden dejar reseñas
- **Visualización de reseñas**: Todas las reseñas se muestran en la página de detalle del juego
- **Promedio de calificaciones**: Cálculo automático del promedio de estrellas
- **Contador de reseñas**: Muestra el número total de reseñas por juego

### 3. Usuarios Precargados (en users.json)
- **Usuario 1**: 
  - Username: `carlos123`
  - Password: `password123`
  - Email: carlos@example.com

- **Usuario 2**: 
  - Username: `maria_gamer`
  - Password: `maria456`
  - Email: maria@example.com

- **Usuario 3**: 
  - Username: `juan_pro`
  - Password: `juan789`
  - Email: juan@example.com

### 4. Reseñas Precargadas
Ya existen al menos 2 reseñas por cada juego del catálogo, creadas por diferentes usuarios.

## 📂 Estructura de Archivos JSON

### Data/items.json
Contiene los videojuegos del catálogo

### Data/users.json
Contiene los usuarios registrados en el sistema

### Data/reviews.json
Contiene todas las reseñas de los usuarios

## 🔑 Reglas de Negocio

1. **Para dejar una reseña**, el usuario DEBE estar autenticado
2. Las calificaciones deben ser entre **1 y 5 estrellas**
3. Los comentarios deben tener **mínimo 10 caracteres** y **máximo 500 caracteres**
4. Cada reseña registra:
   - ID del item
   - ID del usuario
   - Nombre del usuario
   - Número de estrellas
   - Comentario
   - Fecha de la reseña

## 🚀 Cómo Usar el Sistema

### Para Usuarios No Autenticados:
1. Navegar el catálogo de juegos
2. Ver detalles y reseñas de otros usuarios
3. Ver el promedio de calificaciones
4. Registrarse para dejar reseñas

### Para Usuarios Autenticados:
1. Iniciar sesión con credenciales
2. Ver catálogo con información de sesión en la barra de navegación
3. Acceder a la página de detalle de un juego
4. Hacer clic en "Agregar Reseña"
5. Seleccionar calificación (1-5 estrellas)
6. Escribir comentario
7. Publicar reseña

## 🛠️ Arquitectura Técnica

### Capas del Proyecto:
- **Catalogo.Domain**: Modelos (Item, User, Review) e Interfaces
- **Catalogo.Application**: Servicios de lógica de negocio
- **Catalogo.Infrastructure**: Repositorios JSON para persistencia
- **Catalogo.Presentation**: Controllers y Views (MVC)

### Tecnologías:
- .NET 10
- ASP.NET Core MVC
- JSON para persistencia de datos
- Bootstrap 5 para estilos
- Session Management para autenticación

## 📝 Nuevos Endpoints

### Account Controller:
- `GET /Account/Login` - Formulario de inicio de sesión
- `POST /Account/Login` - Procesar inicio de sesión
- `GET /Account/Register` - Formulario de registro
- `POST /Account/Register` - Procesar registro
- `GET /Account/Logout` - Cerrar sesión

### Catalogo Controller (Nuevos):
- `GET /Catalogo/AgregarReview?itemId={id}` - Formulario para agregar reseña
- `POST /Catalogo/AgregarReview` - Procesar nueva reseña

## ⚠️ Notas Importantes

- Las contraseñas se almacenan en **texto plano** en el JSON (solo para demostración, NO usar en producción)
- En producción se debería usar:
  - Hash de contraseñas (BCrypt, PBKDF2, etc.)
  - Identity de ASP.NET Core
  - Base de datos real (SQL Server, PostgreSQL, etc.)
  - JWT o cookies seguras para autenticación

## 🎨 Características de UI

- Interfaz moderna y responsiva
- Visualización de estrellas con emojis
- Indicador visual del usuario logueado en la barra de navegación
- Mensajes de éxito/error con TempData
- Validación de formularios en cliente y servidor
- Diseño consistente con el resto de la aplicación
