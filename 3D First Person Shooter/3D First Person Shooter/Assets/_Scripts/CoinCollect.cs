using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour {

    private AudioSource pickUp;
    private Renderer _renderer;
    private BoxCollider boxCollider;

    public GameController gameController;

	// Use this for initialization
	void Start () {
        this.pickUp = gameObject.GetComponent<AudioSource>();
        this._renderer = gameObject.GetComponent<Renderer>();
        this.boxCollider = gameObject.GetComponent<BoxCollider>();

	}
	
	// Update is called once per frame
	
    void OnTriggerEnter(Collider other)
    {
        this.gameController.AddScore(100);
        this.pickUp.Play();
        this._renderer.enabled = false;
        this.boxCollider.enabled = false;
        Destroy(gameObject, 1);

    }
}
