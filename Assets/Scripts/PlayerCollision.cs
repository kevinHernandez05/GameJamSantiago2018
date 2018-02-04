using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public GameObject player;

    public Transform start;

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            player.transform.position = new Vector2(start.position.x, start.position.y );
        }
    }

}
