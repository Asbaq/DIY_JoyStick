using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Script : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    [SerializeField] private GameObject S;
    [SerializeField] private AudioSource SoundEffect; 

    // Update is called once per frame
    void OnMouseDown()
    {
                 if(S.name == "Red_Spray_Can")
                {
                    myMaterial.color = Color.red;
                    SoundEffect.Play();
                }
                else if(S.name == "Green_Spray_Can")
                {
                    myMaterial.color = Color.green;
                    SoundEffect.Play();
                }
                else if(S.name == "Yellow_Spray_Can")
                {
                    myMaterial.color = Color.yellow;
                    SoundEffect.Play();
                }
                else if(S.name == "Cyan_Spray_Can")
                {
                    myMaterial.color = Color.cyan;
                    SoundEffect.Play();
                }
                else if(S.name == "Cleaner")
                {
                    myMaterial.color = Color.white;
                    SoundEffect.Play();
                }
                else
                {
                    myMaterial.color = Color.blue;
                    SoundEffect.Play();
                }
    }       

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition();
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

}
