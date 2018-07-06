using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets.Scripts
{
    public class UIBehavior : MonoBehaviour
    {
        public void GoToScreen(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ChangeVersion(bool spockLizzard)
        {
            if (spockLizzard)
                GameHelper.Version = 1.2m;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
