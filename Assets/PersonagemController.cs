using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PersonagemController : MonoBehaviour
{
    public GameObject groundCheck;
    public Rigidbody2D rb2d; 
    public float vel;
    public float jumpForce;
    public TMP_Text pontuacao;
    private int points = 0;
    public bool isRunning;
    private Animator animator;
    public void AddToPoints(int x)
  
    {
        points += x;
        pontuacao.text = "Pontuação: " + points.ToString();
    }
    // Start is called before the first frame update
    private GroundCheck groundCheckScript;    

    void Start()
    {   
        rb2d = this.GetComponent<Rigidbody2D>();
        groundCheckScript = groundCheck.GetComponent<GroundCheck>();
        pontuacao.text = "Pontuação: 0";
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(rb2d.velocity.magnitude < 5){
        rb2d.velocity += new Vector2(vel,0) *moveHorizontal * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && groundCheckScript.isOnGround)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

        }
        else { 
            animator.SetBool("IsJumping", false);
        }
        if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        if (Input.GetAxis("Horizontal") == -1)
        {
            animator.SetBool("Backwards", true);
        }
        else {
            animator.SetBool("Backwards", false);
        }
        if(groundCheckScript.isOnGround == true)
        {
            animator.SetBool("Fall", true) ;
        }
        else
        {
            animator.SetBool("Fall", false);
        }
        if (rb2d.velocity.y > 0) {
            animator.SetBool("IsJumping", true);
        }
    }
}
