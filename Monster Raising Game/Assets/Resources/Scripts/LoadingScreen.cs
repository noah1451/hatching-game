using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public string SaveKey;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(SaveKey));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
