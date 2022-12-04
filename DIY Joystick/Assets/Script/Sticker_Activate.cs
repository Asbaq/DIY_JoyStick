using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticker_Activate : MonoBehaviour
{
    public GameObject Container;
    public void Activate_Sticker() 
    {  
        if (Container != null) {
            Container.SetActive(true);  
        }  
    }  
}
