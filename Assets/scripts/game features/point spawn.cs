using UnityEngine;

public class pointspawn : MonoBehaviour
{
    [Header("Configuração")]
    public GameObject randomMoverPrefab;
    public int quantidade = 1;

    void Start()
    {
        for (int i = 0; i < quantidade; i++)
        {
            // Instancia o prefab no centro do range
            GameObject obj = Instantiate(randomMoverPrefab);
            obj.transform.position = GetCenter();
            obj.name = randomMoverPrefab.name + "_" + i;
        }
    }

    Vector3 GetCenter()
    {
        float centerX = (PointsPosClass.minX + PointsPosClass.maxX) * 0.5f;
        float centerY = (PointsPosClass.minY + PointsPosClass.maxY) * 0.5f;
        float centerZ = (PointsPosClass.minZ + PointsPosClass.maxZ) * 0.5f;
        return new Vector3(centerX, centerY, centerZ);
    }
}
