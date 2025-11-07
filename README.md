# Leggies

A 2D multiplayer action game built with Unity where players control unique characters called "Leggies" and battle in fast-paced combat arenas.

## Overview

Leggies is a competitive 2D physics-based fighting game where players engage in dynamic battles using movement, attacks, defensive maneuvers, and throwable objects. The game features a player selection system, customizable controls, and an extensible component-based architecture.

## Features

### Core Gameplay Mechanics

- **Movement System**: Physics-based directional movement with customizable power values
- **Attack System**: Timed attacks with visual effects, sound feedback, and cooldown periods
  - Attack duration and cooldown mechanics
  - Visual scaling and optional shake effects during attacks
  - Three-phase sound system (start, loop, end)
  - Collision-based damage system

- **Retreat/Dash**: Quick evasive maneuver that applies force opposite to current velocity
  - Configurable retreat force
  - Sound effect support with random clip selection

- **Throw System**: Launch projectiles at opponents
  - Cooldown-based throwing mechanics
  - Random directional force application
  - Customizable throwable objects

- **Death System**: Modular death handling with multiple causes and methods
  - **Death Causes**: Attack, Throw, Timeout
  - **Death Methods**: Immediate removal, Flying animation
  - **Death Accessories**: Sound effects, visual effects

### Game Systems

- **Player Selection**: Pre-game player selection interface with multiple character options
- **Input Management**: Flexible input system with customizable key bindings per player
- **Camera System**: Intelligent camera that follows players dynamically
- **Speed Limiting**: Configurable maximum velocity constraints
- **Multi-player Support**: Local multiplayer with individual player controls

## Technical Details

### Built With

- **Unity Version**: 2021.3.2f1
- **Rendering**: 2D Built-in Renderer
- **Platform**: Cross-platform (Standalone, Android support configured)
- **Default Resolution**: 1920x1080

### Key Unity Packages

- Unity 2D Feature Set (com.unity.feature.2d)
- Unity UI (uGUI)
- TextMeshPro
- Timeline
- Visual Scripting
- Physics2D

## Project Structure

```
leggies-game/
├── Assets/
│   ├── Prefabs/           # Reusable game objects (players, maps)
│   │   ├── Select Players/
│   │   └── Test Map/
│   ├── Scenes/            # Game scenes
│   │   ├── PlayerSelectionScene.unity
│   │   └── SampleScene.unity
│   ├── Scripts/           # C# game scripts
│   │   ├── Components/    # MonoBehaviour components
│   │   │   ├── Main Camera/
│   │   │   ├── Maps/
│   │   │   ├── Misc/
│   │   │   │   └── Die/   # Death system components
│   │   │   └── Players/   # Player-specific components
│   │   ├── Static/        # Static utility classes
│   │   └── Temp/          # Temporary/experimental scripts
│   ├── Sound/             # Audio clips
│   │   ├── Attack/
│   │   ├── Die/
│   │   ├── Pre-Map/
│   │   └── Retreat/
│   └── Images/            # Sprites and textures
├── Documentation/         # Comprehensive script documentation
│   ├── Index.md          # Documentation index
│   └── Components Scripts/
├── Packages/              # Unity package dependencies
└── ProjectSettings/       # Unity project configuration
```

## Getting Started

### Prerequisites

- Unity 2021.3.2f1 or compatible version
- Unity 2D Feature Set installed

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/ezAldinWaez/leggies-game.git
   ```

2. Open the project in Unity Hub:
   - Click "Add" in Unity Hub
   - Navigate to the cloned project folder
   - Select the folder and click "Open"

3. Wait for Unity to import all assets and compile scripts

4. Open the main scene:
   - Navigate to `Assets/Scenes/`
   - Open `PlayerSelectionScene.unity` to start with player selection
   - Or open `SampleScene.unity` for direct gameplay

### Running the Game

1. In Unity Editor, press the **Play** button (▶) or use `Ctrl+P` (Windows) / `Cmd+P` (Mac)
2. Select your players in the selection scene
3. Start playing!

## Controls

Controls are customizable per player through the `PlayerInput` component. Default control scheme uses directional keys for movement and dedicated keys for actions:

- **Movement**: Arrow keys / WASD (configurable)
- **Attack**: Dedicated attack key (configured per player)
- **Retreat**: Dedicated retreat key (configured per player)
- **Throw**: Dedicated throw key (configured per player)

Controls are set via `DefaultInputDictionaries` and can be customized through the `PlayerInputSetter` component.

## Game Architecture

### Component System

The game uses a modular component-based architecture:

#### Static Scripts
- **InputName**: Enum defining input types (UP, DOWN, LEFT, RIGHT, ATTACK, RETREAT, THROW)
- **DefaultInputDictionaries**: Manages default key bindings for different players
- **LeggiesLibrary**: Utility library containing:
  - `LeggiesMath`: Mathematical utilities (vector shaking, random directions)
  - `LeggiesSounds`: Audio playback utilities

#### Component Scripts

**Player Components:**
- `PlayerInput`: Handles input detection and event dispatching
- `Move`: Applies physics-based movement forces
- `Attack`: Manages attack state, timing, and effects
- `Feint`: Attack variation or fake-out mechanic
- `Retreat`: Dash/retreat movement
- `Throw`: Projectile launching system
- `Throwable`: Component for thrown objects

**Map Components:**
- `PlayerBuilder`: Instantiates players in the scene
- `PlayerPositioner`: Positions players at spawn points
- `PlayerInputSetter`: Assigns input configurations to players
- `PlayersListManager`: Maintains list of active players

**Misc Components:**
- `Die`: Orchestrates death events, causes, methods, and accessories
- `DieCause`: Base class for death triggers (Attack, Throw, Timeout)
- `DieMethod`: Base class for death animations/effects (Immediate, Fly)
- `DieAccessory`: Base class for death decorators (PlaySound)
- `SpeedLimiter`: Enforces maximum velocity constraints
- `CameraFollow`: Camera tracking for active players

## Documentation

Comprehensive documentation for all scripts is available in the `Documentation/` folder. The documentation is organized using Obsidian markdown format and includes:

- Purpose and rationale for each script
- Detailed functionality descriptions
- Usage instructions
- Development history with dates

To browse the documentation:
1. Open the `Documentation/` folder
2. Start with `Index.md` for an overview
3. Follow the links to specific component documentation

Alternatively, you can open the Documentation folder in [Obsidian](https://obsidian.md/) for a better linked documentation experience.

## Development

### Code Organization Principles

1. **Separation of Concerns**: Death system split into Causes, Methods, and Accessories
2. **Event-Driven Architecture**: Components communicate through events (e.g., `OnKeyPressed`, `OnDying`)
3. **Reusability**: Static utility classes in `LeggiesLibrary` for shared functionality
4. **Modularity**: Each component handles a single responsibility

### Adding New Features

To extend the game:

1. **New Death Cause**: Inherit from `DieCause` base class
2. **New Death Method**: Inherit from `DieMethod` base class
3. **New Death Accessory**: Inherit from `DieAccessory` base class
4. **New Player Ability**: Create component subscribing to `PlayerInput.OnKeyPressed`

### Development Timeline

Notable development milestones documented in the codebase:
- **May 2022**: Initial game mechanics (Move, Attack, Retreat)
- **Sep 2022**: Audio support, camera system, death system foundation
- **Feb 2023**: LeggiesLibrary utilities expanded
- **Mar 2023**: Death system refactored into modular architecture
- **Jun 2023**: Throw system implemented
- **Nov 2023**: Current iteration

## Building the Game

### Build Settings

The project is configured for multiple platforms:

1. **Standalone (Windows/Mac/Linux)**:
   - Default resolution: 1920x1080
   - Fullscreen mode enabled

2. **Android**:
   - Minimum SDK: API Level 22
   - Target SDK: Automatic
   - Android 5.0+ compatible

### Creating a Build

1. Open **File > Build Settings**
2. Select your target platform
3. Click **Build** or **Build and Run**
4. Choose output directory

## Contributing

When contributing to this project:

1. Follow the existing code organization structure
2. Add components to appropriate folders (Players, Maps, Misc)
3. Document new scripts in the `Documentation/` folder following the existing format
4. Include the documentation date at the bottom of each documentation file
5. Test multiplayer functionality with at least 2 players

## Credits

- **Developer**: EzA
- **Product Name**: Leggies
- **Company**: EzA

## License

All rights reserved. See project owner for licensing details.

---

**Note**: This is an active development project. Features and documentation are continuously being updated and improved.
