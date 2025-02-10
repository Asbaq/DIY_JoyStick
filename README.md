Here's a documentation based on your request:

---

# 🎮 **DIY JoyStick**  

![Capture](https://user-images.githubusercontent.com/62818241/205512630-400116f7-7bab-4024-bb4c-ca07920d0f4d.PNG)

## 📌 **Introduction**  
The **DIY JoyStick** project focuses on creating a painting and interactive experience with draggable objects, customizable color sprays, and dynamic UI panels. It involves manipulating 2D elements using different tools like brushes, spray cans, and cleaners, with each component responding to mouse input. The project includes systems to change colors, draw on surfaces, and interact with panels dynamically.

🔗 Video Trailer

https://youtube.com/shorts/imdJociNnSs?si=60khfnKDTpJWgEjm

## 🔥 **Features**  
- 🖌️ **Brush Painting**: Allows users to paint on surfaces using a brush tool, tracking mouse movement.
- 🎨 **Color Spray**: Use different spray cans to change the color of an object or surface.
- 🧹 **Cleaner Tool**: Clean or reset painted surfaces.
- 🖱️ **Mouse Interaction**: Click-and-drag to interact with objects and surfaces.
- 🧩 **UI Panels**: Toggle and open different UI panels dynamically.
- 🚪 **Object Movement**: Draggable objects that respond to mouse events for repositioning.

---

## 🏗️ **How It Works**  

### 📌 **Panel Activation**  
Toggles between different panels in the UI by setting them active or inactive.

```csharp
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
```

---

### 📌 **Brush Painting**  
A simple system that lets the player paint by clicking and dragging the mouse, instantiating brush points along the path.

```csharp
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
```

---

### 📌 **Cleaner Tool**  
Toggles between the cleaner tool’s active and inactive state.

```csharp
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
```

---

### 📌 **Color Change (Spray Cans)**  
Changes the color of an object based on the selected spray can.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Script : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    [SerializeField] private GameObject S;
    [SerializeField] private AudioSource SoundEffect; 

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
```

---

### 📌 **Drag-and-Drop Interaction**  
Allows dragging objects and placing them into a drop area.

```csharp
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
```

---

### 📌 **Object Deactivation**  
Deactivates an object and plays a sound effect.

```csharp
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
```

---

### 📌 **Spray Cans Toggle**  
Toggles the spray cans’ activation states and plays a sound effect.

```csharp
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
```

---

## 🎯 **Conclusion**  
**DIY JoyStick** provides a set of interactive tools to paint, move objects, and change colors dynamically. It is a great way to explore UI interactions, painting systems, and object manipulation in Unity. This project can be extended with more features like complex brush shapes, more spray can colors, or advanced panel transitions to create a fully immersive experience. 🎨✨

