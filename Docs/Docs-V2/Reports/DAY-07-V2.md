# Day 7 - Formation Visualizer

## Step 1 - Membuat FormationVisualizer

### Tujuan

Membangun komponen yang bertugas menyimpan seluruh FormationSlot hasil generate agar dapat digunakan untuk visualisasi menggunakan Gizmos pada step berikutnya.

---

## Yang Dikerjakan

- Membuat script `FormationVisualizer.cs`
- Menerapkan Singleton Pattern
- Menambahkan cache `List<FormationSlot>`
- Menambahkan property `IReadOnlyList<FormationSlot>`
- Menambahkan method:
  - `SetSlots()`
  - `ClearSlots()`

---

## Arsitektur

CommandManager

↓

FormationGenerator

↓

FormationVisualizer (Cache Slot)

↓

FormationAssigner

↓

NPC Movement

---

## Hasil

FormationVisualizer kini dapat menyimpan seluruh slot terakhir yang dihasilkan oleh FormationGenerator.

Belum ada visualisasi pada Scene View. Tahap ini hanya mempersiapkan data yang akan digunakan pada langkah berikutnya.

---

## Status

✅ Step 1 Selesai

Progress Day 7:

- [x] Step 1 - FormationVisualizer
- [ ] Step 2 - Menghubungkan CommandManager
- [ ] Step 3 - Menggambar Gizmos
- [ ] Step 4 - Pewarnaan Slot
- [ ] Step 5 - Debug Visual

## Step 2 - Menghubungkan CommandManager

### Tujuan

Menghubungkan CommandManager dengan FormationVisualizer agar setiap formasi yang baru dibuat dapat disimpan dan digunakan untuk proses visualisasi.

---

## Yang Dikerjakan

- Memodifikasi `CommandManager.cs`
- Menambahkan pemanggilan:
  - `FormationVisualizer.Instance.SetSlots(slots)`
- Menambahkan pengecekan `Instance != null` untuk mencegah NullReferenceException.

---

## Alur Baru

Mouse Right Click

↓

GenerateRectangle()

↓

FormationVisualizer.SetSlots()

↓

AssignRelative()

↓

NPC Movement

---

## Hasil

Setiap kali pemain memberikan perintah bergerak, seluruh FormationSlot yang baru dibuat langsung disimpan oleh FormationVisualizer.

Belum ada perubahan visual pada Scene View karena proses penggambaran Gizmos akan dilakukan pada Step 3.

---

## Status

✅ Step 2 Selesai

Progress Day 7:

- [x] Step 1 - FormationVisualizer
- [x] Step 2 - Hubungkan CommandManager
- [ ] Step 3 - Menggambar Gizmos
- [ ] Step 4 - Pewarnaan Slot
- [ ] Step 5 - Debug Visual

## Step 3 - Menggambar Gizmos

### Tujuan

Menampilkan seluruh FormationSlot pada Scene View menggunakan Unity Gizmos agar formasi dapat divisualisasikan selama proses debugging.

---

## Yang Dikerjakan

- Menambahkan method `OnDrawGizmos()`
- Menggambar setiap FormationSlot menggunakan `Gizmos.DrawSphere()`
- Menambahkan parameter `_slotRadius` agar ukuran visual slot dapat diatur melalui Inspector.
- Menggunakan warna hijau sebagai warna default semua slot.

---

## Alur

CommandManager

↓

FormationGenerator

↓

FormationVisualizer.SetSlots()

↓

OnDrawGizmos()

↓

Scene View

---

## Hasil

Setiap kali pemain memberikan perintah bergerak, slot-slot formasi langsung terlihat pada Scene View sebagai bola hijau kecil.

Visualisasi ini mempermudah proses debugging dan verifikasi posisi formasi.

---

## Status

✅ Step 3 Selesai

Progress Day 7

- [x] Step 1 - FormationVisualizer
- [x] Step 2 - Hubungkan CommandManager
- [x] Step 3 - Menggambar Gizmos
- [ ] Step 4 - Pewarnaan Slot
- [ ] Step 5 - Debug Visual Lengkap

## Step 4 - Pewarnaan Slot Berdasarkan Status

### Tujuan

Memberikan visualisasi status setiap FormationSlot menggunakan warna berbeda agar proses debugging formasi menjadi lebih mudah.

---

## Yang Dikerjakan

- Mengubah warna Gizmos berdasarkan `FormationSlotState`.
- Menggunakan `switch` untuk menentukan warna:
  - Hijau (`Free`)
  - Kuning (`Reserved`)
  - Merah (`Occupied`)
- Menggunakan `_slotRadius` sebagai ukuran sphere agar dapat diatur dari Inspector.
- Menambahkan visual garis vertikal menggunakan `Debug.DrawLine()`.

---

## Alur

FormationSlot.State

↓

OnDrawGizmos()

↓

Switch State

↓

Set Gizmos.color

↓

DrawSphere()

---

## Hasil

Visualisasi formasi kini menunjukkan status setiap slot secara real-time:

- 🟢 Slot kosong.
- 🟡 Slot sudah dipesan oleh NPC.
- 🔴 Slot telah ditempati NPC.

Perubahan warna mempermudah proses debugging dan validasi sistem formasi.

---

## Status

✅ Step 4 Selesai

Progress Day 7

- [x] Step 1 - FormationVisualizer
- [x] Step 2 - Hubungkan CommandManager
- [x] Step 3 - Menggambar Gizmos
- [x] Step 4 - Pewarnaan Slot
- [ ] Step 5 - Debug Visual Lengkap