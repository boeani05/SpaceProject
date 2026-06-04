using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
