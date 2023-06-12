// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.RandomGenerators.RandomEngines;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="IntLCG64Generator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LCG64DiscreteDistributionFolder + "Int LCG64 Generator Provider",
		fileName = "IntLCG64GeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class IntLCG64GeneratorProvider : DiscreteGeneratorProvider<int>
	{
		[SerializeField] private int m_Min = LCG64Defaults.DefaultMin;
		[SerializeField] private int m_Max = LCG64Defaults.DefaultMax;
		[SerializeField] private uint m_InitialState;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private IntLCG64Generator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="IntLCG64Generator"/> and returns it as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => LCG64Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="IntLCG64Generator"/> as <see cref="IDiscreteGenerator{T}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator => sharedLCG64Generator;

		/// <summary>
		/// Creates a new <see cref="IntLCG64Generator"/> and returns it.
		/// </summary>
		[NotNull]
		public IntLCG64Generator LCG64Generator
		{
			[Pure]
			get => m_DefaultConstructor
				? new IntLCG64Generator(m_Min, m_Max)
				: new IntLCG64Generator(m_InitialState, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="IntLCG64Generator"/>.
		/// </summary>
		[NotNull]
		public IntLCG64Generator sharedLCG64Generator => m_sharedGenerator ??= LCG64Generator;

		/// <summary>
		/// Initial state of <see cref="LCG64"/>. Must be non-zero.
		/// </summary>
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

		public int min
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

		public int max
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
