using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Transform target;
    public float speed;
    private Rigidbody2D _projectile_rigidbody;
    private float _lifeRemaining = 0.0f;
    public float projectileLifetime = 4;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _projectile_rigidbody = this.GetComponent<Rigidbody2D>();
        _lifeRemaining = projectileLifetime;

    }

    // Update is called once per frame
    void Update()
    {

        float range = Vector2.Distance (this.transform.position, target.position);
        //projectile moves towards player if in certain range. Once it touches the player it is destroyed.
        if (range <= 15f) {
            _projectile_rigidbody.AddForce(new Vector2(target.position.x-this.transform.position.x, target.position.y-this.transform.position.y));

        }

        _lifeRemaining -= Time.deltaTime;
        if (_lifeRemaining <= 0) {
            Destroy(gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Email")) {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        } else if (other.gameObject.CompareTag("PlayerDamager")) {
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}