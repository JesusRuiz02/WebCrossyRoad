using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMnager : MonoBehaviour
{
    [SerializeField] private GameObject _canvasGameOver = default;

    public void ActivateCanvas()
    {
        _canvasGameOver.SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
