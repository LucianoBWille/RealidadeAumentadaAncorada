using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCrateController : MonoBehaviour
{
    // variavel para o prefab da caixa
    public GameObject cratePrefab;
    // caixa já instanciada
    public GameObject spawnedCrate;

    // posição e rotação da caixa
    private Transform crateTransform;

    // salvar parente da caixa
    private Transform crateParent;

    // função para reintanciar a caixa
    public void RespawnCrate()
    {
        // se a caixa já foi instanciada
        if (spawnedCrate)
        {
            // salvar a posição e rotação da caixa
            crateTransform = spawnedCrate.transform;
            // salvar o parente da caixa
            crateParent = spawnedCrate.transform.parent;
            // destruir a caixa
            Destroy(spawnedCrate);
        }
        // instanciar a caixa na posição e rotação salvas
        spawnedCrate = Instantiate(cratePrefab, crateTransform.position, crateTransform.rotation);

        // ajustar a escala da caixa
        spawnedCrate.transform.localScale = crateTransform.localScale;

        // setar o parente da caixa
        spawnedCrate.transform.parent = crateParent;
    }
}
