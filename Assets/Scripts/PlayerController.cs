using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text pickUpCountText;
    public Text winText;

    private Rigidbody rigidbody;
    private int pickupCount;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pickupCount = 0;
        SetPickUpCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickupCount += 1;
            SetPickUpCountText();
        }
    }

    private void SetPickUpCountText()
    {
        pickUpCountText.text = "Count: " + pickupCount.ToString();
        if (pickupCount >= 12)
        {
            winText.text = "You Win!";
        }
    }

}

        
