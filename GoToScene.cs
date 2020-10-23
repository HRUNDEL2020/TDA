using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true, 60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToScen()
    {
        SceneManager.LoadScene(1);
    }
}
