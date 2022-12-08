using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelect : MonoBehaviour
{
    public GameObject selectUI;
    // Start is called before the first frame update
    void Start()
    {
        selectUI.SetActive(false);
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void pointerEnter()
    {
        selectUI.SetActive(true);
    }

    //Detect when Cursor leaves the GameObject
    public void pointerExit()
    {
        selectUI.SetActive(false);
    }
}
