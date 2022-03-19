using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonScript : MonoBehaviour
{
    public Image Star1, Star2, Star3, Locket;
    private string LS_Stars;
    private int LevelSelectorStars;
    public static LevelButtonScript Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void OnClick()
    {
        if (EnergyManager.Instance.totalEnergy > 0)
        {
            SceneManager.LoadScene(name);
            EndColDect.GameSpeed = 1;
        }
        else
        {
            EnergyManager.Instance.OutOfLives.SetActive(true);
        }
    }

    private void Start()
    {
        Locket.enabled = true;
        Star1.enabled = false;
        Star2.enabled = false;
        Star3.enabled = false;

        LS_Stars = this.name + "StarsAchieved";
        LevelSelectorStars = PlayerPrefs.GetInt(LS_Stars);

        if (LevelSelectorStars == 1)
        {
            Star1.enabled = true;
            Star2.enabled = false;
            Star3.enabled = false;
        }

        if (LevelSelectorStars == 2)
        {
            Star1.enabled = true;
            Star2.enabled = true;
            Star3.enabled = false;
        }

        if (LevelSelectorStars == 3)
        {
            Star1.enabled = true;
            Star2.enabled = true;
            Star3.enabled = true;
        }

    }

    private void OnEnable()
    {
        if (this.GetComponent<Button>().interactable) Locket.enabled = false;
    }
}


   
