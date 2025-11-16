using UnityEngine;

public class cubessystem : MonoBehaviour
{
    public GameObject cubePrefab;
    private int cubeToSkip;   // Guarda o ID do cubo que NÃO vai ser instanciado

    private void Start()
    {
        game_started();
    }
    private void game_started()
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
        for (int i = 0; i < CubesPosClass.positions.Length; i++)
        {
            if (i == cubeToSkip)
                continue; // pula o cubo escolhido

            Instantiate(cubePrefab, CubesPosClass.positions[i], Quaternion.identity);
        }
    }



    private void cube_movement()
    {
        //para o movimento dos cubos
    }
}
