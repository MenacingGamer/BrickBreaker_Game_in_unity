using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoseCollider : MonoBehaviour {
private Ball ball;
public GM gm;
public GameObject Ball;
private Paddle paddle;
private bool hasRestarted = false;
public Text BallLivesText;
public static int BallLives = 3;	
public static int CurrentBallLives = 0;


	
void Start ()
	{
		
	

		paddle = GameObject.FindObjectOfType<Paddle>();
		ball = GameObject.FindObjectOfType<Ball>();
		gm = GameObject.FindObjectOfType<GM>();
		 
	}


void OnTriggerEnter2D (Collider2D trigger)
	{
		hasRestarted = true;
		BallLives = BallLives -= 1;


		if (BallLives <= 0) {
			
			gm.LoadLevel ("Lose");
		} else {
			Destroy(GetComponent<Ball>());
			BallRestart ();
		}
			
			//lock the ball to paddle
			}
	void Update ()
	{	
		CurrentBallLives = BallLives;
		BallLivesText.text = "LIVES : " + CurrentBallLives; 
		Debug.Log("Lives "+ CurrentBallLives);
	}

		void BallRestart ()
	{
		if (hasRestarted) {
			Instantiate(Ball, new Vector2(paddle.transform.position.x, paddle.transform.position.y + 0.3f), Quaternion.identity);
				if (Input.GetMouseButton (0)) {

				ball.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			

			}
		}
	}
}