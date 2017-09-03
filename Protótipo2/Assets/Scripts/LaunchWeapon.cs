using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchWeapon : MonoBehaviour {
	public GameObject knifePrefab;

	public PickUpWeapon weaponName;

	public bool launch;
    public bool left;
    public bool right;
    public float timer;
	public float velocidadeL = 10f;
	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
        if(left == true || right == true)
        {
            timer += Time.deltaTime;
        }

        if(timer >= 0.5f)
        {
            left = false;
            right = false;
            timer = 0;
        }

		if (launch == true && weaponName.activeWeapon == "Knife") {
			if (this.transform.localScale.x > 0 && right == true) {
                GameObject knife = Instantiate(knifePrefab) as GameObject;
                knife.transform.localEulerAngles = new Vector3 (0, 180, 0);
				knife.transform.position = new Vector3 (this.transform.position.x + 0.8f, this.transform.position.y, this.transform.position.z);
				knife.GetComponent<Rigidbody2D> ().AddForce (transform.right * velocidadeL * 80);
				weaponName.activeWeapon = "none";
				launch = false;
                left = false;
                right = false;
                timer = 0;
			}

			if (this.transform.localScale.x < 0 && left == true) {
                GameObject knife = Instantiate(knifePrefab) as GameObject;
                knife.transform.localEulerAngles = new Vector3 (0, 0, 0);
				knife.transform.position = new Vector3 (this.transform.position.x - 0.8f, this.transform.position.y, this.transform.position.z);
				knife.GetComponent<Rigidbody2D> ().AddForce (transform.right * velocidadeL * -80);
				weaponName.activeWeapon = "none";
				launch = false;
                left = false;
                right = false;
                timer = 0;
			}
		}
	}

	public void Lançar(bool lançar)
	{
		launch = lançar;
	}

    public void Esquerda(bool esq)
    {
        left = esq;
    }

    public void Direita(bool dir)
    {
        right = dir;
    }
}
