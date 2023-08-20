using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("VARIABLES")]
    public float mouseSensitivity = 100;
    public Transform PlayerBody;
    public float MouseClamp = 65;
    [Header("DEBUG")]
    public float xRotation = 0f;
    [Header("RUNTIME")]
    public bool wantCursor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -MouseClamp, MouseClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up, mouseX);

        if(wantCursor)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (!wantCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }


    }

    public void ChangeCursor(bool ChangeTo)
    {
        wantCursor = ChangeTo;
    }
}
