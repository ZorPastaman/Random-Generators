// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.UniformDistributions
{
	/// <summary>
	/// Provides <see cref="SharpGenerator"/> with the default seed.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.SharpContinuousDistributionFolder + "Sharp Generator Simple Provider",
		fileName = "Sharp Generator Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class SharpGeneratorSimpleProvider : ContinuousGeneratorProvider
	{
		private SharpGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="SharpGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new SharpGenerator();
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
			get => new SharpGenerator();
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

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
