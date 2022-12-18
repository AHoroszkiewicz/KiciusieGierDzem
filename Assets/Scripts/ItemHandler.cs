using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using ReadOnlyAttribute = Unity.Collections.ReadOnlyAttribute;

public class ItemHandler : MonoBehaviour
{
    [ReadOnly][SerializeField] bool aboveBackpack, isDynamic; 
        public bool inBackpack;
    Vector3 startingPos;

    private void Start()
    {
        startingPos= transform.position;
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
        inBackpack= false;
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
        else if (collision.gameObject.CompareTag("OutOfBounds")) ResetPos();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
            aboveBackpack = false;
        else if (collision.gameObject.CompareTag("OutOfBounds")) ResetPos();
        if (collision.gameObject.CompareTag("InBackpack")) inBackpack= true;
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
