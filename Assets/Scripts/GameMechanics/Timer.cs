using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Maze
{
    public class Timer : MonoBehaviour
    {
        public float timer;
        public Text clockText;

        void Start()
        {
        }

        void Update()
        {
            if (timer == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }   
          
            timer -= Time.deltaTime;
            clockText.text = timer.ToString("F1");

            if (timer == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
        void LateUpdate()
        {
            if (timer < 0)
            {
                timer = 0; // this sets us back to 0
            }
        }
    }
}