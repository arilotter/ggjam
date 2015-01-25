using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int vel;
	public Vector2 position;
	public string type;

	public int damage;
	public string shooter;
	
	public Bullet()
	{
		vel = 5;
		//public Vector2 position;
		damage = 50;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
  void OnBecameInvisible()
  {
     DestroyObject(gameObject);
  }
  
  	void OnCollisionEnter2D(Collision2D _col){
		var parmas = new ArrayList();
		parmas.Add(gameObject);
		parmas.Add(shooter);

		_col.gameObject.SendMessage("HitByBullet", parmas,
    SendMessageOptions.DontRequireReceiver);
	}
	
	public int getDamage(){
		return damage;
	}
}
