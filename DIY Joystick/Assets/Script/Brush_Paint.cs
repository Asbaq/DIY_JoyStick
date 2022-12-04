using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush_Paint : MonoBehaviour
{
    public new Camera camera;
    public GameObject brush;
    LineRenderer currentLinerenderer;
    Vector2 lastPos;


    private void Update()
    {
        Paint();
    }
    void Paint()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            createBrush();
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            if(mousePos != lastPos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else
        {
            currentLinerenderer = null;
        }
    }

    void createBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLinerenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousepos = camera.ScreenToWorldPoint(Input.mousePosition);
        currentLinerenderer.SetPosition(0,mousepos);
        currentLinerenderer.SetPosition(1,mousepos);
    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLinerenderer.positionCount++;
        int positionindex = currentLinerenderer.positionCount - 1;
        currentLinerenderer.SetPosition(positionindex, pointPos);
    }
}
