using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public static KeyCode firstSkillCode = KeyCode.E;
    public static KeyCode secondSkillCode = KeyCode.LeftShift;
    public static KeyCode thirdSkillCode = KeyCode.F;

    public static float GetAxis(string _command) {
        if(_command == "Horizontal") {
            return Input.GetAxis(_command);
        }
        if (_command == "Vertical") {
            return Input.GetAxis(_command);
        }
        if (_command == "Mouse X") {
            return Input.GetAxis(_command);
        }
        if (_command == "Mouse Y") {
            return Input.GetAxis(_command);
        }

        return 0;
    }

    public static bool GetButtonDown(string _command) {
        if (_command == "Jump") {
            return Input.GetButtonDown(_command);
        }
        return false;
    }

    public static bool GetKey(string _command) {
        if (_command == "firstskill") {
            if (Input.GetKey(firstSkillCode)) {
                return true;
            }
            else {
                return false;
            }
        }
        if (_command == "secondskill") {
            if (Input.GetKey(secondSkillCode)) {
                return true;
            }
            else {
                return false;
            }
        }
        if (_command == "thirdskill") {
            if (Input.GetKey(thirdSkillCode)) {
                return true;
            }
            else {
                return false;
            }
        }
        return false;
    }

    public static bool GetKeyUp(string _command) {
        if(_command == "ESC") {
            return Input.GetKeyUp(KeyCode.Escape);
        }
        return false;
    }

    public static bool GetMouseButton(string _command) {
        if (_command == "left") {
            return Input.GetMouseButton(0);
        }
        if (_command == "right")
        {
            return Input.GetMouseButton(1);
        }
        return false;
    }

    public static bool GetMouseButtonUp(string _command) {
        if(_command == "left") {
            return Input.GetMouseButtonUp(0);
        }
        if (_command == "right")
        {
            return Input.GetMouseButtonUp(1);
        }
        return false;
    }


}
