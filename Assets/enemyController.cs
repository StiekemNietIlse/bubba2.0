using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    public float Speed = 1f;
    private Rigidbody2D _body;
    private int Startpoint;
    public int Endpoint;

    float fMinX = 0.54f;
    float fMaxX = 1.88f;
    int Direction = -1;
    float fEnemyX = 0;
    float fEnemyY = 0;

    

    // Use this for initialization
    void Start () {
        _body = GetComponent<Rigidbody2D>();
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");

        }
        if (other.gameObject.tag == "Floor")
        {
            Debug.Log("ground!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        fEnemyX = _body.position.x;
        fEnemyY = _body.position.y;

        switch (Direction)
        {
            case -1:
                // Moving Left
                if (fEnemyX > fMinX)
                {
                    fEnemyX -= 1.0f;
                }
                else
                {
                    // Hit left boundary, change direction
                    Direction = 1;
                }
                break;

            case 1:
                // Moving Right
                if (fEnemyX < fMaxX)
                {
                    fEnemyX += 1.0f;
                }
                else
                {
                    // Hit right boundary, change direction
                    Direction = -1;
                }
                break;
        }

        _body.transform.localPosition = new Vector3(fEnemyX, fEnemyY, 0.0f);

    }

    public void FixedUpdate()
    {
       

       


    }
}
