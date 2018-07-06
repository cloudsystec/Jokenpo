using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets.Scripts
{
    public class BaseBehavior : UIBehavior
    {
        public Image P1Hand;
        public Image P2Hand;
        public GameObject WinLoseHolder;
        public GameObject RefreshButton;
        public GameObject Canvas;

        public Sprite WinImage;
        public Sprite LoseImage;
        public Sprite DrawImage;
        protected bool niceToPlay = true;
        protected Random rand = new Random();

        /// <summary>
        /// ROCK, PAPER, SCISSOR
        /// </summary>
        public List<GameObject> Hands;

        void Start()
        {
            //just to normalize the entrace
            foreach (var item in Hands)
            {
                GameHelper.Hands.Add(item.GetComponent<Hand>().Jokenpo, item);
            }

            ChangeVersionLogo();
        }
        
        protected GameHelper.Jokenpo GetComputerHand()
        {
            var randomNumber = GameHelper.WinRules.Count;
            var hand = rand.Next(0,randomNumber);

            return GameHelper.WinRules.Keys.ToList()[hand];
        }

        protected IEnumerator PlayHands(GameHelper.Jokenpo selectedHand)
        {
            niceToPlay = false;
            GameHelper.CurrentHand++;

            var computerHand = GetComputerHand();

            P1Hand.sprite = (GameHelper.Hands[selectedHand].GetComponent(typeof(Image)) as Image).sprite;
            P2Hand.sprite = (GameHelper.Hands[computerHand].GetComponent(typeof(Image)) as Image).sprite;

            P1Hand.GetComponent<Animator>().SetTrigger("ShowHand");
            yield return new WaitForSeconds(1);
            P2Hand.GetComponent<Animator>().SetTrigger("ShowHand");
            yield return new WaitForSeconds(2);

            var win = GameHelper.Winner(selectedHand,computerHand);
            SwitchHolder(win);

            if(win.HasValue)
                if (win.Value)
                    GameHelper.P1Hand++;
                else
                    GameHelper.P2Hand++;

            WinLoseHolder.SetActive(true);

            yield return new WaitForSeconds(2);

            WinLoseHolder.SetActive(false);
            P1Hand.GetComponent<Animator>().SetTrigger("ShowHand");
            P2Hand.GetComponent<Animator>().SetTrigger("ShowHand");

            if (GameHelper.P1Hand == 2 || GameHelper.P2Hand == 2)
                GameEnd();
            else
            {
                yield return new WaitForSeconds(1);
                niceToPlay = true;
            }

        }

        protected void GameEnd()
        {
            WinLoseHolder.SetActive(true);
            RefreshButton.SetActive(true);
            Canvas.SetActive(false);
            niceToPlay = false;

            GameHelper.ClearGame();
        }


        public void StartAgain()
        {
            //just for check again
            GameHelper.ClearGame();

            niceToPlay = true;
            WinLoseHolder.SetActive(false);
            RefreshButton.SetActive(false);
            Canvas.SetActive(true);
        }

        protected void SwitchHolder(bool? win)
        {
            var img = WinLoseHolder.GetComponent(typeof(Image)) as Image;
            img.sprite = win.HasValue ? win.Value ? WinImage : LoseImage : DrawImage;

            var text = WinLoseHolder.GetComponentsInChildren(typeof(Text));
            (text[1] as Text).text = win.HasValue ? win.Value ? "Win" : "Lose" : "Draw";
            (text[0] as Text).text = (text[1] as Text).text;
            (text[1] as Text).color = win.HasValue ? win.Value ? Color.green : Color.red : Color.yellow;
        }
        
    }
}
