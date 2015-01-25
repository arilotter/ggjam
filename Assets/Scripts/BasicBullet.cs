﻿using UnityEngine;
using System.Collections;

public class BasicBullet : Bullet {

	public Sprite bulletSprite;
	
	public BasicBullet () {
		type="basic";
		vel = 5;
		//public Vector2 position;

	}

		// Use this for initialization
	void Start () {
		sRender = gameObject.GetComponent<SpriteRenderer>();		
		sRender.sprite = bulletSprite;
				Debug.Log(explosionTime);

	}
}
