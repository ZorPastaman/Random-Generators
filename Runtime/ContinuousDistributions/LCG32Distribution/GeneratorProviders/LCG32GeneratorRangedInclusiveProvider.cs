// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="LCG32GeneratorRangedInclusive"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LCG32DistributionFolder + "LCG32 Generator Ranged Inclusive Provider",
		fileName = "LCG32GeneratorRangedInclusiveProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class LCG32GeneratorRangedInclusiveProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private float m_Min = LCG32Defaults.DefaultMin;
		[SerializeField] private float m_Max = LCG32Defaults.DefaultMax;
		[SerializeField] private uint m_InitialState;
		[SerializeField, Tooltip("If it's true, the default constructor is used. It doesn't use Initial State.")]
		private bool m_DefaultConstructor;

		private LCG32GeneratorRangedInclusive m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="LCG32GeneratorRangedInclusive"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			get => lcg32Generator;
		}

		/// <summary>
		/// Returns a shared <see cref="LCG32GeneratorRangedInclusive"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedLCG32Generator;

		/// <summary>
		/// Creates a new <see cref="LCG32GeneratorRangedInclusive"/> and returns it.
		/// </summary>
		public LCG32GeneratorRangedInclusive lcg32Generator
		{
			get => m_DefaultConstructor
				? new LCG32GeneratorRangedInclusive(m_Min, m_Max)
				: new LCG32GeneratorRangedInclusive(m_InitialState, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="LCG32GeneratorRangedInclusive"/>.
		/// </summary>
		public LCG32GeneratorRangedInclusive sharedLCG32Generator => m_sharedGenerator ??= lcg32Generator;

		public uint initialState
		{
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
