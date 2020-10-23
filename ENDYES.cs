using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ENDYES : MonoBehaviour
{
    public AudioSource play;
    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    public void OVELIKIYSYPNAVARILY()
    {
        play.Play();
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
