using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Specialized;

public class PlayerController1 : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winTextObject;
    private Rigidbody rb;

    private float movementX;
    private float movementY;


    private int count;
    private int remaining;

    public float timeStart = 0;
    private int finalTime;
    private float timer = 0f;
    public TextMeshProUGUI Timer;

    public Boolean isMobileBuild;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        

        SetCountText();

        winTextObject.gameObject.SetActive(false);

 //       if (isMobileBuild)
  //      {
    //        InputSystem.EnableDevice(UnityEngine.InputSystem.Accelerometer.current);
     //   }
    }



    //private void OnMove(InputValue movementValue)
    //{
    //    Vector2 movementVector = movementValue.Get<Vector2>();


    //    movementX = movementVector.x;
    //    movementY = movementVector.y;
    //}

    //private void FixedUpdate()

    //{
    //    Vector3 movement = Vector3.zero;

    //    if (isMobileBuild) {
    //        Vector3 a = UnityEngine.InputSystem.Accelerometer.current.acceleration.ReadValue();
    //        movement = new Vector3(a.x, 0.0f, a.y);
    //    }

    //    else {
    //        movement = new Vector3(movementX, 0.0f, movementY);

    //    }
    //    rb.AddForce(movement * speed);
    //    timeStart += Time.deltaTime;
    //    Timer.text = "Timer : " + Mathf.Round(timeStart).ToString() + " seconds";
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;
            

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void SetCountText()
    {
        remaining = 12 - count;
        countText.text = remaining.ToString() + " Collectibles remaining" ;

        if (count >= 12)
        {
            // Set the text value of your 'winText'
            finalTime = (int)Mathf.Round(timeStart);
            winTextObject.text = "Congrats it took you " + finalTime.ToString() + " seconds to collect them all. Try again to be even faster ! :)";
            winTextObject.gameObject.SetActive(true);
        }
    }

}
