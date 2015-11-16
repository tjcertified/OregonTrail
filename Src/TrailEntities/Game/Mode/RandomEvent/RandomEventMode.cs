﻿using TrailEntities.Entity;
using TrailEntities.Simulation;

namespace TrailEntities.Game
{
    /// <summary>
    ///     Attached by the event director when it wants to execute an event against the simulation. It will attach this mode,
    ///     which then hooks the event delegate it will trigger right after this class finishes initializing.
    /// </summary>
    public sealed class RandomEventMode : ModeProduct<RandomEventCommands, RandomEventInfo>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:TrailEntities.ModeProduct" /> class.
        /// </summary>
        public RandomEventMode()
        {
            // Event director has event to know when events are triggered.
            GameSimulationApp.Instance.EventDirector.OnEventTriggered += Director_OnEventTriggered;
        }

        /// <summary>
        ///     Defines the current game mode the inheriting class is going to take responsibility for when attached to the
        ///     simulation.
        /// </summary>
        public override GameMode GameMode
        {
            get { return GameMode.RandomEvent; }
        }

        /// <summary>
        ///     Fired when the event director triggers an event because it rolled the dice and hit it or it was forcefully
        ///     triggered by some method under a defined condition.
        /// </summary>
        private void Director_OnEventTriggered(IEntity simEntity, DirectorEvent directorEvent)
        {
            // Attached the random event state when we intercept an event it would like us to trigger.
            UserData.DirectorEvent = directorEvent;
            UserData.SourceEntity = simEntity;
            //CurrentState = new RandomEventState(this, eventInfo);
            SetState(typeof (RandomEventState));
        }

        /// <summary>
        ///     Fired when this game mode is removed from the list of available and ticked modes in the simulation.
        /// </summary>
        protected override void OnModeRemoved(GameMode gameMode)
        {
            base.OnModeRemoved(gameMode);

            // Event director has event for when he triggers events.
            if (GameSimulationApp.Instance.EventDirector != null)
                GameSimulationApp.Instance.EventDirector.OnEventTriggered -= Director_OnEventTriggered;
        }
    }
}