using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour {

    // private bool[] keys = new bool[5];
    private int keyCount = 0;

	// Use this for initialization
	void Start () {
        keyCount = 0;
	}
	
    public void UseKey()
    {
        keyCount--;
    }

    public void AddKey()
    {
        keyCount++;
    }

    public int GetKeyCount()
    {
        return keyCount;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
