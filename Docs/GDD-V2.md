# GAME DESIGN DOCUMENT (GDD)

# Simple Crowd Simulator v2.0

---

# Document Information

| Item | Value |
|------|-------|
| Project | Simple Crowd Simulator |
| Version | 2.0 |
| Engine | Unity 2022.3.62f3 LTS |
| Platform | Windows PC |
| Language | C# |
| Repository Strategy | Git Flow |
| Branch Development | feature/v2-refactor |

---

# Vision

Membuat simulator crowd sederhana sebagai media pembelajaran Unity 3D dengan fokus pada arsitektur project yang rapi, sistem selection seperti game RTS, movement menggunakan NavMesh, serta AI sederhana.

Project ini **bukan membuat game selesai**, tetapi membuat pondasi yang benar agar mudah dikembangkan menjadi simulator yang lebih besar.

---

# Learning Goals

Setelah project selesai diharapkan memahami:

- Unity Project Structure
- Clean Code
- SOLID Principle (dasar)
- Single Responsibility Principle
- Unity Component Architecture
- Git Workflow
- Mouse Input
- Raycast
- UI
- Selection System
- Command System
- NavMesh
- Animator
- Finite State Machine
- Crowd Behaviour
- Collision Avoidance
- Basic Optimization

---

# Gameplay

Player dapat memilih satu atau banyak NPC menggunakan mouse.

NPC yang dipilih dapat diberi perintah untuk berjalan menuju posisi tertentu.

NPC memiliki animasi dan behaviour sederhana.

NPC tidak saling bertabrakan ketika bergerak.

---

# Core Gameplay Loop

Player Select NPC

↓

Selection Manager

↓

Player Give Command

↓

NPC Move

↓

Avoid Other NPC

↓

Destination Reached

↓

Idle

↓

Waiting Next Command

---

# Core Features

## Selection

- Single Selection
- Drag Selection
- Multiple Selection
- Clear Selection

---

## Command

- Click Ground
- Move To Position

---

## NPC Movement

- NavMeshAgent
- Smooth Rotation
- Stop Distance

---

## Animation

- Idle
- Walk

---

## Behaviour

NPC memiliki state:

- Idle
- Walking
- Waiting

---

## Crowd

NPC memiliki:

- Personal Space
- Collision Avoidance
- Smooth Movement

---

## UI

- FPS Counter
- NPC Counter
- Selection Box

---

# Technical Architecture

## Input

MouseInput

Bertugas membaca seluruh input mouse.

Tidak ada script lain yang membaca Input secara langsung.

---

## SelectionManager

Bertugas mengatur:

- Single Selection
- Multi Selection
- Clear Selection
- Selected NPC List

---

## NPCSelection

Bertugas:

- Menyimpan status selected
- Mengubah visual

Tidak menangani movement.

---

## CommandManager

Bertugas memberikan perintah kepada NPC yang sedang dipilih.

---

## NPCMovement

Bertugas menggerakkan NPC menggunakan NavMesh.

---

## NPCBehaviour

Mengatur FSM NPC.

---

## NPCAnimation

Mengatur Animator.

---

## NPCManager

Menyimpan seluruh NPC di scene.

---

## SpawnManager

Spawn NPC.

---

## UI

SelectionBoxUI hanya menggambar kotak seleksi.

Tidak membaca Input.

---

# Final Architecture

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

Animator

---

# Folder Structure

Assets

├── Animations

├── Art

├── Materials

├── NavMesh

├── Prefabs

├── Scenes

├── Scripts

│

├── Core

├── Input

├── Managers

├── NPC

│   ├── Animation

│   ├── Behavior

│   ├── Detection

│   ├── Movement

│   ├── Selection

│

├── UI

└── Utilities

---

# Out of Scope

Tidak dikerjakan pada versi ini.

- Multiplayer
- Combat
- Enemy AI
- Saving
- Inventory
- Quest
- Dialogue
- DOTS
- ECS
- VAT
- Behavior Tree
- GOAP
- Utility AI

---

# Success Criteria

Project dianggap selesai apabila:

✓ Single Selection bekerja

✓ Drag Selection bekerja

✓ NPC dapat menerima command

✓ NPC bergerak menggunakan NavMesh

✓ NPC memiliki animasi Idle & Walk

✓ NPC tidak saling bertabrakan

✓ Struktur project tetap bersih

✓ Seluruh dokumentasi lengkap