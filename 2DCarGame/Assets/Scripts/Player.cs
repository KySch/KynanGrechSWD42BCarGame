﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float xMin, xMax;

    [SerializeField] float padding = 0.7f;
    [SerializeField] float CarSpeed = 10f;
    [SerializeField] float playerHealth = 100;
    [SerializeField] AudioClip enemyDeathSound;

    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.75f;


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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //access the Damage Dealer from the "other" object which hit the enemy
        //and depending on the laser damage reduce health
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();

        AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, enemyDeathSoundVolume);

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
