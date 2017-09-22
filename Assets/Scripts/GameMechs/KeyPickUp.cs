using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class KeyPickUp : MonoBehaviour
    {
        public GameObject[] key;
        public GameObject exit;
        public int keyCount;

        void OnTriggerEnter(Collider col)
        {
            if (GameObject.FindGameObjectWithTag("key"))
            {
                keyCount++;
                gameObject.SetActive(false);
                if (keyCount >= key.Length)
                {
                    exit.SetActive(true);
                }
            }
        }
    }
}