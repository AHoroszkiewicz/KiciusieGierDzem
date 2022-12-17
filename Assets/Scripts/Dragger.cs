using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using ReadOnlyAttribute = Unity.Collections.ReadOnlyAttribute;

public class Dragger : MonoBehaviour
{
    [ReadOnly] [SerializeField] bool aboveBackpack, onTable, isDynamic;
    Vector3 startingPos;

    private void Start()
    {
        startingPos= transform.position;
        onTable = true;
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
        if (isDynamic)
        {
            ChangeToKinematic();
        }
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        if (aboveBackpack)
        {
            ChangeToDynamic();
        }
        else ResetPos();
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7) 
            aboveBackpack = true;
        else if (collision.gameObject.layer == 8) 
            onTable = true;
        else if (collision.gameObject.CompareTag("OutOfBounds")) ResetPos();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
            aboveBackpack = false;
        else if (collision.gameObject.layer == 8)
            onTable = false;
        else if (collision.gameObject.CompareTag("OutOfBounds")) ResetPos();
    }

    private Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void ResetPos()
    {
        ChangeToKinematic();
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0); 
        transform.position = startingPos;
        transform.rotation = Quaternion.identity;
    }

    private void ChangeToKinematic()
    {
        isDynamic = false;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    
    private void ChangeToDynamic()
    {
        isDynamic = true;
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    
}
