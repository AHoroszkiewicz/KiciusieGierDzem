using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField]
   GameObject bar;
   [SerializeField]
   GameObject indicator;
    //[SerializeField]
   float sizeOfBar;
    void Start()
    {
        sizeOfBar = bar.transform.localScale.x;
        
    }

    private void Update() 
    {

        // if(indicator.transform.position.x >= sizeOfBar)
        // {
        //     indicator.transform.position = new Vector2(1, bar.transform.position.y) * IndicatorSpeed * Time.deltaTime;
        // }else{
        //     indicator.transform.position = new Vector2(-1, bar.transform.position.y) * IndicatorSpeed * Time.deltaTime;

        // }

        // if(turnLeft)
        // {
        //    indicator.transform.Translate(Vector3.right * indicatorSpeed * Time.deltaTime); 
        // }else if(!turnLeft)
        // {
        //     indicator.transform.Translate(Vector3.left * indicatorSpeed * Time.deltaTime);
        // }

    }

   

    // private void OnTriggerEnter2D(Collider2D other) {
       

    //     turnLeft = false;
        
    // }

    // private void (Collision2D other) {
    //     if(other.gameObject.tag == "rightBarCollider")
    //     {
    //         turnLeft = true;
    //         //indicator.transform.Translate(Vector3.right * indicatorSpeed * Time.deltaTime);

    //     }else if(other.gameObject.tag == "leftBarCollider")
    //     {
    //                         //indicator.transform.Translate(Vector3.left * indicatorSpeed * Time.deltaTime);

    //     turnLeft = false;
    //     }
    // }

}
