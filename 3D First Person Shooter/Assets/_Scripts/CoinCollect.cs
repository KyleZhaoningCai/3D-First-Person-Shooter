/* Source File Name: CoinCollect.cs
 * Author's Name: Zhaoning Cai
 * Last Modified on: Nov 18, 2015
 * Program Description: First Person Shooter Game. Player destroys a berrel to win
 * the level. The player can earn points by collecting coins and killing aliens.
 * Revision History: Final Version
 */
using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++
    private AudioSource pickUp;
    private Renderer _renderer;
    private BoxCollider boxCollider;

    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++
    public GameController gameController;

	// Use this for initialization
	void Start () {
        // Reference objects
        this.pickUp = gameObject.GetComponent<AudioSource>();
        this._renderer = gameObject.GetComponent<Renderer>();
        this.boxCollider = gameObject.GetComponent<BoxCollider>();

	}
	
	// Update is called once per frame
	
    void OnTriggerEnter(Collider other)
    {
        // Coin is destroyed and 100 is added to player's score
        this.gameController.AddScore(100);
        this.pickUp.Play();
        this._renderer.enabled = false;
        this.boxCollider.enabled = false;
        Destroy(gameObject, 1);

    }
}
