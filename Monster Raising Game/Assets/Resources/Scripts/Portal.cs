using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string LoadingScreenName;
    public string SceneToLoad;
    public string SaveKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "PLAYER")
        {
            PlayerPrefs.SetString(SaveKey, SceneToLoad);
            SceneManager.LoadScene(LoadingScreenName);
        }
    }
}
