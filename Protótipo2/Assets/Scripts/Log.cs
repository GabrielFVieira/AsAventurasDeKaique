using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour {
    public GameObject player;
    public GameObject plataforma;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        plataforma = GameObject.Find("plataformaPlayer");
}
	
	// Update is called once per frame
	void Update () {
        if (plataforma.transform.position.y > transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }

        else if (plataforma.transform.position.y < transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }

        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder;
        }
    }
}
