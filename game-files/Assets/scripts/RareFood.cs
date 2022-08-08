using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareFood : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public int randomNumber;

    private void Start()
    {
        gameObject.SetActive(false);
        // randomNumber = Random.Range(0, 100);
        // RandomizedPosition();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);

    }


    public void RandomizedPosition(int randomNumber)
    {
        // randomNumber = Random.Range(0, 100);
        if (randomNumber >= 69 && randomNumber <= 80)
        {
            Bounds bounds = this.gridArea.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            this.transform.position = new Vector3(x, y, 0.0f);
            gameObject.SetActive(true);
        }
        Debug.Log(randomNumber);

    }

    public void RandomizedNumber()
    {
        randomNumber = Random.Range(0, 100);
        Debug.Log(randomNumber);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        // RandomizedPosition();
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);


        }

    }
}
