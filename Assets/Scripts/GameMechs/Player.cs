using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Maze
{
    public class Player : MonoBehaviour
    {
        public int lives = 3;
        public Transform spawnPoint;
        public Text livesText;
        public Text spawnClock;
        public GameObject level;


        private float spawnTimer = 3;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            livesText.text = "Lives: " + lives;
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime; // count down this may take us below 0
            }
            else
            {
                spawnTimer = 0; // this sets us back to 0
            }
        }
        void OnCollisionEnter(Collision col)
        {
            if (col.transform.gameObject.tag == "enemy")
            {
                if (lives > 0)
                {
                    level.transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.position = spawnPoint.position;
                    lives--;
                    OnGUI();
                }
                if (lives <= 0)
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("GameOverScene");
                }
            }
        }
        void OnGUI()
        {
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;

            int mins = Mathf.FloorToInt(spawnTimer / 60);
            int secs = Mathf.FloorToInt(spawnTimer - mins * 60);

            string clockTime = string.Format("{0:0}:{1:00}", mins, secs);
            spawnClock.text = clockTime;
        }
    }
}