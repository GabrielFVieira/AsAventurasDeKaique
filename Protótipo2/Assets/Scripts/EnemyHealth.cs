using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    public float curHealth;
    //public GameObject knifePrefab;
    public GameObject medKitPrefab;
	public GameObject littleWaterBottlePrefab;
    public GameObject healthBar;
    public GameObject healthBarContainer;
    public PlayerHealth playerHealth;
    public bool encostando;
    public bool encostando2;

    Animator animo;

    public AudioSource punch;
    public AudioSource punch2;

    public Collider2D[] colliders;

    public float random;
    public int golpe;

    public float timer = 0.0f;
    public bool start = false;

    public float delta;
    // Use this for initialization
    void Start()
    {
        delta = 1;

        colliders = GetComponents<Collider2D>();

        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        MaxHealth = 100f;
        curHealth = MaxHealth;
        encostando = false;

        animo = GetComponent<Animator>();

        if (gameObject.name == "Boss")
            MaxHealth = curHealth = 600f;
    }


    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 5);

        golpe = Random.Range(3, 6);

        if (start == true)
            timer += Time.deltaTime;

        if (curHealth <= 0)
        {
            animo.SetInteger("Condição", 2);
            start = true;
            healthBarContainer.SetActive(false);
            foreach (Collider2D col in colliders)
            {
                col.enabled = false;
            }
                
        

            if (timer >= 1.0f && gameObject.name != "Boss")
            {
                Destroy(gameObject);
                //Drop a Knife
               /* if (random == 0)
                {
                    GameObject knife = Instantiate(knifePrefab) as GameObject;
                    knife.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
                }*/
                //Drop a MedKit
                if (random == 1)
                {
                    GameObject medkit = Instantiate(medKitPrefab) as GameObject;
                    medkit.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
                }

				if (random == 2)
				{
					GameObject litteWaterBottle = Instantiate(littleWaterBottlePrefab) as GameObject;
					litteWaterBottle.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
				}
            }
        }

        if (delta <= 0.01f && playerHealth.curHealth > 0)
        {
            animo.SetInteger("Condição", golpe);

            if (encostando2 == true)
            {
                playerHealth.curHealth -= 5;
                encostando2 = false;
            }
            if (golpe == 4)
                punch2.Play();

            else
                punch.Play();
        }


        if (encostando == true && curHealth > 0)
        {
            delta -= Time.deltaTime;
            
            //InvokeRepeating("Dano", 0.5f, 2f);
            //animo.SetInteger("Condição", 1); attack number
        }

        if (delta <= 0 || encostando == false)
            delta = 0.5f;
        /*
		else if (encostando == false || curHealth <=0)
        {
            CancelInvoke();
        }*/

    }
    void FixedUpdate()
    {
        float calc_Health = curHealth / MaxHealth;
        SetHealthBar(calc_Health);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            encostando2 = true;
        }
    }
        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            encostando = true;
        }
        /*
        if (collision.gameObject.name == "KnifePrefab(Clone)")
        {
            curHealth -= 20;
			Destroy(collision.gameObject);
        }*/

		if (collision.gameObject.tag == "WaterBall")
		{
			curHealth -= 40;
			Destroy(collision.gameObject);
		}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            encostando = false;
            encostando2 = false;
        }
    }

    void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void Dano()
    {
        playerHealth.curHealth -= 0.05f;


    }
}