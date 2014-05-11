using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager _sharedManager;
	
	public PlayerController playerController;

	public SpawnPoint currentSpawnPoint;

	public int startingLives = 2;
	private int loot;
	private int lives;
	public int Lives {
		get { return lives; }
	}
	public int Loot {
		get { return loot; }
	}

	public delegate void GameManagerChangeResponder(GameManager manager);
	public GameManagerChangeResponder gameChangeResponder;

	public delegate void GameOverResponder(GameManager manager);
	public GameOverResponder gameOverResponder;

	public static GameManager SharedManager   // the Name property
	{
		get 
		{
			return _sharedManager; 
		}
	}

	public void RestartGame() {
		lives = startingLives;
		loot = 0;
		if (gameChangeResponder != null) {
			gameChangeResponder (this);
		}
	}

	public void GameOver() {
		lives = 0;
		if (gameOverResponder != null) {
			gameOverResponder (this);
		}
	}

	public void LostALife() {
		lives--;
		gameChangeResponder (this);

		if (lives <= 0) {
			GameOver ();
		} else {
			playerController.DieAndGoToSpawnPoint(currentSpawnPoint);
		}
	}

	public void GotLoot() {
		loot++;
		gameChangeResponder (this);
	}

	// Use this for initialization
	void Awake () {
		_sharedManager = this;
		RestartGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
