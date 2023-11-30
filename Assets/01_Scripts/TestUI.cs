using UnityEngine;


public class TestUI : MonoBehaviour
{
    public void SetObjectActive(GameObject openObj)
    {
        openObj.SetActive(true);
    }
    public void DisableObject(GameObject currentObj)
    {
        currentObj.SetActive(false);
    }

}
