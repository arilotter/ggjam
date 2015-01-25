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
		Vector2 direction = new Vector2(Input.GetAxis("P" + playerNum + " LX"), Input.GetAxis("P" + playerNum + " LY"));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);

		Vector2 rightJoy = new Vector2(Input.GetAxis ("P" + playerNum + " RX"), Input.GetAxis ("P" + playerNum + " RY"));
		Vector2 faceDirection = (rightJoy != Vector2.zero ? rightJoy : (rigidbody2D.velocity));

		angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if(fire(energy, weapon.energy)) { // right trigger pressed
			if (weapon.fireGun())
				energy -= weapon.energy;
		}
		if (energy < maxEnergy)
			energy+= 2;
	}
	
	void HitByBullet(ArrayList list){
	
		Debug.Log(list[1]);
		if (!list[1].Equals(gameObject.tag))
		{
			Debug.Log(gameObject.tag);
			GameObject bul = (GameObject)list[0];
			Bullet bullet = bul.GetComponent<Bullet>();
			health -= bullet.getDamage();
			
			// Get the Animator component from your gameObject
			Animator anim = bul.GetComponent<Animator>();
			// Sets the value
			anim.SetTrigger("explode"); 
			StartCoroutine(waitForExplosion(bul));

			
			Debug.Log(health);
		}
	}
	
	IEnumerator waitForExplosion(GameObject _gameObject) {
		yield return new WaitForSeconds(0.5f); //this will wait 5 seconds
		DestroyObject(_gameObject);
	}
	
	public bool fire(int _availEnergy, int _energy){
		return (Input.GetAxis("P" + playerNum + " Shoot") < 0) && (_availEnergy - _energy >= 0);
	}
}
