using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{


    public int type;
    public GameObject groundLayout1;
    public GameObject groundLayout2;
    public GameObject groundLayout3;
    public GameObject groundLayout4;
    public GameObject rampLayout1;
    public GameObject rampLayout2;
    public GameObject rampLayout3;
    public GameObject rampLayout4;
    public GameObject wallLayout1;
    public GameObject wallLayout2;
    public GameObject wallLayout3;
    public GameObject wallLayout4;



    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            // type 0 equals ground
            case 0:
                groundLayout1.SetActive(true);
                groundLayout2.SetActive(true);
                groundLayout3.SetActive(true);
                groundLayout4.SetActive(true);
                rampLayout1.SetActive(false);
                rampLayout2.SetActive(false);
                rampLayout3.SetActive(false);
                rampLayout4.SetActive(false);
                wallLayout1.SetActive(false);
                wallLayout2.SetActive(false);
                wallLayout3.SetActive(false);
                wallLayout4.SetActive(false);
                break;
            // type 1 equals ramp
            case 1:
                groundLayout1.SetActive(false);
                groundLayout2.SetActive(false);
                groundLayout3.SetActive(false);
                groundLayout4.SetActive(false);
                rampLayout1.SetActive(true);
                rampLayout2.SetActive(true);
                rampLayout3.SetActive(true);
                rampLayout4.SetActive(true);
                wallLayout1.SetActive(false);
                wallLayout2.SetActive(false);
                wallLayout3.SetActive(false);
                wallLayout4.SetActive(false);
                break;
            // type 2 equals wall
            case 2:
                groundLayout1.SetActive(false);
                groundLayout2.SetActive(false);
                groundLayout3.SetActive(false);
                groundLayout4.SetActive(false);
                rampLayout1.SetActive(false);
                rampLayout2.SetActive(false);
                rampLayout3.SetActive(false);
                rampLayout4.SetActive(false);
                wallLayout1.SetActive(true);
                wallLayout2.SetActive(true);
                wallLayout3.SetActive(true);
                wallLayout4.SetActive(true);
                break;
        }
    }
}
