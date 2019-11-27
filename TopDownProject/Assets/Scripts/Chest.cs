using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractionHandler
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 public void Interact (IInteractionHandler whoInteracts)
    {
      Debug.Log("it was pressed");
    }
   
}
