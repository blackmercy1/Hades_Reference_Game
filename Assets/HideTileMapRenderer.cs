using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapRenderer))]
public class HideTileMapRenderer : MonoBehaviour
{
    private void Awake()
    {
        var tileMapRenderer = GetComponent<TilemapRenderer>();
        tileMapRenderer.enabled = false;
    }
}
