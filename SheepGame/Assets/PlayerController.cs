﻿using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public GameObject camera;
	public BullTimer timerScript;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (x, 0, y);

		rb.velocity = movement * 3f;

		if (x != 0 && y != 0) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, Mathf.Atan2 (x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
		}
		//transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
		Quaternion q = transform.rotation;
		q.eulerAngles = new Vector3 (0, q.eulerAngles.y, 0);
		transform.rotation = q;

		Vector3 tmp = transform.position;
		tmp.y = 0;
		transform.position = tmp;


		/*Vector3 dir = transform.position;
		dir = camera.transform.TransformDirection (dir);
		dir.y = 0;
		Vector3.Normalize (dir);*/
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.name == "GameOverCollider")
			{
			Destroy(GameObject.FindGameObjectWithTag ("bull"));
			TextMesh bullText = GameObject.Find ("BullEnd").GetComponent<TextMesh> ();
			bullText.text = "Failure";
			timerScript.victory = false;
		}
	}
}
