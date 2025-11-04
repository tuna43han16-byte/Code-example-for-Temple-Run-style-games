# 3D Endless Runner - Unity Project

This is a foundational 3D Endless Runner game built with the Unity engine and C#. It is inspired by popular mobile games like *Subway Surfers* and *Temple Run*.

This project was created as a learning exercise to understand and implement core Unity mechanics, including physics, C# scripting, prefab management, UI, and game state management.

> **CRITICAL:** Add a screenshot or, even better, a short `.gif` of your game in action here! This is the most important part of your README.
>
> `![Game Demo GIF](demo.gif)`

---

## 🚀 Core Features

This prototype includes the following gameplay mechanics:

* **Endless Forward Movement:** The player character automatically moves forward along the Z-axis.
* **3-Lane Control System:** The player can smoothly switch between three lanes (left, middle, right) using keyboard inputs. Movement is interpolated using `Mathf.Lerp` for a clean feel.
* **Procedural Level Generation:** The `LevelManager` script dynamically spawns new road prefabs ahead of the player (`Instantiate`) and destroys old ones (`Destroy`) to create an infinite "illusion of movement" and maintain performance.
* **Obstacle Collision:** Running into any object tagged as "Engel" (Obstacle) will trigger a game-over event (`OnCollisionEnter`).
* **Collectible System:** The player can collect items tagged as "Altin" (Coin). This uses `OnTriggerEnter` to detect collection without a hard collision.
* **Game State Management:** A central `GameManager` (Singleton) tracks the game state (`isGameOver`), score, and handles the UI.
* **UI System:**
    * An on-screen **Score** display that updates in real-time.
    * A **Game Over Panel** that appears upon collision.
    * A **Restart Button** that reloads the current scene (`SceneManager.LoadScene`) to start a new run.

## 🛠️ Tech Stack

* **Game Engine:** Unity (e.g., 2022.3.x or newer)
* **Programming Language:** C#
* **UI:** Unity UI (Canvas, Panel, Button) & TextMeshPro

---

## 🧠 Core Code Structure

The game's logic is primarily driven by three key scripts:

### 1. `PlayerMovement.cs`

* Manages the player's continuous forward `transform.Translate` in `Update()`.
* Listens for user input (`Input.GetKeyDown`) to set the `hedefSerit` (target lane).
* Handles all physics interactions:
    * `OnCollisionEnter()`: Detects collisions with "Engel" tagged objects and notifies the `GameManager` to end the game.
    * `OnTriggerEnter()`: Detects "Altin" (Coin) triggers, notifies the `GameManager` to add score, and destroys the coin object.

### 2. `GameManager.cs`

* Implemented as a **Singleton** (`public static GameManager instance`) for easy access from other scripts.
* Holds references to UI elements (`skorText`, `oyunBittiPanel`).
* Maintains the game state (`isGameOver`) and the `skor` (score).
* Provides public methods:
    * `SkorEkle(int)`: Called by the player to add to the score.
    * `OyunBitti()`: Called by the player on collision. Stops time (`Time.timeScale = 0`) and shows the game over panel.
    * `YenidenBasla()`: Linked to the UI Restart Button. Resets the time scale and reloads the active scene.

### 3. `LevelManager.cs`

* Tracks the player's position (`oyuncu.position.z`).
* Spawns new `yolPrefab` (road prefabs) as the player approaches the end of the current segment.
* Optimizes performance by destroying old road segments that are far behind the player.
* Checks the `GameManager.instance.isGameOver` flag to stop spawning new segments when the game has ended.

---

## ⚙️ How to Run

1.  Clone this repository or download the ZIP file.
    ```bash
    git clone [https://github.com/](https://github.com/)[Your-Username]/[Your-Repo-Name].git
    ```
2.  Open **Unity Hub**.
3.  Click "Open" or "Add project from disk" in the "Projects" tab.
4.  Select the cloned project folder and let Unity import it.
5.  Once the project is open, navigate to the `Assets/Scenes/` folder in the `Project` window.
6.  Double-click the main scene file (e.g., `MainScene.unity`).
7.  Press the **Play** button at the top of the Unity editor to start the game.

## 📈 Future Improvements (To-Do)

* [ ] **Random Obstacle Spawning:** Automatically spawn obstacle and coin prefabs onto the road segments in random patterns.
* [ ] **Mobile Controls:** Implement touch-based swipe controls (`Input.GetTouch`) for lane switching.
* [ ] **Main Menu:** Add a proper main menu scene.
* [ ] **Sound Effects & Music:** Add sounds for collecting coins, crashing, and background music.
