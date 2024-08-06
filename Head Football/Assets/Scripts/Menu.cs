using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject panelLoadding,panelTransit;
    public Image img_loading;
    public static bool isLoadding;

    
     
    // Start is called before the first frame update
    void Start()
    {
        
        if(isLoadding==false)
        {
            StartCoroutine(WaitLoaddingMenu());
        }else{
             panelLoadding.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(img_loading.fillAmount<1)
        {
            img_loading.fillAmount+=0.01f;
        }
        if(img_loading.fillAmount >= 1){
            isLoadding=true;

        }
    }
    IEnumerator WaitLoaddingMenu(){
        yield return new WaitForSeconds(1.5f);
        panelLoadding.SetActive(false);
        yield return new WaitForSeconds(1.5f);
         panelTransit.SetActive(true);
         yield return new WaitForSeconds(1.5f);
        panelTransit.SetActive(false);

    }
    
        
    
}
