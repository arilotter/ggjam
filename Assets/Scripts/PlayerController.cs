using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

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
	void FixedUpdate() {
		//Debug.Log(energy);
		Vector2 direction = new Vector2(XCI.GetAxis(XboxAxis.LeftStickX, playerNum), XCI.GetAxis(XboxAxis.LeftStickY, playerNum));
		direction *= movespeed;
		rigidbody2D.AddForce(direction);

		Vector2 rightJoy = new Vector2(XCI.GetAxis(XboxAxis.RightStickX, playerNum), XCI.GetAxis(XboxAxis.RightStickY, playerNum));
		Vector2 faceDirection = (rightJoy != Vector2.zero ? rightJoy : (rigidbody2D.velocity));

		angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if(shouldFire(energy, weapon.energy)) { // right trigger pressed

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
	
	public bool shouldFire(int _availEnergy, int _energy){
		return (XCI.GetAxis(XboxAxis.RightTrigger, playerNum) > 0) && (_availEnergy - _energy >= 0);
	}
}
