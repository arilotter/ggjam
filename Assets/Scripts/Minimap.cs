using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {

	private Camera _camera;
	private GameObject p1, p2;

	void Start() {
		_camera = this.GetComponent<Camera>();
		
		p1 = (GameObject) GameObject.FindWithTag("Player 1");
		p2 = (GameObject) GameObject.FindWithTag("Player 2");
		_camera.rect = new Rect((float)0, (float)0, (float)0.3, (float)0.1);

	}
	
	void Update() {
		Vector2 middlepos = (p1.transform.position + p2.transform.position) * 0.5f;
		_camera.transform.position = new Vector3(middlepos.x, middlepos.y, -10);
	}
}
