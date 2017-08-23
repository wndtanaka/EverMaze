using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class MusicPlayer : MonoBehaviour
    {
        static MusicPlayer instance = null;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                GameObject.DontDestroyOnLoad(gameObject);
            }
        }
    }
}