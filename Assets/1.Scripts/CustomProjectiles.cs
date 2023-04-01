using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomProjectiles : MonoBehaviour
{
    public bool activated;

    [Header("Componenets")]
    public Rigidbody rb;
    public GameObject explosion;

    [Header("Set the basic stats:")]
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    [Header("Lifetime:")]
    public int maxCollisions;
    public float maxLifetime;

    private int collisions;

    private PhysicMaterial physic_mat;
    public bool alreadyExploded;

    /// Call the setup functions
    void Start()
    {
        Setup();
    }

    void Update()
    {
        if (!activated) return;

        if (collisions >= maxCollisions && activated) Explode();

        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0 && activated) Explode();
    }

    ///Just to set the basic variables of the bullet/projectile
    private void Setup()
    {
        //Setup physics material
        physic_mat = new PhysicMaterial();
        physic_mat.bounciness = bounciness;
        physic_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physic_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Apply the physics material to the collider
        GetComponent<SphereCollider>().material = physic_mat;

        rb.useGravity = useGravity;
    }

    public void Explode()
    {
        //Bug fixing
        if (alreadyExploded) return;
        alreadyExploded = true;

        Debug.Log("Explode");

        //Instantiate explosion if attatched
        if (explosion != null)
            Instantiate(explosion, transform.position, Quaternion.identity);

        //Invoke destruction
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<TrailRenderer>().emitting = false;
        Invoke("Delay", 0.08f);

    }
    private void Delay()
    {
        Destroy(gameObject);
    }

}
