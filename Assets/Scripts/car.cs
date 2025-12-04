using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float limitX = 3f; // الحد اللي العربية ما تطلعش برّه

    void Update()
    {
        var keyboard = UnityEngine.InputSystem.Keyboard.current;
        if (keyboard == null) return;

        float moveInput = 0f;

        if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            moveInput = -1f;
        else if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
            moveInput = 1f;

        // حركة يمين وشمال فقط
        Vector3 newPos = transform.position + Vector3.right * moveInput * moveSpeed * Time.deltaTime;

        // نحدد الحدود عشان ما تخرجش برّه الطريق
        newPos.x = Mathf.Clamp(newPos.x, -limitX, limitX);

        transform.position = newPos;
    }
}
