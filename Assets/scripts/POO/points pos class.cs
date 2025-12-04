using UnityEngine;

public static class PointsPosClass
{
    public static Vector3[] positions =
    {
        new Vector3(-8.5f,  8.37f, 21.74f),
        new Vector3( 8.5f,  8.37f, 21.74f),
        new Vector3( 8.5f, 16.95f, 21.74f),
        new Vector3(-8.5f, 16.95f, 21.74f)
    };

    // limites calculados a partir dos pontos
    public static readonly float minX = -8.5f;
    public static readonly float maxX = 8.5f;
    public static readonly float minY = 8.37f;
    public static readonly float maxY = 16.95f;
    public static readonly float minZ = 21.74f;
    public static readonly float maxZ = 21.74f;

    // opcional: centro e tamanho do bounds
    public static readonly Vector3 center = new Vector3(
        (minX + maxX) * 0.5f,
        (minY + maxY) * 0.5f,
        (minZ + maxZ) * 0.5f
    );

    public static readonly Vector3 size = new Vector3(
        maxX - minX,
        maxY - minY,
        maxZ - minZ
    );
}

