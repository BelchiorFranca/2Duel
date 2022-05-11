using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pivot : MonoBehaviour
{
    Vector2 direction;
    Vector2 DeltaPointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(direction);
        //direction = mousePos - (Vector2)transform.position;
        
        FaceMouse();
    }

    public void Look(InputAction.CallbackContext context){
      direction = context.ReadValue<Vector2>();
    }
    void FaceMouse(){
        transform.right = direction;
    }
}
