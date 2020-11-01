﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
	public void restartGame()
	{
		SceneManager.LoadScene(1);
	}
	public void loadRestartGame()
	{
		SceneManager.LoadScene(2);
	}
	public void quitGame()
	{
		Application.Quit();
	}
}
