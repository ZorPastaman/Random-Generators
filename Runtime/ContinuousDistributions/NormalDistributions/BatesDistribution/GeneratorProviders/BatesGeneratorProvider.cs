// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BatesGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BatesDistributionFolder + "Bates Generator Provider",
		fileName = "Bates Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BatesGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private BatesGenerator m_BatesGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="BatesGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BatesGenerator(m_BatesGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_BatesGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="BatesGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BatesGenerator batesGenerator
		{
			[Pure]
			get => new BatesGenerator(m_BatesGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BatesGenerator"/>.
		/// </summary>
		[NotNull]
		public BatesGenerator sharedBatesGenerator
		{
			[Pure]
			get => m_BatesGenerator;
		}
	}
}
