using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class start : MonoBehaviour
{
    public GameObject Cover;
    public GameObject Controller;
    public void Move() 
    {
        if (Cover != null) {
        Cover.transform.DOLocalMove( new Vector3(-155,56,-517), 1f );
        Controller.transform.DOLocalMove( new Vector3(-356,152,-109), 1f );
    }
    }
}

