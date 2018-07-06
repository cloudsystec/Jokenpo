using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public static class GameHelper
    {
        public enum Jokenpo
        {
            NONE,
            ROCK,
            PAPER,
            SCISSOR
        }

        public static decimal Version = 1;
        public static bool SpockLizzardVersion { get { return Version > 1; } }

        public static int CurrentHand = 0;
        public static int P1Hand = 0;
        public static int P2Hand = 0;

        public static void ClearGame()
        {
            P1Hand = 0;
            P2Hand = 0;
            CurrentHand = 0;
        }

        public static Dictionary<Jokenpo, GameObject> Hands = new Dictionary<Jokenpo, GameObject>();

        public static readonly Dictionary<Jokenpo, IEnumerable<Jokenpo>> WinRules = new Dictionary<Jokenpo, IEnumerable<Jokenpo>>
        {
            {Jokenpo.PAPER, new []{Jokenpo.ROCK, }},
            {Jokenpo.ROCK, new []{Jokenpo.SCISSOR, }},
            {Jokenpo.SCISSOR, new []{Jokenpo.PAPER, }}
        };

        /// <summary>
        /// ask p1 win p2
        /// </summary>
        /// <param name="p1">Player one</param>
        /// <param name="p2">Player Two</param>
        /// <returns>true if p1 wins, false if p2 wins, null if match draw</returns>
        public static bool? Winner(Jokenpo p1, Jokenpo p2)
        {
            if (WinRules[p1].Any(x => x == p2)) return true;
            if (WinRules[p2].Any(x => x == p1)) return false;
            return null;
        }
    }
}
