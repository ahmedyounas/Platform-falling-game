using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {
    [HideInInspector] public bool facingright = true;
  public bool jump = false;
    public float moveforce = 365f;
    public float maxspeed = 5f;
    public float jumpforce = 1000f;
    public Transform groundcheck;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundcheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
   void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs( h));
        if(h*rb2d.velocity.x<maxspeed)
        {
            rb2d.AddForce(Vector2.right * h * moveforce);

        }
        if (Mathf.Abs(rb2d.velocity.x) > maxspeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxspeed, rb2d.velocity.y);
        }
        if(h>0&&!facingright)
        {
            flip();
        }
        else if(h<0&&facingright)
        {
            flip();
        }
        if(jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpforce));
            jump = false;
        }
    }
    void flip()
    {
        facingright = !facingright;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;

    }
}
