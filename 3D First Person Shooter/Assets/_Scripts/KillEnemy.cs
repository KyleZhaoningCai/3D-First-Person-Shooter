/* Source File Name: KillEnemy.cs
 * Author's Name: Zhaoning Cai
 * Last Modified on: Nov 18, 2015
 * Program Description: First Person Shooter Game. Player destroys a berrel to win
 * the level. The player can earn points by collecting coins and killing aliens.
 * Revision History: Final Version
 */
using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES ++++++++++++++++++++++++++++++
    public GameController gameController;
    public GameObject enemyExplosion;

    // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++
    private Transform _transform;
    private AudioSource die;



    // Use this for initialization
    void Start () {
        // Reference objects
        this._transform = gameObject.GetComponent<Transform>();
        this.die = gameObject.GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider other)
    {
        // If colliding with the player, reduce player's lives by 1 and play die sound
        if (other.gameObject.CompareTag("Player"))
        {
            gameController.SubstractLives(1);
            this.die.Play();
        }
    }
}
