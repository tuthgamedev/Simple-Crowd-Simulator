# Day 2 — Selection System

**Version:** v2.0
**Branch:** `feature/v2-refactor`

---

# Objective

Membangun fondasi sistem seleksi NPC.

Pada tahap ini pemain dapat memilih satu NPC menggunakan klik kiri mouse.

Belum ada sistem movement.

Belum ada drag selection.

Belum ada command system.

Hari ini hanya berfokus pada proses memilih NPC.

---

# Learning Objectives

Setelah menyelesaikan Day 2 diharapkan memahami:

* Mouse Input
* Screen Point Raycast
* Physics Raycast
* Layer Mask
* Component Detection
* Selection Logic
* Clean Code Architecture

---

# Features To Develop

## Single Selection

Player dapat memilih satu NPC.

Jika NPC dipilih:

* NPC menjadi Selected.
* NPC sebelumnya akan kehilangan status Selected.
* Hanya ada satu NPC yang aktif.

---

## Deselect

Klik area kosong.

↓

Semua NPC menjadi tidak terseleksi.

---

## Selection Highlight

NPC yang dipilih akan memiliki indikator visual.

Implementasi awal:

* Mengubah warna material

Versi berikutnya:

* Selection Circle
* Outline Shader

---

# New Scripts

## Managers

SelectionManager.cs

Tugas:

* Menyimpan NPC yang sedang dipilih.
* Mengatur proses Select.
* Mengatur proses Deselect.

---

## Input

MouseInput.cs

Tugas:

* Membaca input mouse.
* Melakukan Raycast.
* Mengirim hasil Raycast ke SelectionManager.

---

## NPC

NPCSelection.cs

Tugas:

* Menyimpan status Selected.
* Mengubah visual NPC.
* Menyediakan fungsi Select() dan Deselect().

---

# Scene Requirements

NPC harus memiliki:

* Collider
* Layer "NPC"

Ground harus memiliki:

* Layer "Ground"

Camera harus dapat melihat seluruh area permainan.

---

# Acceptance Criteria

Project dianggap selesai apabila:

* Klik NPC memilih NPC tersebut.
* Klik NPC lain memindahkan seleksi.
* Klik area kosong menghapus seleksi.
* Tidak terjadi error pada Console.
* Struktur project tetap rapi.

---

# Not Included

Hari ini tidak mengerjakan:

* Drag Selection
* NPC Movement
* Animation
* FSM
* Collision Avoidance
* Group Command

---

## Concept Explanation

Sebelum NPC bisa berjalan, kita harus mengetahui **NPC mana yang ingin dikendalikan**.

Bayangkan kita mempunyai 20 NPC.

Jika pemain menekan mouse ke tanah, bagaimana game mengetahui NPC mana yang harus bergerak?

Jawabannya adalah:

NPC harus dipilih terlebih dahulu.

Karena itu kita membangun **Selection System** sebelum membuat Movement System.

---

### Analogi Sederhana

Bayangkan kamu seorang guru.

Di kelas ada 20 murid.

Kalau kamu berkata:

> "Maju ke depan!"

Semua murid akan bingung.

Tetapi jika kamu berkata:

> "Budi, maju ke depan."

Barulah Budi bergerak.

Game juga bekerja dengan cara yang sama.

NPC harus mengetahui bahwa dirinya adalah NPC yang sedang dipilih.

Barulah nanti ia akan menerima perintah.

---

### Flow Selection

Player Klik NPC

↓

Raycast mengenai NPC

↓

Selection Manager menerima informasi

↓

NPC menjadi Selected

↓

NPC menampilkan indikator visual

↓

Menunggu perintah berikutnya

---

### Goal Hari Ini

Hari ini kita **belum membuat NPC bergerak**.

Target hari ini hanya:

* Memilih NPC.
* Menghapus pilihan NPC.
* Memahami bagaimana Selection System bekerja.

Movement akan dibuat pada tahap berikutnya.

# Expected Result

Player dapat memilih satu NPC menggunakan mouse.

NPC yang dipilih memiliki indikator visual.

Belum ada pergerakan NPC.

Selection System menjadi fondasi untuk Day 3.

## Progress — Step 1

### Selection Manager

Pada langkah pertama dibuat `SelectionManager` sebagai pusat pengelolaan sistem seleksi.

Tanggung jawab `SelectionManager`:

* Menyimpan referensi NPC yang sedang dipilih.
* Memilih NPC baru.
* Membatalkan pilihan NPC sebelumnya.
* Menyediakan fungsi untuk menghapus seluruh seleksi.

Pada tahap ini belum ada interaksi dengan mouse maupun visual NPC. `SelectionManager` hanya bertugas mengatur logika seleksi sehingga dapat digunakan kembali oleh sistem input apa pun (mouse, touch screen, atau gamepad) di masa depan.

**Status:** ✅ Completed

## Progress — Step 2

### NPC Selection Component

Dibuat `NPCSelection.cs` sebagai komponen yang dipasang pada setiap NPC.

Tanggung jawab komponen ini:

* Menyimpan status apakah NPC sedang dipilih.
* Menyediakan fungsi `Select()`.
* Menyediakan fungsi `Deselect()`.
* Menyediakan properti hanya-baca `IsSelected` untuk dicek oleh sistem lain.

Pada tahap ini komponen belum mengubah tampilan NPC. Visual seperti outline, perubahan material, atau selection circle akan ditambahkan pada tahap berikutnya agar logika dan tampilan tetap terpisah.

**Status:** ✅ Completed

## Progress — Step 3

### Mouse Input

Dibuat `MouseInput.cs` sebagai penghubung antara pemain dan Selection System.

Tanggung jawab komponen ini:

* Membaca klik kiri mouse.
* Membuat Raycast dari posisi mouse ke dunia 3D.
* Mendeteksi apakah objek yang diklik memiliki komponen `NPCSelection`.
* Mengirim hasil seleksi ke `SelectionManager`.

Pada tahap ini `MouseInput` tidak mengubah status NPC secara langsung. Seluruh keputusan tetap didelegasikan ke `SelectionManager`, sehingga sistem input tetap terpisah dari logika seleksi.

**Status:** ✅ Completed
