using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2Controller : MonoBehaviour {
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    // Use this for initialization
    void Start()
    {
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
        enemy5.SetActive(false);
        enemy6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount == 6)
        {
            enemy1.SetActive(true);
        }

        if (gameObject.transform.childCount == 5)
        {
            enemy2.SetActive(true);
            enemy3.SetActive(true);
        }

        if (gameObject.transform.childCount == 3)
        {
            enemy4.SetActive(true);
        }

        if (gameObject.transform.childCount == 2)
        {
            enemy5.SetActive(true);
            enemy6.SetActive(true);
        }
    }
}
