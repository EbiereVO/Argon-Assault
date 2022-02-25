using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject HitVfx;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard;
    Rigidbody rb;
    GameObject parentgameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentgameObject = GameObject.FindWithTag("Spawn");
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(HitVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = parentgameObject.transform;

        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentgameObject.transform;
        Destroy(gameObject);
    }
}
