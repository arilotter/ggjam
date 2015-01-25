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

	void OnTriggerEnter2D(Collider2D c) {
		if(!inUse) {
			if(c.gameObject.tag == "Player 1" || c.gameObject.tag == "Player 2") {
				Teleporter t = this;
				while(t == this) {
					int r = Random.Range(0, teleporters.Count);
					t = teleporters[r];
				}

				t.inUse = true;
				Vector2 p = t.gameObject.transform.position;
				c.gameObject.transform.position = new Vector3(p.x, p.y, -1); // player's z should be -1 so they're on top of teleporters
			}
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		inUse = false;
	}
}
