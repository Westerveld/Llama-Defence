using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour {

	public Text goldLabel;

	private int gold;
	public int Gold {
		get { return gold;}
		set {
			gold = value;
			goldLabel.GetComponent<Text> ().text = "GOLD: " + gold;
		}
	}
	
	public Text waveLabel;
	public GameObject[] nextWaveLabels;

	public bool gameOver = false;

	private int wave;
	public int Wave {
		get{ return wave;}
		set {
			wave = value;
			if (!gameOver) {
				for (int i = 0; i < nextWaveLabels.Length; i++) {
					nextWaveLabels [i].GetComponent<Animator> ().SetTrigger ("nextWave");
				}
			}
			waveLabel.GetComponent<Text> ().text = "WAVE: " + (wave + 1);
		}
	}
	
	public Text healthLabel;

	private int health;
	public int Health {
		get{ return health;}
		set {
			if (value < health) {
				Camera.main.GetComponent<CameraShake> ().Shake ();
			}

			health = value;
			healthLabel.GetComponent<Text>().text = "HEALTH: " + health;

			if(health <= 0 && !gameOver){
				gameOver = true;
				GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
				gameOverText.GetComponent<Animator>().SetBool ("gameOver", true);
				StartCoroutine (gameOverWait());
				Application.LoadLevel("Start");

			}
		}
	}
	void Start(){
		Gold = 1000;
		Wave = 0;
		Health = 5;
	}

	IEnumerator gameOverWait()
	{
		yield return new WaitForSeconds (2f);
	}
}
