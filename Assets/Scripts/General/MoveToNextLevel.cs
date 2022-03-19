using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToNextLevel : MonoBehaviour
{
    public EndColDect EndColScript;
    public int nextSceneLoad;
    public GameObject GameComplete;
    private string AS_name;
    void Start()
    {
        AS_name = SceneManager.GetActiveScene().name + "ButtonOpen";
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        GameComplete.SetActive(false);
    }

    public void NextLevel()
    {

        if (SceneManager.GetActiveScene().buildIndex == 65)
        {
            GameComplete.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(nextSceneLoad);
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
            EndColDect.GameSpeed = 1;
        }

        PlayerPrefs.SetInt(AS_name, 5);
    }
}
