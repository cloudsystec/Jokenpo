using UnityEngine;

namespace Assets.Scripts
{
    public class ComputerBehavior : BaseBehavior
    {
        public void PlaySelectHand()
        {
            StartCoroutine(PlayHands(GetComputerHand()));
        }

        void Update()
        {
            if (niceToPlay)
                PlaySelectHand();
        }
    }
}
