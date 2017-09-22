using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    bool isTutorialShown;
    // Use this for initialization
    void Start()
    {
        isTutorialShown = true;
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorialShown)
        {
            Debug.Log("Turotial Active");
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.SetActive(false);
                Time.timeScale = 1;
                isTutorialShown = false;
                Debug.Log("Tutorial Deactivate");
            }
        }
    }
}
