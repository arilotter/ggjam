using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Bullet _bullet;
	public enum WeaponType{rpgs, chainGun, plasma};	
	public WeaponType type;
	//public PlayerController player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown("space"))
            fireGun();
	}
	
	void fireGun(){
		_bullet.rigidbody2D.velocity = new Vector2(5, 0);
	}
}
