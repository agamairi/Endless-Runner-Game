using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float _speed = 5f;
    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Collectabke")
        {
            Destroy(other.gameObject);
        }
    }
}
