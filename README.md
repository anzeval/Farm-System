# Farm-System
Grid-based farming system with a data-driven architecture. The world is represented as a cell grid with entities (grass, rocks, trees) separated from visual logic. Tools interact via polymorphism, loot and inventory use events, and systems are decoupled for scalability and clean Unity lifecycle handling.

<img width="962" height="541" alt="Screenshot 2026-02-08 at 21 41 23" src="https://github.com/user-attachments/assets/163d4adb-d9f4-4027-8f6f-f91e81354dda" />

Overview
This project is a grid-based farming system built in Unity with a data-driven and entity-based architecture.
The system focuses on clean separation between data, logic, and visuals, as well as scalable interactions between tools and world objects.
The project is designed as a learning and portfolio piece, demonstrating architectural thinking rather than a finished game.

Grid & Cell Data

-The world is represented as a Vector2Int → CellData grid

-CellData contains only logical state (cell type, soil stage)

-No direct references to Unity GameObjects inside data

<img width="966" height="538" alt="Screenshot 2026-02-08 at 21 42 31" src="https://github.com/user-attachments/assets/2aec2d24-b6f7-45e3-81a7-8f27780905b9" />

Entity-Based World Objects

-World objects (grass, rocks, trees) are implemented as CellEntity instances

-Each entity encapsulates its own behavior and interaction logic

-Different behaviors are handled through polymorphism instead of conditional logic

<img width="958" height="535" alt="Screenshot 2026-02-08 at 21 44 17" src="https://github.com/user-attachments/assets/52ccb275-20d6-4fba-ae8d-864b52410288" />

Tool Interaction System

-Tools interact with entities via a unified interface

-Entities decide how they react to a specific tool

-Supports single-hit destruction (grass) and multi-hit objects (rocks, trees)

Event-Driven Architecture

-Systems communicate through events instead of direct references

-Decouples gameplay logic, UI, and world representation

-Prevents tight coupling and improves scalability


Procedural Growth

-Grass is spawned procedurally based on cell state and probability

-Growth logic is independent from visual representation

<img width="959" height="540" alt="Screenshot 2026-02-08 at 21 44 31" src="https://github.com/user-attachments/assets/c910450e-2748-408c-a3ff-b0b68c243bd3" />

Inventory & Loot Flow

-Entities emit loot events on destruction

-Loot handling is separated from entity logic

-Inventory UI reacts to data changes via events


Architectural Goals

-Clear separation between data, logic, and visuals

-Extensible system for adding new tools and entities

-Safe handling of Unity lifecycle (Awake, OnEnable, Start)

-Maintainable and scalable design suitable for further expansion


Technologies & Concepts Used

-Unity (C#)

-Grid-based world representation

-Data-driven design

-Polymorphism & interfaces

-Event-based communication

-Unity lifecycle management


What This System Demonstrates

-Understanding of clean architecture principles in Unity

-Ability to design extensible gameplay systems

-Practical experience with real-world Unity pitfalls (lifecycle, dependencies)

-Focus on long-term maintainability rather than quick solutions

