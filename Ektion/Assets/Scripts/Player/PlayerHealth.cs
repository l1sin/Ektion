public class PlayerHealth : Health
{
    public override void CheckDeath()
    {
        if (CurrentHealth <= 0)
        {
            UI.Instance.SpawnMenu(UI.Instance._menus[3]);
            UI.Instance.CanUnpause = false;
            Instantiate(DeathSound, transform.position, transform.rotation);
            Destroy(gameObject);
        } 
    }
}
