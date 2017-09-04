using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Destroyer : MonoBehaviour
    {
        void OnTriggerEnter(Collider col)
        {
            if (GameObject.FindGameObjectWithTag("key"))
            {
                Destroy(gameObject);
            }
        }
    }
}