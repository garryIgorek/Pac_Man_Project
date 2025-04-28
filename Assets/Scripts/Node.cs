using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public readonly List<Vector2> availableDirections = new();

    private void Start()
    {
        availableDirections.Clear();

        // Определяем, доступно ли направление с помощью приведения в соответствие, чтобы увидеть, доступно ли
        // мы уперлись в стену. Направление будет добавлено в список, если оно доступно.
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0f, direction, 1f, obstacleLayer);

        // Если коллайдер не задет, то в этом направлении нет никаких препятствий
        if (hit.collider == null)
        {
            availableDirections.Add(direction);
        }
    }

}
