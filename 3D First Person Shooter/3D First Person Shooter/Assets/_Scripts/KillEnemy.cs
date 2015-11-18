using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

    public GameController gameController;
    public GameObject enemyExplosion;

    private Transform _transform;
    //private Renderer _renderer;
    //private CapsuleCollider capsuleCollider;


    // Use this for initialization
    void Start () {
        //this._renderer = gameObject.GetComponentInChildren<Renderer>();
        //this.capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        this._transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameController.SubstractLives(1);
            //this._renderer.enabled = false;
            //this.capsuleCollider.enabled = false;
            
        }
    }
}
