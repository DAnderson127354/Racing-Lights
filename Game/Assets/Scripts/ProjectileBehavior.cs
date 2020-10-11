using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ProjectileBehavior : MonoBehaviour
{
	public int maxReflectionCount;
	public float maxStepDistance;
	public LineRenderer laser;

	void FixedUpdate()
	{
		//draw intended reflection pattern
    	DrawPredictedReflectionPattern(this.transform.position + this.transform.forward * 0.75f, this.transform.forward, maxReflectionCount);
	}

    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
    	//break out of recursive loop
    	if (reflectionsRemaining == 0)
    	{
    		return;
    	}

    	Vector3 startingPosition = position;
    	laser.SetPosition(0, startingPosition);

    	//Raycast to detect reflection
    	Ray ray = new Ray(position, direction);
    	RaycastHit hit;
    	if (Physics.Raycast(ray, out hit, maxStepDistance))
    	{
    		laser.SetPosition(1, position);
    		if (hit.collider.name == "Player")
    		{
    			hit.collider.gameObject.transform.Translate(0, 0, -5);
    		}
    		// Debug.Log(hit.collider.name);
    		direction = Vector3.Reflect(direction, hit.normal);
    		position = hit.point;
    		laser.SetPosition(2, position);
    	}
    	else
    	{
    		position += direction * maxStepDistance;
    	}

    	
    	Debug.DrawLine(startingPosition, position, Color.yellow);

    	DrawPredictedReflectionPattern(position, direction, reflectionsRemaining -1);
    }
}
