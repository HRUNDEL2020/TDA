using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OpastyStart : MonoBehaviour
{
    public Image Windows;
    public Text  TextSave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Windows.color.a >1)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void StartC()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while (Windows.color.a < 255)
        {
            Windows.color = new Color(Windows.color.r,Windows.color.g,Windows.color.b,Windows.color.a+0.003f);
            
            TextSave.color = new Color(TextSave.color.r, TextSave.color.g, TextSave.color.b, TextSave.color.a + 0.003f);
            
            yield return new WaitForFixedUpdate();
           
        }
       
        
    }
}
