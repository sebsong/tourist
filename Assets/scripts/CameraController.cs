using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
	//public float cameraOffset;
	public float cameraFollowSpeed;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = Vector3.back;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, player.position, cameraFollowSpeed * Time.deltaTime) + offset;
	}

}
