using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour,IInteractionHandler
{

[Header("Character Attributes")]
    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;
    Vector2 moveVec;
    float angle;
    Vector2  direction = new Vector2 (0,-1);
    [SerializeField ]
    GameObject attackZone;
    
    IInteractionHandler itemToInteract;
        
    [Header("States")]
    bool isAttacking;
  

    

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        attackZone.SetActive(false);
       
    }
   


    // Update is called once per frame
    void FixedUpdate()
    {
        moveVec = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
       Movement();
       InputCheck();
       
       
    }

    public void Interact(IInteractionHandler whoInteracts)
    {
       Debug.Log("Dont Touch me");
    }

    void InputCheck ()
    {
        if(Input.GetButtonUp("Use")) 
        {
                if(itemToInteract != null)
                {
                    itemToInteract.Interact(this);
                }
               
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Attack();
            
        }
    }
    void Movement ()
    {
        
        
        Vector2 currentPos = rbody.position;
        moveVec = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        moveVec = Vector2.ClampMagnitude(moveVec, 1);
        Vector2 movement = moveVec * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        RotateCollision();
        
        
        
          
    }
    
   
    
    void OnCollisionEnter2D(Collision2D other)
    {
        MonoBehaviour[] list = other.gameObject.GetComponents<MonoBehaviour>();
         foreach(MonoBehaviour mb in list)
         {
             if (mb is IInteractionHandler)
             {
                 itemToInteract = (IInteractionHandler)mb;
                 
             }
         }
    }
     
     private   void RotateCollision()
        {
            if (moveVec != Vector2.zero)
          {
              Vector2 dir = moveVec * movementSpeed;
              Vector2 normDir = dir.normalized;
              float angle = Vector2.SignedAngle(Vector2.up, normDir);
              attackZone.transform.rotation = Quaternion.Euler(0,0,angle);
             
          }
             
                           
        
       
        
        
        }

        void Attack ()
        {
              isAttacking = true;
              StartCoroutine(DoAttack());
        }
        IEnumerator DoAttack()
        {
            attackZone.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            attackZone.SetActive(false);
            isAttacking =false;
        }
        
}

  
