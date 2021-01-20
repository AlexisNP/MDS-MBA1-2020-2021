using System;
using UnityEngine;

public class MoveBall : MonoBehaviour {

    public float Speed = 3;
    float ShapeRecoverRate = 0.05f;

    public Rigidbody2D rb;
    public GameObject particleSystemPrefab; 

    DateTime _nextChangeTime = DateTime.Now;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (_nextChangeTime < DateTime.Now) {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        rb.rotation = Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.y, rb.velocity.x);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, ShapeRecoverRate);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player")) {
            GetComponent<SpriteRenderer>().color = Color.red;
            _nextChangeTime = DateTime.Now.AddMilliseconds(150);
            transform.localScale = new Vector3(1.1f, 0.7f, 1f);
            OnPlayerHit(col.contacts[0].point);
        }
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "Goal R") {
            Destroy(gameObject);
        }

        if (target.gameObject.tag == "Goal L") {
            Destroy(gameObject);
        }
    }

    private void OnPlayerHit(Vector3 position) {

    }
}