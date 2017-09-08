using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Maze
{
    public class SceneNavigator : MonoBehaviour
    {
        GUIManager game;
        public Timer timer;

        private void Update()
        {
            if (timer.timer == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
        public void LoadLevel()
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
        private void OnTriggerEnter(Collider other)
        {
            if (GameObject.FindGameObjectWithTag("exit"))
            {
                SceneManager.LoadScene("Scene_02");
            }
        }
    }
}