using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactive : MonoBehaviour
{
    public GameObject Cover; 
    public GameObject Container; 
    [SerializeField] private AudioSource SoundEffect; 
    [SerializeField] private Material myMaterial;
    public void DeactiveGameObject() 
    {  
        if (Cover != null ) {
            Cover.SetActive(false);  
        }  
        myMaterial.color = Color.black;
        Container.SetActive(false);
        SoundEffect.Play();
    }  
}
