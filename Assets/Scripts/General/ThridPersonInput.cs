using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System.Collections;

public class ThridPersonInput : MonoBehaviour
{
    public EndColDect LevelDone;
    public FixedJoystick LeftJoystick;
    public FixedButton Button;
    protected ThirdPersonUserControl Control;
    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Animator anim;
    public float speed = 2;


    // Use this for initialization
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()

    {
        Control.Hinput = LeftJoystick.inputVector.x;
        Control.Vinput = LeftJoystick.inputVector.y;

        if (Button.Pressed)
        {
            anim.SetInteger("condition", 1);
            moveDir = new Vector3(0, 0, 1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if (!Button.Pressed)
        {
            anim.SetInteger("condition", 0);
            moveDir = new Vector3(0, 0, 0);
        }
       
            controller.Move(moveDir * EndColDect.GameSpeed * Time.deltaTime);
    }

    
}