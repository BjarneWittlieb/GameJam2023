using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RestartHandler : MonoBehaviour
    {
        public Button restartButton;

        private void Start()
        {
            var btn = restartButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        private void TaskOnClick()
        {
            Debug.Log("You have clicked the button!");
            // SceneManager.LoadScene("MiCar Scene", LoadSceneMode.Single);
        }
    }
}