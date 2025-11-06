using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        // Quando o jogador se move (WASD ou analógico)
        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Player.Move.canceled += ctx => Move(Vector2.zero);

        // Quando o jogador clica ou faz ação da mão esquerda
        controls.Player.LeftHandAction.performed += ctx => LeftAction();

        // Quando o jogador clica ou faz ação da mão direita
        controls.Player.RightHandAction.performed += ctx => RightAction();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Move(Vector2 direction)
    {
        Debug.Log("Movimento: " + direction);
        // Aqui podes mover o jogador, por exemplo:
        // transform.Translate(new Vector3(direction.x, 0, direction.y) * Time.deltaTime * speed);
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
