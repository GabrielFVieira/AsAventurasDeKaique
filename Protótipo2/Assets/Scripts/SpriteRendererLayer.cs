using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererLayer : MonoBehaviour
{
    public GameObject player;
    // Use this for initialization
    public void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void Update()
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
        
    }
}
