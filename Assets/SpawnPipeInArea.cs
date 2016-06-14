using UnityEngine;
using System.Collections.Generic;

public class SpawnPipeInArea : MonoBehaviour {

	[SerializeField]
	GameObject _PipePrefab;

	BoxCollider2D _Collider;

	void Start () {
		_Collider = gameObject.GetComponent<BoxCollider2D> ();
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		bool isPipe = collider.gameObject.CompareTag("Pipes");
		if (isPipe) {
			var startX = _Collider.bounds.max.x;
			var startY = Random.Range (_Collider.bounds.min.y, _Collider.bounds.max.y);
			var pos = collider.gameObject.transform.position;
			collider.gameObject.transform.position = new Vector3 (startX, startY, pos.z);
		}
	}
}
