using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
	public float cameraFollowSpeed;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, player.position, cameraFollowSpeed * Time.deltaTime) + offset;
	}

}
