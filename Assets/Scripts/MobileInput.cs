using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static bool jumpPressed = false;

    public void onJumpPressed()
    {
        jumpPressed = true;
    }
}
