using Archer;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{ 
        public class Ui : MonoBehaviour
        {
                [SerializeField] private Text scoreText;
                [SerializeField] private GameObject endGamePanel;
                [SerializeField] private Text deathCounterText;
                [SerializeField] private ArcherHealth archerHealth;

                private void ChangeText(int count)
                {
                        deathCounterText.text = "Killed: " + count.ToString();
                }

                private void Start()
                {
                        DeathCounter.OnAddDeath += ChangeText;
                        endGamePanel.SetActive(false);
                        archerHealth.OnDead += ShowEndGame;
                }

                private void ShowEndGame()
                {
                        endGamePanel.SetActive(true);
                        deathCounterText.gameObject.SetActive(false);
                        scoreText.text = deathCounterText.text;
                }

                private void OnDestroy()
                {
                        DeathCounter.OnAddDeath -= ChangeText; 
                }
        }
}