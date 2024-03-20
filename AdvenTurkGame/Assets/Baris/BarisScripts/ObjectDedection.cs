using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDedection : MonoBehaviour
{
    float interactObject;
void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePoint=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit=Physics2D.Raycast(mousePoint,Vector2.zero);
            if (hit.transform.GetComponent<Interactable>()!=null&&hit.collider)
            {
                hit.transform.GetComponent<Interactable>().Interact();
                interactObject=hit.transform.position.x;
            }
        }
    }
    private void FixedUpdate() {
        transform.position=Vector2.MoveTowards(transform.position,new Vector2(interactObject,transform.position.y),10*Time.deltaTime);
    }
}
