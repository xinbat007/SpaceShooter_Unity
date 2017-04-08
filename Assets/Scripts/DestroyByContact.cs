using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameController gameController;
	public int score;

	// Use this for initialization
	void Start () {
		GameObject gamecontrollerobject = GameObject.FindWithTag ("GameController");
		if (gamecontrollerobject != null) {
			gameController = gamecontrollerobject.GetComponent<GameController> ();
		}
	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary")
			return;
		Instantiate (explosion, this.transform.position, this.transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		} else {
			gameController.AddScore (score);
		}
		Destroy (other.gameObject);
		Destroy (this.gameObject);
	}
}
