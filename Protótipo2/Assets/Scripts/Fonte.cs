﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fonte : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fonte")
        {
            GetComponent<PlayerWater>().curWater = 100;
        }
    }
}
