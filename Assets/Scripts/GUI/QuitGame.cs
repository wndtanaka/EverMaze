using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GUIManager
{
    public class QuitGame : MonoBehaviour
    {

        public void Exit()
        {
            Debug.Log("Quit Game");
            Application.Quit(); // Quit the Game
        }
    }
}