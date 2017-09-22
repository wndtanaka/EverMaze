using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Maze
{
    public class KeyPickUp : MonoBehaviour
    {
        public Text keyCounter;
        int keyCount;

        void OnTriggerEnter(Collider col)
        {
            if (GameObject.FindGameObjectWithTag("key"))
            {
                Destroy(gameObject);
                keyCount++;
            }
            Debug.Log(keyCount);
            
        }
        void Update()
        {
            keyCounter.text = "Key: " + keyCount + " / 3";
        }
    }
}