using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton Pattern
    public static GameManager GMInstance { get; private set; }

    private void Awake()
    {
        if(GMInstance != null && GMInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GMInstance = this;
        }
    }
    #endregion

    //Gets the scene with the current name and reloads it
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
