using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fol : MonoBehaviour
{
    private Transform Target;
    public float Distance = 5;
    public float Angle = 43;
    public float Height = 9.5f;
    private float SmoothSpeed = 0.5f;
    private Vector3 refVelocity;
    private Animator MainCamAnimCont;
    private string LevelCamAnim;
    public Score GScore;
    public GameManager GMan;
    public Text LevelNotice;
    public GameObject NCanvas;
    private GameObject iGCanvas;

    void Start()
    {
        iGCanvas = GameObject.FindGameObjectWithTag("iGCanvas");
        NCanvas.SetActive(true);
        LevelNotice.enabled = true;
        LevelNotice.text = SceneManager.GetActiveScene().name.ToUpper();
        LevelCamAnim = SceneManager.GetActiveScene().name + " Anim";
        MainCamAnimCont = GetComponent<Animator>();
        MainCamAnimCont.Play(LevelCamAnim);
        GScore.enabled = false;
        StartCoroutine(DisableAnim());
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        HandleCamera(); 
    }

    void Update()
    {
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        if (!Target)
        {
            return;
        }

        Vector3 WorldPosition = (Vector3.forward * -Distance) + (Vector3.up * Height);
        Vector3 RotatedVector = Quaternion.AngleAxis(Angle, Vector3.up) * WorldPosition;
        Vector3 FlatTargetPosition = Target.position;
        FlatTargetPosition.y = 0f;
        Vector3 FinalPosition = FlatTargetPosition + RotatedVector;

        transform.position = Vector3.SmoothDamp(transform.position, FinalPosition, ref refVelocity, SmoothSpeed);
        transform.LookAt(FlatTargetPosition);
    }

    IEnumerator DisableAnim()
    {
        yield return new WaitForSeconds(7);
        GetComponent<Animator>().enabled = false;
        GScore.enabled = true;
        LevelNotice.enabled = false;
        NCanvas.SetActive(false);
    }

    void Canvas_On()
    {
        iGCanvas.SetActive(true);
    }

}
