# Simple Crowd Simulator

A beginner-friendly crowd simulation project built with Unity 2022.3.62f3 LTS.

This project was created as a learning exercise to understand the fundamentals of 3D game development in Unity, including scene creation, NPC movement, NavMesh navigation, spawning systems, UI systems, and basic performance monitoring.

---

## Project Overview

The simulator generates multiple NPCs that navigate a 3D environment using Unity's NavMesh system.

Each NPC:

* Selects a random destination
* Moves using NavMeshAgent
* Chooses a new destination after reaching its target

The project also includes:

* Dynamic NPC spawning
* NPC count monitoring
* FPS monitoring
* Basic optimization concepts

---

## Features

### Core Systems

* Random NPC Movement
* NavMesh Navigation
* Spawn Manager
* NPC Registry
* Runtime NPC Spawning
* NPC Counter UI
* FPS Counter UI

### Learning Topics

* Unity Interface
* Scene Management
* Prefabs
* C# Scripting
* NavMesh System
* UI Development
* Game Optimization Basics
* Git & GitHub Workflow

---

## Project Structure

```text
Assets
├── Art
│   ├── Materials
│   ├── Models
│   └── Textures
│
├── Prefabs
│   └── NPC.prefab
│
├── Scenes
│   └── MainScene
│
├── Scripts
│   ├── NPC
│   │   └── NPCMovement.cs
│   │
│   ├── Managers
│   │   ├── SpawnManager.cs
│   │   └── NPCRegistry.cs
│   │
│   └── UI
│       ├── UIManager.cs
│       └── SpawnButton.cs
│
└── TextMesh Pro
```

---

## Unity Version

Unity 2022.3.62f3 LTS

---

## Current Version

v1.0

Status:

Prototype Complete

Completed Scope:

* Scene Setup
* NPC Creation
* Prefab Workflow
* NavMesh Navigation
* Random Movement
* Spawn System
* NPC Counter
* FPS Counter
* Basic Optimization

---

## Performance Testing

Recommended Test Levels:

| NPC Count | Expected Result     |
| --------- | ------------------- |
| 20        | Smooth              |
| 50        | Smooth              |
| 100       | Smooth              |
| 200+      | Depends on hardware |

---

## Future Improvements

### Version 2.0

* Interest Point System
* Crowd Zones
* Weighted Destinations
* Better Crowd Distribution

### Version 3.0

* Group Behavior
* Crowd Scheduling
* State Machines
* Advanced Simulation

---

## Git Workflow

Create a commit:

```bash
git add .
git commit -m "Your message"
git push
```

Create a release tag:

```bash
git tag v1.0
git push origin v1.0
```

---

## Author

Developed as a personal learning project to explore Unity game development and crowd simulation systems.
