using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBagRolling : MonoBehaviour {
    public float rot;

    public GameObject Bag;
    public GameObject Player;

    // Use this for initialization
    void Start () {
        rot = -3;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, rot);

        if (Bag.transform.position.y < Player.transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }

        else if (Bag.transform.position.y > Player.transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }

        else
            GetComponent<SpriteRenderer>().sortingOrder = Player.GetComponent<SpriteRenderer>().sortingOrder;

    }
}
