using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPerspectives : MonoBehaviour
{
    public MouseLook ML;
    public KeyCode FirstPersonKey;
    public KeyCode ThirdPersonKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            if(Input.GetKeyDown(FirstPersonKey))
            {
                ML.firstPerson = true;
                Debug.Log("first person");
            }

            if (Input.GetKeyDown(ThirdPersonKey))
            {
                ML.firstPerson = false;
                Debug.Log("third person");
            }


    }
}
