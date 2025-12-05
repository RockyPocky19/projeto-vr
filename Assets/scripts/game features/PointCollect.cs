using UnityEngine;

public class PointCollect : MonoBehaviour
{
    public int pontos = 1;           // quanto vale este objeto
    public string targetTag = "Player"; // quem precisa tocar (tag do outro objeto)

    private void OnTriggerEnter(Collider other)
    {
        // só reage se foi o objeto certo (por tag)
        if (!other.CompareTag(targetTag))
            return;

        // Aumenta pontos (ajusta para o teu sistema de score)
        ScoreManager.Instance.AddScore(pontos);

        // Destroi este objeto
        Destroy(gameObject);
    }
}
