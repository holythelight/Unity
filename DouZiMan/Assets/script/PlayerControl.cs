using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody2D heroBody;
    public float moveForce = 100;
    private float fInput = 0.1f;
    public float maxSpeed = 5;

    private bool bFaceRight = true;

    Transform mGroundCheck;

    public float jumpForce = 100f;
    private bool bJump = true;

    // Start is called before the first frame update

    void Start()
    {
        heroBody = this.GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("Groundcheck");
    }

    // Update is called once per frame
    void Update()
    {
        fInput = Input.GetAxis("Horizontal");

        // Vector2 vector2 = transform.position;
        //vector2.x = vector2.x +force*h*Time.deltaTime;
        //transform.position = vector2;
        // heroBody.MovePosition(vector2);
        if (fInput > 0 && !bFaceRight)
        {

            flip();
        }
        else if (fInput < 0 && bFaceRight)
        {

            flip();
        }
        //°´Î»ÔËËã
        Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(heroBody.velocity.x) < maxSpeed)
        {
            heroBody.AddForce(Vector2.right * fInput * moveForce);

        }
        if (Mathf.Abs(heroBody.velocity.x) > maxSpeed)
        {
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * maxSpeed, heroBody.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && (Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"))))
        {

            if (bJump)
            {
                heroBody.AddForce(new Vector2(0f, jumpForce));
                bJump = false;
            }
            bJump = true;

        }


    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
}
