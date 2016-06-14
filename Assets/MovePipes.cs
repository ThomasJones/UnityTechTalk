using UnityEngine;
using System.Collections;

public class MovePipes : MonoBehaviour {

	[SerializeField]
	private float _BirdSpeed = 1.0f;

	private FlappyBirdRules _FlappyBirdRules;

	void Start () {
		_FlappyBirdRules = GameObject.FindObjectOfType<FlappyBirdRules> ();
	}

	void Update () {
		var velocity = Time.deltaTime * _BirdSpeed;
		this.transform.Translate (Vector3.left * velocity);
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		bool isBird = collider.gameObject.CompareTag ("Bird");
		if (isBird)
		{
			_FlappyBirdRules.ScorePoint();
		}
	}
}
