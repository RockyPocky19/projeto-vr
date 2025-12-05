using UnityEngine;

public class Cubes : MonoBehaviour
{
    [Header("Configuração")]
    public GameObject cubePrefab;
    public float spawnInterval = 5f; // Intervalo entre spawns
    public float cubeLifetime = 3f; // Tempo de vida dos cubos (segundos)
    public bool gameActive = true;

    private int cubeToSkip;
    private float spawnTimer = 0f;

    private void Update()
    {
        if (!gameActive)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnCubes();
            spawnTimer = 0f;
        }
    }

    private int cube_choice()
    {
        cubeToSkip = Random.Range(1, 6);
        Debug.Log("Cubo que NÃO será instanciado: " + cubeToSkip);
        return cubeToSkip;
    }

    private void SpawnCubes()
    {
        int cube_skipped = cube_choice();
        for (int i = 0; i < CubesPosClass.positions.Length; i++)
        {
            if (i == cube_skipped)
                continue;

            // Instancia o cubo com tempo de vida
            GameObject cube = Instantiate(cubePrefab, CubesPosClass.positions[i], Quaternion.identity);

            // Adiciona script de tempo de vida (ou usa Destroy direto)
            Destroy(cube, cubeLifetime);
        }
    }

    public void StopSpawning()
    {
        gameActive = false;
    }
}
