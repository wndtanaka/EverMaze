using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Maze
{
    public class OptionsManager : MonoBehaviour
    {
        #region Variables
        [Header("Bools")]
        public bool isMute;
        public bool isFullScreen;

        [Header("Keys")]
        public KeyCode forward;
        public KeyCode backward;
        public KeyCode left;
        public KeyCode right;
        // this remembers the key code of a key we are trying to change
        public KeyCode holdingKey;

        [Header("GUI Text")]
        public Text forwardText;
        public Text backwardText;
        public Text leftText;
        public Text rightText;

        [Header("GUI Elements")]
        public Toggle fullScreenToggle;
        public Toggle muteToggle;

        [Header("Resolutions")]
        public Dropdown resolutionDropDown;
        public int[] resX, resY;
        public int index;

        [Header("References")]
        public Slider volumeSlider;
        public Slider brightnessSlider;
        public AudioSource music;
        public Light dirLight;
        #endregion

        void Start()
        {
            Time.timeScale = 5;

            music = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
            if (volumeSlider != null && music != null)
            {
                if (PlayerPrefs.HasKey("Volume"))
                {
                    Load();
                }
                volumeSlider.value = music.volume;
            }
            if (brightnessSlider != null && dirLight != null)
            {
                if (PlayerPrefs.HasKey("Brightness"))
                {
                    Load();
                }
                brightnessSlider.value = dirLight.intensity;
            }

            #region SetUp Keys
            //Set out keys to the preset keys we may have saved, else set keys to default.
            forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
            backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
            left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
            right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));

            forwardText.text = forward.ToString();
            backwardText.text = backward.ToString();
            leftText.text = left.ToString();
            rightText.text = right.ToString();
            #endregion
        }
        void Update()
        {
            if (volumeSlider != null && music != null)
            {
                if (music.volume != volumeSlider.value)
                {
                    music.volume = volumeSlider.value;
                }
            }
            if (brightnessSlider != null && dirLight != null)
            {
                if (brightnessSlider.value != dirLight.intensity)
                {
                    dirLight.intensity = brightnessSlider.value;
                }
            }
        }
        public void Exit()
        {
            SceneManager.LoadScene(0);
        }
        public void Save()
        {
            PlayerPrefs.SetInt("Resolutions", resolutionDropDown.value);

            PlayerPrefs.SetFloat("Volume", music.volume);
            PlayerPrefs.SetFloat("Brightness", dirLight.intensity);

            PlayerPrefs.SetString("Forward", forward.ToString());
            PlayerPrefs.SetString("Backward", backward.ToString());
            PlayerPrefs.SetString("Left", left.ToString());
            PlayerPrefs.SetString("Right", right.ToString());

            PlayerPrefs.SetString("Mute", isMute.ToString());
        }
        public void Load()
        {
            resolutionDropDown.value = PlayerPrefs.GetInt("Resolutions");

            music.volume = PlayerPrefs.GetFloat("Volume");
            dirLight.intensity = PlayerPrefs.GetFloat("Brightness");

            PlayerPrefs.GetString("Forward");
            PlayerPrefs.GetString("Backward");
            PlayerPrefs.GetString("Left");
            PlayerPrefs.GetString("Right");

            PlayerPrefs.GetString("Mute");

        }
        public void Default()
        {
            resolutionDropDown.captionText.text = "1920*1080";
            Screen.SetResolution(1920, 1080, true);
            volumeSlider.value = 1;
            brightnessSlider.value = 1;
            if (isMute)
            {
                muteToggle.isOn = false;
                MuteSounds();
            }
            #region Reset Keys
            //Set out keys to the preset keys we may have saved, else set keys to default.
            forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
            backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
            left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
            right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));

            forwardText.text = forward.ToString();
            backwardText.text = backward.ToString();
            leftText.text = left.ToString();
            rightText.text = right.ToString();
            #endregion
        }
        public void MuteSounds()
        {
            isMute = !isMute;
            if (isMute)
            {
                music.mute = true;
                volumeSlider.value = 0;
            }
            else
            {
                music.mute = false;
                volumeSlider.value = 1;
            }

        }
        #region Key Press Event
        void OnGUI()
        {
            Event e = Event.current;
            if (forward == KeyCode.None)
            {
                //if an event is trigged by a key press
                if (e.isKey)
                {
                    Debug.Log("Key Code: " + e.keyCode);
                    //if this key is not the same as the other keys
                    if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right))
                    {
                        //set forward to the new key
                        forward = e.keyCode;
                        //set holding key to none
                        holdingKey = KeyCode.None;
                        //set to new Key
                        forwardText.text = forward.ToString();
                    }
                    else
                    {
                        //set forward back to what the holding key is
                        forward = holdingKey;
                        //set holding key to none
                        holdingKey = KeyCode.None;
                        //set back to last Key
                        forwardText.text = forward.ToString();

                    }
                }
            }
            if (backward == KeyCode.None)
            {
                //if an event is trigged by a key press
                if (e.isKey)
                {
                    Debug.Log("Key Code: " + e.keyCode);
                    //if this key is not the same as the other keys
                    if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == right))
                    {
                        //set back to the new key
                        backward = e.keyCode;
                        //set holding key to none
                        holdingKey = KeyCode.None;
                        //set to new Key
                        backwardText.text = backward.ToString();
                    }
                    else
                    {
                        //set forward back to what the holding key is
                        backward = holdingKey;
                        //set holding key to none
                        holdingKey = KeyCode.None;
                        //set back to last Key
                        backwardText.text = backward.ToString();

                    }
                }
            }
            if (left == KeyCode.None)
            {
                //if an event is trigged by a key press
                if (e.isKey)
                {
                    Debug.Log("Key Code: " + e.keyCode);
                    //if this key is not the same as the other keys
                    if (!(e.keyCode == backward || e.keyCode == forward || e.keyCode == right))
                    {
                        //set left to the new key
                        left = e.keyCode;
                        //set holding key to none
                        holdingKey = KeyCode.None;
                        //set to new Key
                        leftText.text = left.ToString();
                    }
                    else
                    {
                        //set left back to what the holding key is
                        left = holdingKey;
                        //set holding key to none
                        holdingKey = KeyCode.None;
                        //set back to last Key
                        leftText.text = left.ToString();

                    }
                }
            }
            if (right == KeyCode.None)
            {
                //if an event is trigged by a key press
                if (e.isKey)
                {
                    Debug.Log("Key Code: " + e.keyCode);
                    //if this key is not the same as the other keys
                    if (!(e.keyCode == backward || e.keyCode == forward || e.keyCode == left))
                    {
                        //set right to the new key
                        right = e.keyCode;
                        //set holding key to none
                        holdingKey = KeyCode.None;
                        //set to new Key
                        rightText.text = right.ToString();
                    }
                    else
                    {
                        //set right back to what the holding key is
                        right = holdingKey;
                        //set holding key to none
                        holdingKey = KeyCode.None;
                        //set back to last Key
                        rightText.text = right.ToString();

                    }
                }
            }
        }
        #endregion
        #region Controls
        public void Forward()
        {
            // if none of the other keys are blank
            // then we can edit this key
            if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None))
            {
                // set our holding key to the key of this button
                holdingKey = forward;
                // set this button to non allowing only this to be editable
                forward = KeyCode.None;
                // set the text to none
                forwardText.text = forward.ToString();
            }
        }
        public void Backward()
        {
            // if none of the other keys are blank
            // then we can edit this key
            if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None))
            {
                // set our holding key to the key of this button
                holdingKey = backward;
                // set this button to non allowing only this to be editable
                backward = KeyCode.None;
                // set the text to none
                backwardText.text = backward.ToString();
            }
        }
        public void Left()
        {
            // if none of the other keys are blank
            // then we can edit this key
            if (!(backward == KeyCode.None || forward == KeyCode.None || right == KeyCode.None))
            {
                // set our holding key to the key of this button
                holdingKey = left;
                // set this button to non allowing only this to be editable
                left = KeyCode.None;
                // set the text to none
                leftText.text = left.ToString();
            }
        }
        public void Right()
        {
            // if none of the other keys are blank
            // then we can edit this key
            if (!(backward == KeyCode.None || left == KeyCode.None || forward == KeyCode.None))
            {
                // set our holding key to the key of this button
                holdingKey = right;
                // set this button to non allowing only this to be editable
                right = KeyCode.None;
                // set the text to none
                rightText.text = right.ToString();
            }
        }
        #endregion
        #region FullScreen Toggle and Resolutions
        public void FullScreenToggle()
        {
            isFullScreen = !isFullScreen;
            Screen.fullScreen = !Screen.fullScreen;
        }
        public void ResolutionDropDown()
        {
            index = resolutionDropDown.value;
            Screen.SetResolution(resX[index], resY[index], isFullScreen);
        }
        #endregion
    }
}
