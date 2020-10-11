using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySettings : MonoBehaviour
{
    public void SetDifficulty(string choice)
    {
    	PlayerPrefs.SetString("settings", choice);
    	SceneManager.LoadScene("MainLevel");
    }

    public string GetDifficulty()
    {
    	return PlayerPrefs.GetString("settings");
    }
}
