using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Bullet _bullet;
	public enum WeaponType{rpgs, chainGun, plasma};	
	public WeaponType type;
	public int energy;
	int wait = 0;
	//public PlayerController player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown("space"))
            fireGun();
	}
	
	public bool fireGun(){
		if (wait == 0)
		{
			Debug.Log(wait);
			Bullet clone;
			clone = Instantiate(_bullet, transform.position, transform.rotation) as Bullet;
			//clone.velocity = transform.TransformDirection(Vector3.forward * 10);		
			clone.rigidbody2D.velocity = transform.right * clone.vel;
			wait = clone.fireSpeed;
			return true;
		}
		else
			wait --;
		return false;
		//_bullet.rigidbody2D.velocity = new Vector2(5, 0);
	}
}
