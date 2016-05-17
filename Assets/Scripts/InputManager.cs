using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private static InputManager _inputManager;
    
    private float horizontal;
    private float vertical;

    public static InputManager Instance {
        get {
            return _inputManager;
        }
    }

    void Awake() {
        if (_inputManager != null && _inputManager != this) {
            Destroy(this.gameObject);
        }
        else {
            _inputManager = this;
        }
    }

    void Update() {

        //Raw Stick Direction
        Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
    }
}
