// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="SharpGenerator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SharpDiscreteDistributionFolder + "Sharp Generator Simple Provider",
		fileName = "Sharp Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class SharpGeneratorSimpleProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private int m_Min;
		[SerializeField] private int m_Max;
#pragma warning restore CS0649

		private SharpGenerator m_sharedSharpGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new SharpGenerator(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGenerator"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
			get
			{
				if (m_sharedSharpGenerator == null)
				{
					m_sharedSharpGenerator = sharpGenerator;
				}

				return m_sharedSharpGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public SharpGenerator sharpGenerator
		{
			[Pure]
			get => new SharpGenerator(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGenerator"/>.
		/// </summary>
		[NotNull]
		public SharpGenerator sharedSharpGenerator
		{
			[Pure]
			get
			{
				if (m_sharedSharpGenerator == null)
				{
					m_sharedSharpGenerator = sharpGenerator;
				}

				return m_sharedSharpGenerator;
			}
		}
	}
}
