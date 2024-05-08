# Realm-Rush

### Introduction
    Realm Rush is a tower defense game in which players aim to protect their territory by preventing 
    enemies from reaching their base. Limited towers can be strategically placed on a grid to target and
    stop incoming enemies, ensuring the player's base remains secure.

### Features
    - Placement of up to 7 towers on the grid(Customizable).
    - Placable blocks (waypoints) change to green when a tower can be placed on the grid, turning red if not 
      placable.
    - Intelligent AI finds the shortest path from the starting point(enemy base) to the destination(player base).
      enemies spawn from the enemy base at fixed intervals and move toward the player's base.
    - Towers automatically target the nearest enemy.
    - Spacious vibes and immersive sound effects.
    
### Screenshots

   ![StartMenu](./Screenshots/MainMenu.png)
   ![TowerShooting](./Screenshots/TowerShooting4.png)
   ![TowerShooting](./Screenshots/TowerShooting.png)
   ![TowerShooting2](./Screenshots/TowerShooting2.png)
   ![EnemyDestroyed](./Screenshots/EnemyDestroyed.png)
   ![GameOver](./Screenshots/GameOver.png)

   
### Implementation and Game Design
#### Implementation
    Design Patterns Used:
    
    Observer Pattern: 
        - Implemented to handle events and notifications in a decoupled manner. The Observer<T> class 
          allows subscribing to events and invoking callbacks when certain actions occur. 
        - For example, Enemy.OnDestroyed event uses this pattern to notify the ScoreManager to update score.

    Flyweight Factory Pattern with Object Pooling: 
        - Used to efficiently manage and reuse game objects, especially particles and enemies. 
        - The FlyweightFactory class manages pools of objects such as enemies and VFX, ensuring they are 
          created and destroyed as needed without incurring performance overhead.
          
    Generic Singleton:
        - Used to ensure only one instance of certain classes exists throughout the application. 
        - Classes like MonoSingletonGeneric<T> and MonoSingletonGeneric<VfxSpawnManager> are examples
          where this pattern is implemented.
          
    Scriptable Objects: 
       - Leveraged to store and manage data in a flexible and modular way. Scriptable objects like 
         TowerData, EnemySettings, and VfxSettings allow easy configuration and customization of game 
         entities without modifying code.

    Key Classes and Components:

    Tower: 
    Represents a defense tower in the game. It utilizes the IDefenseUnit interface and is instantiated
    using a TowerFactory, which is a subclass of DenfenseUnitFactory. Towers shoot at enemies within 
    their attack range and are placed on waypoints using the TowerSpawnManager.

    Enemy: 
    Represents an enemy in the game. It extends the Flyweight class and is pooled and managed by the
    EnemySpawnManager. Enemies move along predefined paths using the EnemyMovement component and trigger 
    VFX and score updates upon destruction.

    VFX: 
    Managed using the flyweight pattern and pooled by the VfxSpawnManager. VFX are instantiated, play 
    their effects, and then returned to the pool for reuse, improving performance and memory usage.

    PathFinder:
    Implements pathfinding using a breadth-first search algorithm to find paths between waypoints.
    It calculates paths dynamically and is used by enemies to navigate towards their targets.

    WayPoint:
    Represents a grid-based waypoint used for tower and enemy placement as well as pathfinding. 
    It handles mouse input for tower placement and changes color based on placability.

    GameManager: 
    Controls game flow, including pausing, quitting, and transitioning to the game over scene 
    upon player death.

    MainMenu: 
    Manages the main menu UI and handles button clicks for starting the game, showing instructions,
    and quitting.

    ScoreManager: 
    Updates and displays the player's score based on enemy destruction events.

 
 #### Game Design
     - Designed strategic level independently using provided assets.
     - Implemented an editor script(CubeEditor) to facilitate the placement of blocks (waypoints) with 
       restricted integer coordinates.
       
#### Focus
    - Learn custom pathfinding for an analog grid-based world using the BFS algorithm.
    - Gain familiarity with design patterns like Flyweight Factory with object pooling, Observer, and Singleton.
    - Get acquainted with using data structures like queues, dictionaries and lists.
    - Learn how to use a Particle System.
    
### Gameplay Demonstration
    - For a visual demonstration of the gameplay, watch video on YouTube:
 [Youtube video link](https://youtu.be/cmyqPkxtXsE)

### Play the Game
    - To experience the game firsthand, play it directly by following this playable link:
[Play in browser(WebGl)](https://rahul-pargi.itch.io/realm-rush)
