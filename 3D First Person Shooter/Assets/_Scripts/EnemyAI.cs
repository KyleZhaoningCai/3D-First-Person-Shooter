/* Source File Name: EnemyAI.cs
 * Author's Name: Zhaoning Cai
 * Last Modified on: Nov 18, 2015
 * Program Description: First Person Shooter Game. Player destroys a berrel to win
 * the level. The player can earn points by collecting coins and killing aliens.
 * Revision History: Final Version
 */
using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++
    public float patrolSpeed = 3f;
    public Vector3 pointB;

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++++++++++++++
    private Transform _transform;
    private Vector3 pointA;

    // Following code is inspired by users from the Internet
    IEnumerator Start()
    {
        // Set current gameObject's position as PointA
        this._transform = gameObject.GetComponent<Transform>();
        pointA = this._transform.position;
        
        // An infinite loop that cause the alien to patrol between Point A and Point B
        while (true)
        {
            yield return StartCoroutine(Move(this._transform, pointA, pointB, patrolSpeed));
            yield return StartCoroutine(Move(this._transform, pointB, pointA, patrolSpeed));
        }
    }

    // Moves gameObject from one point to another in a certain speed
    IEnumerator Move(Transform currentTransform, Vector3 startingPosition, Vector3 endPosition, float time)
    {
        float i = 0f;
        float rate = 1f / time;
        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            currentTransform.position = Vector3.Lerp(startingPosition, endPosition, i);
            yield return null;
        }
    }

}
