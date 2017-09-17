using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public GameObject player;
    public Sprite[] states;
    public int i = 3;
    public float timer;

    public float random;
    public GameObject medKit;
    public GameObject waterBottle;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y > transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }

        else if (player.transform.position.y < transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }

        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder;
        }

        if(i >= 0)
        GetComponent<SpriteRenderer>().sprite = states[i];

        if(i <= 0)
            timer += Time.deltaTime;

        if (timer > 0.8f)
        {
            random = Random.Range(0, 5);

            if (random == 1)
            {
                GameObject medkit = Instantiate(medKit) as GameObject;
                medkit.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.7f, this.transform.position.z);
            }

            if (random == 2)
            {
                GameObject waterbottle = Instantiate(waterBottle) as GameObject;
                waterbottle.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.7f, this.transform.position.z);
            }

            GameObject.Find("plataformaPlayer").GetComponent<PlataformaSeguePlayer>().canWalkDown = GameObject.Find("plataformaPlayer").GetComponent<PlataformaSeguePlayer>().canWalkUp = true;
            Destroy(gameObject);
        }
    }
}
