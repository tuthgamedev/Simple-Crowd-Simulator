# Day 03 Report

Project: Simple Crowd Simulator v2.0

Version: 2.0

Branch:
feature/v2-refactor

Date:
(isi tanggal hari ini)

---

# Objective

Membangun sistem Selection yang menjadi pondasi utama gameplay.

Target yang ingin dicapai:

- Single Selection
- Drag Box Selection
- Multiple NPC Selection
- Visual Selection
- Selection Framework

---

# Features Implemented

## 1. Single Selection

Player dapat memilih satu NPC menggunakan Left Click.

Flow:

Mouse Left Click

↓

Raycast

↓

Hit NPC

↓

SelectionManager

↓

NPC Selected

---

## 2. Drag Selection Box

Player dapat melakukan drag mouse.

Selection Box akan muncul mengikuti posisi mouse.

Flow:

Mouse Down

↓

Selection Box Show

↓

Mouse Drag

↓

Selection Box Resize

↓

Mouse Up

↓

Selection Box Hide

---

## 3. Multiple Selection

Saat drag selesai,

SelectionManager akan:

- Menghitung seluruh NPC
- Mengubah World Position menjadi Screen Position
- Mengecek apakah NPC berada di dalam Rectangle Selection
- Menambahkan NPC ke Selected List

---

## 4. Selection Highlight

NPC yang terpilih akan:

- Menggunakan Selected Material

NPC yang tidak dipilih:

- Menggunakan Normal Material

---

## 5. Click vs Drag Detection

Ditambahkan Drag Threshold.

Apabila mouse hanya berpindah sedikit:

→ dianggap Click.

Apabila mouse berpindah melewati threshold:

→ dianggap Drag Selection.

Hal ini mencegah konflik antara Single Selection dan Drag Selection.

---

# Scripts Updated

## MouseInput.cs

Responsibilities:

- Mouse Down
- Mouse Drag
- Mouse Up
- Click Detection
- Drag Detection

Tidak lagi menangani visual Selection Box.

---

## SelectionManager.cs

Responsibilities:

- Single Selection
- Multiple Selection
- Clear Selection
- Add Selection
- Remove Selection
- Rectangle Selection

SelectionManager menjadi pusat seluruh sistem Selection.

---

## NPCSelection.cs

Responsibilities:

- Menyimpan status Selected
- Mengubah Material
- Menampilkan Visual Selection

NPC tidak mengetahui SelectionManager.

---

## SelectionBoxUI.cs

Responsibilities:

- Show Selection Box
- Resize Selection Box
- Hide Selection Box

Tidak memiliki logika Selection.

Hanya bertugas menampilkan UI.

---

# Architecture

Mouse

↓

MouseInput

↓

SelectionManager

↓

NPCSelection

↓

SelectionBoxUI

---

# Current Features

✅ Single Selection

✅ Drag Selection

✅ Multi Selection

✅ Selection Highlight

✅ Click Detection

✅ Drag Detection

---

# Testing Result

## Test 1

Click NPC

Result

PASS

---

## Test 2

Click Ground

Result

PASS

---

## Test 3

Drag Selection

Result

PASS

---

## Test 4

Multiple NPC Selection

Result

PASS

---

## Test 5

Selection Highlight

Result

PASS

---

# Known Limitations

Belum tersedia:

- Move Command
- Right Click Command
- Formation Movement
- FSM
- Animation State
- Crowd Avoidance

Fitur tersebut akan dikerjakan pada milestone berikutnya.

---

# Lessons Learned

Selama Day 3 dipelajari konsep:

- Raycast
- Screen Space
- World Space
- Rect
- Drag Detection
- Separation of Responsibility
- Selection Manager Pattern

---

# Milestone Status

Milestone 2

Selection System

Status:

✅ COMPLETED

---

# Next Target

Day 4

Command System

Target:

- Right Click Command
- Move Selected NPC
- NavMeshAgent Movement
- Command Architecture
