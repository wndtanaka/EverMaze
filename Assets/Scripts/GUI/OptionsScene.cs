﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsScene : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
