using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour {
    public GameObject Boss;
	// Use this for initialization
	void Start () {
        Boss.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.transform.position.x > transform.position.x)
            {
                Boss.SetActive(true);
                GetComponent<Collider2D>().isTrigger = false;
            }
        }
    }
}
