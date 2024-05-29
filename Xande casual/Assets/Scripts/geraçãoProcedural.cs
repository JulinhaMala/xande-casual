using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geraçãoProcedural : MonoBehaviour
{
    [SerializeField] int width, heigth;
    [SerializeField] int minStoneheigth, maxStoneheigth;
    [SerializeField] GameObject dirt, grass, stone;
    void Start()
    {
        Genaration();
    }

    // Update is called once per frame
    public void Genaration()
    {
        for (int i = 0; i < width; i++)
        {
            int minHeigth = heigth - 1;
            int maxHeigth = heigth + 2;

            heigth = Random.Range(minHeigth, maxHeigth);

            int minStoneSpawnDistance = heigth - minStoneheigth;

            int maxStoneSpawnDistance = heigth - maxStoneheigth;

            int totalStoneSpawnDIstance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);

            for (int j = 0; j < heigth; j++)
            {
                if (j < totalStoneSpawnDIstance)
                {
                    spawnObj(stone, i, j);
                }
                else
                {
                    spawnObj(dirt, i, j);
                }
                //Instantiate(dirt, new Vector2(i, 0), Quaternion.identity);

            }
            if (totalStoneSpawnDIstance == heigth)
            {
                spawnObj(stone, i, heigth);
            }
            else
            {
                spawnObj(grass, i, heigth);
            }
            //Instantiate(grass, new Vector2(i,heigth), Quaternion.identity);

        }
    }

    void spawnObj(GameObject obj, int width, int heigth)
    {
        obj = Instantiate(obj, new Vector2(width, heigth), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
