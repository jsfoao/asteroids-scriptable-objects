using TMPro;
using UnityEngine;
using Vars;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _laserText;
        
        [Header("Variable References")]
        [SerializeField] private IntVar health;
        [SerializeField] private IntVar score;
        [SerializeField] private IntVar lasers;
        
        
        public void UpdateHealthText()
        {
            _healthText.text = $"Health: {health.Value}";
        }
        
        public void UpdateScoreText()
        {
            _scoreText.text = $"Score: {score.Value}";
        }
        
        public void UpdateLasersText()
        {
            _laserText.text = $"Lasers Shot: {lasers.Value}";
        }

        private void Start()
        {
            UpdateHealthText();
            UpdateScoreText();
            UpdateLasersText();
        }
    }
}
