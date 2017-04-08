using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	// Use this for initialization
	void Start () {
	}

	void Update() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			this.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		Rigidbody curRigid = this.gameObject.GetComponent<Rigidbody> ();
		curRigid.velocity = movement * speed;
		Vector3 curPos = curRigid.position;
		curRigid.position = new Vector3 (
			Mathf.Clamp(curPos.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(curPos.z, boundary.zMin, boundary.zMax)
		);
		curRigid.rotation = Quaternion.Euler (0.0f, 0.0f, curRigid.velocity.x * -tilt);
	}
}
