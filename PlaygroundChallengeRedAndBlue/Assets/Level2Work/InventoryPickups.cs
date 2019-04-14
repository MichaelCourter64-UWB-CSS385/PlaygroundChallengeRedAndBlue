using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickups : MonoBehaviour {

    private GameObject inventoryItem;
    private bool hasItem;

    public float pickUpDistance = 2f;

    
    GameObject findNearestPickup()      // NOTE: add string parameter for the tag type (color)
    {
        // Code borrowed from unity documentation on
        // GameObject.FindGameObjectWithTag() method
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Pickup");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        if (distance <= pickUpDistance)
            return closest;
        else return null;
    }

    void Grab() // NOTE: add string parameter for the tag type (color)
    {
        GameObject item = findNearestPickup();
        if (item != null)
        {
            // // Attempt 1
            //inventoryItem = item;
            //item.SetActive(false);
            //hasItem = true;

            // // Attempt 2
            inventoryItem = Instantiate(item);
            inventoryItem.transform.position = new Vector2(1000f, 1000f);
            Destroy(item);
            hasItem = true;

            // Attempt 3
            //inventoryItem = item;
            //item.transform.position = new Vector2(100f, 100f);
            //hasItem = true;

        }
    }

    // Hacked together check for whether there is something blocking 
    // where the object would be dropped
    bool CanDrop()
    {
        Vector2 itemSize = inventoryItem.GetComponent<Collider>().bounds.size;
        Vector2 playerSize = this.GetComponent<Collider>().bounds.size;
        Vector2 playerPos = this.transform.position;
        Vector2 castStart;
        Vector2 castEnd;
        float direction = this.transform.forward.x;

        if (direction > 0)
        {
            castStart.x = playerPos.x + (playerSize.x / 2);
            castEnd.x = castStart.x + itemSize.x;
        }
        else
        {
            castStart.x = playerPos.x + (playerSize.x / 2);
            castEnd.x = castStart.x + itemSize.x;
        }
        castStart.y = playerPos.y;
        castEnd.y = playerPos.y;

        RaycastHit2D hit = Physics2D.Linecast(castStart, castEnd);

        if (hit != null)
            return false;
        else
            return true;
    }

    void Drop()
    {
        // // Attempt 2
        Vector2 itemSize = inventoryItem.GetComponent<Collider>().bounds.size;
        Vector2 playerSize = this.GetComponent<Collider>().bounds.size;
        Vector2 playerPos = this.transform.position;
        Vector2 newItemLocation;
        newItemLocation.x = (playerPos.x + (playerSize.x / 2)) + (itemSize.x / 2);
        newItemLocation.y = playerPos.y;
        inventoryItem.transform.position = newItemLocation;
        //inventoryItem.SetActive(true);
        hasItem = false;

        // Attempt 3
        //Vector2 itemSize = inventoryItem.GetComponent<Collider>().bounds.size;
        //Vector2 playerSize = this.GetComponent<Collider>().bounds.size;
        //Vector2 playerPos = this.transform.position;
        //Vector2 newItemLocation;
        //newItemLocation.x = (playerPos.x + (playerSize.x / 2)) + (itemSize.x / 2);
        //newItemLocation.y = playerPos.y;
        //inventoryItem.transform.position = newItemLocation;
        ////inventoryItem.SetActive(true);
        //hasItem = false;

    }

    // Use this for initialization
    void Start ()
    {
        hasItem = false;
        inventoryItem = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Player")
        {
            // If interact key is pressed, invetory is empty and item is
            // within range, store item in player's invetory and destroy
            // item in game world.
            if (Input.GetKeyDown(KeyCode.RightControl) && hasItem == false)
            {
                Grab();

            }
            // If interact key is pressed and invetory has an item, drop the 
            // item in front of the player.
            else if (Input.GetKeyDown(KeyCode.RightControl) && hasItem == true)
            {
                if (this.CanDrop())
                {
                    Drop();
                }
            }
        }
        else if (this.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && hasItem == false)
            {
                Grab();
            }
            // If interact key is pressed and invetory has an item, drop the 
            // item in front of the player.
            else if (Input.GetKeyDown(KeyCode.LeftControl) && hasItem == true)
            {
                if (this.CanDrop())
                {
                    Drop();
                }
            }
        }
    }
}
