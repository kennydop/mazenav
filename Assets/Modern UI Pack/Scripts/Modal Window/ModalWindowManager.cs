using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class ModalWindowManager : MonoBehaviour
{
    private Animator mwAnimator;
   

    void Start()
    {
        mwAnimator = GetComponent<Animator>();
        
    }

    public void OpenWindow()
    {
        mwAnimator.Play("Fade-in");
    }

    public void CloseWindow()
    {
        mwAnimator.Play("Fade-out");
    }
}
