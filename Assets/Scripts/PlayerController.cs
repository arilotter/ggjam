using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float movespeed = 5;
	float angle;

	public Scrollbar healthbar;
	public Scrollbar energybar;
	public Scrollbar shieldbar;
	public int playerNum;
	public Weapon weapon;
	public int maxHealth = 999999;
	public int maxEnergy = 999999;
	public int maxShield = 100;
	int health;
	int energy;
	int shield;

	void Start() {
		health = maxHealth;
		energy = maxEnergy;
		shield = 0;
	}
	
	void FixedUpdate() {
		//Debug.Log(energy);
		Vector2 direction = new Vector2(Input.GetAxis("P" + playerNum + " LX"), Input.GetAxis("P" + playerNum + " LY"));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);

		Vector2 rightJoy = new Vector2(Input.GetAxis("P" + playerNum + " RX"), Input.GetAxis("P" + playerNum + " RY"));
		Vector2 faceDirection = (rightJoy != Vector2.zero ? rightJoy : (rigidbody2D.velocity));

		angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if(shouldFire(energy, weapon.energy)) { // right trigger pressed

			if (weapon.fireGun())
				energy -= weapon.energy;
		}
		if (energy < maxEnergy)
			energy+= 2;
			
		healthbar.size = (float)health/maxHealth;
		energybar.size = (float)energy/maxEnergy;
		shieldbar.size = (float)shield/maxShield;
	}
	
	public void HitByBullet(int damage){
		if(shield > 0) {
			shield -= damage;
			if(shield < 0) {
				health -= shield;
				shield = 0;
			}
		} else {
			health -= damage;
		}
	}
	
	/*void HitByBullet(ArrayList list){
		if (!list[1].Equals(gameObject.tag))
		{
			GameObject bul = (GameObject)list[0];
			bul.rigidbody2D.velocity = Vector2.zero;
			Bullet bullet = bul.GetComponent<Bullet>();
			health -= bullet.getDamage();
			// Get the Animator component from your gameObject
			Animator anim = bul.GetComponent<Animator>();
			// Sets the value
			anim.SetTrigger("explode"); 
			StartCoroutine(waitForExplosion(bul));

			
		}
	}*/

	
	public bool shouldFire(int _availEnergy, int _energy){
		return (Input.GetAxis("P" + playerNum + " Shoot") < 0) && (_availEnergy - _energy >= 0);
	}

	public void heal(int h) {
		this.health = Mathf.Min(this.health + h, this.maxHealth);
	}

	public void addEnergy(int e) {
		this.energy = Mathf.Min(this.energy + e, this.maxEnergy);
	}

	public void addShield(int s) {
		this.shield = Mathf.Min(this.shield + s, this.maxShield);
	}
}
