using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        ghost.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        // Ничего не делай, пока призрак напуган
        if (node != null && enabled && !ghost.frightened.enabled)
        {
            // Выбери произвольное доступное направление
            int index = Random.Range(0, node.availableDirections.Count);

            // Предпочитаю не возвращаться в том же направлении, поэтому увеличь индекс до
            // следующего доступного направления
            if (node.availableDirections.Count > 1 && node.availableDirections[index] == -ghost.movement.direction)
            {
                index++;

                // Оберни индекс обратно, если он переполнен
                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            ghost.movement.SetDirection(node.availableDirections[index]);
        }
    }

}
