using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour
{
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    private Animator Star1AnimCont;
    private Animator Star2AnimCont;
    private Animator Star3AnimCont;
    private string LevelStars;
    void Start()
    {
        LevelStars = SceneManager.GetActiveScene().name + "StarsAchieved";
        Star1AnimCont = Star1.GetComponent<Animator>();
        Star2AnimCont = Star2.GetComponent<Animator>();
        Star3AnimCont = Star3.GetComponent<Animator>();
    }

    public void PlayOneStarAnim()
    {
        StartCoroutine(OneStar());
        if(PlayerPrefs.GetInt(LevelStars) < 1)
            PlayerPrefs.SetInt(LevelStars, 1);
    }

    public void PlayTwoStarAnim()
    {
        StartCoroutine(TwoStars());
        if (PlayerPrefs.GetInt(LevelStars) < 2)
            PlayerPrefs.SetInt(LevelStars, 2);
    }

    public void PlayThreeStarAnim()
    {
        StartCoroutine(ThreeStars());
        if (PlayerPrefs.GetInt(LevelStars) < 3)
            PlayerPrefs.SetInt(LevelStars, 3);
    }

    IEnumerator OneStar()
    {
        yield return new WaitForSeconds(0.5f);
        Star1AnimCont.Play("StarsAnim");
    }

    IEnumerator TwoStars()
    {
        yield return new WaitForSeconds(0.5f);
        Star1AnimCont.Play("StarsAnim"); 
        yield return new WaitForSeconds(0.5f);
        Star2AnimCont.Play("StarsAnim");
    }
    IEnumerator ThreeStars()
    {
        yield return new WaitForSeconds(0.5f);    
        Star1AnimCont.Play("StarsAnim");
        yield return new WaitForSeconds(0.5f);
        Star2AnimCont.Play("StarsAnim");
        yield return new WaitForSeconds(0.5f);
        Star3AnimCont.Play("StarsAnim");
    }
}
