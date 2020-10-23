using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorGhosts : MonoBehaviour
{
    public GameObject GIU;
    public Animator amn,amn2;
    public AudioSource syp,nosyp;
    // Start is called before the first frame update
    void Start()
    {
        amn.SetInteger("am", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator enumerator()
    {
      
        yield return new WaitForSeconds(4f);
        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
            if (GameObject.Find(child.name).GetComponent<Chosts>())
            {
                GameObject.Find(child.name).GetComponent<Chosts>().Recenche();
            }
        }
        yield return new WaitForSeconds(0.5f);
        GIU.SetActive(true);

        amn2.SetInteger("IZAEBALSA", 1);

    }
    public void SetStand()
    {
        nosyp.Stop();
        syp.Play();
        amn.SetInteger("am", 2);
        
        StartCoroutine(enumerator());
        
    }
}
