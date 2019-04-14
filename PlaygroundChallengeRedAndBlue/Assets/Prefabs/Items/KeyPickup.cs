using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour {
    // Automatically picks up keys that match player type
    // when they are walked over.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == this.tag)
        {
            other.GetComponent<KeyInventory>().AddKey();
            //this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
