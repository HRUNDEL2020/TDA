using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapOpenPanel : MonoBehaviour,IPointerDownHandler
{
    public int count = 0;
    public GameObject panelKrest;
    public Sprite sprite,sprite2,sprite3;
    public AudioSource ar;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        gameObject.GetComponent<Image>().sprite = sprite2;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("e");
        panelKrest.tag = "not";
        panelKrest.GetComponent<SpriteRenderer>().sprite = sprite3;
        
        if (gameObject.GetComponent<Image>().sprite != sprite)
        {
            ar.Play();
            count++;
        }
        gameObject.GetComponent<Image>().sprite = sprite;
       
        if (count == 3)
        {
            Destroy(GameObject.Find("man"));
            Destroy(GameObject.Find("man (2)"));
            GameObject.Find("Point Light 2D").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 10000;
        }
        
    }
}
