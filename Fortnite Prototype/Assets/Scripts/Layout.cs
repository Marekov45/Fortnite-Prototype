using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout : MonoBehaviour
{

    public Material cutout; //if ray doesnt hit layout (player doesnt look at it), layout is 100% invisible
    public Material transparent; //if ray hits layout, it is shown as transparent
    public Element component;
    public bool target;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            this.GetComponent<Renderer>().material = transparent;
        }
        else
        {
            this.GetComponent<Renderer>().material = cutout;
        }
        // as soon as it isnt tracked by the ray anymore
        target = false;
    }
}


