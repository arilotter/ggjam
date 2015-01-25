using UnityEngine;
using System.Collections;

public class TwoPlayerCamera : MonoBehaviour {

	private GameObject p1, p2;

	private Camera _mainCamera, _p1Camera, _p2Camera;

	private Shader shapeMask;
	
	void Start() {
		_mainCamera = this.GetComponent<Camera>();
		p1 = (GameObject) GameObject.FindWithTag("Player 1");
		p2 = (GameObject) GameObject.FindWithTag("Player 2");

		_p1Camera = ((GameObject) GameObject.FindWithTag ("Player 1 Camera")).camera;
		_p2Camera = ((GameObject) GameObject.FindWithTag ("Player 2 Camera")).camera;

		//shapeMask = Shader.Find
	}
	
	void Update() {
		var middlepos = (p1.transform.position + p2.transform.position) * 0.5f;
		transform.position = new Vector3(middlepos.x, middlepos.y, -10);
		var p1p = _mainCamera.WorldToViewportPoint(p1.transform.position);
		var p2p = _mainCamera.WorldToViewportPoint(p2.transform.position);
		if((p1p.x > 0 && p1p.x < 1 && p1p.y > 0 && p1p.y < 1 && p2p.x > 0 && p2p.x < 1 && p2p.y > 0 && p2p.y < 1)) {  // best code ever, checks if players are in camera view
			_mainCamera.enabled = true;
		} else {
			//_mainCamera.enabled = false;
			//_p1Camera.RenderWithShader(shapeMask, )
		}


	}
}
