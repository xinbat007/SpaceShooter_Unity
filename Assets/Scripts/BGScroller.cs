using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPos = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPos + Vector3.forward * newPos;
		
	}
}
