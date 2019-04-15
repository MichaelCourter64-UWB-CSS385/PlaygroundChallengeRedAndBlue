using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    // Automatically picks up keys that match player type
    // when they are walked over.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == this.tag)
        {
            if (other.GetComponent<KeyInventory>().GetKeyCount() > 0)
            {
                other.GetComponent<KeyInventory>().UseKey();
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
