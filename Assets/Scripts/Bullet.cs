using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	public int vel;
	public Vector2 position;
	public string type;
	public int damage;
	public string shooter;
	public float explosionTime;
	protected SpriteRenderer sRender;
	
	public Bullet()
	{
		vel = 5;
		//explosionTime = 0.5f;
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
	
		if (!_col.gameObject.tag.Equals(shooter))
		{

			gameObject.rigidbody2D.velocity = Vector2.zero;
			
			if (_col.gameObject.tag.Equals("Player 1") ||
			_col.gameObject.tag.Equals("Player 2"))
			{
				PlayerController player = _col.gameObject.GetComponent<PlayerController>();
				player.HitByBullet(getDamage());
			}
			//
			// Get the Animator component from your gameObject
			Animator anim = gameObject.GetComponent<Animator>();
			// Sets the value
			anim.SetTrigger("explode"); 
			StartCoroutine(waitForExplosion());

		
		}
	
		/*_col.gameObject.SendMessage("HitByBullet", parmas,
    SendMessageOptions.DontRequireReceiver);*/
	}
	
		
	IEnumerator waitForExplosion() {
		
		//yield return new WaitForSeconds(_gameObject.GetComponent<Bullet>().explosionTime);
		yield return new WaitForSeconds(explosionTime);
		DestroyObject(gameObject);
	}
	
	public int getDamage(){
		return damage;
	}
}
