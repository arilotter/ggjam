using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Bullet _bullet;
	public enum WeaponType{rpgs, chainGun, plasma};	
	public WeaponType type;
	public int damage;
	public int energy;
	//public PlayerController player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown("space"))
            fireGun();
	}
	
	public void fireGun(){
		Debug.Log("FIRE");
	
		Rigidbody2D clone;
		clone = Instantiate(_bullet.rigidbody2D, transform.position, transform.rotation) as Rigidbody2D;
		//clone.velocity = transform.TransformDirection(Vector3.forward * 10);		
		clone.velocity = transform.right * 5;
		
		//_bullet.rigidbody2D.velocity = new Vector2(5, 0);
	}
}
