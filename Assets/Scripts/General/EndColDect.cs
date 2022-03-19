using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndColDect : MonoBehaviour
{
    public ModalWindowManager WinMan;
    public Score Tym;

    public GameManager GM;
    public GameObject PauseBtn;
    public GameObject Energy;
    public GameObject iGTime;
    public GameObject iGFixedJoyStick, Run;
    public GameObject Blur;
    public GameObject TimerBar;
    private Animator CharacterAnimator;

    public static float GameSpeed = 1;
    private int Active_Scene;
    private float TotalPoints;
    private float LevelCompletePoints;

    void Start()
    {
        CharacterAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        WinMan.enabled = false;
        Active_Scene = SceneManager.GetActiveScene().buildIndex - 2;
        TotalPoints = PlayerPrefs.GetFloat("Total Points", 0);
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(LevelComplete());
        }
       
    }
    public IEnumerator LevelComplete()
    {
        WinMan.enabled = true;
        Energy.SetActive(false);
        PauseBtn.SetActive(false);
        Tym.enabled = false;
        Blur.SetActive(true);
        TimerBar.SetActive(false);
        WinMan.OpenWindow();
        yield return new WaitForSeconds(0.1f);
        GameSpeed = 0;
        GM.StarRating();
        CharacterAnimator.speed = GameSpeed;
        Run.GetComponent<Image>().enabled = false;
        iGFixedJoyStick.SetActive(false);
        iGTime.SetActive(false);
        Run.SetActive(false);
        LevelCompletePoints = Tym.Points;
        TotalPoints = PlayerPrefs.GetFloat("Total Points") + LevelCompletePoints;
        PlayerPrefs.SetFloat("Total Points", TotalPoints);
        if (PlayerPrefs.GetInt("levelAt", 1) <= Active_Scene)
        {
            PlayerPrefs.SetInt("levelAt", (Active_Scene + 1));
        }
            
        yield return new WaitForSeconds(1);
    }


}
