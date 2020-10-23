using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlau : MonoBehaviour
{
    public SpriteRenderer sprt;
    public Sprite CheckSprite,SetSprite;
    public CollisionHero herCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sprt.sprite == CheckSprite&&herCol.NotCan)
        {
            StartCoroutine(WaitSprite());
        }
    }
    IEnumerator WaitSprite()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        sprt.sprite = SetSprite;
    }
}
