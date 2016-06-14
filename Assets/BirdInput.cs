using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BirdInput : MonoBehaviour {

	[SerializeField]
	private float _FlapUpwardVelocity = 1.5f;

	private float _GravityScale;
	private Rigidbody2D _RigidBody;
	private FlappyBirdRules _FlappyBirdRules;

	void Start () {
		_FlappyBirdRules = GameObject.FindObjectOfType<FlappyBirdRules> ();
		FindRigidBody ();
	}

	void Update () {
		if (Input.anyKeyDown) {
			_RigidBody.velocity = new Vector2 (0.0f, _FlapUpwardVelocity);
		}
	}

	public void SetEnabled(bool enabled)
	{
		FindRigidBody ();

		this.enabled = enabled;

		if (!enabled) {
			_RigidBody.gravityScale = 0.0f;
			_RigidBody.velocity = Vector3.zero;
		} else {
			_RigidBody.gravityScale = _GravityScale;
			_RigidBody.velocity = new Vector2 (0.0f, _FlapUpwardVelocity);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		_FlappyBirdRules.OnBirdHitPipe ();
	}

	void FindRigidBody()
	{
		if (_RigidBody == null) 
		{
			_RigidBody = gameObject.GetComponent<Rigidbody2D> ();
			_GravityScale = _RigidBody.gravityScale;
		}
	}
}
