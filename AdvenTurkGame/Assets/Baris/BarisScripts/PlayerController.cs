using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float MovingStep;
    [SerializeField] LayerMask triggerMask;
    Camera _mainCamera;
    Rigidbody2D rb;
    Vector2 mousePosition;
    bool isclick;
    private void Awake() {
        _mainCamera=Camera.main;
    }
    private void Start() {
        rb=this.gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        OnClickInteract();
        OnClickMoving();    
    }
    public void OnClickInteract()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        RaycastHit2D rayHit=Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition),Vector3.forward,Mathf.Infinity,triggerMask);
        if(!rayHit.collider)
        { 
            return;
        } 
        rayHit.collider.GetComponent<Interactable>().Interact();
        
    }
    public void OnClickMoving()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        if (Input.GetMouseButtonDown(1))
        {
            isclick=true;
        }
        mousePosition =_mainCamera.ScreenToWorldPoint(Input.mousePosition);    
        
    }
    private void FixedUpdate() {
        if (isclick==true)
        {
            transform.position=Vector2.MoveTowards(transform.position,new Vector2(mousePosition.x,transform.position.y),MovingStep*Time.deltaTime);
            
        }  
    }

}