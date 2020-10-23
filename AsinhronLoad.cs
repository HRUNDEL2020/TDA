using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AsinhronLoad : MonoBehaviour
{
    public bool Die;
    public GameObject DieObj;
    public GameObject ActiveObject;
    public float progres;
    public int SceneId = 0;
    public Text TxtLoad;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCor(int saveId)
    {
        SceneId = saveId;
        StartCoroutine(AsinhronLoading());
    }
    IEnumerator AsinhronLoading()
    {
       
        ActiveObject.SetActive(true);
      
        if (!Die)
        {
            
            DieObj.SetActive(false);
        }
        yield return new WaitForSeconds(Random.Range(2, 4));
        AsyncOperation LoadScene = SceneManager.LoadSceneAsync(SceneId);
        while (!LoadScene.isDone)
        {
            progres = LoadScene.progress / 0.9f;
            TxtLoad.text = "Loading..." + progres*100+"%";
            yield return null;
        }
    }
}
