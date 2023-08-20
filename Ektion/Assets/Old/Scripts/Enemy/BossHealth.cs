public class BossHealth : Health
{
    public override void CheckDeath()
    {
        if (CurrentHealth <= 0)
        {
            UI.Instance.SpawnMenu(UI.Instance._menus[4]);
            Instantiate(DeathSound, transform.position, transform.rotation);
            AudioManager.Instance.AudioSource.clip = AudioManager.Instance.WinMusic;
            AudioManager.Instance.AudioSource.Play();
            Destroy(gameObject);
        }
    }
}
