using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentControl : MonoBehaviour
{
	private float speed;
	public Light lt;
	public DistanceLeft winCondition;
	public FinishRace raceDone;
	float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = new Color(0.2f, 0.1f, 0.1f);
    public Text winText;

    void Awake()
    {
        if (PlayerPrefs.GetString("settings") == "easy")
        {
            speed = 0.5f;
        }
        else if (PlayerPrefs.GetString("settings") == "medium")
        {
            speed = 1.0f;
        }
        else
        {
            speed = 2.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
    	if (raceDone.Finish())
    	{
    		speed = 0;
    	}
    	
    	if (winCondition.Win())
    	{
    		winText.text = "You Lost!";
    		winText.color = Color.red;
    		raceDone.Finish();
    	}

    	//simple movement forward
        transform.Translate(0, 0, speed * Time.deltaTime);

        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
}
