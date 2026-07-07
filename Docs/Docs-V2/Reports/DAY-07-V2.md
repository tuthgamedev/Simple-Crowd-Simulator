# Day 7 - Formation Visualization System

Tanggal: xx/xx/2026

---

# Tujuan

Pada Day 7 fokus utama adalah membangun sistem visualisasi formasi sehingga pemain dapat melihat posisi tujuan setiap NPC sebelum mereka sampai di lokasi.

Selain itu, sistem slot juga mulai memiliki lifecycle yang jelas (Free → Reserved → Occupied → Free).

---

# Progress

## ✅ Step 1 - Formation Visualizer

Membuat singleton `FormationVisualizer`.

Fungsi:

- Menyimpan daftar slot aktif.
- Menjadi pusat visualisasi formasi.
- Dapat diakses dari CommandManager.

Class:

- FormationVisualizer.cs

---

## ✅ Step 2 - Menghubungkan CommandManager

Setelah formasi selesai dibuat oleh `FormationGenerator`, daftar slot langsung dikirim ke FormationVisualizer.

Flow:

CommandManager

↓

FormationGenerator

↓

FormationVisualizer.SetSlots()

---

## ✅ Step 3 - Gizmos Debug

Menambahkan visualisasi slot menggunakan Gizmos.

Visual:

- Garis vertikal merah
- Sphere merah

Digunakan hanya untuk debugging di Scene View.

---

## ✅ Step 4 - Runtime Formation Marker

Menambahkan object marker yang muncul saat game berjalan.

Class baru:

- FormationMarker.cs

Fungsi:

- Menampilkan posisi slot di Game View.
- Tidak lagi bergantung pada Gizmos.

---

## ✅ Step 5 - Spawn Marker

FormationVisualizer sekarang dapat:

- Menghapus marker lama.
- Membuat marker baru.
- Menempatkan marker sesuai slot.

Flow:

Generate Slot

↓

Destroy Marker Lama

↓

Instantiate Marker Baru

↓

Marker muncul di Game View

---

## ✅ Step 6 - Slot State Event

FormationSlot sekarang memiliki event.

```csharp
OnStateChanged
```

Marker tidak lagi di-update secara manual.

Flow:

FormationSlot

↓

OnStateChanged

↓

FormationMarker

↓

Update Warna

Keuntungan:

- Decoupled
- Mudah dikembangkan
- Tidak perlu polling

---

## ✅ Step 7 - Auto Hide Marker

Marker otomatis menghilang setelah seluruh NPC selesai bergerak.

Flow:

Klik kanan

↓

Marker muncul

↓

NPC berjalan

↓

Semua NPC mencapai tujuan

↓

Marker menghilang

---

# Perubahan Arsitektur

Sebelumnya:

CommandManager

↓

FormationSlot

↓

NPC

↓

Marker

Sekarang:

FormationSlot

↓

Event

↓

FormationMarker

Marker tidak lagi bergantung pada CommandManager.

---

# Slot Lifecycle

Free

↓

Reserve()

↓

Reserved

↓

Occupy()

↓

Occupied

↓

Release()

↓

Free

Seluruh perubahan state sekarang memiliki event.

---

# File yang Dibuat

Assets/
Scripts/

Formation/

- FormationVisualizer.cs
- FormationMarker.cs
- FormationSlot.cs

Managers/

- CommandManager.cs

NPC/

- NPCMovement.cs

---

# Fitur yang Berhasil

✔ Formation Gizmos

✔ Runtime Formation Marker

✔ Marker Spawn

✔ Marker Destroy

✔ Slot Reserve

✔ Slot Occupied

✔ Slot Release

✔ Slot Event

✔ Marker mengikuti perubahan state

✔ Marker Auto Hide

---

# Hasil Day 7

Sistem visualisasi formasi kini sudah lengkap.

Pemain dapat:

- Melihat posisi formasi.
- Melihat status slot.
- Mengetahui slot yang sedang digunakan.
- Marker otomatis hilang setelah pergerakan selesai.

Sistem ini menjadi fondasi untuk pengembangan fitur formasi yang lebih kompleks pada Day 8.

---

# Roadmap Selanjutnya (Day 8)

Fokus Day 8 adalah meningkatkan kualitas sistem formasi agar terasa seperti RTS modern.

Target:

- Dynamic Formation
- Slot Reassignment
- Slot Swapping
- Path Optimization
- Anti Crossing
- Better Local Avoidance
- Dynamic Rotation
- Formation Cohesion