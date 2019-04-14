using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPlaces : MonoBehaviour {

    private GameObject Player2;

	void Update () {
		if (Input.GetKeyUp("space")) {
            Player2 = GameObject.Find("Player2");
            Vector3 temp = this.transform.position;
            this.transform.position = Player2.transform.position;
            Player2.transform.position = temp;
        }
	}
}
