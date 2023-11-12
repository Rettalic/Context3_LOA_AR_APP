using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Vector3 Vposition;
    public GameObject button;

    public void Button1() { 
        button.SetActive(true);

        button.transform.position = Vposition;
        button2.SetActive(false);
        button3.SetActive(false);


    }

    public GameObject button2;

    public void Button2()
    {
        button2.SetActive(true);

        button2.transform.position = Vposition;
        button.SetActive(false);
        button3.SetActive(false);

    }

    public GameObject button3;

    public void Button3()
    {
        button3.SetActive(true);

        button3.transform.position = Vposition;
        button2.SetActive(false);
        button.SetActive(false);

    }
}
