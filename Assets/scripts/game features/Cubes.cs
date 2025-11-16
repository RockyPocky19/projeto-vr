using UnityEngine;

public class Cubes : MonoBehaviour
{
    private int cubeToSkip;   // Guarda o ID do cubo que NÃO vai ser instanciado
    public GameObject cubePrefab;


    private void Start()
    {
        SpawnCubes();
    }
    private int cube_choice()
    {
        cubeToSkip = Random.Range(1, 7);   // De 1 a 6
        Debug.Log("Cubo que NÃO será instanciado: " + cubeToSkip);
        return cubeToSkip;
    }
    private void SpawnCubes()
    {
        int cube_skipped = cube_choice();
        for (int i = 0; i < CubesPosClass.positions.Length; i++)
        {
            if (i == cube_skipped)
                continue; // pula o cubo escolhido

            Instantiate(cubePrefab, CubesPosClass.positions[i], Quaternion.identity);
        }
    }
}
