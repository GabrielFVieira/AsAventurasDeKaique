using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : MonoBehaviour {
    public GameObject boss;
    public GameObject player;
    public float vel;
	// Use this for initialization
	void Start () {
        boss = GameObject.Find("Boss");
        player = GameObject.FindGameObjectWithTag("Player");
        
            if (boss.transform.localScale.x > 0)
            vel = 4;

        else
            vel = -4;
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(vel * Time.deltaTime, 0, 0);

        if(transform.position.x > player.transform.position.x + 30)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < player.transform.position.x - 30)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().curHealth -= 25;
            Destroy(gameObject);
        }

    }
}
