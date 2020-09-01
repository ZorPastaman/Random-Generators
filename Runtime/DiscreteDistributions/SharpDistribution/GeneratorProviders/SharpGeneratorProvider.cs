// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.DiscreteDistributions
{
	/// <summary>
	/// Provides <see cref="SharpGenerator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SharpDiscreteDistributionFolder + "Sharp Generator Provider",
		fileName = "Sharp Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class SharpGeneratorProvider : DiscreteGeneratorProvider<int>
	{
#pragma warning disable CS0649
		[SerializeField] private int m_Seed;
		[SerializeField] private int m_Min;
		[SerializeField] private int m_Max = 10;
#pragma warning restore CS0649

		private SharpGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> generator
		{
			[Pure]
			get => new SharpGenerator(m_Seed, m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGenerator"/> as <see cref="IDiscreteGenerator{Int32}"/>.
		/// </summary>
		public override IDiscreteGenerator<int> sharedGenerator
		{
			[Pure]
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
		/// Creates a new <see cref="SharpGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public SharpGenerator sharpGenerator
		{
			[Pure]
			get => new SharpGenerator(m_Seed, m_Min, m_Max);
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
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = sharpGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public int seed
		{
			[Pure]
			get => m_Seed;
			set
			{
				if (m_Seed == value)
				{
					return;
				}

				m_Seed = value;
				m_sharedGenerator = null;
			}
		}

		public int min
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

		public int max
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
