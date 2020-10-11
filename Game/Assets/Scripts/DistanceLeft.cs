using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceLeft : MonoBehaviour
{
	public GameObject racer;
	public GameObject finishLine;
	private float distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
    	distance = finishLine.transform.position.z - racer.transform.position.z;
        gameObject.GetComponent<Slider>().value = distance;
    	
    }

    public bool Win()
    {
    	if (gameObject.GetComponent<Slider>().value == gameObject.GetComponent<Slider>().minValue)
    	{
    		return true;
    	}
    	return false;
    }
}
