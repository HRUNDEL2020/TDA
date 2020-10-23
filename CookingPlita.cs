using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPlita : MonoBehaviour
{
   [SerializeField]
   private bool CanColor;
    
    public bool isCook;
    [SerializeField]
    private float min, max;
    public AudioSource CookPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void YesCook()
    {
        StartCoroutine(WaitCook());
    }
    // Update is called once per frame
    void Update()
    {
        if (CanColor)
        {
            GetComponent<SpriteRenderer>().color += new Color(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max), 0);
        }
    }
    IEnumerator WaitCook()
    {
        CanColor = true;
        CookPlay.Play();
        yield return new WaitForSeconds(24);
        CanColor = false;
        isCook = true;
    }
}
