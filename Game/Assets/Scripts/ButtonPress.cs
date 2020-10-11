using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
	public GameObject wall;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
    	{
    		//Debug.Log("hi");
    		GetComponent<Animator>().Play("buttonAnim");
    		wall.GetComponent<Animator>().Play("wallAnim");
    	}
	}
}
