using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public float moveTime = 0.1f;

    public LayerMask blockingLayer;

    private float movementSpeed;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Use this for initialization
    void Start () {
        movementSpeed = 1f / moveTime;
	}

    protected bool Move(int xDir, int yDir, out RaycastHit2D hit) {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
    }
}
