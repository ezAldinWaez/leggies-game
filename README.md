# Leggies

A 2D multiplayer action game where players control "Leggies" characters in fast-paced physics-based combat arenas.

## Overview

Leggies is a local multiplayer fighting game built with Unity. Players battle using movement, attacks, dash mechanics, and throwable projectiles in dynamic 2D environments.

## Features

- **Movement**: Physics-based directional controls
- **Attack System**: Timed attacks with visual effects, sounds, and cooldowns
- **Retreat/Dash**: Quick evasive maneuvers
- **Throw System**: Launch projectiles at opponents
- **Death System**: Modular death handling with various causes (Attack, Throw, Timeout) and effects
- **Player Selection**: Choose your character before battle
- **Customizable Controls**: Configure key bindings per player
- **Dynamic Camera**: Follows active players intelligently

## Getting Started

### Prerequisites

- Unity 2021.3.2f1 or compatible version
- Unity 2D Feature Set

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/ezAldinWaez/leggies-game.git
   ```

2. Open in Unity Hub:
   - Click "Add" and select the project folder
   - Wait for Unity to import assets

3. Open a scene:
   - `Assets/Scenes/PlayerSelectionScene.unity` - Start with player selection
   - `Assets/Scenes/SampleScene.unity` - Jump straight into gameplay

4. Press Play (▶) to start

## Controls

Controls are customizable per player. Default scheme:
- **Movement**: Arrow keys / WASD
- **Attack**: Configured per player
- **Retreat**: Configured per player
- **Throw**: Configured per player

## Project Structure

```
Assets/
├── Scenes/           # Game scenes
├── Scripts/          # C# game scripts
│   ├── Components/   # Player, Map, Camera components
│   ├── Static/       # Utility classes (LeggiesLibrary, InputName)
│   └── Temp/         # Experimental scripts
├── Prefabs/          # Reusable game objects
├── Sound/            # Audio clips (Attack, Die, Retreat)
└── Images/           # Sprites and textures

Documentation/        # Detailed script documentation (Obsidian format)
```

## Architecture

The game uses a modular component-based architecture:

**Key Components:**
- `PlayerInput` - Input handling and event dispatching
- `Move` - Physics-based movement
- `Attack` - Attack mechanics with effects
- `Retreat` - Dash movement
- `Throw` / `Throwable` - Projectile system
- `Die` - Death event orchestration
- `CameraFollow` - Camera tracking

**Utilities:**
- `LeggiesLibrary` - Math and sound utilities
- `DefaultInputDictionaries` - Input configurations

See `Documentation/Index.md` for comprehensive documentation of all components.

## Development

Built with Unity 2021.3.2f1 using 2D Built-in Renderer. The project uses event-driven architecture and modular components for extensibility.

To add new features, inherit from base classes (`DieCause`, `DieMethod`, `DieAccessory`) or create new components that subscribe to existing events.

## Building

Go to **File > Build Settings**, select your platform, and click **Build**.

Configured for:
- Standalone (Windows/Mac/Linux) - 1920x1080
- Android - API Level 22+

## Credits

**Developer**: EzA
**Company**: EzA

---

For detailed documentation, see the `Documentation/` folder or open it in [Obsidian](https://obsidian.md/).
