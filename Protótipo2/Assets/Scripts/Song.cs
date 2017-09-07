using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Song : MonoBehaviour {
    public Slider vol;
    public Sprite[] volume;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (vol.value >= 0.7f)
        {
            GetComponent<Image>().sprite = volume[0];
        }

        if (vol.value >= 0.3f && vol.value < 0.7f)
        {
            GetComponent<Image>().sprite = volume[1];
        }

        if (vol.value > 0 && vol.value < 0.3f)
        {
            GetComponent<Image>().sprite = volume[2];
        }

        if (vol.value == 0)
        {
            GetComponent<Image>().sprite = volume[3];
        }
    }
}
