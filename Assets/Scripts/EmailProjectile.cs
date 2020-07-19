using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailProjectile : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float projectileDelay = 2f;
    private Rigidbody2D _projectile_rigidbody;
    public GameObject projectile;
    private bool moving = false;

    public AudioClip damageClip;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _projectile_rigidbody = this.GetComponent<Rigidbody2D>();
        Instantiate(projectile, this.transform.position, Quaternion.identity);
        InvokeRepeating("createProjectile",0.5f,projectileDelay);
         
    }

    void createProjectile() {
        Instantiate(projectile, this.transform.position, Quaternion.identity);
    }
    
    // Update is called once per frame
    void Update() {
        GameObject current = GameObject.FindGameObjectWithTag("Projectile");
        if (current == null) {
            Instantiate(projectile, this.transform.position, Quaternion.identity);
        }
    }
}
