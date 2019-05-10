using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hits = 15;
    
    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hits--;
        scoreBoard.Scorehit(scorePerHit);
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
