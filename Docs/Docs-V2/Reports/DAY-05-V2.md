# Day 05 Report

Project: Simple Crowd Simulator v2.0

Date:
(isi tanggal hari ini)

Branch:
feature/v2-refactor

---

# Goal

Membangun sistem Command RTS sehingga NPC tidak lagi berjalan ke satu titik yang sama, tetapi membentuk formasi ketika menerima perintah Move.

---

# Target

- Grid Formation
- Formation Offset
- Center Formation
- Formation Direction Preparation

Status:

✔ Completed

---

# Features Added

## 1. Grid Formation

NPC yang dipilih tidak lagi menuju satu posisi.

Setiap NPC mendapatkan slot sendiri pada grid.

Contoh:

□ □ □

□ □ □

---

## 2. Dynamic Column Count

Jumlah kolom dihitung otomatis.

Formula:

columns = Ceil(Sqrt(NPC Count))

Contoh:

1 NPC -> 1 Column

4 NPC -> 2 Columns

9 NPC -> 3 Columns

16 NPC -> 4 Columns

---

## 3. Row Calculation

Jumlah baris dihitung otomatis.

Formula:

rows = Ceil(NPC Count / Columns)

---

## 4. Formation Offset

Setiap NPC memperoleh offset.

Contoh:

NPC0

Offset (0,0)

NPC1

Offset (2,0)

NPC2

Offset (4,0)

NPC3

Offset (0,-2)

---

## 5. Center Formation

Formasi tidak lagi dimulai dari pojok kiri atas.

Seluruh grid dipusatkan terhadap titik klik pemain.

Hasil:

Sebelum

X □ □ □

Sesudah

□ □ □

□ X □

□ □ □

---

## 6. Direction Calculation

Menambahkan perhitungan arah gerakan menggunakan:

Vector3 direction

Normalize()

Direction ini akan digunakan pada Day 6 untuk melakukan rotasi formasi.

---

# Files Updated

Assets/
│
├── Scripts/
│
├── Input/
│   └── MouseInput.cs
│
├── Managers/
│   ├── SelectionManager.cs
│   └── CommandManager.cs
│
├── NPC/
│   ├── NPCMovement.cs
│   └── Selection/
│       └── NPCSelection.cs

---

# Learning Notes

Materi baru yang dipelajari:

- Grid Formation
- Row & Column Calculation
- Offset Position
- Center Pivot
- Vector Normalize
- Direction Vector
- RTS Command Concept

---

# Testing Result

Tested:

✔ Single Selection

✔ Multi Selection

✔ Drag Selection

✔ Move Command

✔ Grid Formation

✔ Center Formation

✔ Dynamic NPC Count

Result:

PASS

---

# Problems Found

Formasi masih mengikuti World Axis.

Belum mengikuti arah pergerakan NPC.

Status:

Planned for Day 6.

---

# Next Day

Day 6

Target:

- Rotate Formation
- Quaternion LookRotation
- Formation Facing Direction
- RTS Style Movement