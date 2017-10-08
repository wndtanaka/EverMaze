using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Teleport : MonoBehaviour
    {
        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Trigger 21"))
             {
                transform.gameObject.CompareTag("Trigger 82");
             }

            if (col.gameObject.CompareTag("Trigger 26"))
            {
                transform.gameObject.CompareTag("Trigger 77");
            }

            if (col.gameObject.CompareTag("Trigger 76"))
            {
                transform.gameObject.CompareTag("Trigger 87");
            }

            if (col.gameObject.CompareTag("Trigger 83"))
            {
                transform.gameObject.CompareTag("Trigger 78");
            }

            if (col.gameObject.CompareTag("Trigger 84"))
            {
                transform.gameObject.CompareTag("Trigger 79");
            }

            if (col.gameObject.CompareTag("Trigger 85"))
            {
                transform.gameObject.CompareTag("Trigger 80");
            }

            if (col.gameObject.CompareTag("Trigger 86"))
            {
                transform.gameObject.CompareTag("Trigger 81");
            }

        }
    }
}
