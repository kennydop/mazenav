using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameManager gM;

    public Image TimeBar;
    public Text TimerText;
    public float countdownTime = 60;
    public Text OnPauseTimeLeft;
    public float Points;
    public int MaxPoints = 60;
    public float LostPoints;
    public Text PointsText;
    public float pointsToMultiplyBy = 5;
    void Start()
    {
        TimerText.enabled = true;
        TimeBar.enabled = true;
        gM.iGCanvas.SetActive(true);
    }
    private void Update()
    {
        LostPoints += Time.deltaTime;
        Points = (MaxPoints - LostPoints) * pointsToMultiplyBy;
        PointsText.text = Points.ToString("0");


        countdownTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(countdownTime / 60f);
        int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        TimerText.text = niceTime;

        OnPauseTimeLeft.text = "You Have " + niceTime + " Left.";

        TimeBar.fillAmount = countdownTime / MaxPoints;

        if (countdownTime < 0)
        {
            countdownTime = 0;
        }

        if (Points <= 0)
        {
            gM.GameOver();
        }

        if (Points < 0)
        {
            Points = 0;
        }

    }

    public void Restart()
    {
        EndColDect.GameSpeed = 1;
    }
}



