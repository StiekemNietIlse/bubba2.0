using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour {

    public float Speed = 5f;
    public float JumpHeight = 0;
    //public float maxJumpHeight = 3f;
    public Joystick joystick;

    private Rigidbody2D _body;
    private Vector2 _inputs = Vector2.zero;
    private bool spaceKeyDown = false;

    [SerializeField]
    private bool isGrounded = false;
    
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        //_inputs.x = 0;
        //_inputs.y = 0;
        //if (joystick.Horizontal > 0f)
        //{
        //    _inputs.x = Speed;
        //}
        //if (joystick.Horizontal < 0f)
        //{
        //    _inputs.x = -Speed;
        //}  
    }

   public void JumpData()
    {
        if (isGrounded == true)
        {
            Debug.Log("Jump");
            _body.AddForce(Vector2.up * JumpHeight);
        }
    }

    //public void JumpRelease()
    //{
    //    JumpHeight = 0f;
    //}
    
    public void FixedUpdate()
    { 
        _body.velocity = new Vector2(joystick.Horizontal * Speed, _body.velocity.y);

        //_body.velocity = _inputs;
        //if (JumpHeight > 0) {
        //  //  transform.Translate(Vector2.up * JumpHeight * Time.smoothDeltaTime);

        //}
        // _body.AddForce(Vector3.up * JumpHeight);

        //GetComponent<Rigidbody2D>().AddForce(Vector2.up* 1 , ForceMode2D.Impulse);
        //transform.Translate(0, JumpHeight , 0 );
    }
}
