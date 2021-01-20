﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        Destroy(collision.gameObject);
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }
}