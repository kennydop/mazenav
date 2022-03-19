using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    int defaultLevel = 1;
    public bool check_lock;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", defaultLevel);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + defaultLevel > levelAt)
            {
                print(i + " + " + defaultLevel + " = " + (i + defaultLevel) + " and it's greater than " + levelAt + " therefore Level " + (i+1) + " is locked ");
                lvlButtons[i].interactable = false;
            }
        }
        
    }

}
