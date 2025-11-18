using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("VR Input Actions")]
    [Tooltip("Ação de movimento (por exemplo, joystick esquerdo).")]
    public InputActionReference moveAction;

    [Tooltip("Ação da mão esquerda (por exemplo, botão de agarrar ou trigger).")]
    public InputActionReference leftHandAction;

    [Tooltip("Ação da mão direita (por exemplo, botão de agarrar ou trigger).")]
    public InputActionReference rightHandAction;

    [Header("Configurações de movimento")]
    public float moveSpeed = 1.5f;
    public Transform playerBody;

    void Update()
    {
        // Leitura do movimento (joystick esquerdo)
        if (moveAction != null && moveAction.action != null)
        {
            Vector2 moveValue = moveAction.action.ReadValue<Vector2>();
            Move(moveValue);
        }

        // Leitura da ação da mão esquerda
        if (leftHandAction != null && leftHandAction.action != null)
        {
            float leftValue = leftHandAction.action.ReadValue<float>();
            if (leftValue > 0.1f)
                LeftAction();
        }

        // Leitura da ação da mão direita
        if (rightHandAction != null && rightHandAction.action != null)
        {
            float rightValue = rightHandAction.action.ReadValue<float>();
            if (rightValue > 0.1f)
                RightAction();
        }
    }

    void Move(Vector2 direction)
    {
        if (playerBody == null) return;

        // Move o jogador na direção do headset
        Vector3 forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 right = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        Vector3 move = (forward * direction.y + right * direction.x) * moveSpeed * Time.deltaTime;
        playerBody.Translate(move, Space.World);

        if (direction.magnitude > 0.1f)
            Debug.Log("Movimento: " + direction);
    }

    void LeftAction()
    {
        Debug.Log("🖐️ Ação da mão esquerda!");
    }

    void RightAction()
    {
        Debug.Log("✊ Ação da mão direita!");
    }
}
