using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Principles.I
{
    class InterfaceSegretation
    {
        class PrincipleBroken
        {
            interface IGame
            {
                public void PlayEasyMode();
                public void PlayNormalMode();
                public void PlayHardMode();
            }

            class GodOfWar : IGame
            {
                public void PlayEasyMode()
                {
                    // jugar el papita
                }

                public void PlayHardMode()
                {
                    // bestia, esta dificil
                }

                public void PlayNormalMode()
                {
                    // el que todos juegan
                }
            }

            class PokemonFiredRed : IGame
            {
                public void PlayEasyMode()
                {
                    throw new Exception("Nelson no se puede");
                }

                public void PlayHardMode()
                {
                    throw new Exception("Nelson no se puede");
                }

                public void PlayNormalMode()
                {
                    // simona, vamo a juga
                }
            }
        }
        
        class PrincipleOk
        {
            interface IEasyGame
            {
                public void PlayEasyMode();
            }

            interface INormalGame
            {
                public void PlayNormalMode();
            }

            interface IHardGame
            {
                public void PlayHardMode();
            }

            class GodOfWar : IEasyGame, INormalGame, IHardGame
            {
                public void PlayEasyMode()
                {
                    // jugar el papita
                }

                public void PlayHardMode()
                {
                    // bestia, esta dificil
                }

                public void PlayNormalMode()
                {
                    // el que todos juegan
                }
            }

            class PokemonFiredRed : INormalGame
            {
                public void PlayNormalMode()
                {
                    // simona, vamo a juga
                }
            }
        }
    }
}
