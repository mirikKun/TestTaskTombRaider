using UnityEngine;

[SelectionBase]
public class InteractableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            Interact(player);
        }
    }

    public virtual void Interact(Player player)
    {
        Debug.Log($"{player} touched {gameObject.name}");
    }
}
