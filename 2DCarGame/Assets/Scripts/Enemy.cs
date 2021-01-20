using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] float enemyBulletSpeed = 0.3f;

    [Header("Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }


    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }



    private void CountDownAndShoot()
    {
        //every frame reduces the amount of time that the frame takes to run
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            EnemyFire();
            //reset shotCounter after every fire
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    //reduces health whenever enemy collides with a gameObject which has DamageDealer component
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
    }

    private void EnemyFire()
    {
        GameObject enemyLaser = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity) as GameObject;
        //enemy laser shoots downwards, hence -enemyLaserSpeed
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - enemyBulletSpeed);
    }

}