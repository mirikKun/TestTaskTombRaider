namespace DefaultNamespace.InteractableObjects
{
    public class Destination:InteractableObject
    {
        public override void Interact(Player player)
        {
            player.InvokeVictory();
        }
    }
}