﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using UnityEngine;

namespace Dev.ComradeVanti.GGJ24
{
    [CreateAssetMenu(menuName = "GGJ24/Act", fileName = "New Act")]
    public class ActAsset : ScriptableObject, IAct
    {
        [SerializeField] private PropAsset?[] initialProps =
            new PropAsset?[Stage.SlotsPerStage];

        [SerializeField] private Crowd crowd = null!;


        private IEnumerable<IProp?> InitialProps => initialProps;

        public Stage InitialStage => new Stage(InitialProps.ToImmutableArray());

        public ICrowd Crowd => crowd;


        private void OnValidate()
        {
            if (initialProps.Length == Stage.SlotsPerStage) return;

            Debug.LogWarning($"Act must define exactly {Stage.SlotsPerStage} props!");
            Array.Resize(ref initialProps, Stage.SlotsPerStage);
        }
    }
}