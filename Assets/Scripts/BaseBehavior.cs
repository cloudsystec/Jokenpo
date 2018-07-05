using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class BaseBehavior : MonoBehaviour {

        public void GoToScreen(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
