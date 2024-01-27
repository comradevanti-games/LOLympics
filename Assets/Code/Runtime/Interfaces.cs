﻿#nullable enable

using System;
using Dev.ComradeVanti.GGJ24.Player;
using UnityEngine;

namespace Dev.ComradeVanti.GGJ24
{
    /// <summary>
    /// Synonymous to "level". Contains information about the props and the
    /// crowd.
    /// </summary>
    public interface IAct
    {
        /// <summary>
        /// The state of the stage that is the default for this act.
        /// </summary>
        public Stage InitialStage { get; }
    }

    /// <summary>
    /// Contains data about a prop.
    /// </summary>
    public interface IProp
    {
        /// <summary>
        /// The props prefab.
        /// </summary>
        public GameObject Prefab { get; }
    }

    /// <summary>
    /// A person that is visiting an act. Has opinions about what they like.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Information about what type of humor this person likes.
        /// </summary>
        public HumorPreferences Preferences { get; }
    }

    /// <summary>
    /// The people that are visiting the act.
    /// </summary>
    public interface ICrowd
    {
    }

    public interface IPhaseKeeper
    {
        public record PhaseChangedArgs(PlayerPhase NewPhase);


        public event Action<PhaseChangedArgs>? PhaseChanged;
    }

    /// <summary>
    /// Keeps track of the current stage. Only tracks the stage on a
    /// data level. Game-objects of props are held by <see cref="ILiveStageKeeper"/>.
    /// </summary>
    public interface IStageKeeper
    {
        public record StageChangedArgs(Stage NewStage);


        public event Action<StageChangedArgs>? StageChanged;


        public Stage Stage { get; }
    }

    /// <summary>
    /// Manages the live (game-object) representation of the stage and props.
    /// </summary>
    public interface ILiveStageKeeper
    {
        /// <summary>
        /// Attempts to find the world position of a slot index. Null if
        /// the slot index is out of bounds.
        /// </summary>
        public Vector3? TryGetPositionForSlot(int slotIndex);
    }

    /// <summary>
    /// Responsible for instantiating props. This is a singleton.
    /// </summary>
    public interface IPropBuilder
    {
        public GameObject BuildProp(IProp prop, int slotIndex);
    }

    /// <summary>
    /// Keeps information about what act the player is on.
    /// </summary>
    public interface IActKeeper
    {
        public record ActChangedArgs(IAct Act);


        public event Action<ActChangedArgs>? ActChanged;
    }

    /// <summary>
    /// Contains functions for querying and interacting with the crowd.
    /// </summary>
    public interface ILiveCrowdKeeper
    {
    }
}