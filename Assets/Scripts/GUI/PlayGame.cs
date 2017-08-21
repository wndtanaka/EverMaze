using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GUIManager
{
    public class PlayGame : MonoBehaviour
    {

        public void LoadLevel(string name)
        {
            SceneManager.LoadScene(name); // Start level 1 scene
        }
    }
}