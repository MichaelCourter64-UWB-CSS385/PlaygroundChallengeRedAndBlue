using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInteraction : MonoBehaviour {
    [SerializeField] KeyCode interactKey;
    [SerializeField] Vector3 interactionBoxOffset;
    [SerializeField] string color;

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(interactKey))
        {
            RaycastHit2D[] results = Physics2D.BoxCastAll(transform.position + interactionBoxOffset, GetComponent<SpriteRenderer>().size * 2, 0, new Vector2(1, 0), 0);

            // For each collider found:
            for(int i = 0; i < results.Length; i++)
            {
                string resultsTag = results[i].transform.tag;

                // If the result's tag is the correct color, then:
                if(resultsTag.CompareTo(color) == 0)
                {
                    MovableBlock theBlock = results[i].transform.GetComponent<MovableBlock>();

                    // If the block is a draggable block, then:
                    if((DraggableBlock)theBlock)
                    {
                        theBlock.Move(GetComponent<Rigidbody2D>().velocity.x * Time.deltaTime);
                    }
                    else if((WeighableBlock)theBlock)
                    {
                        theBlock.Move(GetComponent<Rigidbody2D>().velocity.y * Time.deltaTime);
                    }
                }
            }
            
        }
	}
}
