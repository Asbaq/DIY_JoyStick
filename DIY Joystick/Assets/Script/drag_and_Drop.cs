using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_and_Drop : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "Drop_Area";

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider2D>().enabled = false;
    }
    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition();
    }

    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if(hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
            }
            transform.GetComponent<Collider2D>().enabled = true;
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
