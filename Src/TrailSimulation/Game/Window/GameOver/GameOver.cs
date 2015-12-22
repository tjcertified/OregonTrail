﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameOver.cs" company="Ron 'Maxwolf' McDowell">
//   ron.mcdowell@gmail.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace TrailSimulation.Game
{
    using Core;

    /// <summary>
    ///     Represents all of the needed forms and dialogs to end the game and restart it without any problems. This window
    ///     will be able to deal with both the win and fail state and route to the correct system depending on ending.
    /// </summary>
    public sealed class GameOver : Window<GameOverCommands, GameOverInfo>
    {
        /// <summary>
        ///     Defines the current game Windows the inheriting class is going to take responsibility for when attached to the
        ///     simulation.
        /// </summary>
        public override GameWindow WindowCategory
        {
            get { return GameWindow.GameOver; }
        }

        /// <summary>
        ///     Called after the window has been added to list of modes and made active.
        /// </summary>
        public override void OnWindowPostCreate()
        {
            base.OnWindowPostCreate();


        }
    }
}