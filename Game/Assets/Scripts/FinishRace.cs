using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishRace : MonoBehaviour
{
  public Slider player;
  public Slider opponent;

	public bool Finish()
	{
		if (player.value == 0 || opponent.value == 0)
		{
			return true;
		}
		return false;
	}

}
