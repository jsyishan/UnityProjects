using UnityEngine;
using System.Collections;


public class CharacterMotion : MonoBehaviour {

    //基本动作相关属性定义
    [SerializeField]private float m_MaxSpeed = 10f;
    [SerializeField]private float m_JumpForce = 400f;
    [SerializeField]private LayerMask m_WhatIsGround;

    //其他属性/控件
    private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;
    private bool m_Grounded;
    private bool m_Spelling;

    private Transform m_CeilingCheck;
    const float k_CeilingRadius = .1f;

    private Animator m_Anim;
   // private AnimationState m_AnimState;
    private Rigidbody2D m_Rigidbody;
    private bool m_FacingRight = true;


    void Awake() {
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
       // m_AnimState = a
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        m_Grounded = false;
        m_Spelling = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position,k_GroundedRadius,m_WhatIsGround);
        for(int i = 0;i < colliders.Length;i++) {
            if(colliders[i].gameObject != gameObject) {
                m_Grounded = true;
            }
        }
        m_Anim.SetBool("Ground",m_Grounded);

        m_Anim.SetFloat("vSpeed",m_Rigidbody.velocity.y);
    }

    
    public void Spell(bool spell) {
        if(spell && !m_Anim.GetBool("Spell") ) {
            m_Anim.SetBool("Spell",true);
        }
        else if(!spell && m_Anim.GetBool("Spell")) {
            m_Anim.SetBool("Spell",false);
        }
    }
    

    public void Move(float move,bool jump) {
        
            m_Anim.SetFloat("Speed",Mathf.Abs(move));
            m_Rigidbody.velocity = new Vector2(move * m_MaxSpeed,m_Rigidbody.velocity.y);

            if(move > 0 && !m_FacingRight) {
                Flip();
            }

            else if(move < 0 && m_FacingRight) {
                Flip();
            }

        if(jump && m_Grounded && m_Anim.GetBool("Ground")) {
            m_Grounded = false;
            m_Anim.SetBool("Ground",false);
            m_Rigidbody.AddForce(new Vector2(0f,m_JumpForce));
        }

    }

    private void Flip() {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float getMaxSpeed() {
        return m_MaxSpeed;
    }
}
