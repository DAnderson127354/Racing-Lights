using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour
{
	private int direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
        	transform.Rotate(0f, 0f, 10f * Time.deltaTime, Space.Self);
        	
        	if (transform.rotation.z >= 0.6f)
        	{
        		direction = 1;
        	}
        }
        else
        {
        	transform.Rotate(0f, 0f, -10f * Time.deltaTime, Space.Self);
        	
        	if (transform.rotation.z <= 0.3f)
        	{
        		direction = 0;
        	}
        }

    }
}
