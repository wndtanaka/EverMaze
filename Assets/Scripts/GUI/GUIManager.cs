using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GUIManager : MonoBehaviour
    {
        public GameObject pauseMenu;
        //public GameObject tutorial;

        private bool pause;
        private bool gameScene;

        //private bool isTutorialShown;

        void Start()
        {
            //tutorial.SetActive(true);
            //isTutorialShown = true;
            if (gameScene)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseMenu();
            }
            //if (isTutorialShown)
            //{
            //    Debug.Log("Turotial Active");
            //    Time.timeScale = 0;
            //    Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.visible = false;
            //    if (Input.GetKeyDown(KeyCode.Space))
            //    {
            //        tutorial.SetActive(false);
            //        Time.timeScale = 1;
            //        isTutorialShown = false;
            //        Debug.Log("Tutorial Deactivate");
            //    }
            //}
        }
        public void PauseMenu()
        {
            TogglePauseMenu();
        }
        public bool TogglePauseMenu()
        {
            if (pause)
            {
                Time.timeScale = 1;
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