using UnityEngine;
using System.Collections;


public class GM : MonoBehaviour {
	private LoseCollider loseCollider;

	void Start ()
	{
		loseCollider = GameObject.FindObjectOfType<LoseCollider>();
	}


	public void LoadLevel (string name) {
	Brick.breakableCount = 0;
		LoseCollider.BallLives = 3;
	Application.LoadLevel(name);
	}

	void Update ()
	{
		
 }

	public void QuitRequest()
	{
		Application.Quit();
	}

	public void LoadNextLevel() {
		Brick.breakableCount = 0;

		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed ()
	{
		if (Brick.breakableCount <= 0) {
			
			LoadNextLevel ();
		}
	}
}
