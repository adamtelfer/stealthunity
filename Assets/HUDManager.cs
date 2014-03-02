using UnityEngine;
using System.Collections.Generic;

public class HUDManager : MonoBehaviour {

	public List<GameObject> lifeIcons;

	void UpdateHUD(GameManager manager) {
		for (int i = 0; i < lifeIcons.Count; ++i) {
			GameObject lifeIcon = lifeIcons[i];
			if (manager.Lives > i) {
				lifeIcon.renderer.enabled = true;
			} else {
				lifeIcon.renderer.enabled = false;
			}
		}
	}

	void OnGameManagerChange(GameManager manager) {
		UpdateHUD (manager);
	}

	void OnGameOver (GameManager manager) {
		UpdateHUD (manager);
	}

	// Use this for initialization
	void Start () {
		GameManager.SharedManager.gameChangeResponder += OnGameManagerChange;
		GameManager.SharedManager.gameOverResponder += OnGameOver;
		UpdateHUD (GameManager.SharedManager);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
