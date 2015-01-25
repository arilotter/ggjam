using UnityEngine;
using System.Collections;

public class PlasmaBullet : Bullet {

	public Sprite bulletSprite;
	
	public PlasmaBullet () {
		type="plasma";
		vel = 5;
		//public Vector2 position;
	}
	
	// Use this for initialization
	void Start () {
		sRender = gameObject.GetComponent<SpriteRenderer>();		
		sRender.sprite = bulletSprite;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
