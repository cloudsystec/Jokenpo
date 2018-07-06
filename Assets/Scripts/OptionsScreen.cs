using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class OptionsScreen : MonoBehaviour
    {
        public Toggle SpockLizzardOpt;

        void Start()
        {
            SpockLizzardOpt.isOn = GameHelper.SpockLizzardVersion;
        }
    }
}
