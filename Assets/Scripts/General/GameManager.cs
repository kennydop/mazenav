using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Score ScoreScript;
    public Stars star_anim;

    public GameObject GameOverMenu;
    public GameObject Tyme;
    public GameObject Star1, Star2, Star3;
    public GameObject iGFixedJoyStick, Run;
    private Animator GaMeOvEr;
    public GameObject Blur;
    public GameObject TimerBar;
    public GameObject PauseWindow;
    public GameObject PauseBtn;
    public GameObject iGCanvas;
    public GameObject OuttaEnergy;
    public GameObject EnergyGained;
    public GameObject iGWatchAd;
    public GameObject Energy;

    public float PointsForOneStar;
    public float PointsForTwoStar;
    public float PointsForThreeStar;
    private int Active_Scene;
    private int nextSceneLoad;
    private void Start()
    {
        GaMeOvEr = GameOverMenu.GetComponent<Animator>();
        PauseWindow.SetActive(false);
        GameOverMenu.SetActive(false);
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        Blur.SetActive(false);
        iGCanvas.SetActive(false);
        EnergyGained.SetActive(false);
        iGWatchAd.SetActive(false);
        Active_Scene = SceneManager.GetActiveScene().buildIndex;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void StarRating()
    {
        if (ScoreScript.Points <= PointsForOneStar)
        {
            Star1.SetActive(true);
            star_anim.PlayOneStarAnim();
        }

        if (ScoreScript.Points > PointsForOneStar && ScoreScript.Points <= PointsForTwoStar)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            star_anim.PlayTwoStarAnim();
        }

        if (ScoreScript.Points > PointsForTwoStar && ScoreScript.Points <= PointsForThreeStar)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            star_anim.PlayThreeStarAnim();
        }

    }

    public void GameOver()
    {
        StartCoroutine(GameOverProcess());
    }
    IEnumerator GameOverProcess()
    {
        Tyme.SetActive(false);
        PauseBtn.SetActive(false);
        GameOverMenu.SetActive(true);
        Blur.SetActive(true);
        TimerBar.SetActive(false);
        Energy.SetActive(false);
        GaMeOvEr.Play("Fade-in");
        iGFixedJoyStick.SetActive(false);
        Run.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        PauseWindow.SetActive(true);
        Blur.SetActive(true);
        Time.timeScale = 0;
        Energy.SetActive(false);
        iGFixedJoyStick.SetActive(false);
        Run.GetComponent<Image>().enabled = false;
        TimerBar.SetActive(false);
        Tyme.SetActive(false);
        PauseBtn.SetActive(false);
    }

    public void PlayB()
    {
        Time.timeScale = 1;
        PauseWindow.SetActive(false);
        Blur.SetActive(false);
        Time.timeScale = 1;
        Energy.SetActive(true);
        iGFixedJoyStick.SetActive(true);
        Run.GetComponent<Image>().enabled = true;
        TimerBar.SetActive(true);
        Tyme.SetActive(true);
        PauseBtn.SetActive(true);
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Active_Scene);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    public void CloseIGOE()
    {
        OuttaEnergy.SetActive(false);
    }

    public void WatchAdBtn()
    {
        StartCoroutine(WatchAd());
    }
    IEnumerator WatchAd()
    {
        OuttaEnergy.SetActive(false);
        iGWatchAd.SetActive(true);
        iGFixedJoyStick.SetActive(false);
        Run.GetComponent<Image>().enabled = false;
        TimerBar.SetActive(false);
        Tyme.SetActive(false);
        PauseBtn.SetActive(false);
        Energy.SetActive(false);
        yield return new WaitForSeconds(5);
        iGWatchAd.SetActive(true);
        EnergyGained.SetActive(true);
    }

    public void OnGameCompleteHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
}
