/* Source File Name: PlayerShooting.cs
 * Author's Name: Zhaoning Cai
 * Last Modified on: Nov 18, 2015
 * Program Description: First Person Shooter Game. Player destroys a berrel to win
 * the level. The player can earn points by collecting coins and killing aliens.
 * Revision History: Final Version
 */
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class PlayerShooting : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES - Exposed on the Inspector +++++++++++++++++++++
    public ParticleSystem muzzleFlash;
    public GameObject impact;
    public Animator gunAnimator;
    public AudioSource bulletFireSound;
    public AudioSource bulletImpactSound;
    public GameObject explosion;
    public GameObject enemyExplosion;
    public GameController gameController;

    // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++++++++++
    private GameObject[] _impacts;
    private int currentImpact = 0;
    private int maxImpacts = 5;
    private Transform _transform;
    private GameObject[] enemies;

    private bool _shooting = false;

    // Use this for initialization
    void Start () {

        // Reference to the gameObject's transform component
        this._transform = gameObject.GetComponent<Transform>();

        // Object pool for impacts
        this._impacts = new GameObject[this.maxImpacts];
        for(int impactCount = 0; impactCount < this.maxImpacts; impactCount++)
        {
            this._impacts[impactCount] = (GameObject) Instantiate(this.impact);
        }
        	
	}
	
	// Update is called once per frame
	void Update () {

        // Play muzzle flash and shoot impact when left-mouse button is pressed;
	    if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            this._shooting = true;
            this.muzzleFlash.Play();
            this.bulletFireSound.Play();
            this.gunAnimator.SetTrigger("Fire");
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            this._shooting = false;
        }
	}

    // Physics effects
    void FixedUpdate ()
    {
        if (this._shooting)
        {
            this._shooting = false;

            RaycastHit hit;
            if (Physics.Raycast(this._transform.position, this._transform.forward, out hit, 50f))
            {
                // Destroying barrel will grant player the victory
                if (hit.transform.CompareTag("Barrels"))
                {
                    Destroy(hit.transform.gameObject);
                    Instantiate(this.explosion, hit.point, Quaternion.identity);
                    enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        Destroy(enemies[i].gameObject);
                    }
                    gameController.gameOverLabel.text = "You've WON!";
                }
                // Destroy enemies to earn 300 points
                if (hit.transform.CompareTag("Enemy"))
                {
                    Destroy(hit.transform.gameObject);
                    Instantiate(this.explosion, hit.point, Quaternion.identity);
                    gameController.AddScore(300);
                }
                // Move impact particle system to location of ray hit
                this._impacts[this.currentImpact].transform.position = hit.point;
                // Play the particle effect (impact)
                this._impacts[this.currentImpact].GetComponent<ParticleSystem>().Play();
                // Play impact sound
                this.bulletImpactSound.Play();

                if (++this.currentImpact >= this.maxImpacts)
                {
                    this.currentImpact = 0;
                }
            }
        }
    }
}
