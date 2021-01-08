using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float xMin, xMax;

    [SerializeField] float padding = 0.7f;
    [SerializeField] float CarSpeed = 10f;
 
    void Start()
    {
        ViewPortToWorldPoint();
    }

    private void ViewPortToWorldPoint()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public float returnCarSpeed()
    {
        return CarSpeed;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * CarSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos, transform.position.y);
    }

}
