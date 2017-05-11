using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {


	void Start () 
	{
	 
		GetComponent<Rigidbody> ().velocity = transform.forward * -5;

	}


}
