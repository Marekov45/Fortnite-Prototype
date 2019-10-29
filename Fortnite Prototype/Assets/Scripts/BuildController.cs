using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{

    public Image wall;
    public Image ramp;
    public Image ground;
    public float maxDist;
    public Camera cam;
    public GameObject player;
    public GameObject element;
    public GameObject layout;
    private GameObject layoutBox;
    private Vector3 layoutVector;
    public GameObject wallPrefab;
    public GameObject groundPrefab;
    public GameObject rampPrefab;
    public GameObject groundLayout;
    public GameObject rampLayout;
    public GameObject wallLayout;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private bool VectorSet = false;
    private int type = 0;
    bool bulletExists = false;
    RaycastHit hit;
    Ray ray;

    // ground is the default element at the start
    private void Start()
    {
        type = 0;
        element = groundPrefab;
        layout = groundLayout;
        ground.color = Color.blue;
    }
    // Update is called once per frame
    private void Update()
    {
        // if the player shoots, destroy the current layout so the layout doesnt travel along with the bullet
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            bulletExists = true;
            Destroy(layoutBox);
            VectorSet = false;
            Fire();
        }
        // choose ground prefab when F1 was pushed
        if (Input.GetKeyDown(KeyCode.F1))
        {
            type = 0;
            element = groundPrefab;
            layout = groundLayout;
            ground.color = Color.blue;
            ramp.color = Color.white;
            wall.color = Color.white;
            Destroy(layoutBox);
            VectorSet = false;
        }
        // choose ramp prefab when F2 was pushed
        else if (Input.GetKey(KeyCode.F2))
        {
            type = 1;
            element = rampPrefab;
            layout = rampLayout;
            ground.color = Color.white;
            ramp.color = Color.blue;
            wall.color = Color.white;
            Destroy(layoutBox);
            VectorSet = false;
        }
        // choose wall prefab when F3 was pushed
        else if (Input.GetKey(KeyCode.F3))
        {
            type = 2;
            element = wallPrefab;
            layout = wallLayout;
            ground.color = Color.white;
            ramp.color = Color.white;
            wall.color = Color.blue;
            Destroy(layoutBox);
            VectorSet = false;
        }
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawLine(ray.origin, ray.GetPoint(maxDist));

        if (Physics.Raycast(ray, out hit, maxDist))
        {
            // makes sure that the layout moves with the player and doesnt get instantiated every time the player looks at another point
            if (layoutVector != hit.point && VectorSet)
            {
                layoutBox.transform.position = hit.point;
                layoutBox.transform.rotation = player.transform.rotation;
            }
            if (!VectorSet && !bulletExists)
            {
                layoutBox = Instantiate(layout, hit.point, player.transform.rotation);
                layoutVector = hit.point;
                VectorSet = true;
            }
            // if raycast collides with the layout, change material from cutout to transparent and update type
            if (hit.collider.gameObject.tag == "Layout")
            {
                hit.collider.gameObject.GetComponent<Layout>().target = true;
                hit.collider.gameObject.GetComponent<Layout>().component.type = type;
                Destroy(layoutBox);
                VectorSet = false;
            }
            // if raycast collides with a building block, only upodate type of element
            if (hit.collider.gameObject.tag == "Building Block")
            {
                hit.collider.gameObject.GetComponent<Element>().type = type;
                Destroy(layoutBox);
                VectorSet = false;
            }



            if (Input.GetKeyDown(KeyCode.R))
            {
                // makes sure that it is not possible to instantiate an element on a building block (prevents player from building towers)
                if (hit.collider.gameObject.tag == "Building Block")
                {

                }
                // if raycast hits layout and button is pressed, instantiate the element on the exact position of the layout
                else if (hit.collider.gameObject.tag == "Layout")
                {
                    GameObject o;
                    o = Instantiate(element, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                }


                // takes care of the first element, before any other elements have been built
                else
                {
                    if (type == 1)
                    {
                        GameObject o = Instantiate(element, hit.point, player.transform.rotation);
                        o.transform.Rotate(0, -90, 45);
                        o.transform.Translate(2f, 0, 0);
                    }
                    else if (type == 2)
                    {
                        GameObject o = Instantiate(element, hit.point, player.transform.rotation);
                        o.transform.Rotate(90, 0, 0);
                        o.transform.Translate(0, 0, -2f);
                    }
                    else
                    {
                        Instantiate(element, hit.point, player.transform.rotation);
                    }

                }
            }
        }



    }



    //Takes care of the shooting mechanism

    private void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
        if (bullet == null)
        {
            bulletExists = false;
        }
    }
}