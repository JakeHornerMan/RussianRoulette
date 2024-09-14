using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Look Settings")]
    public Camera playerCamera;
    public bool canLook = true;
    public float lookSpeed = 2f;
    public float lookXLimit = 40f;
    public float lookYLimit = 90f;
    float rotationX = 0;
    float rotationY = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update() {
        if(canLook){
            Looking(); 
        }
    }

    private void Looking(){
        rotationX += - Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X")  * lookSpeed, 0);

        // rotationY += - Input.GetAxis("Mouse X") * lookSpeed;
        // rotationY = Mathf.Clamp(rotationY, -lookYLimit, lookYLimit);
        // transform.rotation *= Quaternion.Euler(0, rotationY * lookSpeed, 0);

    }
}
