﻿// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="LCG64GeneratorRanged"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LCG64DistributionFolder + "LCG64 Generator Ranged Provider",
		fileName = "LCG64GeneratorRangedProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class LCG64GeneratorRangedProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private float m_Min = LCG64Defaults.DefaultMin;
		[SerializeField] private float m_Max = LCG64Defaults.DefaultMax;
		[SerializeField] private uint m_InitialState;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private LCG64GeneratorRanged m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="LCG64GeneratorRanged"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => lcg64Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="LCG64GeneratorRanged"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => sharedLCG64Generator;
		}

		/// <summary>
		/// Creates a new <see cref="LCG64GeneratorRanged"/> and returns it.
		/// </summary>
		[NotNull]
		public LCG64GeneratorRanged lcg64Generator
		{
			[Pure]
			get => m_DefaultConstructor
				? new LCG64GeneratorRanged(m_Min, m_Max)
				: new LCG64GeneratorRanged(m_InitialState, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="LCG64GeneratorRanged"/>.
		/// </summary>
		[NotNull]
		public LCG64GeneratorRanged sharedLCG64Generator => m_sharedGenerator ??= lcg64Generator;

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			set
			{
				if (m_Min == value)
				{
					return;
				}

				m_Min = value;
				m_sharedGenerator = null;
			}
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			set
			{
				if (m_Max == value)
				{
					return;
				}

				m_Max = value;
				m_sharedGenerator = null;
			}
		}

		public uint initialState
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_InitialState;
			set
			{
				if (m_InitialState == value)
				{
					return;
				}

				m_InitialState = value;
				m_sharedGenerator = null;
			}
		}

		/// <summary>
		/// If it's true, the default constructor is used. It doesn't use <see cref="initialState"/>.
		/// </summary>
		public bool defaultConstructor
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DefaultConstructor;
			set
			{
				if (m_DefaultConstructor == value)
				{
					return;
				}

				m_DefaultConstructor = value;
				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
