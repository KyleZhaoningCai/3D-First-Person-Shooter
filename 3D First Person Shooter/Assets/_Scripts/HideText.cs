/* Source File Name: HideText.cs
 * Author's Name: Zhaoning Cai
 * Last Modified on: Nov 18, 2015
 * Program Description: First Person Shooter Game. Player destroys a berrel to win
 * the level. The player can earn points by collecting coins and killing aliens.
 * Revision History: Final Version
 */
using UnityEngine;
using System.Collections;

public class HideText : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES
    public GameController gameController;
	
    // Hide Game Over Text Upon Triggered
    void OnTriggerEnter(Collider other)
    {
        gameController.gameOverLabel.text = "";
    }
}
