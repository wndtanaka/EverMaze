using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class SceneNavigator : MonoBehaviour
    {
        GameManager game;

        public void LoadLevel(string name)
        {
            SceneManager.LoadScene("Scene_01"); // Start Level_01 scene
        }
        public void OptionScene()
        {
            SceneManager.LoadScene("OptionsMenu"); // Load Options Menu
        }
        public void ExitGame()
        {
            Debug.Log("Quit Game");
            Application.Quit(); // Quit the Game
        }
        public void StartMenu()
        {
            SceneManager.LoadScene("StartMenu");
        }
        public void PauseOptions()
        {
            SceneManager.LoadScene("GamePauseMenu",LoadSceneMode.Additive);
        }
        public void BackToPauseMenu()
        {
            SceneManager.UnloadSceneAsync("GamePauseMenu");
        }
    }
}