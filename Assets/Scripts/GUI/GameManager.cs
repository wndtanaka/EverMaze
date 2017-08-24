using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GameManager : MonoBehaviour
    {
        public GameObject pauseMenu;

        public bool pause;
        public bool gameScene;

        void Start()
        {
            if (!gameScene)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 5;
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseMenu();
            }
        }
        public void PauseMenu()
        {
            TogglePauseMenu();
        }
        public bool TogglePauseMenu()
        {
            if (pause)
            {
                Time.timeScale = 5;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pause = false;
                pauseMenu.SetActive(false);
                return false;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pause = true;
                pauseMenu.SetActive(true);
                return true;
            }
        }
    }
}