using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {
    public GameObject player;
    public GameObject moneyBag;
    public EnemyHealth health;
    public PlayerWin win;
    Animator animo;
    public float Timer;
    public float LaunchTime;
    public float velY;
    public float velX;
    public float maxD;
    public float minD;

    public float offsetX;
    public float offsetY;

    public float RunTimer;
    public bool controle = true;
    
    public int randomAttack;
    // Use this for initialization
    void Start () {
        health = GetComponent<EnemyHealth>();

        player = GameObject.FindGameObjectWithTag("Player");
        LaunchTime = 1.8f;

        RunTimer = 0;

        animo = GetComponent<Animator>();

        velX = 3f;
        velY = 1.5f;

        maxD = 8f;
        minD = 4.5f;

        offsetX = 0.7f;
        offsetY = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (health.curHealth <= 0)
            win.BossDefeated = true;

        if (animo.GetInteger("Condição") != 2)
        {
            randomAttack = Random.Range(3, 6);

            if (player.GetComponent<PlayerHealth>().curHealth > 0)
            {
                if (player.transform.position.y > transform.position.y)
                {
                    GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
                }

                else if (player.transform.position.y < transform.position.y)
                {
                    GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 1;
                }

                else
                    GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder;

                //Timer += Time.deltaTime;
                if (Timer > LaunchTime && animo.GetInteger("Condição") != 1)
                {
                    GameObject bag = Instantiate(moneyBag) as GameObject;
                    bag.transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, 0);
                    Timer = 0;
                }

                if (player.transform.position.x < transform.position.x && RunTimer == 0)
                {
                    transform.localScale = new Vector3(-1.771533f, 1.771533f, 1);
                    offsetX = -0.7f;
                }

                if (player.transform.position.x > transform.position.x && RunTimer == 0)
                {
                    transform.localScale = new Vector3(1.771533f, 1.771533f, 1);
                    offsetX = 0.7f;
                }

                if (player.transform.position.x > transform.position.x || player.transform.position.x < transform.position.x)
                {
                    if (player.transform.position.x > transform.position.x + minD || player.transform.position.x < transform.position.x - minD)
                        Timer += Time.deltaTime;

                    if (player.transform.position.y - 0.1f > transform.position.y && Timer < 1.3f && RunTimer == 0)
                    {
                        transform.Translate(0, velY * Time.deltaTime, 0);
                        animo.SetInteger("Condição", 1);
                    }

                    else if (player.transform.position.y + 0.1f < transform.position.y && Timer < 1.3f && RunTimer == 0)
                    {
                        transform.Translate(0, -velY * Time.deltaTime, 0);
                        animo.SetInteger("Condição", 1);
                    }

                    else
                        animo.SetInteger("Condição", 0);
                }

                if (player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + minD || player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - minD)
                {
                    Timer = 0;

                    if (player.transform.position.x - 1f > transform.position.x && RunTimer == 0)
                    {
                        transform.Translate(velX * Time.deltaTime, 0, 0);
                        animo.SetInteger("Condição", 1);
                    }

                    else if (player.transform.position.x + 1f < transform.position.x && RunTimer == 0)
                    {
                        transform.Translate(-velX * Time.deltaTime, 0, 0);
                        animo.SetInteger("Condição", 1);
                    }

                    else
                        animo.SetInteger("Condição", randomAttack);
                }


                if (player.transform.position.x > transform.position.x + maxD && RunTimer == 0)
                {
                    transform.Translate(velX * Time.deltaTime, 0, 0);
                    animo.SetInteger("Condição", 1);
                }

                else if (player.transform.position.x < transform.position.x - maxD && RunTimer == 0)
                {
                    transform.Translate(-velX * Time.deltaTime, 0, 0);
                    animo.SetInteger("Condição", 1);
                }
            }

            else
                animo.SetInteger("Condição", 0);


            if (health.curHealth > 300 && health.curHealth < 400)
                controle = true;

            if (health.curHealth > 50 && health.curHealth < 100)
                controle = true;

            if (health.curHealth > 400 && health.curHealth < 500 || health.curHealth > 150 && health.curHealth < 250 || health.curHealth < 50 && health.curHealth > 0)
            {
                if (controle == true)
                {
                    LaunchTime -= 0.35f;
                    RunTimer = 1.2f;
                    controle = false;
                }
                if (player.transform.position.x > transform.position.x && RunTimer != 0)
                {
                    transform.localScale = new Vector3(-1.771533f, 1.771533f, 1);
                    transform.Translate(-velX * 2 * Time.deltaTime, 0, 0);
                    animo.SetInteger("Condição", 1);
                }

                else if (player.transform.position.x < transform.position.x && RunTimer != 0)
                {
                    transform.localScale = new Vector3(1.771533f, 1.771533f, 1);
                    transform.Translate(velX * 2 * Time.deltaTime, 0, 0);
                    animo.SetInteger("Condição", 1);
                }
            }

            if (RunTimer > 0)
                RunTimer -= Time.deltaTime;

            if (RunTimer < 0)
            {
                RunTimer = 0;
            }
        }
    }
}
