# GAME DESIGN DOCUMENT (GDD)

# Simple Crowd Simulator v2.0

---

# Project Information

| Item                     | Description                          |
| ------------------------ | ------------------------------------ |
| **Project Name**         | Simple Crowd Simulator               |
| **Version**              | 2.0                                  |
| **Engine**               | Unity 2022.3.62f3 LTS                |
| **Genre**                | 3D Simulation / RTS Learning Project |
| **Platform**             | Windows (PC)                         |
| **Programming Language** | C#                                   |

---

# Project Goal

Membangun simulasi kerumunan sederhana yang dapat dikendalikan oleh pemain menggunakan sistem seleksi dan perintah (Selection & Command System).

Project ini bertujuan sebagai media pembelajaran Unity 3D dengan fokus pada arsitektur project, AI dasar, movement menggunakan NavMesh, sistem seleksi NPC, animasi karakter, dan interaksi antar NPC.

---

# Learning Objectives

Setelah menyelesaikan versi ini diharapkan memahami:

* Unity Project Architecture
* Clean Folder Structure
* Mouse Input
* Raycast
* Selection System
* Multi Selection
* Drag Selection
* Command System
* NavMesh Navigation
* Animator Controller
* Animation State
* NPC Behaviour
* Finite State Machine (FSM)
* Collision Avoidance
* Crowd AI Basics
* Debugging
* Code Refactoring

---

# Gameplay

Pemain bertindak sebagai pengendali sekelompok NPC.

Pemain dapat:

* Memilih satu NPC menggunakan klik kiri.
* Memilih beberapa NPC menggunakan drag selection.
* Membatalkan pilihan dengan klik area kosong.
* Memberikan perintah bergerak kepada NPC yang sedang dipilih.

NPC akan:

* Bergerak menuju tujuan menggunakan NavMesh.
* Menghindari NPC lain selama bergerak.
* Mengubah animasi sesuai state.
* Berhenti ketika mencapai tujuan.

Project ini tidak memiliki kondisi menang atau kalah dan difokuskan sebagai media pembelajaran.

---

# Core Gameplay Loop

```text
Player Select NPC
        ↓
Single / Multi Selection
        ↓
Click Ground
        ↓
Raycast Ground
        ↓
Move Command
        ↓
NPC Navigation
        ↓
Collision Avoidance
        ↓
Destination Reached
        ↓
Idle
```

---

# Player Controls

| Input                 | Function          |
| --------------------- | ----------------- |
| Left Click NPC        | Select Single NPC |
| Mouse Drag            | Multi Selection   |
| Left Click Ground     | Move Selected NPC |
| Left Click Empty Area | Deselect          |

---

# Features

## Selection System

* Single Selection
* Multi Selection
* Drag Selection Box
* Selected Highlight
* Deselect

---

## Command System

* Move Command
* Group Movement
* Destination Assignment

---

## Input System

* Mouse Left Click
* Mouse Drag
* Raycast Detection

---

## NPC Movement

* Click To Move
* NavMesh Navigation
* Smooth Rotation
* Stop Distance
* Adjustable Move Speed

---

## Animation System

* Idle
* Walk
* Run (Optional)

Animasi berubah secara otomatis berdasarkan kecepatan NPC.

---

## Behaviour System

NPC memiliki beberapa state.

### Idle

NPC diam dan menunggu perintah.

---

### Selected

NPC sedang dipilih oleh pemain.

NPC akan menampilkan indikator visual.

---

### Moving

NPC bergerak menuju tujuan.

Animasi Walk aktif.

---

### Avoiding

NPC menjaga jarak dan menghindari NPC lain.

---

### Arrived

NPC telah mencapai tujuan.

Kembali ke state Idle.

---

## Crowd System

NPC mampu:

* Menjaga Personal Space
* Menghindari tabrakan
* Bergerak secara halus
* Mengikuti jalur NavMesh

---

## UI

* NPC Counter
* FPS Counter
* Selected NPC Counter (Optional)

---

# AI State Diagram

```text
Idle
 ↓
Selected
 ↓
Moving
 ↓
Avoiding
 ↓
Moving
 ↓
Arrived
 ↓
Idle
```

---

# Visual Feedback

## Selected NPC

* Selection Circle
* Highlight Material
* Outline (Optional)

---

## Destination

* Destination Marker (Optional)

---

## Selection Box

* Semi Transparent Rectangle

---

# Technical Scope

## Scene

* Ground
* Camera
* Directional Light

---

## NPC

* Capsule Character
* NavMeshAgent
* Animator
* Capsule Collider
* Selection Indicator

---

## Systems

* Selection Manager
* Input Manager
* NPC Manager
* Command Manager
* Spawn Manager
* UI Manager

---

# Project Structure

```text
Assets
│
├── Animations
├── Art
├── Materials
├── Prefabs
├── Scenes
│
├── Scripts
│   ├── Core
│   ├── Input
│   ├── Managers
│   ├── NPC
│   │   ├── Animation
│   │   ├── Behavior
│   │   ├── Controller
│   │   ├── Detection
│   │   ├── Movement
│   │   └── Selection
│   │
│   ├── UI
│   └── Utilities
│
└── Settings
```

---

# Development Roadmap

## Phase 1

Project Refactoring

* Rapikan struktur folder
* Pisahkan script berdasarkan tanggung jawab
* Bersihkan kode v1.0

---

## Phase 2

Selection System

* Single Selection
* Highlight NPC
* Deselect

---

## Phase 3

Multi Selection

* Drag Selection
* Selection Box
* Multiple Selection

---

## Phase 4

Command System

* Click Ground
* Move Selected NPC
* Group Movement

---

## Phase 5

Movement & Animation

* NavMesh Movement
* Rotation
* Idle Animation
* Walk Animation

---

## Phase 6

Behaviour System

* FSM
* Idle
* Selected
* Moving
* Arrived

---

## Phase 7

Crowd Intelligence

* NPC Detection
* Personal Space
* Collision Avoidance

---

## Phase 8

Polishing

* Debug Gizmos
* UI Improvements
* Code Cleanup
* Optimization
* Build

---

# Technical Constraints

Target Performance

* 100 NPC
* Stable 60 FPS
* Windows Platform

---

# Out of Scope

Versi ini tidak mencakup:

* Multiplayer
* Inventory
* Combat
* Enemy AI
* Quest System
* Dialogue
* Saving System
* DOTS / ECS
* Vertex Animation Texture (VAT)
* Behavior Tree
* GOAP
* Utility AI

---

# Success Criteria

Project dianggap selesai apabila:

* Player dapat memilih satu NPC.
* Player dapat memilih banyak NPC menggunakan drag selection.
* NPC yang dipilih memiliki indikator visual.
* Hanya NPC yang dipilih menerima perintah.
* NPC bergerak menuju tujuan menggunakan NavMesh.
* NPC berpindah animasi Idle dan Walk secara otomatis.
* NPC menghindari tabrakan dengan NPC lain.
* UI menampilkan jumlah NPC.
* UI menampilkan FPS.
* Struktur project tetap rapi dan mudah dikembangkan.

---

# Future Features

## Version 2.1

* Formation Movement
* Leader-Follower
* Better Collision Avoidance

---

## Version 3.0

* Waypoint System
* Patrol System
* Queue System
* Job System
* Object Pooling

---

# Version History

## Version 1.0

* Random NPC Movement
* Spawn Manager
* NPC Counter
* FPS Counter
* Basic Optimization

---

## Version 2.0

* Single Selection
* Multi Selection
* Drag Selection
* Command System
* Click To Move
* Animation Controller
* FSM Behaviour
* Crowd Avoidance
* Project Refactoring
* Improved Project Architecture
