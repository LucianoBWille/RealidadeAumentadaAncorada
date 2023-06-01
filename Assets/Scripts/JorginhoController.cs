using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorginhoController : MonoBehaviour
{
    // variasveis privadas para o rigidbody, animation e joystick
    private Rigidbody rb;
    private Animation anim;
    private Joystick joystick;
    
    // private sword box collider
    // private BoxCollider swordCollider;

    // bool atacando
    private bool atacando = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        joystick = FindObjectOfType<Joystick>();

        // swordCollider = GameObject.Find("Sword02").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // variaveis para o movimento do personagem
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        // variavel para a velocidade do personagem
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = movement * 2f;

        // rotacao do personagem
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            // transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg, transform.eulerAngles.z);
            transform.rotation = Quaternion.LookRotation(movement);
        }

        // animacao do personagem
        // ataque do personagem
        if (atacando)
        {
            anim.Play("Attack");
        }else{
            if (moveHorizontal != 0 || moveVertical != 0)
                {
                    anim.Play("Walk");
                }
                else
                {
                    anim.Play("Wait");
                }
        }

    }

    // funcao para o ataque do personagem
    public void Atacar()
    {
        if (!atacando)
        {
            atacando = true;
            // swordCollider.enabled = true;
            Invoke("AtaqueFinalizado", 0.5f);
        }
    }

    // funcao para finalizar o ataque do personagem
    void AtaqueFinalizado()
    {
        atacando = false;
        // swordCollider.enabled = false;
    }

    // getter para o atacando
    public bool GetAtacando()
    {
        return atacando;
    }

}
