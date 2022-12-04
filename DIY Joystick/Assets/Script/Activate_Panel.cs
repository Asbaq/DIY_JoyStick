using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Panel : MonoBehaviour
{
    public GameObject Own_Panel;
    public GameObject Different_Panel;     
    public void PanelOpener() 
    {  
        if (Different_Panel != null) {
            Different_Panel.SetActive(true);  
            Own_Panel.SetActive(false);
        }  
    }  
}
