namespace DefaultNamespace.InteractableObjects
{
    public class DeathZone:InteractableObject
    {
        public override void Interact(Player player)
        {
            player.InvokeDeath();
        }
    }
}