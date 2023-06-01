using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    // estado da animação Wait, Damage e Dead
    private string estadoAnimacao = "Wait";

    // animation
    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update() {
        anim.Play(estadoAnimacao);
    }

    private void OnTriggerStay(Collider other)
    {
        // if sword is colliding with slime and is attacking then damage slime, then dead slime, then deactivate slime, then after 3 seconds wait slime and reactivate
        if (other.gameObject.CompareTag("Sword") && other.GetComponentInParent<JorginhoController>().GetAtacando() && estadoAnimacao == "Wait")
        {
            DamageSlime();
        }
    }

    void DamageSlime()
    {
        estadoAnimacao = "Damage";
        Invoke("DeadSlime", .5f);
    }

    void DeadSlime()
    {
        estadoAnimacao = "Dead";
        Invoke("DeactivateSlime", 1f);
    }

    void DeactivateSlime()
    {
        gameObject.SetActive(false);
        Invoke("WaitSlime", 3f);
    }

    void WaitSlime()
    {
        estadoAnimacao = "Wait";
        gameObject.SetActive(true);
    }

}
