using UnityEngine;
using System.Collections;
//using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (CharacterMotion))]

public class CharacterControl : MonoBehaviour {

    private CharacterMotion m_Character;
    private bool m_Jump;
    private bool m_Spell;
    private PlayerInput pi;

	void Awake() {
        m_Character = GetComponent<CharacterMotion>();
        pi = GetComponent<PlayerInput>();
    }
	
	
	void Update () {
	    if(!m_Jump) {
            //  m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            m_Jump = pi.isJumping();
        }

        if(!m_Spell) {
            m_Spell = pi.isSpelling();
        }
	}

    void FixedUpdate() {
        // float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float h = pi.getMove();
        m_Character.Move(h,m_Jump);
       // m_Character.Spell(m_Spell);
        m_Jump = false;
    }
}
