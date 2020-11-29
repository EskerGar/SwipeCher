using UnityEngine;
using UnityEngine.UI;

namespace UI
{ 
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Text bestScoreText;

        private void Start()
        {
            bestScoreText.text = "Best Score: " +  DeathCounter.GetCounter().ToString();
        }
    }
}
