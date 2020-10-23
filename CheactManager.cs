using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CheactManager : MonoBehaviour
{
    public Text txtset;
  
    
    [SerializeField]
    private float fps_cout = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

  
    void Update()
    {
        fps_cout = 1.0f / Time.deltaTime;
        txtset.text = "FPS:" +Mathf.RoundToInt(fps_cout);
       
    }
}
