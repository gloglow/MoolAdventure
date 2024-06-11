using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacter : Controller
{
    InputManager inputManager;

    [SerializeField] private float rotateSensitivity;

    private void Start()
    {
        inputManager = GameManager.inputManager;

    }

    public override void Update()
    {
        base.Update();
        if (inputManager.Attack.down)
        {
            Attack();
        }
    }

    public override void GetMoveDirection()
    {
        moveDirection =  new Vector3(inputManager.horizontalAxis, 0, inputManager.verticalAxis);
    }

    public override void GetRotateQuaternion()
    {
        rotateVector.y = inputManager.mouseRotationY * rotateSensitivity;
    }

    public override void UpdateAttackPattern()
    {
        attackPattern++;
        attackPattern = attackPattern > 2 ? 0 : attackPattern;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Portal")
        {
            Portal _portal = other.GetComponent<Portal>();
            StartCoroutine(_portal.OnPortal());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Portal")
        {
            Portal _portal = other.GetComponent<Portal>();
            _portal.OffPortal();
        }
    }
}
