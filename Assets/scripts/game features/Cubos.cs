using UnityEngine;

public class Cubos : MonoBehaviour
{
    private float velocidade = 5f;
    private bool terminouZ = false;

    private void Update()
    {
        cube_movement();
    }
    private void cube_movement()
    {
        // Primeiro mover no Z
        if (!terminouZ)
        {
            transform.Translate(Vector3.up * velocidade * Time.deltaTime);

            // Quando chegar a certo ponto no Y
            if (transform.position.y >= 2.5f)
            {
                terminouZ = true;
            }
        }
        else
        {
            // Depois mover no Z
            transform.Translate(Vector3.back * velocidade * Time.deltaTime);
        }
    }
}
