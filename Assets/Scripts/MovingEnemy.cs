﻿using UnityEngine;
using System.Collections;


// Controller for the moving enemies
// Author: Jenna Kopra

public class MovingEnemy : Enemies {										// perii Enemies classin



	void Update () {														// päivittää kerran framessa
		gameObject.transform.Translate (-0.1f, 0, 0);						// Liikuttaa vihollista vasemmalle
	}
}
