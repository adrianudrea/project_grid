using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool isColliding;

    private void Update()
    {
        ChanceColorOnCollision();
    }

    private void ChanceColorOnCollision()
    {
        if(isColliding)
        {
            gameObject.transform.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.transform.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.collider.tag == "Building") { isColliding = true; }    
    }

    private void OnCollsionStay(Collision collision)
    {
        if(collision.collider.tag == "Building") { isColliding = true; }
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
}
