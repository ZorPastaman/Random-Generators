// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="LCG64GeneratorInclusive"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LCG64DistributionFolder + "LCG64 Generator Inclusive Provider",
		fileName = "LCG64GeneratorInclusiveProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class LCG64GeneratorInclusiveProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private uint m_InitialState;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private LCG64GeneratorInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="LCG64GeneratorInclusive"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => lcg64Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="LCG64GeneratorInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => sharedLCG64Generator;
		}

		/// <summary>
		/// Creates a new <see cref="LCG64GeneratorInclusive"/> and returns it.
		/// </summary>
		[NotNull]
		public LCG64GeneratorInclusive lcg64Generator
		{
			[Pure]
			get => m_DefaultConstructor ? new LCG64GeneratorInclusive() : new LCG64GeneratorInclusive(m_InitialState);
		}

		/// <summary>
		/// Returns a shared <see cref="LCG64GeneratorInclusive"/>.
		/// </summary>
		[NotNull]
		public LCG64GeneratorInclusive sharedLCG64Generator => m_sharedGenerator ??= lcg64Generator;

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
