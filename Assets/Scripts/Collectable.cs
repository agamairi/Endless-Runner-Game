using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public bool once = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.addCoins();
                collisionParticleSystem.Play();
            }
            else
            {
                Debug.Log("Player is null");
                Destroy(this.gameObject);
            }
            Destroy(this.gameObject, 0.15f);
        }
    }
}
