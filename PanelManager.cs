using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PanelManager : MonoBehaviour,IPointerClickHandler
{
    public Sprite panelSprite;
    public GameObject opengm;
    public AudioSource open;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnEnable()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-18, 11);
        GetComponent<Image>().color = Color.white;
        CheckIsOpasty();
    }
    IEnumerator Opasty()
    {
        while (gameObject.GetComponent<Image>().color.a > 0)
        {
            gameObject.GetComponent<Image>().color -= new Color(0, 0, 0, 0.1f);

            yield return new WaitForSeconds(Random.Range(0, 0.2f));
        }
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(12000, 30000);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckIsOpasty()
    {
        int max = 0;
        for (int a = 0; a < 5; a++)
        {
            if (transform.GetChild(a).GetComponent<RotateBolt>().hp > 100)
            {
                max++;
                if (max == 3)
                {
                    opengm.SetActive(true);
                    open.Play();
                    opengm.GetComponentInChildren<TapOpenPanel>().panelKrest = gameObject.GetComponentInChildren<RotateBolt>().panelobj;
                    gameObject.GetComponentInChildren<RotateBolt>().panelobj.GetComponent<SpriteRenderer>().sprite = panelSprite;
                    StartCoroutine(Opasty());
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CheckIsOpasty();
    }
}
