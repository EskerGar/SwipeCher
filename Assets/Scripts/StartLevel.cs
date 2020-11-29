using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
        public void LoadLevel() => SceneManager.LoadScene("Game");
}