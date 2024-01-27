﻿#nullable enable

using System;
using Dev.ComradeVanti.GGJ24.Player;
using UnityEngine;

namespace Dev.ComradeVanti.GGJ24
{
    public class PhaseKeeper : MonoBehaviour, IPhaseKeeper
    {
        public event Action<IPhaseKeeper.PhaseChangedArgs>? PhaseChanged;


        private PlayerPhase currentPhase = PlayerPhase.Idle;


        private bool CanDoSwitch(PlayerPhase from, PlayerPhase to)
        {
            return true;
        }

        public void TrySwitchPhase(PlayerPhase nextPhase)
        {
            if (!CanDoSwitch(currentPhase, nextPhase)) return;

            currentPhase = nextPhase;
            PhaseChanged?.Invoke(new IPhaseKeeper.PhaseChangedArgs(currentPhase));
        }

        private void OnActChanged(IActKeeper.ActChangedArgs _)
        {
            TrySwitchPhase(PlayerPhase.PropSelection);
        }

        private void Awake()
        {
            Singletons.Require<IActKeeper>().ActChanged += OnActChanged;
        }
    }
}