using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
   
    [SerializeField]
    private MoveHero mvher;
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "right":
                mvher.RightDown();
                break;
            case "left":
                mvher.LeftDown();
                break;
            case "up":
                mvher.UpDown();
                break;
            case "down":
                mvher.DownDown();
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mvher.UPUP();
    }

    // Start is called before the first frame update
    void Start()
    {
        mvher = GameObject.Find("gg").GetComponent<MoveHero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
