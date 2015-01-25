using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	int timer = 0;
	public int healAmount = 20;
	public int regenTime = 500;

	void Start () {
		
	}
	
	void Update () {
		if(timer > 0) {
			timer --;
		} else if(timer == 0) {
			gameObject.renderer.enabled = true;
			timer --;
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		if((c.gameObject.tag == "Player 1" || c.gameObject.tag == "Player 2") && gameObject.renderer.enabled) {
			c.gameObject.GetComponent<PlayerController>().heal(healAmount);
			gameObject.renderer.enabled = false;
			timer = regenTime;
		}
	}

}
