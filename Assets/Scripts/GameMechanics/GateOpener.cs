using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GateOpener : MonoBehaviour
    {
        public Player player;
        public Light right;
        public Light left;

        Animator anim;
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
                left.color = Color.green;
                right.color = Color.green;
            }
            else
            {
                block.SetActive(true);
                left.color = Color.red;
                right.color = Color.red;
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