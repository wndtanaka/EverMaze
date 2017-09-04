using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class Timer : MonoBehaviour
    {

        public float timer;
        public Text clockText;

        void Start()
        {
            Time.timeScale = 50;
        }

        void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime; // count down this may take us below 0
            }
            else
            {
                timer = 0; // this sets us back to 0
            }

            int mins = Mathf.FloorToInt(timer / 60);
            int secs = Mathf.FloorToInt(timer - mins * 60);

            string clockTime = string.Format("{0:0}:{1:00}", mins, secs);
            clockText.text = clockTime;
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