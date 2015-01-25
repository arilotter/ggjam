using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Bullet _bullet;
	public enum WeaponType{rpgs, chainGun, plasma};	
	public WeaponType type;
	public int fireSpeed = 0;
	public int energy;
	string parentTag;
	int wait = 0;
	int side = 1;
	//public PlayerController player;

	// Use this for initialization
	void Start () {
		parentTag = transform.parent.gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown("space"))
            fireGun();
	}
	
	public bool fireGun(){
		if (wait == 0)
		{
			Bullet clone;
			Vector3 offset = transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.extents;
			clone = Instantiate(_bullet, transform.position, transform.rotation) as Bullet;
			transform.Translate(0, offset.y*side, 0);
			side *= -1;
			clone.shooter = parentTag;
			clone.rigidbody2D.velocity = transform.right * clone.vel;
			
			wait = fireSpeed;
			return true;
		}
		else
			wait --;
		return false;
		//_bullet.rigidbody2D.velocity = new Vector2(5, 0);
	}
}
