using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FlappyBirdRules : MonoBehaviour {

	[SerializeField]
	private GameObject _GameOver;

	[SerializeField]
	private GameObject _Title;

	[SerializeField]
	private ScoreSprite _Score;

	private int _Points = 0;
	private GameObject _FlappyBird;
	private BirdInput _FlappyBirdInput;
	private SpawnPipeInArea _PipeSpawner;
	private bool _IsActive = false;
	private bool _IsGameOver = false;

	public void Start()
	{
		_FlappyBird = GameObject.FindGameObjectWithTag ("Bird");
		_FlappyBirdInput = _FlappyBird.GetComponent<BirdInput> ();
		_PipeSpawner = GameObject.FindObjectOfType<SpawnPipeInArea> ();
		SetGameObjectsEnabled (false);

		_Title.SetActive (true);
		_GameOver.SetActive (false);
		_Score.SetScore (_Points);
		_Score.gameObject.SetActive (false);
	}

	public void Update()
	{
		if (Input.anyKeyDown && !_IsActive && !_IsGameOver) 
		{
			// Start the game - bird physics and scrolling pipes
			SetGameObjectsEnabled(true);
			_IsActive = true;
			_Title.SetActive (false);
			_Score.gameObject.SetActive (true);
		}
	}

	public void ScorePoint()
	{
		_Points += 1;
		_Score.SetScore (_Points);
	}

	public void OnBirdOffScreen()
	{
		GameOver ();
	}		

	public void OnBirdHitPipe()
	{
		GameOver ();
	}

	void SetGameObjectsEnabled(bool enabled)
	{		
		_FlappyBirdInput.SetEnabled (enabled);
		_PipeSpawner.enabled = enabled;

		var pipeMovers = GameObject.FindObjectsOfType<MovePipes> ();
		foreach (var mover in pipeMovers)
		{
			mover.enabled = enabled;
		}
	}

	private void GameOver()
	{
		_GameOver.SetActive (true);
		_IsGameOver = true;
		SetGameObjectsEnabled(false);
		Invoke("Reset", 1.0f);
	}
		
	void Reset() {
		_Points = 0;
		SceneManager.LoadScene (0);
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		bool isBird = collider.gameObject.CompareTag ("Bird");
		if (isBird)
		{
			OnBirdOffScreen ();
		}
	}
}
