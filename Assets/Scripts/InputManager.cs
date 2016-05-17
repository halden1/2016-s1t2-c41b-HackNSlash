using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private static InputManager _inputManager;

    // Gameplay Variables
    [SerializeField]
    private Vector3 _LSDir;
    [SerializeField]
    private Vector3 _RSDir;

    // Unity InputManager Raws
    private float LStickX;       //inputAxisX;
    private float LStickY;       //inputAxisY;
    private float RStickX;       //inputAxis4;
    private float RStickY;       //inputAxis5;
    private float DPadX;         //inputAxis6;
    private float DPadY;         //inputAxis7;
    private float L2;            //inputAxis9;
    private float R2;            //inputAxis10;
    
    private bool XButton;        //joystick button 0;
    private bool OButton;        //joystick button 1;
    private bool SqrButton;      //joystick button 2;
    private bool TriButton;      //joystick button 3;
    private bool L1;             //joystick button 4;
    private bool R1;             //joystick button 5;
    private bool SelectButton;   //joystick button 6;
    private bool StartButton;    //joystick button 7;
    private bool L3;             //joystick button 8;
    private bool R3;             //joystick button 9;

    private bool mouseButton0;   //mouse button 0
    private bool mouseButton1;   //mouse button 1
    private bool mouseButton2;   //mouse button 2

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
        getAxis();
        getButton();
        getMouse();
        updateScript();
    }

    #region UnityToScript

    /// <summary>
    /// Get Axis data of the joysick
    /// </summary>
    void getAxis() {
        LStickX = Input.GetAxisRaw("LStickX");
        LStickY = Input.GetAxisRaw("LStickY");
        RStickX = Input.GetAxisRaw("RStickX");
        RStickY = Input.GetAxisRaw("RStickY");
        DPadX = Input.GetAxisRaw("DPadX");
        DPadY = Input.GetAxisRaw("DPadY");
        L2 = Input.GetAxisRaw("L2");
        R2 = Input.GetAxisRaw("R2");
    }

    /// <summary>
    /// get the button data of the joystick
    /// </summary>
    void getButton() {
        XButton = Input.GetButton("X Button");
        OButton = Input.GetButton("O Button");
        SqrButton = Input.GetButton("Sqr Button");
        TriButton = Input.GetButton("Tri Button");
        L1 = Input.GetButton("L1");
        R1 = Input.GetButton("R1");
        SelectButton = Input.GetButton("Select");
        StartButton = Input.GetButton("Start");
        L3 = Input.GetButton("L3");
        R3 = Input.GetButton("R3");
    }

    /// <summary>
    /// get the mouse data of the mouse
    /// </summary>
    void getMouse() {
        mouseButton0 = Input.GetMouseButton(0);
        mouseButton1 = Input.GetMouseButton(1);
        mouseButton2 = Input.GetMouseButton(2);
    }
    #endregion

    private void updateScript() {
        _LSDir.x = LStickX;
        _LSDir.z = LStickY;
        _LSDir.Normalize();
        _RSDir.x = RStickX;
        _RSDir.z = RStickY;
        _RSDir.Normalize();
    }

    public Vector3 LSDir {
        get{
            return _LSDir;
        }
    }
}
