using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class AutoTile : MonoBehaviour {
	SpriteRenderer sprite;
	void Awake () {

		sprite = GetComponent<SpriteRenderer>();
		Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);
		
		GameObject childPrefab = new GameObject();
		
		SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
		childPrefab.transform.position = transform.position;
		childSprite.sprite = sprite.sprite;
		childSprite.sortingLayerID = sprite.sortingLayerID;
		childSprite.sortingOrder = sprite.sortingOrder;

		GameObject child;
		for (int i = 0, h = (int)Mathf.Round(sprite.bounds.size.y); i*spriteSize.y < h; i++) {
			for (int j = 0, w = (int)Mathf.Round(sprite.bounds.size.x); j*spriteSize.x < w; j++) {
				child = Instantiate(childPrefab) as GameObject;
				child.transform.position = transform.position - (new Vector3(spriteSize.x*j, spriteSize.y*i, 0));
				child.transform.parent = transform;
			}
		}

		
		Destroy(childPrefab);
		sprite.enabled = false;

	}
}