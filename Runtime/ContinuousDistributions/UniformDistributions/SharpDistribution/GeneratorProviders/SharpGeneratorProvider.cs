// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Provides <see cref="SharpGenerator"/> with the specified seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SharpContinuousDistributionFolder + "Sharp Generator Provider",
		fileName = "Sharp Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class SharpGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private int m_Seed;
#pragma warning restore CS0649

		private SharpGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new SharpGenerator(m_Seed);
		}

		/// <summary>
		/// Returns a shared <see cref="SharpGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
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
			get => new SharpGenerator(m_Seed);
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
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
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

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
