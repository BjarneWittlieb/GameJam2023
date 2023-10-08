using UnityEngine;
using UnityEngine.SceneManagement;
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
            SceneManager.LoadScene("Bjarne Scene", LoadSceneMode.Single);
        }
    }
}