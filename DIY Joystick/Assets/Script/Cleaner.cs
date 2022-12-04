using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
   public GameObject Cleaners;

   public void Move() 
    {
         if (Cleaners != null) {
            bool isActive = Cleaners.activeSelf;  
            Cleaners.SetActive(!isActive); 
        }  
    }
}

