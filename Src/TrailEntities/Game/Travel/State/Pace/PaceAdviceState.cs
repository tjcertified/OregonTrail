﻿using System;
using System.Text;
using TrailEntities.Simulation.Mode;

namespace TrailEntities.Game
{
    /// <summary>
    ///     Shows information about what the different pace settings mean in terms for the simulation and how they will affect
    ///     vehicle, party, and events.
    /// </summary>
    public sealed class PaceAdviceState : DialogState<TravelInfo>
    {
        /// <summary>
        ///     This constructor will be used by the other one
        /// </summary>
        public PaceAdviceState(IModeProduct gameMode, TravelInfo userData) : base(gameMode, userData)
        {
        }

        /// <summary>
        ///     Defines what type of dialog this will act like depending on this enumeration value. Up to implementation to define
        ///     desired behavior.
        /// </summary>
        protected override DialogType DialogType
        {
            get { return DialogType.Prompt; }
        }

        /// <summary>
        ///     Fired when dialog prompt is attached to active game mode and would like to have a string returned.
        /// </summary>
        protected override string OnDialogPrompt()
        {
            // Steady
            var _paceHelp = new StringBuilder();
            _paceHelp.Append($"{Environment.NewLine}steady - You travel about 8 hours a{Environment.NewLine}");
            _paceHelp.Append($"day, taking frequent rests. You take{Environment.NewLine}");
            _paceHelp.Append($"care not to get too tired.{Environment.NewLine}{Environment.NewLine}");

            // Strenuous
            _paceHelp.Append($"strenuous - You travel about 12 hours{Environment.NewLine}");
            _paceHelp.Append($"a day, starting just after sunrise{Environment.NewLine}");
            _paceHelp.Append($"and stopping shortly before sunset.{Environment.NewLine}");
            _paceHelp.Append($"You stop to rest only when necessary.{Environment.NewLine}");
            _paceHelp.Append($"You finish each day feeling very{Environment.NewLine}");
            _paceHelp.Append($"tired.{Environment.NewLine}{Environment.NewLine}");

            // Grueling
            _paceHelp.Append($"grueling - You travel about 16 hours{Environment.NewLine}");
            _paceHelp.Append($"a day, starting before sunrise and{Environment.NewLine}");
            _paceHelp.Append($"continuing until dark. You almost{Environment.NewLine}");
            _paceHelp.Append($"never stop to rest. You do not get{Environment.NewLine}");
            _paceHelp.Append($"enough sleep at night. You finish{Environment.NewLine}");
            _paceHelp.Append($"each day feeling absolutely{Environment.NewLine}");
            _paceHelp.Append($"exhausted, and your health suffers.{Environment.NewLine}{Environment.NewLine}");
            return _paceHelp.ToString();
        }

        /// <summary>
        ///     Fired when the dialog receives favorable input and determines a response based on this. From this method it is
        ///     common to attach another state, or remove the current state based on the response.
        /// </summary>
        /// <param name="reponse">The response the dialog parsed from simulation input buffer.</param>
        protected override void OnDialogResponse(DialogResponse reponse)
        {
            //ParentMode.CurrentState = new ChangePaceState(ParentMode, UserData);
            SetState(typeof(ChangePaceState));
        }
    }
}