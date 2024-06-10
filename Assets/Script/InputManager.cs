using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    //　プレイヤー入力関連
    public InputKey Forward = new InputKey(KeyCode.W);
    public InputKey Back = new InputKey(KeyCode.S);
    public InputKey Left = new InputKey(KeyCode.A);
    public InputKey Right = new InputKey(KeyCode.D);

    public InputKey Attack = new InputKey(KeyCode.Mouse0);
    public InputKey Skill1 = new InputKey(KeyCode.Mouse1);
    public InputKey Skill2 = new InputKey(KeyCode.E);
    public InputKey Skill3 = new InputKey(KeyCode.R);
    public InputKey Skill4 = new InputKey(KeyCode.T);

    public InputKey Dodge = new InputKey(KeyCode.LeftShift);
    public InputKey Jump = new InputKey(KeyCode.Space);

    public float horizontalAxis = 0;
    public float verticalAxis = 0;
    public float mouseRotationY;
    public float lastMouseRotationY;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        GetInput();
        horizontalAxis = GetAxis(Right, Left);
        verticalAxis = GetAxis(Forward, Back);

        mouseRotationY += Input.GetAxisRaw("Mouse X");
    }

    private void GetInput()
    {
        Forward.Get();
        Back.Get();
        Left.Get();
        Right.Get();
        
        Attack.Get();
        Skill1.Get();
        Skill2.Get();
        Skill3.Get();
        Skill4.Get();

        Dodge.Get();
        Jump.Get();
   
    }

    public float GetAxis(InputKey positive, InputKey negative)
    {
        if (positive.held == negative.held)
            return 0;

        if (positive.held)
            return 1;
        else
            return -1;
    }
}
