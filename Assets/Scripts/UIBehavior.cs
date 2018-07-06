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
        public GameObject prefabLogo;
        public GameObject prefabLogoFaded;

        public Sprite logo_v1;
        public Sprite logo_v1_2;

        void Start()
        {
            ChangeVersionLogo();
        }

        public void ChangeVersionLogo()
        {
            var logo = logo_v1;
            if (GameHelper.Version == 1.2m) logo = logo_v1_2;
            if (prefabLogo != null)
            {
                var prefLogo = prefabLogo.GetComponent(typeof(Image)) as Image;
                prefLogo.sprite = logo;
            }

            if (prefabLogoFaded != null)
            {
                var prefFadLogo = prefabLogoFaded.GetComponent(typeof(Image)) as Image;
                prefFadLogo.sprite = logo;
            }

            var findLogo = GameObject.Find("icon_master");
            if (findLogo != null)
                (findLogo.GetComponent(typeof(Image)) as Image).sprite = logo;

            var findLogoFad = GameObject.Find("icon_masterfaded");
            if (findLogoFad != null)
                (findLogoFad.GetComponent(typeof(Image)) as Image).sprite = logo;

        }

        public void GoToScreen(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ToggleVersionToSpockLizzard(Toggle _this)
        {
            if (!_this.isOn) GameHelper.V1();
            else GameHelper.V1_2();

            ChangeVersionLogo();
        }

        private void V1()
        {
            GameHelper.V1();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
