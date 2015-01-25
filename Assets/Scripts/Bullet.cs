using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector2 velocity;
	public Vector2 position;
	public string type;
	public int fireSpeed;

	public Bullet()
	{
	
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
}
