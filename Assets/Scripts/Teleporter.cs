using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleporter : MonoBehaviour {
	private static List<Teleporter> teleporters = new List<Teleporter>();
	private bool inUse = false;
	void Start() {
		teleporters.Add(this);
	}
	
	void Update() {
		
	}

	void OnCollisionEnter(Collision2D c) {
		if(!inUse) {
			if(c.gameObject.tag == "Player 1" || c.gameObject.tag == "Player 2") {
				int r = Random.Range(0, teleporters.Count);
				teleporters[r].inUse = true;
				c.gameObject.transform.position = teleporters[r].gameObject.transform.position;
			}
		}
	}

	void OnCollisionExit(Collision2D c) {
		inUse = false;
	}
}
