# 🎨 Guía de Efectos Visuales - Gaming Theme

Esta guía documenta todos los efectos visuales y personalizaciones implementadas en el proyecto de Catálogo de Videojuegos.

---

## 📦 Efectos Implementados

### 1. **Video Background Animado**
- **Ubicación**: Fondo de toda la aplicación
- **Descripción**: Video de gameplay real reproduciendo en loop
- **Tecnología**: HTML5 Video + CSS overlays
- **Configuración**: `gaming-theme.js` - `initVideoBackground()`
- **Personalización**: Cambiar URLs en el array `videoSources`

```javascript
const videoSources = [
    'https://videos.pexels.com/video-files/7561983/...',
    // Agregar más videos aquí
];
```

---

### 2. **Sistema de Partículas Flotantes**
- **Ubicación**: Fondo de toda la aplicación
- **Descripción**: 15 partículas de colores gaming flotando
- **Colores**: Rojo, Naranja, Verde, Azul, Morado
- **Configuración**: `initParticles()` en gaming-theme.js
- **Rendimiento**: Optimizado con límite de partículas

**Clases CSS**:
- `.particles-container` - Contenedor
- `.particle` - Cada partícula individual

---

### 3. **Efecto Scanlines Retro**
- **Ubicación**: Overlay global
- **Descripción**: Líneas horizontales sutiles tipo CRT
- **Opacidad**: 0.02 (muy sutil para no molestar)
- **Clase CSS**: `.scanlines`

---

### 4. **Ripple Effect (Ondas)**
- **Ubicación**: Todos los botones
- **Descripción**: Efecto de onda al hacer clic
- **Activación**: Click en botones
- **Clase**: `.ripple-button`
- **Uso**:
```html
<button class="btn ripple-button">Click Me</button>
```

---

### 5. **Rainbow Hover Effect**
- **Ubicación**: Botones principales
- **Descripción**: Gradiente arcoíris animado en hover
- **Clase**: `.rainbow-hover`
- **Colores**: 7 colores del arcoíris rotando
- **Uso**:
```html
<a class="btn rainbow-hover">Hover aquí</a>
```

---

### 6. **Neon Border Animado**
- **Ubicación**: Feature cards
- **Descripción**: Borde neón con gradiente fluyendo
- **Velocidad**: 4s por ciclo
- **Clase**: `.neon-border`
- **Colores**: Rojo → Naranja → Verde → Azul → Morado

---

### 7. **Parallax Scroll**
- **Ubicación**: Cards de características y juegos
- **Descripción**: Movimiento 3D al hacer scroll
- **Velocidad**: Variable según posición del elemento
- **Clase**: `.parallax-layer`
- **Función**: `initParallaxEffect()`

---

### 8. **Glitch Effect**
- **Ubicación**: Títulos principales (hover)
- **Descripción**: Efecto de "glitch" cyberpunk
- **Colores**: Cian y Magenta (RGB split)
- **Activación**: Mouse hover en h1, h2
- **Clase**: `.glitch-effect`
- **Uso**:
```html
<h1 data-text="Título">Título</h1>
```

---

### 9. **Floating Elements**
- **Ubicación**: Iconos de features
- **Descripción**: Animación de flotación suave
- **Movimiento**: 20px arriba y abajo
- **Duración**: 3s
- **Clase**: `.float-element`

---

### 10. **Pulse Badge**
- **Ubicación**: Números de estadísticas
- **Descripción**: Pulso con sombra expandiéndose
- **Color**: Rojo gaming
- **Clase**: `.pulse-badge`
- **Uso en badges/notificaciones**

---

### 11. **Counter Animation**
- **Ubicación**: Números de estadísticas
- **Descripción**: Animación de conteo desde 0
- **Activación**: Cuando el elemento entra en viewport
- **Función**: `initCounterAnimation()`
- **Tecnología**: Intersection Observer API

---

### 12. **Tooltips Gaming Style**
- **Ubicación**: Elementos con atributo data-tooltip
- **Descripción**: Tooltips personalizados con borde rojo
- **Función**: `initTooltips()`
- **Uso**:
```html
<button data-tooltip="Descripción aquí">Botón</button>
```

**Estilo**:
- Fondo: Gradiente oscuro
- Borde: Rojo gaming
- Animación: Fade in/out

---

### 13. **Smooth Scroll**
- **Ubicación**: Links de anclaje (#)
- **Descripción**: Scroll suave + highlight del destino
- **Función**: `initSmoothScroll()`
- **Efecto adicional**: Flash de sombra al llegar

---

### 14. **Floating Action Button (FAB)**
- **Ubicación**: Esquina inferior derecha
- **Descripción**: Botón flotante "Scroll to Top"
- **Icono**: ⬆️
- **Aparición**: Después de 300px de scroll
- **Animación**: Scale + rotate en hover

**Características**:
- Gradiente rojo
- Sombra gaming
- Rotación 360° en hover
- Scroll suave al top

---

### 15. **Gradient Animated Buttons**
- **Clase**: `.gradient-button`
- **Descripción**: Botón con gradiente de 4 colores moviéndose
- **Velocidad**: 4s por ciclo
- **Efecto adicional**: Onda blanca en click

---

### 16. **Holographic Card**
- **Clase**: `.holographic-card`
- **Descripción**: Efecto holográfico con brillo deslizante
- **Uso**: Cards especiales o destacados
- **Efecto**: Línea de brillo atravesando cada 3s

---

### 17. **Pixel Border Effect**
- **Clase**: `.pixel-border`
- **Descripción**: Borde pixelado retro animado
- **Estilo**: Inspirado en juegos 8-bit
- **Colores**: 4 colores rotando

---

### 18. **Easter Egg: Código Konami**
- **Código**: ↑ ↑ ↓ ↓ ← → ← → B A
- **Efecto**: Activa "Modo Retro"
- **Duración**: 10 segundos
- **Cambios**:
  - Hue rotate 180°
  - Saturación aumentada
  - Fuente monospace
- **Notificación**: Achievement popup

**Función**: `initKonamiCode()`

---

### 19. **Shake Effect**
- **Clase**: `.shake-effect`
- **Uso**: Errores, validaciones fallidas
- **Duración**: 0.5s
- **Aplicar con JS**:
```javascript
element.classList.add('shake-effect');
setTimeout(() => element.classList.remove('shake-effect'), 500);
```

---

### 20. **Gaming Spinner (Loading)**
- **Clase**: `.gaming-spinner`
- **Descripción**: Spinner estilo gaming
- **Color**: Rojo gaming rotando
- **Tamaño**: 60x60px
- **Uso**:
```html
<div class="gaming-spinner"></div>
```

---

## 🎯 Combinaciones Recomendadas

### Botón Épico
```html
<button class="btn gradient-button ripple-button rainbow-hover" data-tooltip="¡Haz click!">
    Botón Épico
</button>
```

### Card Destacada
```html
<div class="feature-card holographic-card neon-border parallax-layer">
    <div class="float-element">🎮</div>
    <h3>Título</h3>
</div>
```

### Título Impactante
```html
<h1 class="neon-text glitch-effect" data-text="Gaming">Gaming</h1>
```

---

## ⚡ Optimizaciones de Rendimiento

### 1. Reduced Motion
Si el usuario prefiere menos movimiento:
```css
@media (prefers-reduced-motion: reduce) {
    * {
        animation-duration: 0.01ms !important;
    }
}
```

### 2. Lazy Loading de Partículas
- Máximo 15 partículas simultáneas
- Intervalo de creación: 3s

### 3. Intersection Observer
- Animaciones solo cuando son visibles
- Contadores se activan al 50% de visibilidad

### 4. RequestAnimationFrame
- Animaciones sincronizadas con refresh rate
- Mejor rendimiento que setInterval

---

## 🎨 Paleta de Colores Gaming

```css
:root {
    --primary-red: #dc2626;
    --primary-dark-red: #991b1b;
    --accent-orange: #f59e0b;
    --accent-green: #10b981;
    --accent-blue: #3b82f6;
    --accent-purple: #8b5cf6;
    --dark-bg: #1f2937;
    --darker-bg: #111827;
}
```

---

## 📱 Responsive Design

Todos los efectos son responsive y se adaptan a:
- **Desktop**: Todos los efectos activos
- **Tablet**: Efectos reducidos (menos partículas)
- **Mobile**: Efectos esenciales (sin parallax pesado)

---

## 🔧 Personalización Rápida

### Cambiar Velocidad de Animaciones
En `gaming-effects.css`, buscar `animation-duration`:
```css
/* Más rápido: 1s, Más lento: 5s */
animation-duration: 3s;
```

### Cambiar Colores de Partículas
En `gaming-theme.js`:
```javascript
const colors = ['#dc2626', '#f59e0b', '#10b981', '#3b82f6', '#8b5cf6'];
// Agregar más colores aquí
```

### Desactivar Efecto Específico
Comentar la llamada en DOMContentLoaded:
```javascript
// initParallaxEffect(); // Desactivado
```

---

## 🐛 Troubleshooting

### Video no se reproduce
- Verificar URLs de video
- Revisar política de autoplay del navegador
- Asegurar que video tiene `muted="true"`

### Efectos no se ven
- Verificar que los archivos CSS/JS están cargados
- Abrir DevTools → Console para errores
- Verificar que las clases están aplicadas

### Rendimiento lento
- Reducir número de partículas
- Desactivar parallax en móviles
- Usar `will-change` CSS con cuidado

---

## 📚 Recursos Adicionales

- [MDN Web Animations API](https://developer.mozilla.org/en-US/docs/Web/API/Web_Animations_API)
- [CSS Tricks - Animation](https://css-tricks.com/almanac/properties/a/animation/)
- [Gaming UI Inspiration](https://www.awwwards.com/websites/gaming/)

---

## 🎮 Contribuir

Para agregar nuevos efectos:
1. Crear función en `gaming-theme.js`
2. Agregar estilos en `gaming-effects.css`
3. Llamar función en `DOMContentLoaded`
4. Documentar aquí con ejemplo

---

**Última actualización**: Mayo 2026  
**Versión**: 2.0 - Gaming Edition
