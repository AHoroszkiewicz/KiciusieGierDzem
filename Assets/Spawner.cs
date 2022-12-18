using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject hitPointObject;

    [SerializeField]
        Transform minBound;
    [SerializeField]
        Transform maxBound;

        //GameObject currentHit;
    private void Start()
    {

        SpawnHitPoint();
    }


    public void SpawnHitPoint()
    {
                float width = GetComponent<SpriteRenderer>().bounds.size.x;

        Instantiate(hitPointObject, new Vector3(Random.Range(minBound.position.x, maxBound.position.x), gameObject.transform.position.y, 0), Quaternion.identity);
        //instantiatedObject.transform.parent = gameObject.transform;
    }



}
