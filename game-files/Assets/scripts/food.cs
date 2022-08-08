using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public RareFood RareFood;
    public int randomNumber;

    private void Start()
    {
        RandomizedPosition();
    }

    private void RandomizedPosition()
    {
        randomNumber = Random.Range(0, 100);
        // RareFood.RandomizedPosition(randomNumber);
        Debug.Log(randomNumber);
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(x, y, 0.0f);

    }




    private void OnTriggerEnter2D(Collider2D other)
    {

        // RandomizedPosition();
        if (other.tag == "Player")
        {

            RandomizedPosition();

            RareFood.RandomizedPosition(randomNumber);

            // RareFood.RandomizedNumber();

        }

    }
}
