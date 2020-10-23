using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ClosePanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject closeObj, closeObj2, openObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        openObj.SetActive(true);
        closeObj.SetActive(false);
        closeObj2.SetActive(false);
        if (GameObject.Find("gg").GetComponent<MoveHero>().IsPc == false)
        {
            GameObject.Find("gg").GetComponent<MoveHero>().IsPc = true;
        }
    }
}
