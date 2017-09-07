using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		public bool crouch;
		public float h;
		public float v;

        public PlataformaSeguePlayer plat;
        public GameObject buttonUp;
        public GameObject buttonDown;
        public Collider2D col;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (crouch == true)
            {
                col.transform.localEulerAngles = new Vector3(0, 0, 90);
                col.offset = new Vector2(-0.33f, -0.05f);
            }

            else
            {
                col.transform.localEulerAngles = new Vector3(0, 0, 0);
                col.offset = new Vector2(-0.05127324f, -0.1661299f);
            }

          if(plat.onRamp == true)
            {
                m_Character.m_MaxSpeed = 8f;
                plat.velocidadeMov = 1.2f;
                buttonUp.GetComponent<Button>().interactable = false;
                buttonDown.GetComponent<Button>().interactable = false;
                if (h > 0)
                    plat.controleBaixo = 1;

                if (h < 0)
                    plat.controleCima = 1;

                if (h == 0)
                    plat.controleBaixo = plat.controleCima = 0;
            }

          if(plat.onRamp == false && plat.controle == true)
            {
                plat.controleBaixo = plat.controleCima = 0;
                plat.velocidadeMov = 2.5f;
                m_Character.m_MaxSpeed = 10f;
                buttonUp.GetComponent<Button>().interactable = true;
                buttonDown.GetComponent<Button>().interactable = true;
                plat.controle = false;
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            // Pass all parameters to the character control script.
            m_Character.Move(h, v, crouch, m_Jump);
            m_Jump = false;
        }

		public void Agaichar(bool agaichar)
		{

			crouch = agaichar;
		}

		public void Pular(bool pulo)
		{
			m_Jump = pulo;
		}

		public void AndarEsq(float Esq)
		{
			h = -Esq;
		}

		public void AndarDir(float Dir)
		{
			h = Dir;
		}

		public void AndarCima(float Cima)
		{
			v = Cima;
		}

		public void AndarBaixo(float Baixo)
		{
			v = -Baixo;
		}
    }
}
