using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; 
    public TextMeshProUGUI CountText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;

private float movementX;
private float movementY;

// Start is called before the first frame update

    void Start()
    {
        winTextObject.SetActive(false);
        SetCountText();
        count = 1;
    rb = GetComponent <Rigidbody>();     
    }

    // Update is called once per frame
 void OnMove (InputValue movementValue)
   {
   Vector2 movementVector = movementValue.Get<Vector2>();

    movementX = movementVector.x; 
    movementY = movementVector.y;  
   }
      void SetCountText() 
   {
       CountText.text =  "Count: " + count.ToString();
   }
private void FixedUpdate()
{
    Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

    rb.AddForce(movement * speed);
} 

private void OnTriggerEnter(Collider other)
{
    SetCountText();
    if (other.gameObject.CompareTag("PickUp")) {
        other.gameObject.SetActive(false);
        count = count + 1;
        if (count >= 12)
       {
           winTextObject.SetActive(true);
       }
        
    }
    
}

}
