using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public float TotalPoints;
    public Text TotalPointsText;
    Animator CamAnim;
    public GameObject Home;
    public GameObject Settings;
    public GameObject LevelSelector;
    public Sprite radioOn;
    public Sprite radioOff;

    void Start()
    {
        Settings.SetActive(false);
        LevelSelector.SetActive(false);
        CamAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        CamAnim.Play("HomeCamAnim");
        TotalPoints = PlayerPrefs.GetFloat("Total Points");
        TotalPointsText.text = "Points: " + TotalPoints.ToString("0");
    }

    public void Play()
    {
        LevelSelector.SetActive(true);
        Home.SetActive(false);
    }
    #region SETTINGS
    public void SettingsB()
    {
        Home.SetActive(false);
        Settings.SetActive(true);
    }
    public void CloseSettings()
    {
        Home.SetActive(true);
        Settings.SetActive(false);
    }

    public void SOUND()
    {
        string name = "sound";
        if(GameObject.Find(name).GetComponentInChildren<Image>().sprite == radioOff) 
        {
            GameObject.Find(name).GetComponentInChildren<Image>().sprite = radioOn;
        }            
        else         
        {
            GameObject.Find(name).GetComponentInChildren<Image>().sprite = radioOff;
        }
    }
    #endregion SETTINGS
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Store()
    {
        SceneManager.LoadScene("Store");
    }

    public void LSBack()
    {
        LevelSelector.SetActive(false);
        Home.SetActive(true);
    }
    public void QiutGame()
    {
        Application.Quit();
    }

}
