using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
    private GM gm;
	private int timesHit;
	private bool isBreakable; 
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;
	private LoseCollider loseCollider;
	// Use this for initialization
	void Start ()
	{
		loseCollider = GameObject.FindObjectOfType<LoseCollider>();
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
			}
		timesHit = 0;
		gm = GameObject.FindObjectOfType<GM>();
	}	
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit++;
		int	maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			gm.BrickDestroyed();
			GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy (gameObject);
		} else {
			LoadSprites ();
			}
		}


		void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
		void SimulateWin () {

		gm.LoadNextLevel();
		}

	
}
