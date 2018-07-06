using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameScreen : MonoBehaviour
    {
        void Start()
        {
            ShowSpockLizzardHands(GameHelper.SpockLizzardVersion);
        }

        private void ShowSpockLizzardHands(bool active)
        {
            var spkHnd = GameObject.Find("SpockHand");
            var lzdHnd = GameObject.Find("LizzardHand");

            if (spkHnd == null || lzdHnd == null) return;

            spkHnd.SetActive(active);
            lzdHnd.SetActive(active);
        }
    }
}
