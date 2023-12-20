using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButton : MonoBehaviour
{
    public GameObject theButton;
    // Start is called before the first frame update
    void Awake()
    {
        theButton.SetActive(true);
        Destroy(this.gameObject);
    }

    
}
