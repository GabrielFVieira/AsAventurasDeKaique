using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
    }

        // Update is called once per frame
        void Update () {
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Play()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void Credits()
	{
		SceneManager.LoadScene ("Credits");
    }

	public void Options()
	{
		SceneManager.LoadScene ("Options");
	}

	public void Back()
	{
		SceneManager.LoadScene ("MainMenu");
    }

	public void BackToOptions()
	{
		SceneManager.LoadScene ("Options");
	}
}