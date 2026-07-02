/* =========================================================
   SIMPLE CROWD SIMULATOR — LAUNCHER SCRIPT
   Vanilla JS — no dependencies
   ========================================================= */

(() => {
  'use strict';

  const prefersReducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;

  /* -----------------------------------------------------
     DATA — single source of truth for demo versions.
     Add a new version by pushing an object here; the modal
     and play buttons read from this automatically.
  ----------------------------------------------------- */
  const VERSIONS = {
    v1: {
      title: 'VERSION 1 (V1)',
      features: ['Basic crowd movement', 'Random walk behavior', 'Simple environment'],
      released: '2024-05-10',
      playUrl: './v1/index.html'
    },
    v2: {
      title: 'VERSION 2 (V2)',
      features: ['Obstacle avoidance', 'Waypoint system', 'Performance optimization'],
      released: '2024-08-15',
      playUrl: './v2/index.html'
    },
    v3: {
      title: 'VERSION 3 (V3)',
      features: ['Group behavior', 'Formation movement', 'UI & Settings'],
      released: '2024-11-20',
      playUrl: './v3/index.html'
    },
    latest: {
      title: 'VERSION 3 (V3) — LATEST',
      features: ['Group behavior', 'Formation movement', 'UI & Settings'],
      released: '2024-11-20',
      playUrl: './v3/index.html'
    }
  };

  /* -----------------------------------------------------
     MOBILE NAV
  ----------------------------------------------------- */
  const menuToggle = document.getElementById('menuToggle');
  const mobileNav = document.getElementById('mobileNav');

  if (menuToggle && mobileNav) {
    menuToggle.addEventListener('click', () => {
      const isOpen = mobileNav.classList.toggle('is-open');
      menuToggle.classList.toggle('is-open', isOpen);
      menuToggle.setAttribute('aria-expanded', String(isOpen));
    });

    mobileNav.querySelectorAll('a').forEach(link => {
      link.addEventListener('click', () => {
        mobileNav.classList.remove('is-open');
        menuToggle.classList.remove('is-open');
        menuToggle.setAttribute('aria-expanded', 'false');
      });
    });
  }

  /* -----------------------------------------------------
     ACTIVE NAV LINK ON SCROLL
  ----------------------------------------------------- */
  const navLinks = document.querySelectorAll('[data-nav]');
  const sections = ['hero', 'versions', 'about']
    .map(id => document.getElementById(id))
    .filter(Boolean);

  const setActiveNav = (id) => {
    navLinks.forEach(link => {
      const match = link.getAttribute('href') === `#${id}`;
      link.classList.toggle('is-active', match);
    });
  };

  if ('IntersectionObserver' in window && sections.length) {
    const navObserver = new IntersectionObserver(
      (entries) => {
        entries.forEach(entry => {
          if (entry.isIntersecting) setActiveNav(entry.target.id);
        });
      },
      { rootMargin: '-40% 0px -55% 0px', threshold: 0 }
    );
    sections.forEach(sec => navObserver.observe(sec));
  }

  /* -----------------------------------------------------
     SCROLL REVEAL — fade + rise, staggered via data-attrs
  ----------------------------------------------------- */
  const revealEls = document.querySelectorAll('[data-reveal]');

  if (prefersReducedMotion || !('IntersectionObserver' in window)) {
    revealEls.forEach(el => el.classList.add('is-visible'));
  } else {
    const revealObserver = new IntersectionObserver(
      (entries, observer) => {
        entries.forEach(entry => {
          if (!entry.isIntersecting) return;
          const el = entry.target;
          const delay = parseInt(el.dataset.revealDelay || '0', 10);
          setTimeout(() => el.classList.add('is-visible'), delay);
          observer.unobserve(el);
        });
      },
      { threshold: 0.15, rootMargin: '0px 0px -60px 0px' }
    );
    revealEls.forEach(el => revealObserver.observe(el));
  }

  /* -----------------------------------------------------
     TIMELINE PROGRESS FILL — animates once in view
  ----------------------------------------------------- */
  const timelineFill = document.getElementById('timelineFill');
  const timelineTrack = document.querySelector('.timeline-track');
  // 3 of 4 milestones complete → fill to the 3rd node position (~66%)
  const TIMELINE_PROGRESS = '66%';

  if (timelineFill && timelineTrack) {
    const fillObserver = new IntersectionObserver(
      (entries, observer) => {
        entries.forEach(entry => {
          if (entry.isIntersecting) {
            timelineFill.style.width = prefersReducedMotion ? TIMELINE_PROGRESS : TIMELINE_PROGRESS;
            observer.disconnect();
          }
        });
      },
      { threshold: 0.4 }
    );
    fillObserver.observe(timelineTrack);
  }

  /* -----------------------------------------------------
     HEADER — subtle border intensify on scroll
  ----------------------------------------------------- */
  const header = document.getElementById('siteHeader');
  if (header) {
    let lastScroll = 0;
    window.addEventListener('scroll', () => {
      const y = window.scrollY;
      if (y > 8 && lastScroll <= 8) {
        header.style.borderBottomColor = 'rgba(0, 255, 136, 0.25)';
      } else if (y <= 8 && lastScroll > 8) {
        header.style.borderBottomColor = '';
      }
      lastScroll = y;
    }, { passive: true });
  }

  /* -----------------------------------------------------
     BUTTON RIPPLE FEEDBACK
  ----------------------------------------------------- */
  document.querySelectorAll('.btn').forEach(btn => {
    btn.addEventListener('click', (e) => {
      if (prefersReducedMotion) return;
      const rect = btn.getBoundingClientRect();
      const ripple = document.createElement('span');
      const size = Math.max(rect.width, rect.height);
      ripple.className = 'ripple';
      ripple.style.width = ripple.style.height = `${size}px`;
      ripple.style.left = `${e.clientX - rect.left - size / 2}px`;
      ripple.style.top = `${e.clientY - rect.top - size / 2}px`;
      btn.appendChild(ripple);
      ripple.addEventListener('animationend', () => ripple.remove());
    });
  });

  /* -----------------------------------------------------
     TOAST
  ----------------------------------------------------- */
  const toast = document.getElementById('toast');
  let toastTimer = null;

  function showToast(message) {
    if (!toast) return;
    toast.textContent = message;
    toast.classList.add('is-visible');
    clearTimeout(toastTimer);
    toastTimer = setTimeout(() => toast.classList.remove('is-visible'), 2600);
  }

  /* -----------------------------------------------------
     PLAY BUTTONS — launch the matching build
     Swap the `showToast` fallback for a real navigation
     once each build has a URL in VERSIONS above.
  ----------------------------------------------------- */
  document.querySelectorAll('[data-play]').forEach(btn => {
    btn.addEventListener('click', () => {
      const key = btn.dataset.play;
      const version = VERSIONS[key];
      if (!version) return;

      if (version.playUrl && version.playUrl !== '#') {
        window.location.href = version.playUrl;
      } else {
        showToast(`> LAUNCHING ${version.title}... (add build path in script.js)`);
      }
    });
  });

  /* -----------------------------------------------------
     DETAILS MODAL
  ----------------------------------------------------- */
  const modalOverlay = document.getElementById('modalOverlay');
  const modalTitle = document.getElementById('modalTitle');
  const modalList = document.getElementById('modalList');
  const modalPlay = document.getElementById('modalPlay');
  const modalClose = document.getElementById('modalClose');
  const modalCloseBtn = document.getElementById('modalCloseBtn');

  let lastFocusedEl = null;
  let currentModalKey = null;

  function openModal(key) {
    const version = VERSIONS[key];
    if (!version || !modalOverlay) return;

    currentModalKey = key;
    modalTitle.textContent = version.title;
    modalList.innerHTML = version.features
      .map(f => `<li>${f}</li>`)
      .join('') + `<li>Released: ${version.released}</li>`;

    lastFocusedEl = document.activeElement;
    modalOverlay.classList.add('is-open');
    modalOverlay.setAttribute('aria-hidden', 'false');
    document.body.style.overflow = 'hidden';
    modalClose.focus();
  }

  function closeModal() {
    if (!modalOverlay) return;
    modalOverlay.classList.remove('is-open');
    modalOverlay.setAttribute('aria-hidden', 'true');
    document.body.style.overflow = '';
    if (lastFocusedEl) lastFocusedEl.focus();
  }

  document.querySelectorAll('[data-details]').forEach(btn => {
    btn.addEventListener('click', () => openModal(btn.dataset.details));
  });

  if (modalPlay) {
    modalPlay.addEventListener('click', () => {
      const version = VERSIONS[currentModalKey];
      closeModal();
      if (version?.playUrl && version.playUrl !== '#') {
        window.location.href = version.playUrl;
      } else {
        showToast(`> LAUNCHING ${version?.title}... (add build path in script.js)`);
      }
    });
  }

  [modalClose, modalCloseBtn].forEach(el => el?.addEventListener('click', closeModal));

  modalOverlay?.addEventListener('click', (e) => {
    if (e.target === modalOverlay) closeModal();
  });

  document.addEventListener('keydown', (e) => {
    if (e.key === 'Escape' && modalOverlay?.classList.contains('is-open')) closeModal();
  });

  /* -----------------------------------------------------
     SMOOTH ANCHOR SCROLL WITH HEADER OFFSET
  ----------------------------------------------------- */
  const headerHeight = () => header?.offsetHeight || 0;

  document.querySelectorAll('a[href^="#"]').forEach(link => {
    link.addEventListener('click', (e) => {
      const id = link.getAttribute('href').slice(1);
      const target = document.getElementById(id);
      if (!target) return;
      e.preventDefault();
      const top = target.getBoundingClientRect().top + window.scrollY - headerHeight() - 8;
      window.scrollTo({ top, behavior: prefersReducedMotion ? 'auto' : 'smooth' });
    });
  });

})();
