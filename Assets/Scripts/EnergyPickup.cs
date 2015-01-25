using UnityEngine;
using System.Collections;

public class EnergyPickup : MonoBehaviour {

	int timer = 0;
	public int energyAmount = 20;
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
			c.gameObject.GetComponent<PlayerController>().addEnergy(energyAmount);
			gameObject.renderer.enabled = false;
			timer = regenTime;
		}
	}

}
