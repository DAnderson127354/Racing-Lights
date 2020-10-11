using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public int direction;
    public GameObject player;
    bool moveWith = false;

    // Update is called once per frame
    void Update()
    {
    	switch (direction)
    	{
    		case 0:
    			transform.Translate(-2 * Time.deltaTime, 0, 0);
    			// //have the player move with platform if touching
    			if (moveWith)
    			{
    				player.GetComponent<CharacterController>().SimpleMove(Vector3.left * 2);
    			}
    			//switch directions
    			if (transform.position.x < -8)
    			{
    				direction = 1;
    			}
    			break;
    		case 1:
    			transform.Translate(2 * Time.deltaTime, 0, 0);
    			// //have the player move with platform if touching
    			if (moveWith)
    			{
    				player.GetComponent<CharacterController>().SimpleMove(Vector3.right * 2);
    			}
    			//switch directions
    			if (transform.position.x > 8)
    			{
    				direction = 0;
    			}
    			break;
    		case 2:
    			transform.Translate(0, 0, 4 * Time.deltaTime);
    			// //have the player move with platform if touching
    			if (moveWith)
    			{
    				player.GetComponent<CharacterController>().SimpleMove(Vector3.forward * 4);
    			}
    			//switch directions
    			if (transform.position.z >= 80)
    			{
    				direction = 3;
    			}
    			break;
    		case 3:
    			transform.Translate(0, 0, -4 * Time.deltaTime);
    			// //have the player move with platform if touching
    			if (moveWith)
    			{
    				player.GetComponent<CharacterController>().SimpleMove(Vector3.forward * -4);
    			}
    			//switch directions
    			if (transform.position.z <= 56)
    			{
    				direction = 2;
    			}
    			break;
    		default:
    			break;
    	}
    }

    void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject == player)
    	{
    		//Debug.Log("hi");
    		moveWith = true;
    	}
    }

    void OnTriggerExit()
    {
    	//Debug.Log("bye");
    	moveWith = false;
    }
}
