﻿using System.Text;
using TrailSimulation.Core;

namespace TrailSimulation.Game
{
    [RequiredMode(GameMode.RiverCrossing)]
    public sealed class FerryHelpState : DialogState<RiverCrossInfo>
    {
        /// <summary>
        ///     This constructor will be used by the other one
        /// </summary>
        public FerryHelpState(IModeProduct gameMode) : base(gameMode)
        {
        }

        /// <summary>
        ///     Fired when dialog prompt is attached to active game mode and would like to have a string returned.
        /// </summary>
        protected override string OnDialogPrompt()
        {
            var _prompt = new StringBuilder();
            _prompt.AppendLine("To use a ferry means to put");
            _prompt.AppendLine("your wagon on top of a flat");
            _prompt.AppendLine("boat that belongs to someone");
            _prompt.AppendLine("else. The owner of the");
            _prompt.AppendLine("ferry will take your wagon");
            _prompt.AppendLine("across the river.");
            return _prompt.ToString();
        }

        /// <summary>
        ///     Fired when the dialog receives favorable input and determines a response based on this. From this method it is
        ///     common to attach another state, or remove the current state based on the response.
        /// </summary>
        /// <param name="reponse">The response the dialog parsed from simulation input buffer.</param>
        protected override void OnDialogResponse(DialogResponse reponse)
        {
            //parentGameMode.CurrentState = null;
            RemoveState();
        }
    }
}