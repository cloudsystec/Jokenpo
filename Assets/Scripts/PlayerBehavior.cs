using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerBehavior : BaseBehavior
    {
        public void PlayerSelectHand(GameObject _this)
        {
            if (!niceToPlay) return;

            var selectedHand = _this.GetComponent<Hand>().Jokenpo;
            StartCoroutine(PlayHands(selectedHand));
        }
    }
}
