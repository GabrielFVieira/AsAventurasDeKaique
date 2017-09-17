using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {
    public GameObject[] buttons;
    public GameObject player;
    public PlataformaSeguePlayer plat;
    public LevelManager pause;

    public bool controle;
    public float velY;
    public float velX;
    // Use this for initialization
    void Start () {
        controle = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            controle = !controle;
        }

        if (controle == true)
        {
            Cursor.visible = pause.pauseMenu.activeSelf;

            foreach (GameObject go in buttons)
            {
                go.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause.pauseMenu.SetActive(!pause.pauseMenu.activeSelf);


                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                if (player.GetComponent<PickUpWeapon>().CanPickUp == true)
                    player.GetComponent<PickUpWeapon>().crounch = true;
            }

            if (Input.GetKeyUp(KeyCode.J))
            {
                if (player.GetComponent<PickUpWeapon>().CanPickUp == true)
                    player.GetComponent<PickUpWeapon>().crounch = false;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                player.GetComponent<LaunchWaterBall>().Fire = true;
            }

            if (Input.GetKeyUp(KeyCode.K))
            {
                player.GetComponent<LaunchWaterBall>().Fire = false;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                player.GetComponent<PlayerMovement>().controleCima = 1;
                plat.controleCima = 1;
                velY = 1;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                player.GetComponent<PlayerMovement>().controleCima = 0;
                plat.controleCima = 0;
                velY = 0;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                player.GetComponent<PlayerMovement>().controleBaixo = 1;
                plat.controleBaixo = 1;
                velY = -1;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                player.GetComponent<PlayerMovement>().controleBaixo = 0;
                plat.controleBaixo = 0;
                velY = 0;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                velX = -1;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                velX = 0;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                velX = 1;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                velX = 0;
            }
        }

        else
        {
            foreach (GameObject go in buttons)
            {
                go.SetActive(true);
            }

            Cursor.visible = true;
        }
    }  
}
