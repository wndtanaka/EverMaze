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
        // public Text spawnClock;
        public GameObject level;
        public Text keyCounter;
        public int keyCount;

        private float spawnTimer = 3;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            livesText.text = "Lives: " + lives;
            keyCounter.text = "Key: " + keyCount + " / 3";
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
                }
                if (lives <= 0)
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("GameOverScene");
                }
            }
        }
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "key")
            {
                Destroy(col.gameObject);
                keyCount++;
            }
            Debug.Log(keyCount);
        }
    }
}