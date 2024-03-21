using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float MovingStep;
    [SerializeField] LayerMask triggerMask;
    Camera _mainCamera;
    Rigidbody2D rb;
    Vector2 mousePosition;
    float horDir;
    bool isHitDetect;
    bool isclick;
    private void Awake() {
        _mainCamera=Camera.main;
    }
    private void Start() {
        rb=this.gameObject.GetComponent<Rigidbody2D>();
    }
    public void OnClickInteract(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        
        RaycastHit2D rayHit=Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()),Vector3.forward,Mathf.Infinity,triggerMask);
        if(!rayHit.collider)
        { 
            return;
        } 
        rayHit.collider.GetComponent<Interactable>().Interact();
        
    }
    public void OnClickMoving(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (context.started)
        {
            isclick=true;
        }
        mousePosition =_mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());    
        
    }
    private void FixedUpdate() {
        if (isclick==true)
        {
            transform.position=Vector2.MoveTowards(transform.position,new Vector2(mousePosition.x,transform.position.y),MovingStep*Time.deltaTime);    
        }
        
    }
}