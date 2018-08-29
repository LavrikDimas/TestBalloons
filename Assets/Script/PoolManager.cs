using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    float timeSpawn, poolSize;

    [SerializeField]
    List<GameObject> prefabl;

    [SerializeField]
    List<Transform> balloonsInstPosition;

	
	void Start ()
    {        
        InvokeRepeating("InstBalloons", 1f, timeSpawn);       
	}
	

    void InstBalloons()
    {
        if (poolSize <= 0)
            return;

        var randomInst = new Vector2(Random.Range(balloonsInstPosition[1].position.x, balloonsInstPosition[0].position.x), 0);
        var instPosinion = new Vector2(randomInst.x, balloonsInstPosition[2].position.y);
        Instantiate(prefabl[Random.Range(0, prefabl.Count)], instPosinion, Quaternion.identity);
        poolSize--;
    }
}
