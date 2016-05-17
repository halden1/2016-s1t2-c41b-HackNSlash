using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private static InputManager _inputManager;

    public static InputManager Instance {
        get {
            return _inputManager;
        }
    }
    
    void Awake() {
        if (_inputManager != null && _inputManager != this) {
            Destroy(this.gameObject);
        } else {
            _inputManager = this;
        }
    }
    
    void Update() {

    }
}
