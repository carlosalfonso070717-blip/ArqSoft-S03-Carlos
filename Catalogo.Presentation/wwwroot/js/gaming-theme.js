// ========================================
// GAMING THEME - DYNAMIC EFFECTS
// ========================================

// Inicializar cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', function() {
    initVideoBackground();
    initParticles();
    initScrollEffects();
    initCardAnimations();
    initTypingEffect();
    initGamingCursor();
});

// ========================================
// VIDEO BACKGROUND
// ========================================
function initVideoBackground() {
    // Crear contenedor de video si no existe
    if (!document.querySelector('.video-background-wrapper')) {
        const videoWrapper = document.createElement('div');
        videoWrapper.className = 'video-background-wrapper';

        const overlay = document.createElement('div');
        overlay.className = 'video-overlay';

        // URLs de videos reales de gaming - gameplay footage
        const videoSources = [
            // Video de alguien jugando videojuegos - usar videos de Pexels/Pixabay
            'https://videos.pexels.com/video-files/7561983/7561983-uhd_2560_1440_30fps.mp4',
            'https://videos.pexels.com/video-files/8263436/8263436-uhd_2560_1440_25fps.mp4',
            'https://videos.pexels.com/video-files/7562184/7562184-uhd_2560_1440_30fps.mp4'
        ];

        const video = document.createElement('video');
        video.className = 'video-background';
        video.autoplay = true;
        video.loop = true;
        video.muted = true;
        video.playsInline = true;

        const source = document.createElement('source');
        source.src = videoSources[Math.floor(Math.random() * videoSources.length)];
        source.type = 'video/mp4';

        video.appendChild(source);
        videoWrapper.appendChild(video);
        videoWrapper.appendChild(overlay);

        document.body.insertBefore(videoWrapper, document.body.firstChild);

        // Reproducir video
        video.play().catch(e => console.log('Video autoplay prevented'));
    }
}

// ========================================
// PARTICLE SYSTEM
// ========================================
function initParticles() {
    const container = document.createElement('div');
    container.className = 'particles-container';
    document.body.appendChild(container);

    const particleCount = 15; // Reducido para mejor rendimiento
    const colors = ['#dc2626', '#f59e0b', '#10b981', '#3b82f6', '#8b5cf6'];

    for (let i = 0; i < particleCount; i++) {
        createParticle(container, colors);
    }

    // Crear partículas continuamente
    setInterval(() => {
        if (container.children.length < particleCount) {
            createParticle(container, colors);
        }
    }, 3000); // Aumentado el intervalo
}

function createParticle(container, colors) {
    const particle = document.createElement('div');
    particle.className = 'particle';

    const size = Math.random() * 4 + 2;
    const startX = Math.random() * window.innerWidth;
    const duration = Math.random() * 10 + 15;
    const delay = Math.random() * 5;
    const color = colors[Math.floor(Math.random() * colors.length)];

    particle.style.cssText = `
        width: ${size}px;
        height: ${size}px;
        left: ${startX}px;
        background: ${color};
        animation-duration: ${duration}s;
        animation-delay: ${delay}s;
        box-shadow: 0 0 ${size * 2}px ${color};
    `;

    container.appendChild(particle);

    // Remover partícula después de la animación
    setTimeout(() => {
        particle.remove();
    }, (duration + delay) * 1000);
}

// ========================================
// SCROLL EFFECTS
// ========================================
function initScrollEffects() {
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    });

    // Observar elementos con clase 'fade-in-scroll'
    document.querySelectorAll('.game-card, .feature-card, .stat-card, .review-card').forEach(el => {
        el.style.opacity = '0';
        el.style.transform = 'translateY(30px)';
        el.style.transition = 'opacity 0.6s ease-out, transform 0.6s ease-out';
        observer.observe(el);
    });
}

// ========================================
// CARD ANIMATIONS
// ========================================
function initCardAnimations() {
    // Efecto de inclinación 3D en las tarjetas
    document.querySelectorAll('.game-card').forEach(card => {
        card.addEventListener('mousemove', function(e) {
            const rect = card.getBoundingClientRect();
            const x = e.clientX - rect.left;
            const y = e.clientY - rect.top;

            const centerX = rect.width / 2;
            const centerY = rect.height / 2;

            const rotateX = (y - centerY) / 10;
            const rotateY = (centerX - x) / 10;

            card.style.transform = `perspective(1000px) rotateX(${rotateX}deg) rotateY(${rotateY}deg) scale3d(1.05, 1.05, 1.05)`;
        });

        card.addEventListener('mouseleave', function() {
            card.style.transform = 'perspective(1000px) rotateX(0) rotateY(0) scale3d(1, 1, 1)';
        });
    });
}

// ========================================
// TYPING EFFECT
// ========================================
function initTypingEffect() {
    const typingElements = document.querySelectorAll('[data-typing]');

    typingElements.forEach(element => {
        const text = element.getAttribute('data-typing');
        const speed = parseInt(element.getAttribute('data-typing-speed')) || 50;
        let i = 0;

        element.textContent = '';

        function typeWriter() {
            if (i < text.length) {
                element.textContent += text.charAt(i);
                i++;
                setTimeout(typeWriter, speed);
            }
        }

        // Iniciar typing cuando el elemento sea visible
        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    typeWriter();
                    observer.disconnect();
                }
            });
        });

        observer.observe(element);
    });
}

// ========================================
// GAMING CURSOR
// ========================================
function initGamingCursor() {
    const cursor = document.createElement('div');
    cursor.className = 'gaming-cursor';
    cursor.style.cssText = `
        position: fixed;
        width: 20px;
        height: 20px;
        border: 2px solid #dc2626;
        border-radius: 50%;
        pointer-events: none;
        z-index: 10000;
        transition: transform 0.1s ease;
        mix-blend-mode: difference;
    `;
    document.body.appendChild(cursor);

    const cursorGlow = document.createElement('div');
    cursorGlow.style.cssText = `
        position: fixed;
        width: 40px;
        height: 40px;
        background: radial-gradient(circle, rgba(220, 38, 38, 0.3) 0%, transparent 70%);
        border-radius: 50%;
        pointer-events: none;
        z-index: 9999;
        transition: transform 0.15s ease;
    `;
    document.body.appendChild(cursorGlow);

    document.addEventListener('mousemove', (e) => {
        cursor.style.left = e.clientX - 10 + 'px';
        cursor.style.top = e.clientY - 10 + 'px';

        cursorGlow.style.left = e.clientX - 20 + 'px';
        cursorGlow.style.top = e.clientY - 20 + 'px';
    });

    // Efecto al hacer clic
    document.addEventListener('mousedown', () => {
        cursor.style.transform = 'scale(0.8)';
        cursorGlow.style.transform = 'scale(1.5)';
    });

    document.addEventListener('mouseup', () => {
        cursor.style.transform = 'scale(1)';
        cursorGlow.style.transform = 'scale(1)';
    });

    // Esconder cursor por defecto del sistema
    document.body.style.cursor = 'none';
    document.querySelectorAll('a, button, input, textarea, select').forEach(el => {
        el.style.cursor = 'none';

        el.addEventListener('mouseenter', () => {
            cursor.style.transform = 'scale(1.5)';
            cursor.style.borderColor = '#f59e0b';
        });

        el.addEventListener('mouseleave', () => {
            cursor.style.transform = 'scale(1)';
            cursor.style.borderColor = '#dc2626';
        });
    });
}

// ========================================
// ACHIEVEMENT NOTIFICATION
// ========================================
function showAchievement(title, description, icon = '🏆') {
    const achievement = document.createElement('div');
    achievement.className = 'achievement-popup';
    achievement.innerHTML = `
        <div style="display: flex; align-items: center; gap: 15px;">
            <div style="font-size: 2rem;">${icon}</div>
            <div>
                <div style="font-weight: bold; font-size: 1.1rem; margin-bottom: 5px;">${title}</div>
                <div style="font-size: 0.9rem; opacity: 0.8;">${description}</div>
            </div>
        </div>
    `;

    document.body.appendChild(achievement);

    setTimeout(() => {
        achievement.remove();
    }, 5000);
}

// ========================================
// SMOOTH SCROLL
// ========================================
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// ========================================
// EASTER EGG - Konami Code
// ========================================
let konamiCode = ['ArrowUp', 'ArrowUp', 'ArrowDown', 'ArrowDown', 'ArrowLeft', 'ArrowRight', 'ArrowLeft', 'ArrowRight', 'b', 'a'];
let konamiIndex = 0;

document.addEventListener('keydown', (e) => {
    if (e.key === konamiCode[konamiIndex]) {
        konamiIndex++;
        if (konamiIndex === konamiCode.length) {
            showAchievement('¡Código Konami!', 'Has desbloqueado el modo retro', '🎮');
            document.body.classList.add('retro-mode');
            konamiIndex = 0;
        }
    } else {
        konamiIndex = 0;
    }
});

// ========================================
// PERFORMANCE OPTIMIZATION
// ========================================
// Deshabilitar efectos en dispositivos de bajo rendimiento
if (window.matchMedia('(prefers-reduced-motion: reduce)').matches) {
    document.body.classList.add('reduce-motion');
    // Deshabilitar animaciones pesadas
    const style = document.createElement('style');
    style.textContent = `
        * {
            animation-duration: 0.01ms !important;
            animation-iteration-count: 1 !important;
            transition-duration: 0.01ms !important;
        }
    `;
    document.head.appendChild(style);
}

// Exportar funciones para uso global
window.gamingTheme = {
    showAchievement,
    initParticles
};
