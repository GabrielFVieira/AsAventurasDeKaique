using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public PickUpWeapon pick;
    public float MaxHealth;
    public float curHealth;
    public GameObject healthBar;
    public GameObject deathMenu;
    public GameObject hud;
    public GameObject player;

    public GameObject enemies;
    public EnemyHealth enemyHealth;

    public AudioSource punch;
    public AudioSource punch2;

    public PickUpWeapon weapon;
    public bool ataque;
    public bool chute;
    public bool encostando;

    public float dano;
    Animator animo;

    public Camera cam;

	public int golpe;

    public int i;

    public float timer = 0.0f;
    public bool start = false;

    public float delayAttack = 0.0f;
    public bool attackClicked;
    public Collider2D[] colliders;

    public float delay = 1;

    public GameObject box;

    public Keyboard key;

    // Use this for initialization
    void Start()
    {
		pick = player.GetComponent<PickUpWeapon> ();

        colliders[0].enabled = false;

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        enemies = GameObject.Find("Enemies" + cam.i);

        hud = GameObject.Find("HUD");
        //deathMenu = GameObject.Find("DeathMenu");

        player = GameObject.Find("Player");
        healthBar = GameObject.Find("PlayerHealthBar");
        weapon = player.GetComponent<PickUpWeapon>();
	
        MaxHealth = 100f;
        curHealth = MaxHealth;
        deathMenu.SetActive(false);
        ataque = false;
        chute = false;
        encostando = false;
        animo = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(key.controle == true)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (pick.crounch == false && pick.CanPickUp == false)
                {
                    ataque = true;
                    colliders[0].offset = new Vector2(0.45f, -0.12f);
                    animo.SetInteger("Condição", golpe);
                }
            }

            if (Input.GetKeyUp(KeyCode.J))
            {
                ataque = false;
            }
        }



		golpe = Random.Range (3, 5);

        //SET PLAYER HEALTH
        if (curHealth > 100)
            curHealth = 100;


        //PLAYER's DEATH
        if (curHealth <= 0)
        {
            animo.SetInteger("Condição", 1);
            start = true;

            hud.SetActive(false);

            if (timer >= 0.41f)
            {
                Cursor.visible = true;
                deathMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }


        //WEAPON IN HUD
        if (weapon.activeWeapon == "none")
            dano = 20f;

        if (weapon.activeWeapon == "Knife")
            dano = 35f;


        //ENEMIES ALIVE
        i = enemies.transform.childCount;


        //ENEMY's IS DEAD
        if (enemyHealth != null)
        {
            if (enemyHealth.curHealth <= 0)
                encostando = false;
        }

        //DESACTIVE ATTACK 
        if (ataque == false && animo.GetCurrentAnimatorStateInfo(0).IsName("soco"))
        {
            animo.SetInteger("Condição", 0);
            colliders[0].offset = new Vector2(0.18f, -0.12f);
            colliders[0].enabled = false;
        }

        if (chute == false && animo.GetCurrentAnimatorStateInfo(0).IsName("chute"))
        {
            animo.SetInteger("Condição", 0);
            colliders[0].offset = new Vector2(0.18f, -0.12f);
            colliders[0].enabled = false;
        }


        //DELAY FOR DEATH ANIMATION
        if (start == true)
            timer += Time.deltaTime;


        //ACTIVE THE ATTACK COLLIDER
        if (ataque == true && animo.GetCurrentAnimatorStateInfo(0).IsName("soco"))
        {
            colliders[0].enabled = true;
            ataque = false;
        }


        //DETECT THE COLLIDING ENEMY AND ATTACK HIM
        if (animo.GetFloat("Speed") <= 0.1f)
        {
            if (encostando == true && ataque == true || encostando == true && chute == true)
            {
                enemyHealth.curHealth -= dano;
                if (golpe == 4)
                    punch.Play();

                else
                    punch2.Play();

                ataque = false;
            }

            if(box != null && ataque == true || box != null && chute == true)
            {
                box.GetComponent<Box>().i -= 1;
                ataque = chute = false;

            }
        }
    }

    void FixedUpdate()
    {
        if (curHealth >= 0)
        {
            float calc_Health = curHealth / MaxHealth;
            SetHealthBar(calc_Health);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.transform.position.x < transform.position.x && transform.localScale.x < 0)
            {
                encostando = true;
                enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            }
            if (collision.gameObject.transform.position.x > transform.position.x && transform.localScale.x > 0)
            {
                encostando = true;
                enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            }
        }

        if (collision.gameObject.tag == "Box")
        {
            if (collision.gameObject.transform.position.x < transform.position.x && transform.localScale.x < 0)
            {
                box = collision.gameObject;
            }
            if (collision.gameObject.transform.position.x > transform.position.x && transform.localScale.x > 0)
            {
                box = collision.gameObject;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            encostando = false;
            enemyHealth = null;
        }

        if (collision.gameObject.tag == "Box")
        {
            box = null;
        }
    }

    void SetHealthBar(float myHealth)
    {
        healthBar.GetComponent<Image>().fillAmount = myHealth;
    }

    public void Attack(bool attack)
    {
		if (pick.crounch == false && pick.CanPickUp == false) {
			ataque = attack;
			colliders [0].offset = new Vector2 (0.45f, -0.12f);
			animo.SetInteger ("Condição", golpe);
		}
    }
}