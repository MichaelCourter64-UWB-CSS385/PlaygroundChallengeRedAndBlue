using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHighestLeader : MonoBehaviour {
    const short DEFAULT_LEADER = 0;

    [SerializeField] GameObject[] leaders;
    [SerializeField] float smoothTime;
//    [SerializeField] float cameraFollowTriggerPercentage;
    [SerializeField] float minimumHeight;

    Vector3 dampVelocity = new Vector3();

	// Update is called once per frame
	void LateUpdate () {
        Camera thisCamera = GetComponent<Camera>();

        float leadersHeight = -1;
        GameObject highestLeader = leaders[DEFAULT_LEADER];
        float actualHeight = -1;

//        float verticalScreenRatioPosition = -1;

        for (int i = 1; i < leaders.Length; i++)
        {
            leadersHeight = leaders[i].transform.position.y;

            if (leadersHeight > highestLeader.transform.position.y)
            {
                highestLeader = leaders[i];
            }
        }

//        verticalScreenRatioPosition = (thisCamera.pixelHeight - thisCamera.WorldToScreenPoint(highestLeader.transform.position).y) / thisCamera.pixelHeight;

        actualHeight = Mathf.Clamp(highestLeader.transform.position.y, minimumHeight, int.MaxValue);

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, actualHeight, transform.position.z), ref dampVelocity, smoothTime);
	}
}
