// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Generator Provider",
		fileName = "Box-Muller Generator Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class BoxMullerGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private BoxMullerGenerator m_BoxMullerGenerator;
#pragma warning disable CS0649

		/// <summary>
		/// Creates a new <see cref="BoxMullerGenerator"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BoxMullerGenerator(m_BoxMullerGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_BoxMullerGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="BoxMullerGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public BoxMullerGenerator boxMullerGenerator
		{
			[Pure]
			get => new BoxMullerGenerator(m_BoxMullerGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="BoxMullerGenerator"/>.
		/// </summary>
		[NotNull]
		public BoxMullerGenerator sharedBoxMullerGenerator
		{
			[Pure]
			get => m_BoxMullerGenerator;
		}
	}
}
