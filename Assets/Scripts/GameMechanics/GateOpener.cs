using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GateOpener : MonoBehaviour
    {
        Animator anim;
        public Player player;
        GameObject block;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            block = GameObject.Find("GateCollider");
        }

        private void Update()
        {
            if (player.keyCount == player.maxKey)
            {
                block.SetActive(false);
            }
            else
            {
                block.SetActive(true);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (player.keyCount == player.maxKey)
            {
                anim.SetBool("isOpened", true);
            }
            else
            {
                anim.SetBool("isOpened", false);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            anim.SetBool("isOpened", false);
        }
    }
}