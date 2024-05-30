using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geraçãoProcedural : MonoBehaviour
{

    public GameObject[] wallPrefabs; // Lista de prefabs de paredes
    public Transform playerTransform; // Referência ao transform do jogador
    public float wallGap = 2f; // Distância entre as paredes
    public float wallLifetime = 10f; // Tempo de vida das paredes

    private float lastWallY; // Posição y da última parede gerada

    void Start()
    {
        // Inicializa a posição y da última parede gerada
        lastWallY = playerTransform.position.y;

        // Inicia a rotina para remover paredes antigas
        StartCoroutine(RemoveOldWalls());
    }

    void Update()
    {
        // Verifica se o jogador subiu o suficiente para gerar uma nova parede
        if (playerTransform.position.y - lastWallY > wallGap)
        {
            GenerateWall();
        }
    }

    void GenerateWall()
    {
        // Calcula a posição da nova parede
        float newWallY = lastWallY + wallGap;
        lastWallY = newWallY;

        // Sorteia qual prefab de parede usar
        int randomIndex = Random.Range(0, wallPrefabs.Length);
        GameObject selectedWallPrefab = wallPrefabs[randomIndex];

        // Instancia a nova parede
        GameObject newWall = Instantiate(selectedWallPrefab, new Vector3(0f, newWallY, 0f), Quaternion.identity);

        // Inicia a rotina para remover a parede após um tempo
        StartCoroutine(RemoveWall(newWall));
    }

    IEnumerator RemoveOldWalls()
    {
        while (true)
        {
            // Procura todas as paredes na cena
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

            // Remove cada parede após um certo tempo
            foreach (GameObject wall in walls)
            {
                Destroy(wall, wallLifetime);
            }

            // Aguarda um certo tempo antes de verificar novamente
            yield return new WaitForSeconds(wallLifetime);
        }
    }

    IEnumerator RemoveWall(GameObject wall)
    {
        // Remove a parede após um certo tempo
        yield return new WaitForSeconds(wallLifetime);
        Destroy(wall);
    }
}
