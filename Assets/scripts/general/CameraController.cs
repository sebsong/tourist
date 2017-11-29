using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
	//public float cameraOffset;
	public float cameraFollowSpeed;
	private Vector3 offset;
	private float z;

	// Use this for initialization
	void Start () {
		offset = Vector3.back;
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = Vector3.Lerp (transform.position, player.position, cameraFollowSpeed * Time.deltaTime) + offset;
        transform.position = new Vector3(newPos.x, newPos.y, z);
	}

}
