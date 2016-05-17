using UnityEngine;
using System.Collections;

public class GlobalManager : MonoBehaviour {

    private static GlobalManager _globalManager;
    private static InputManager _inputManager;

    void Awake() {
        if (_globalManager != null && _globalManager != this) {
            Destroy(this.gameObject);
        }
        else {
            _globalManager = this;
        }
    }

    void Start () {
        _inputManager = GameObject.FindObjectOfType<InputManager>();
    }
	
	public static InputManager Input() {
        return _inputManager;
    }
}
