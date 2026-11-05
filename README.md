# Run3D

A 3D crowd runner game inspired by Tiny Run 3D built with Unity. Lead your crowd through dynamic obstacle courses, recruit new followers along the road, take down enemy groups, collect coins, and customize character appearances.

## Overview

Run3D is a fast-paced runner where player survival depends on managing group size and reflexes. As you sprint forward down the course, you will encounter lone characters waiting to join your crowd. Gather as many followers as possible to overwhelm enemy obstacles and survive traps along the way.

## Gameplay Mechanics

### Crowd Building and Followers
- Start running with your initial character and recruit neutral followers scattered across the track.
- Every follower you collect joins your moving formation and increases your crowd count.
- Followers act as your collective health. Hitting traps, hammers, or colliding with enemies costs followers.
- If you lose all followers, the run ends.

### Obstacles and Combat
- Static and moving hazards such as rotating hammers and barriers appear across the lanes.
- Enemy groups stand in your path. When your crowd enters their detection range, your followers will charge and engage them.
- Defeating enemies requires enough followers to absorb the clash.

### Economy and Customization
- Collect gold coins positioned along the lanes.
- Spend accumulated coins in the customization menu to unlock and apply different color materials for both your crowd and enemy teams.

## Controls

### Keyboard Controls
- W: Start moving forward along the track.
- S: Stop forward movement.
- A / D or Left / Right Arrows: Steer horizontally across the track lanes.
- Escape: Open or close the pause menu.

### Debug and God Mode Controls
- E: Add a follower instantly when debug followers mode is active.
- R: Remove a follower instantly when debug followers mode is active.
- 1, 2, 3: Switch directly between levels 1, 2, and 3 when god mode level switching is enabled.

## Project Structure

### Scripts
- Assets/Scripts/Player: Player input, crowd movement, attack coordination, and follower formation management.
- Assets/Scripts/Collisions: Collision handling for obstacles, allies, enemies, and dynamic map hazards.
- Assets/Scripts/Pooling: Object pooling system used to recycle followers and scene entities efficiently.
- Assets/Scripts/Map: Dynamic road generation, segment recycling, and coin spawning.
- Assets/Scripts/Color: Customization system for applying material colors to characters and enemies.
- Assets/Scripts/Menu: User interface logic for main menu, level selection, pause screen, and level completion panels.
- Assets/Scripts/Audio: Background music and sound effect controllers with volume adjustments.

### Scenes
- Menu: Main entrance with options to start a new game, load levels, view credits, and select colors.
- Game: Core gameplay loop featuring the runner track, obstacles, and enemy encounters.
- Credits: Credits roll screen.

## Requirements and Setup

- Unity Editor version: 2021.1.12f1 (or compatible LTS releases).
- Open the project directory in Unity Hub.
- Load Assets/Scenes/Menu.unity or Assets/Scenes/Game.unity to play in the editor.
