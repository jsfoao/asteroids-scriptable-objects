using System;
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

        

        public void UpdateHealthText()
        {
            _healthText.text = $"Health: {health.Value}";
        }

        private void Start()
        {
            UpdateHealthText();
        }
    }
}
