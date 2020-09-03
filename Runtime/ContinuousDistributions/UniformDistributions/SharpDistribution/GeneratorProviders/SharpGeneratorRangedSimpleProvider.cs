// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Provides <see cref="SharpGeneratorRanged"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SharpContinuousDistributionFolder +
			"Sharp Generator Ranged Simple Provider",
		fileName = "Sharp Generator Ranged Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class SharpGeneratorRangedSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min;
		[SerializeField] private float m_Max = 1f;
#pragma warning restore CS0649

		private SharpGeneratorRanged m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGeneratorRanged"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new SharpGeneratorRanged(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGeneratorRanged"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = sharpGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="SharpGeneratorRanged"/> and returns it.
		/// </summary>
		[NotNull]
		public SharpGeneratorRanged sharpGenerator
		{
			[Pure]
			get => new SharpGeneratorRanged(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGeneratorRanged"/>.
		/// </summary>
		[NotNull]
		public SharpGeneratorRanged sharedSharpGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = sharpGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public float min
		{
			[Pure]
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
			[Pure]
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
	}
}