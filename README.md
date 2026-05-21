# 🎮 Catálogo de Videojuegos

Sistema web completo para gestionar, calificar y compartir tu colección de videojuegos favoritos. Incluye sistema de autenticación, reseñas con calificaciones de estrellas y una interfaz moderna con efectos visuales gaming.

---

##  Características

**Gestión de Videojuegos**
- Crear, leer, actualizar y eliminar videojuegos
- Filtrado por género
- Información detallada (título, género, consola, año, descripción, imagen)

**Sistema de Reseñas**
- Calificaciones de 1 a 5 estrellas ⭐
- Comentarios de usuarios
- Promedio de calificaciones por juego
- Requiere inicio de sesión para reseñar

**Autenticación de Usuarios**
- Registro de nuevos usuarios
- Inicio de sesión con validación
- Gestión de sesiones
- Persistencia de usuarios en JSON

**Interfaz Moderna**
- Diseño responsive (móvil, tablet, desktop)
- Efectos visuales tipo gaming (partículas, scanlines, video background)
- Animaciones suaves y transiciones
- Tema personalizado con gradientes y efectos de hover

**Página de Privacidad**
- Política de privacidad detallada
- Información sobre manejo de datos

---

## 🛠️ Tecnologías Utilizadas

### Backend
- **Framework**: ASP.NET Core MVC (.NET 10)
- **Lenguaje**: C# 12.0
- **Patrón de Arquitectura**: Clean Architecture (Domain-Driven Design)
- **Persistencia**: JSON (JsonItemRepository, JsonUserRepository, JsonReviewRepository)
- **Gestión de Sesiones**: ASP.NET Core Session

### Frontend
- **Motor de Vistas**: Razor Views (.cshtml)
- **Framework CSS**: Bootstrap 5
- **Estilos Personalizados**: CSS3 con variables CSS, gradientes, animaciones
- **JavaScript**: Vanilla JS (efectos gaming, partículas, animaciones)
- **Iconos**: Bootstrap Icons (SVG)

### Herramientas de Desarrollo
- **IDE**: Visual Studio 2026 Community (18.5.2)
- **Control de Versiones**: Git
- **Repositorio Remoto**: GitHub
- **Terminal**: PowerShell

---

## Arquitectura del Proyecto

El proyecto sigue una **arquitectura en capas (Clean Architecture)** con separación de responsabilidades:

### Principios Aplicados
- **Separación de Responsabilidades**: Cada capa tiene una responsabilidad específica
- **Inversión de Dependencias**: Las capas superiores dependen de abstracciones (interfaces)
- **Inyección de Dependencias**: Configurada en `Program.cs`
- **Single Responsibility**: Cada clase tiene una única razón para cambiar

---

## Uso

### Registro e Inicio de Sesión

1. **Registrarse**: Haz clic en "Registrarse" en la barra de navegación
   - Ingresa tu nombre de usuario, email y contraseña
   - Confirma tu contraseña

2. **Iniciar Sesión**: Usa las credenciales creadas o una cuenta predefinida:
   - Usuario: `carlos123` / Contraseña: `password123`
   - Usuario: `maria_gamer` / Contraseña: `password456`
   - Usuario: `juan_pro` / Contraseña: `password789`

### Explorar el Catálogo

1. **Ver Catálogo**: Navega a "Catálogo" desde el menú
2. **Filtrar por Género**: Usa los botones de filtro (Todos, Acción, RPG, Aventura, etc.)
3. **Ver Detalles**: Haz clic en "Ver Detalles" en cualquier juego

### Agregar un Videojuego

1. Inicia sesión (requerido)
2. Ve a "Catálogo" → "Agregar Videojuego"
3. Completa el formulario:
   - Título
   - Género
   - Consola
   - Año de lanzamiento
   - Descripción
   - URL de imagen
4. Haz clic en "Guardar"

### Agregar una Reseña

1. Inicia sesión (requerido)
2. Ve a los detalles de un juego
3. Haz clic en "Agregar Reseña"
4. Selecciona estrellas (1-5) y escribe tu comentario
5. Haz clic en "Enviar Reseña"

---

## Funcionalidades Principales

### 1. CRUD de Videojuegos
- **Create**: Agregar nuevos videojuegos al catálogo
- **Read**: Listar y filtrar videojuegos, ver detalles
- **Update**: Editar información de videojuegos existentes
- **Delete**: Eliminar videojuegos del catálogo

### 2. Sistema de Autenticación
- Registro con validación de campos
- Login con sesión persistente
- Logout y gestión de sesión
- Protección de rutas (solo usuarios autenticados pueden agregar juegos/reseñas)

### 3. Sistema de Reseñas
- Calificación con estrellas (1-5)
- Comentarios de texto
- Cálculo automático de promedio
- Visualización de todas las reseñas por juego
- Fecha de publicación

### 4. Interfaz Gaming
- **Video Background**: Fondo de video con gameplay real
- **Partículas Animadas**: 15 partículas flotantes de colores gaming
- **Scanlines**: Efecto de pantalla retro
- **Hover Effects**: Animaciones en botones y tarjetas
- **Responsive Design**: Adaptable a todos los dispositivos

---

## Capturas de Pantalla



---

## Licencia

Este proyecto fue desarrollado como parte de un ejercicio académico de Arquitectura de Software.

**Autor**: Carlos Alfonso  
**Materia**: Arquitectura de Software - S03  
**Año**: 2026

---

## Cláusula de IA

Declaro el uso de IA Claude Sonnet para la implementacion de estilos personalizados y de guía para agregar los sistemas de reseñas y login, así como para tener una guía clara de la documentación de README.

---

<p align="center">
  <strong>Hecho con .NET 10</strong>
</p>
