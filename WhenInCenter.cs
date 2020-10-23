using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WhenInCenter : MonoBehaviour
{
    public float Invisible = 1;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
     if (GetComponent<Text>().color!=new Color(1, 0, 0, 0))
        {
            GetComponent<Text>().color = new Color(1, 0, 0, Invisible);
            Invisible -= 0.01f;
            if (Invisible < 0)
            {
               gameObject.SetActive(false);
                Invisible = 1;
            }
        }   
    }
}
