# GAME DESIGN DOCUMENT (GDD)

# Simple Crowd Simulator v2.0

---

# Project Information

**Project Name**
Simple Crowd Simulator

**Version**
2.0

**Engine**
Unity 2022.3.62f3 LTS

**Genre**
3D Simulation

**Platform**
Windows (PC)

**Programming Language**
C#

---

# Project Goal

Membangun simulasi kerumunan sederhana yang dapat dikendalikan oleh pemain menggunakan mouse.

Project ini bertujuan mempelajari dasar-dasar pembuatan game 3D di Unity melalui implementasi sistem movement, AI sederhana, animasi karakter, dan interaksi antar NPC.

---

# Learning Objectives

Setelah menyelesaikan versi ini, diharapkan mampu memahami:

* Unity Project Architecture
* Mouse Input
* Raycast
* NavMesh Navigation
* Animator Controller
* Animation State
* NPC Behaviour
* Finite State Machine (FSM)
* Collision Avoidance
* Basic Crowd AI
* Debugging
* Code Refactoring

---

# Gameplay

Pemain mengontrol tujuan NPC menggunakan klik mouse.

NPC akan berjalan menuju titik yang dipilih.

Selama berjalan NPC akan:

* Menghindari NPC lain
* Mengubah animasi sesuai keadaan
* Berhenti saat mencapai tujuan
* Menunggu instruksi berikutnya

Tidak ada sistem menang atau kalah.

Simulator hanya digunakan sebagai media pembelajaran.

---

# Core Gameplay Loop

Player Click

↓

Raycast

↓

Target Position

↓

NPC Move

↓

Avoid Other NPC

↓

Destination Reached

↓

Idle

↓

Waiting Next Click

---

# Features

## Input System

* Mouse Left Click
* Raycast Ground Detection
* Destination Marker (Opsional)

---

## NPC Movement

* Click To Move
* NavMesh Navigation
* Smooth Rotation
* Stop Distance
* Movement Speed

---

## Animation System

* Idle
* Walk
* Run (Opsional)

Animasi akan berubah otomatis berdasarkan kecepatan NPC.

---

## Behaviour System

NPC memiliki beberapa state.

### Idle

NPC diam.

Animasi Idle aktif.

### Walking

NPC berjalan menuju tujuan.

Animasi Walk aktif.

### Waiting

NPC telah mencapai tujuan.

NPC berhenti.

### Avoiding

NPC menghindari NPC lain apabila terlalu dekat.

---

## Crowd System

NPC dapat:

* Menjaga jarak
* Menghindari tabrakan
* Bergerak secara halus
* Mengikuti jalur NavMesh

---

## UI

* NPC Counter
* FPS Counter

---

# AI State Diagram

Idle

↓

Walking

↓

Destination Reached

↓

Waiting

↓

Idle

Selama Walking:

Walking

↓

Detect NPC

↓

Avoiding

↓

Walking

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

---

## Systems

* Input Manager
* NPC Manager
* Spawn Manager
* UI Manager

---

# Project Structure

Assets

├── Animations

├── Art

├── Materials

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

│

├── UI

│

└── Utilities

---

# Development Roadmap

## Phase 1

Project Refactoring

* Rapikan struktur folder
* Pisahkan script berdasarkan tanggung jawab
* Bersihkan kode versi 1.0

---

## Phase 2

Mouse Input

* Raycast
* Click Position
* Target Destination

---

## Phase 3

NPC Movement

* Click To Move
* Rotation
* Stop Distance

---

## Phase 4

Animation

* Idle
* Walk
* Animator Controller

---

## Phase 5

Behaviour

* FSM
* Idle
* Walking
* Waiting

---

## Phase 6

Crowd Intelligence

* NPC Detection
* Personal Space
* Collision Avoidance

---

## Phase 7

Polishing

* Debug Gizmos
* Code Cleanup
* Optimization
* Build

---

# Out of Scope

Versi ini tidak akan membahas:

* Multiplayer
* Inventory
* Combat
* Enemy AI
* Quest System
* Dialogue
* Saving System
* DOTS/ECS
* Vertex Animation Texture (VAT)
* Behavior Tree
* GOAP
* Utility AI

---

# Success Criteria

Project dianggap selesai apabila memenuhi seluruh kondisi berikut:

* NPC dapat bergerak menuju titik hasil klik mouse.
* NPC berpindah animasi Idle dan Walk secara otomatis.
* NPC tidak saling bertabrakan secara langsung.
* NPC memiliki state Idle, Walking, Waiting, dan Avoiding.
* UI menampilkan jumlah NPC dan FPS.
* Struktur project tetap rapi dan mudah dikembangkan.

---

# Version History

## v1.0

* Random Movement
* Spawn Manager
* NPC Counter
* FPS Counter
* Basic Optimization

## v2.0

* Click To Move
* Animation Controller
* FSM Behaviour
* Crowd Avoidance
* Project Refactoring
