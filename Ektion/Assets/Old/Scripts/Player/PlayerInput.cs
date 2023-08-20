using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float HorizontalInput;
    [HideInInspector] public float VerticalInput;

    private void Update()
    {
        HorizontalInput = Input.GetAxis(GlobalStrings.HorizontalInput);
        VerticalInput = Input.GetAxis(GlobalStrings.VerticalInput);
    }
}
