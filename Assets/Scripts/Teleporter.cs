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
		Debug.Log ("AAA");
		if(!inUse) {
			if(c.gameObject.tag == "Player 1" || c.gameObject.tag == "Player 2") {
				Teleporter t = this;
				while(t == this) {
					int r = Random.Range(0, teleporters.Count);
					t = teleporters[r];
				}

				t.inUse = true;
				c.gameObject.transform.position = t.gameObject.transform.position;
			}
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		inUse = false;
	}
}
