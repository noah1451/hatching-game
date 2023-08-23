using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("VARIABLES")]
    public float mouseSensitivity = 100;
    public Transform PlayerBody;
    public float MouseClamp = 65;
    public Vector3 ThirdPersonPosition;
    public Vector3 FirstPersonPosition;
    [Header("DEBUG")]
    public float xRotation = 0f;
    [Header("RUNTIME")]
    public bool wantCursor;
    public bool firstPerson;
    [Header("THIRD PERSON")]
    public Transform lookAt;
    public float sensivity = 4.0f;
    public float distance = 10.0f;
    private const float YMin = -50.0f;
    private const float YMax = 50.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    float mouseY;
    float mouseX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        if (firstPerson == true)
        {
            transform.localPosition = FirstPersonPosition;


            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -MouseClamp, MouseClamp);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PlayerBody.Rotate(Vector3.up, mouseX);

        }

        if (firstPerson == false)
        {
            transform.localPosition = ThirdPersonPosition;

            currentX += mouseX;
            currentY -= mouseY;

            currentY = Mathf.Clamp(currentY, YMin, YMax);

            Vector3 Direction = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            transform.position = lookAt.position + rotation * Direction;
            transform.LookAt(lookAt.position);
            PlayerBody.Rotate(0, mouseX, 0);
        }

        if (wantCursor)
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

    // Update is called once per frame
    void FixedUpdate()
    {


    }

    public void ChangeCursor(bool ChangeTo)
    {
        wantCursor = ChangeTo;
    }
}
