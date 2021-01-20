using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    float xMin, xMax;

    [SerializeField] float padding = .75f;
    [SerializeField] float CarSpeed = 10f;
    [SerializeField] int playerHealth = 100;
    [SerializeField] AudioClip playerHitSound;
    [SerializeField] AudioClip playerExplodeSound;
    [SerializeField] float Points = 0;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    [SerializeField] [Range(0, 1)] float playerHitSoundVol = 0.75f;
    [SerializeField] [Range(0, 1)] float playerExplodeSoundVol = 0.75f;


    void Start()
    {
        ViewPortToWorldPoint();
    }



    public void ViewPortToWorldPoint()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    void Update()
    {
        Move();
    }

    public int GetHealth()
    {
        return playerHealth;
    }

    public float returnCarSpeed()
    {
        return CarSpeed;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();

        damageDealer.Hit();

        AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, playerHitSoundVol);

        if (playerHealth <= 0 && Points < 100)
        {
            Die();
        }
    }
    public void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * CarSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos, transform.position.y);
    }
    
    private void Die()
    {
        AudioSource.PlayClipAtPoint(playerExplodeSound, Camera.main.transform.position, playerExplodeSoundVol);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
        FindObjectOfType<Level>().LoadGameOver();
    }
}
