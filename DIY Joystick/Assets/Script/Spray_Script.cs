using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray_Script : MonoBehaviour
{
    public GameObject S;
    [SerializeField] private AudioSource SoundEffect; 
    public void Spray() 
    {  
        if(S.name == "Red_Spray_Can" )
        {  
            bool isActive = S.activeSelf;  
            S.SetActive(!isActive);  
            SoundEffect.Play();
        }
        else if(S.name == "Green_Spray_Can" )
        {  
            bool isActive = S.activeSelf;  
            S.SetActive(!isActive);  
            SoundEffect.Play();
        }
        else if(S.name == "Yellow_Spray_Can" )
        {  
            bool isActive = S.activeSelf;  
            S.SetActive(!isActive);  
            SoundEffect.Play();
        }
        else if(S.name == "Cyan_Spray_Can" )
        {  
            bool isActive = S.activeSelf;  
            S.SetActive(!isActive);  
            SoundEffect.Play();
        }
        else
        {  
            bool isActive = S.activeSelf;  
            S.SetActive(!isActive);  
            SoundEffect.Play();
     }
}
}  

