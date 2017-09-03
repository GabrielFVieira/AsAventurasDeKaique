using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSeguePlayer : MonoBehaviour
{
    public GameObject player;
    public float velocidadeMov;
    public int controleCima;
    public int controleBaixo;

    public bool canWalkDown;
    public bool canWalkUp = true;

    public bool onRamp;
    public bool controle;

    // Use this for initialization
    void Start()
    {
        canWalkDown = true;

        player = GameObject.Find("Player");

        velocidadeMov = 2.5f;

        controleCima = controleBaixo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        
        if (canWalkDown == true && controleBaixo == 1)
        {
            transform.Translate(0, -velocidadeMov * Time.deltaTime, 0);
        }

        if (canWalkUp == true && controleCima == 1)
        {
            transform.Translate(0, velocidadeMov * Time.deltaTime, 0);
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WorldProps")
        {
            transform.Translate(0, velocidadeMov * Time.deltaTime, 0);
        }

        if (col.gameObject.tag == "WorldWallsUp")
        {
            canWalkUp = false;
        }

        if (col.gameObject.tag == "WorldRamp")
        {
            onRamp = true;
            controle = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "WorldWallsUp")
        {
            canWalkUp = true;
        }

        if (col.gameObject.tag == "WorldRamp")
        {
            onRamp = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "WorldWalls")
        {
            canWalkDown = false;
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "WorldWalls")
        {
            canWalkDown = true;
        }
    }

    public void AndarCima(int andarCima)
    {
        if(canWalkUp == true)
        controleCima = andarCima;

        else
            controleCima = 0;
    }

    public void AndarBaixo(int andarBaixo)
    {
        if (canWalkDown == true)
            controleBaixo = andarBaixo;

        else
            controleBaixo = 0;
    }
}
