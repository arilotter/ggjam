using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class statusBar : MonoBehaviour {

	public Scrollbar bar;
	public float health;
	// Use this for initialization
	public void damage(float val){
		health -= val;
		bar.size = health / 100f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
