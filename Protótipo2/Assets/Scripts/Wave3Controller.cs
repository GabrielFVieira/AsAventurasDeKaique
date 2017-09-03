using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3Controller : MonoBehaviour {
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    // Use this for initialization
    void Start()
    {
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount == 4)
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
        }

        if (gameObject.transform.childCount == 2)
        {
            enemy3.SetActive(true);
            enemy4.SetActive(true);
        }
    }
}
