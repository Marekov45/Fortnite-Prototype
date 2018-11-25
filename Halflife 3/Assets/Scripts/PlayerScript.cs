using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Transform hand;
    public LayerMask interactionLayer;
    public Camera cam;
    public float throwForce;
    public GameObject boxPrefab;
    public GameObject bombPrefab;
    private Rigidbody objInHand;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (objInHand != null)
            {
                objInHand.transform.parent = null;
                objInHand.isKinematic = false;
                objInHand.AddForce(cam.transform.forward * throwForce);
                objInHand = null;
            }
            else
            {
                GameObject bomb = Instantiate(bombPrefab, hand.position, Quaternion.identity);
                bomb.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwForce);

            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0.25f;
            else
                Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(boxPrefab, hand.position, Quaternion.identity);
        }
    }

}
