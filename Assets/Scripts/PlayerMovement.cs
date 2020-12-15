using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody playerRigidbody;
    private Vector3 movement;
    public Camera playerCamera;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //General movement
        playerRigidbody.MovePosition(playerRigidbody.position + movement * speed * Time.fixedDeltaTime);
        
        //Aiming angle
        Vector2 positionOnScreen = playerCamera.WorldToViewportPoint (transform.position);
        Vector2 mouseOnScreen = (Vector2)playerCamera.ScreenToViewportPoint(Input.mousePosition);
        float angle = GetAngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation =  Quaternion.Euler (new Vector3(0f,-angle,0f));
    }

    float GetAngleBetweenTwoPoints(Vector3 angleA, Vector3 angleB) {
        return Mathf.Atan2(angleA.y - angleB.y, angleA.x - angleB.x) * Mathf.Rad2Deg + 90f;
    }
}
