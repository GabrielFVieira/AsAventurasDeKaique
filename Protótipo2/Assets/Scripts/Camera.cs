using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public bool cameraLock = false;
    public PlataformaSeguePlayer plataforma;

    public Parede parede1;
	public GameObject waveCenter1;
    public GameObject Enemies1;
    //public GameObject parede1Script;

    public Parede parede2;
    public GameObject waveCenter2;
    public GameObject Enemies2;
    //public GameObject parede2Script;

    public Parede parede3;
    public GameObject waveCenter3;
    public GameObject Enemies3;
    //public GameObject parede2Script;

    public int i = 1;
    public bool controle = false;
    void Start()
    {
        player = GameObject.Find("Player");

        parede1 = GameObject.Find("ParedeInvisivelEsquerda1").GetComponent<Parede>();
        waveCenter1 = GameObject.Find("WaveCenter1");
        Enemies1 = GameObject.Find("Enemies1");
        //parede1Script = GameObject.Find("ParedeInvisivelEsquerda1");

        parede2 = GameObject.Find("ParedeInvisivelEsquerda2").GetComponent<Parede>();
        waveCenter2 = GameObject.Find("WaveCenter2");
        Enemies2 = GameObject.Find("Enemies2");
        //parede2Script = GameObject.Find("ParedeInvisivelEsquerda2");

        parede3 = GameObject.Find("ParedeInvisivelEsquerda3").GetComponent<Parede>();
        waveCenter3 = GameObject.Find("WaveCenter3");
        Enemies3 = GameObject.Find("Enemies3");
        //parede3Script = GameObject.Find("ParedeInvisivelEsquerda3");
    }

    void Update()
    {
        if(plataforma.onRamp == false)
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if(transform.position.y > 0)
            transform.position = new Vector3(player.transform.position.x, 0, transform.position.z);

        if (transform.position.y < -10f)
            transform.position = new Vector3(player.transform.position.x, -10, transform.position.z);

        if (plataforma.onRamp == true && plataforma.controleBaixo == 1)
        {
            transform.Translate(3.2f * Time.deltaTime, -1.2f * Time.deltaTime, 0);
        }

        if (plataforma.onRamp == true && plataforma.controleCima == 1)
        {
            transform.Translate(-3.2f * Time.deltaTime, 1.2f * Time.deltaTime, 0);
        }

        if (player.transform.position.y > -2.2f && transform.position.y < 0)
            transform.Translate(0, 2 * Time.deltaTime, 0);

        if (player.transform.position.y < -10f && transform.position.y > -9.9f)
            transform.Translate(0, -2 * Time.deltaTime, 0);

        ////////////////////////////////////////////// WAVE 1 ////////////////////////////////////////////////////////////////
        if (parede1.waveStart == true && cameraLock == true)
        {
            transform.position = new Vector3(waveCenter1.transform.position.x, transform.position.y, transform.position.z);
        }

        if (player.transform.position.x >= waveCenter1.transform.position.x && Enemies1.transform.childCount > 0)
        {
            cameraLock = true;
            Enemies1.SetActive(true);
        }

        if (cameraLock == true && parede1.GetComponent<BoxCollider2D>().isTrigger == false)
            controle = true;


        if (Enemies1.transform.childCount == 0 && i == 1)// && pos.position.x >= waveCenter.transform.position.x || pos.position.x <= parede1.transform.position.x)
        {
            cameraLock = false;
            parede1.waveStart = false;

            if (controle == true)
            {
                i += 1;
                controle = false;
            }
        }

        ////////////////////////////////////////////// WAVE 2 ////////////////////////////////////////////////////////////////

        if (parede2.waveStart == true && cameraLock == true)
        {
            transform.position = new Vector3(waveCenter2.transform.position.x, transform.position.y, transform.position.z);        }

        if (player.transform.position.x >= waveCenter2.transform.position.x && Enemies2.transform.childCount > 0)
        {
            cameraLock = true;
            Enemies2.SetActive(true);
        }

        if (cameraLock == true && parede2.GetComponent<BoxCollider2D>().isTrigger == false)
            controle = true;


        if (Enemies2.transform.childCount == 0 && i == 2)// && pos.position.x >= waveCenter.transform.position.x || pos.position.x <= parede1.transform.position.x)
        {
            cameraLock = false;
            parede2.waveStart = false;

            if (controle == true)
            {
                i += 1;
                controle = false;
            }
        }

        ////////////////////////////////////////////// WAVE 3 ////////////////////////////////////////////////////////////////

        if (parede3.waveStart == true && cameraLock == true)
        {
            transform.position = new Vector3(waveCenter3.transform.position.x, transform.position.y, transform.position.z);
        }

        if (player.transform.position.x >= waveCenter3.transform.position.x && Enemies3.transform.childCount > 0)
        {
            cameraLock = true;
            Enemies3.SetActive(true);
        }

        if (cameraLock == true && parede3.GetComponent<BoxCollider2D>().isTrigger == false)
            controle = true;


        if (Enemies3.transform.childCount == 0 && i == 3)// && pos.position.x >= waveCenter.transform.position.x || pos.position.x <= parede1.transform.position.x)
        {
            cameraLock = false;
            parede3.waveStart = false;

            if (controle == true)
            {
                i += 1;
                controle = false;
            }
        }
    }
}