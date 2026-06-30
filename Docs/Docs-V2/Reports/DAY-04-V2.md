# Day 04 Report

Project: Simple Crowd Simulator v2.0

Branch:
feature/v2-refactor

Version:
2.0

---

# Objective

Membangun sistem Command agar NPC yang dipilih dapat menerima perintah bergerak menggunakan Right Click.

Versi ini mengubah gameplay dari NPC Random Movement menjadi Player Controlled Movement.

---

# Goals

Target Day 4:

- Move Command
- Right Click Detection
- Command Manager
- NPC Move To Position
- Integrasi Selection dengan Movement

Status:

✅ Completed

---

# Features Added

## 1. Command Manager

Ditambahkan script baru:

Managers/
CommandManager.cs

Responsibilities:

- Menerima perintah dari MouseInput
- Mengambil NPC yang sedang dipilih
- Mengirim tujuan ke setiap NPC

Flow:

Mouse Input

↓

Command Manager

↓

Selected NPC

↓

NPC Movement

---

## 2. Right Click Command

Player sekarang dapat:

- Klik kanan pada Ground
- Memberikan tujuan kepada seluruh NPC yang sedang dipilih

Flow:

Right Click

↓

Raycast

↓

Hit Ground

↓

Command Manager

↓

NPC Move

---

## 3. NPC Manual Movement

NPC tidak lagi bergerak secara acak.

Movement sekarang sepenuhnya dikontrol oleh CommandManager.

---

## 4. MoveTo()

NPCMovement memiliki method baru:

MoveTo(Vector3 destination)

Method ini digunakan CommandManager untuk memberikan tujuan kepada NPC.

---

# Scripts Updated

## MouseInput.cs

Added

- HandleRightClick()

Responsibilities

- Left Click
- Drag Selection
- Right Click Command

---

## CommandManager.cs

New Script

Responsibilities

- Move Selected NPCs
- Dispatch Move Command

---

## NPCMovement.cs

Removed

- Random Destination
- Random Patrol
- Automatic Destination

Added

- MoveTo()

NPC sekarang hanya bergerak ketika menerima command.

---

# Removed Features

Karena perubahan gameplay dari v1 menjadi v2, beberapa sistem lama dihapus.

Removed:

- Random Walk
- Auto Patrol
- Walk Radius
- Random Destination

Alasan:

Gameplay v2 menggunakan Player Command System.

---

# Architecture

Mouse

↓

MouseInput

↓

SelectionManager

↓

CommandManager

↓

NPCMovement

↓

NavMeshAgent

---

# Testing

## Test 1

Single Selection

PASS

---

## Test 2

Multiple Selection

PASS

---

## Test 3

Right Click Command

PASS

---

## Test 4

Selected NPC Movement

PASS

---

## Test 5

No Selected NPC

PASS

---

# Current Features

✅ Single Selection

✅ Drag Selection

✅ Multiple Selection

✅ Selection Highlight

✅ Right Click Move

✅ Move Command

---

# Known Issues

NPC masih bergerak menuju satu titik yang sama.

Belum ada:

- Formation Movement
- Crowd Spacing
- Collision Avoidance
- FSM
- Animation

Akan dikerjakan pada milestone berikutnya.

---

# Lessons Learned

Hari ini mempelajari:

- Command Pattern (sederhana)
- Responsibility Separation
- Raycast Command
- NavMeshAgent.SetDestination()
- Manager Communication

---

# Milestone

Milestone 3

Command System

Status

✅ COMPLETED

---

# Next Target

Day 5

Formation Movement

Target:

- Multi Destination
- Formation Algorithm
- Auto Position Offset
- RTS Style Movement