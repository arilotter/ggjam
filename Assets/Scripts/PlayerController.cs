using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float movespeed = 5;
	float angle;


	public int playerNum;
	public Weapon weapon;
	public int maxHealth = 999999;
	public int maxEnergy = 999999;
	int health;
	int energy;

	void Start() {
		health = maxHealth;
		energy = maxEnergy;
	}
	
	// Update is called once per frame
	void Update() {
		//Debug.Log(energy);
		var direction = new Vector2(Input.GetAxis("P" + playerNum + " LX"), Input.GetAxis("P" + playerNum + " LY"));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);

		var rightJoy = new Vector2(Input.GetAxis ("P" + playerNum + " RX"), Input.GetAxis ("P" + playerNum + " RY"));
		var faceDirection = (rightJoy != Vector2.zero ? rightJoy : (rigidbody2D.velocity));

		angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if(fire(energy, weapon.energy)) { // right trigger pressed
			if (weapon.fireGun())
				energy -= weapon.energy;
		}
	}
	
	void OnCollisionEnter2D(Collision2D _col){
		Debug.Log(_col.gameObject.tag);
		if (_col.gameObject.tag == "bullet")
		{
			Bullet bullet = _col.gameObject.GetComponent<Bullet>();
			health -= bullet.getDamage();
			Debug.Log(health);
		}
	}
	
	public bool fire(int _availEnergy, int _energy){
		return (Input.GetAxis("P" + playerNum + " Shoot") < 0) && (_availEnergy - _energy >= 0);
	}
}
