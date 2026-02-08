# Farm-System
Grid-based farming system with a data-driven architecture. The world is represented as a cell grid with entities (grass, rocks, trees) separated from visual logic. Tools interact via polymorphism, loot and inventory use events, and systems are decoupled for scalability and clean Unity lifecycle handling.

Overview
This project is a grid-based farming system built in Unity with a data-driven and entity-based architecture.
The system focuses on clean separation between data, logic, and visuals, as well as scalable interactions between tools and world objects.
The project is designed as a learning and portfolio piece, demonstrating architectural thinking rather than a finished game.

Core Systems

-Grid & Cell Data
The world is represented as a 2D grid (Vector2Int → CellData)
CellData stores only logical state (cell type, soil stage)
No direct references to Unity GameObjects inside data

-Entity System
World objects (grass, rocks, trees) are implemented as entities

-Tool Interaction
Tools interact with entities through a unified interface
Tools do not know entity types
Entities decide how they respond to a given tool
This keeps the system extensible and loosely coupled.

-Procedural Growth
Grass spawns procedurally based on cell state and probability
Growth logic is independent from visual representation
Prevents duplicate entities per cell

-Loot & Inventory
Entities emit loot events when destroyed
Loot handling is separated from entity logic
Inventory and UI react to data changes via events

-Architecture Highlights
Data-driven design
Clear separation of responsibilities
Event-based communication between systems
Safe handling of Unity lifecycle (Awake, OnEnable, Start)
Easily extensible for new entities, tools, or mechanics

-Technologies & Concepts
Unity (C#)
Grid-based world representation
Entity-based architecture
Polymorphism & interfaces
Event-driven systems
Unity lifecycle management
Purpose of the Project

This project demonstrates:
System design thinking in Unity
Ability to structure gameplay logic cleanly
Understanding of common Unity pitfalls and how to avoid them
Readiness for trainee / junior-level development tasks
Multiple entities per cell

Growth stages and animations

ScriptableObject-based loot tables
