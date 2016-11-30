﻿using UnityEngine;
using System.Collections;


// Erikin ohjain
// Author: Jenna Kopra
using UnityEngine.SceneManagement;

public class ErikController : MonoBehaviour
{
	private ButtonController upButton;											// ylöspäinnappi
	private Animator animator;													// vaihtaa Erikin animaatioita
	public bool dead = false;													// boolean joka kertoo onko Erik kuollut vai ei
	private GameObject erik;													// Erikin hahmo
	private Rigidbody2D erikinkeho;												// Erikin keho



	void Start ()																//suorittaa ohjelman alussa
	{

		animator = GetComponent<Animator>();										// kertoo mikä on animatorin
		upButton = GameObject.Find ("UpButton").GetComponent<ButtonController> ();	// hakee upButtonin
		erik = GameObject.Find ("ErikPlayer");										// hakee erikin
		erikinkeho = GetComponent<Rigidbody2D>();									// hakee erikin kehon
	}


	void Update () {																// päivittää kerran framessa	

		if (dead == false) {														// boolean: jos erik ei ole kuollut, hahmo liikkuu eteenpäin
			erikinkeho.velocity = new Vector2(5,erikinkeho.velocity.y);
		}
		if (upButton.GetPressed ()) {												// jos painetaan upButtonnia,suoritetaan MoveErikin "Up"
			MoveErik ("up");
		}
	}

	void MoveErik (string direction)												// Erikin hyppy
	{
	
	
		if (dead == false) {														// Boolean: suorittaa jos erik ei ole kuollut
	
			Debug.Log ("move " + direction);										// kertoo consolessa kun erik liikkuu ja minne


			if (direction.Equals ("up")) {
				erikinkeho.AddForce (transform.up * 500);							// Erikin nousu
			}
				
		}

	}
	void OnCollisionEnter2D (Collision2D coll)										// törmäyksen metodi
	{
		Debug.Log ("test");
		if (coll.gameObject.tag == "Enemy") {										// jos erik törmää objectiin jolle on määrätty tagi Enemy
		animator.SetInteger ("die", 3);												// suorittaa animaation "die"

		dead = true;																// boolean dead muuttuu trueksi

		Debug.Log ("Hit");															// kertoo consolessa "Hit"

	}

}
}