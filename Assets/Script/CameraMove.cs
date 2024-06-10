using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private float mouseY = 0f;
    [SerializeField] private float yRotateMax;
    [SerializeField] private float yRotateMin;

    private void Update()
    {
        mouseY += Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, yRotateMin, yRotateMax);
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}