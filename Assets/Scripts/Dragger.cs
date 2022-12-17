using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    bool aboveBackpack, onTable, isDynamic;
    Vector3 startingPos;

    private void Start()
    {
        startingPos= transform.position;
        onTable = true;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
        if (isDynamic)
        {
            isDynamic= false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnMouseUp()
    {
        if (aboveBackpack)
        {
            isDynamic = true;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
        else if (!onTable)
            transform.position= startingPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 7) 
            aboveBackpack = true;
        else if (collision.gameObject.layer == 8) 
            onTable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 7)
            aboveBackpack = false;
        else if (collision.gameObject.layer == 8)
            onTable = false;
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
