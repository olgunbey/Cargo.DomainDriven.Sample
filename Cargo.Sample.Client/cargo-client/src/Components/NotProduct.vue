
<template>
<div class="no-products">
      <div class="empty-card" role="status" aria-live="polite">
        <span class="glow"></span>
        <div class="icon" aria-hidden="true">
          <svg viewBox="0 0 24 24" width="64" height="64">
            <path d="M3 7h18M7 7l2.4 9.6a2 2 0 0 0 2 1.4h2.2a2 2 0 0 0 2-1.4L18 7" fill="none" stroke="currentColor"
              stroke-width="1.5" stroke-linecap="round" />
            <circle cx="10" cy="12" r="2.2" fill="none" stroke="currentColor" stroke-width="1.5" />
            <circle cx="10" cy="12" r="4.2" fill="none" stroke="currentColor" stroke-width="1.2" opacity="0.25" />
            <path d="M15.5 15.5l4 4" stroke="currentColor" stroke-width="1.8" stroke-linecap="round" />
          </svg>
        </div>
        <h2>Ürün bulunamadı</h2>
        <p>Filtreleri daralttın mı? Kategoriyi değiştirerek yeniden dene.</p>
        <div class="actions">
          <a class="btn ghost">Filtreleri temizle</a>
          <a class="btn">Tüm ürünleri göster</a>
        </div>
      </div>
    </div>
</template>



<script setup lang="ts">
</script>

<style scoped>
.no-products {
  position: absolute;
  /* sayfaya göre konumlandır */
  top: 50%;
  /* dikey ortala */
  left: 50%;
  /* yatay ortala */
  transform: translate(-50%, -50%);
  /* tam ortalama */
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  max-width: 400px;
  /* opsiyonel, kart boyutu */
  pointer-events: none;
  /* tıklanabilirliği kapat */
  z-index: 10;
  /* diğer elementlerin üstünde */
}

.empty-card {
  position: relative;
  width: min(720px, 92vw);
  border-radius: 24px;
  padding: 28px 28px 30px;
  background: var(--card);
  color: var(--fg);
  border: 1px solid var(--stroke);
  backdrop-filter: blur(8px) saturate(120%);
  box-shadow:
    0 10px 30px rgba(0, 0, 0, 0.18),
    inset 0 1px 0 rgba(255, 255, 255, 0.08);
  text-align: center;
  overflow: hidden;
}

/* animasyonlu çerçeve ışıltısı */
.empty-card::after {
  content: "";
  position: absolute;
  inset: -2px;
  border-radius: 26px;
  padding: 2px;
  background: conic-gradient(from 180deg,
      var(--accent), var(--accent-2), var(--accent), var(--accent-2));
  -webkit-mask:
    linear-gradient(#000 0 0) content-box,
    linear-gradient(#000 0 0);
  -webkit-mask-composite: xor;
  mask-composite: exclude;
  animation: spin 6s linear infinite;
  opacity: .35;
}

/* yumuşak parıltı */
.glow {
  position: absolute;
  inset: -40%;
  background: radial-gradient(closest-side, color-mix(in oklab, var(--accent) 35%, transparent), transparent 70%);
  filter: blur(40px);
  animation: float 10s ease-in-out infinite;
  opacity: .25;
}

.icon {
  width: 96px;
  height: 96px;
  margin: 4px auto 10px;
  display: grid;
  place-items: center;
  border-radius: 50%;
  background: linear-gradient(180deg, color-mix(in oklab, var(--accent) 22%, transparent), transparent);
  border: 1px solid var(--stroke);
  box-shadow: inset 0 1px 8px rgba(0, 0, 0, 0.06);
  color: color-mix(in oklab, var(--accent) 70%, var(--fg));
  animation: rise 700ms cubic-bezier(.2, .7, .2, 1) both;
}

.actions {
  display: flex;
  gap: 10px;
  justify-content: center;
  flex-wrap: wrap;
}

.btn {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  padding: 10px 14px;
  border-radius: 12px;
  border: 1px solid var(--stroke);
  background: linear-gradient(180deg, color-mix(in oklab, var(--accent) 18%, transparent), transparent);
  font-weight: 600;
  text-decoration: none;
  transition: transform .15s ease, box-shadow .15s ease, background .2s ease;
  box-shadow: 0 4px 16px rgba(0, 0, 0, 0.08);
  cursor: pointer;
  user-select: none;
}

.btn:hover {
  transform: translateY(-1px);
}

.btn:active {
  transform: translateY(0);
}

.btn.ghost {
  background: transparent;
  backdrop-filter: none;
}

@keyframes spin {
  to {
    transform: rotate(1turn);
  }
}

@keyframes float {

  0%,
  100% {
    transform: translateY(-2%);
  }

  50% {
    transform: translateY(2%);
  }
}

@keyframes rise {
  from {
    transform: translateY(10px);
    opacity: 0;
  }

  to {
    transform: translateY(0);
    opacity: 1;
  }
}

h2 {
  font-size: clamp(20px, 2.4vw, 28px);
  letter-spacing: .2px;
  margin: 6px 0 6px;
}

p {
  margin: 0 auto 18px;
  max-width: 42ch;
  color: var(--muted);
  line-height: 1.5;
}



</style>