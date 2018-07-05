using System.Collections.Generic;
using System.Linq;
using Boo.Lang;

namespace Assets.Scripts
{
    public static class GameHelper
    {
        public enum Jokenpo
        {
            ROCK,
            PAPER,
            SCISSOR
        }

        public static string Version = "V1";

        private static readonly Dictionary<Jokenpo, IEnumerable<Jokenpo>> WinRules = new Dictionary<Jokenpo, IEnumerable<Jokenpo>>
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
