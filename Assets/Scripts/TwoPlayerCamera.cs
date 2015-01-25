using UnityEngine;
using System.Collections;

public class TwoPlayerCamera : MonoBehaviour {

	private GameObject p1, p2, mask;

	private Camera _mainCamera, _p1Camera, _p2Camera;

	private Shader shapeMask;
	
	void Start() {
		_mainCamera = this.GetComponent<Camera>();
		p1 = (GameObject) GameObject.FindWithTag("Player 1");
		p2 = (GameObject) GameObject.FindWithTag("Player 2");



		_p1Camera = ((GameObject) GameObject.FindWithTag ("Player 1 Camera")).camera;
		_p2Camera = ((GameObject) GameObject.FindWithTag ("Player 2 Camera")).camera;

		mask = (GameObject) GameObject.FindWithTag("CameraMask");
	}
	
	void Update() {

		float h = 2f * _mainCamera.orthographicSize;
		float w = h * _mainCamera.aspect;
		
		float dist = Mathf.Sqrt(h*h + w*w) * 0.5f;

		if(Vector2.Distance(p1.transform.position, p2.transform.position) < dist){  // best code ever, checks if players are in camera view
			_mainCamera.enabled = true;
			_p1Camera.enabled = false;
			_p2Camera.enabled = false;
			Vector2 middlepos = (p1.transform.position + p2.transform.position) * 0.5f;
			_mainCamera.transform.position = new Vector3(middlepos.x, middlepos.y, -10);
			mask.renderer.enabled = false;
		} else {
			_mainCamera.enabled = false;
			_p1Camera.enabled = true;
			_p2Camera.enabled = true;
			mask.renderer.enabled = true;
			Vector3 lookPos = p2.transform.position - p1.transform.position;
			float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg - 90;
			mask.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			// HOLY SHIT FINALLY I DID IT

			// Calculate orthographic camera bounds
			float height = 2f * _p1Camera.orthographicSize;
			float width = height * _p1Camera.aspect;

			float camDiag = Mathf.Sqrt(height*height + width*width);

			_p1Camera.transform.position = new Vector3(p1.transform.position.x, p1.transform.position.y, -10);
			_p2Camera.transform.position = new Vector3(p2.transform.position.x, p2.transform.position.y, -10);

			Quaternion or = _p1Camera.transform.rotation;
			_p1Camera.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			_p1Camera.transform.Translate(Vector3.up * (camDiag * .25f));
			_p1Camera.transform.rotation = or;

			or = _p2Camera.transform.rotation;
			_p2Camera.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			_p2Camera.transform.Translate(Vector3.down * (camDiag * .25f));
			_p2Camera.transform.rotation = or;

			mask.transform.position = new Vector3(_p2Camera.transform.position.x, _p2Camera.transform.position.y, -9);
			mask.transform.Translate(Vector3.up * -mask.transform.localScale.y/2);
		}

	}
}
