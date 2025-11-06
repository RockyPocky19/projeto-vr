using UnityEngine;
using Unity.XR.CoreUtils;

public class FollowHandsXR : MonoBehaviour
{
    [Header("Referências (XR Interaction Toolkit)")]
    public XROrigin xrOrigin;
    public Transform leftHandController;
    public Transform rightHandController;

    [Header("Configurações de seguimento")]
    public Vector3 offset = new Vector3(0, 0.2f, -0.6f);
    public float smoothSpeed = 5f;

    private Transform cameraOffset;

    void Start()
    {
        if (xrOrigin == null)
        {
            xrOrigin = FindObjectOfType<XROrigin>();
        }

        if (xrOrigin != null)
        {
            cameraOffset = xrOrigin.CameraFloorOffsetObject.transform;
        }
        else
        {
            Debug.LogWarning("?? XR Origin não encontrado. Arrasta o XR Origin manualmente para o campo no inspetor.");
        }
    }

    void LateUpdate()
    {
        if (leftHandController == null || rightHandController == null || cameraOffset == null)
            return;

        // Ponto médio entre as mãos
        Vector3 middlePoint = (leftHandController.position + rightHandController.position) / 2f;

        // Posição alvo com offset
        Vector3 targetPosition = middlePoint + offset;

        // Movimento suave do Camera Offset
        cameraOffset.position = Vector3.Lerp(cameraOffset.position, targetPosition, Time.deltaTime * smoothSpeed);

        // Faz o XR Origin olhar na direção média entre as mãos
        Vector3 lookDirection = (middlePoint - cameraOffset.position).normalized;
        if (lookDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            cameraOffset.rotation = Quaternion.Slerp(cameraOffset.rotation, targetRotation, Time.deltaTime * smoothSpeed);
        }
    }
}
