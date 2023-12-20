using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObj : MonoBehaviour
{
    public GameObject theObj;
    public GameObject canvasObj;

    public void InstantiateTheObj()
    {
        gameObject.SetActive(false);
        Instantiate(theObj, transform.position, Quaternion.identity);
        Instantiate(canvasObj);
        Canvas canvasComp = canvasObj.GetComponent<Canvas>();
        canvasComp.renderMode = RenderMode.ScreenSpaceCamera;


        canvasObj.SetActive(true);
    }
        
    
}
