using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    private CharacterMotion cm;
    private float MaxSpeed;

    public bool isJumping() {
        if(Input.GetKeyDown(KeyCode.Space)) {
             return true;
        }
        else {
             return false;
        }
    }
    
    public bool isSpelling() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            return true;
        }
        else {
            return false;
        }
    }
    

    public float getMove() {
        float s = 0;
        if(Input.GetKey(KeyCode.D)) {
            s += MaxSpeed * Time.deltaTime;
            return s;
        }
       else if(Input.GetKey(KeyCode.A)) {
            s -= MaxSpeed * Time.deltaTime;
            return s;
        }
        else {
            return 0f;
        }
    }
	void Start () {
        cm = GetComponent<CharacterMotion>();
        MaxSpeed = cm.getMaxSpeed() * 5;
	}
	
}
