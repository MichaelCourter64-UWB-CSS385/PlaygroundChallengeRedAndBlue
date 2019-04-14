﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour {

    private int keyCount;

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
