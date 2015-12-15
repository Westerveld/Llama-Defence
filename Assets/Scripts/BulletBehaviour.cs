﻿using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public float speed = 10;
	public int damage;
	public GameObject target;
	public Vector3 startPosition;
	public Vector3 targetPosition;

	private float distance;
	private float startTime;

	private GameManagerBehaviour gameManager;


	// Use this for initialization
void Start () {
	startTime = Time.time;
	distance = Vector3.Distance (startPosition, targetPosition);
	GameObject gm = GameObject.Find ("GameManager");
	gameManager = gm.GetComponent<GameManagerBehaviour> ();
}
	
	// Update is called once per frame
void Update () {
	float timeInterval = Time.time - startTime;
	gameObject.transform.position = Vector3.Lerp(startPosition,targetPosition, timeInterval * speed / distance);

	if(gameObject.transform.position.Equals(targetPosition)){
		if(target != null){
			Transform healthBarTransform = target.transform.FindChild("HealthBar");
			HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
			healthBar.currentHealth -= Mathf.Max (damage, 0);

			if(healthBar.currentHealth <= 0) {
				Destroy(target);
				gameManager.Gold += 30;
			}
		}
		Destroy(gameObject);
		}
	}
}