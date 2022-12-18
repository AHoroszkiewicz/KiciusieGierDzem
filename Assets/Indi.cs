using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indi : MonoBehaviour
{
    
    [SerializeField]
    Spawner spawner;
[SerializeField] float indicatorSpeed;
 public bool turnLeft;
GameObject hitPoint;
 bool canDestroy;

 [SerializeField]
 PointsManager pointsManager;

    public Difficulty difficulty;


    private void FixedUpdate() 
    {
        
       

        if(turnLeft)
        {
           gameObject.transform.Translate(Vector3.right * indicatorSpeed * Time.deltaTime); 
        }else if(!turnLeft)
        {
            gameObject.transform.Translate(Vector3.left * indicatorSpeed * Time.deltaTime);
        }


      
    }

    private void Update()
    {
        if(canDestroy && Input.GetKeyDown(KeyCode.E))
        {
               hitPoint = GameObject.FindWithTag("HitPoint");
               Destroy(hitPoint);
               canDestroy = false;
                spawner.SpawnHitPoint();
                pointsManager.AddPointsToWiarygodnoscXD(10);
                indicatorSpeed = indicatorSpeed * 1.5f;

        }else if(!canDestroy && Input.GetKeyDown(KeyCode.E))
        {
            pointsManager.AddPointsToLiarMeter(10);

        }
    }

 private void OnTriggerEnter2D(Collider2D other) {
        
            if(other.gameObject.CompareTag("HitPoint"))
            {canDestroy = true;} 


 
            
        
        if(other.gameObject.CompareTag("rightBarCollider"))
        {
            turnLeft = false;
            

        }else if(other.gameObject.CompareTag("leftBarCollider"))
        {            turnLeft = true;


        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("HitPoint"))
            {canDestroy = true;} 
    }

}
