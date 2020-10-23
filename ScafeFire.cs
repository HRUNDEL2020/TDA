using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScafeFire : MonoBehaviour
{
    public AudioSource fire;
    public GameObject go1, go2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetActiveObj()
    {
        go1.SetActive(true);
        go2.SetActive(true);
        fire.Play();
        StartCoroutine(WaitDest());
    }
   IEnumerator WaitDest()
    {
        yield return new WaitForSeconds(Random.Range(5, 7));
        Destroy(go1);
        Destroy(go2);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
