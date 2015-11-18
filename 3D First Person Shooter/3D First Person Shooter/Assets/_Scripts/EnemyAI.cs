using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float patrolSpeed = 3f;

    private Transform _transform;
    public Vector3 pointB;
    private Vector3 pointA;

    IEnumerator Start()
    {
        this._transform = gameObject.GetComponent<Transform>();
        pointA = this._transform.position;
        

        while (true)
        {
            yield return StartCoroutine(Move(this._transform, pointA, pointB, patrolSpeed));
            yield return StartCoroutine(Move(this._transform, pointB, pointA, patrolSpeed));
        }
    }

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
