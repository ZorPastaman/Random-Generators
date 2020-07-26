// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="MarsagliaGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Generator Provider",
		fileName = "Marsaglia Generator Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class MarsagliaGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private MarsagliaGenerator m_MarsagliaGenerator;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="MarsagliaGenerator"/> and returns it
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new MarsagliaGenerator(m_MarsagliaGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="MarsagliaGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			[Pure]
			get => m_MarsagliaGenerator;
		}

		/// <summary>
		/// Creates a new <see cref="MarsagliaGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public MarsagliaGenerator marsagliaGenerator
		{
			[Pure]
			get => new MarsagliaGenerator(m_MarsagliaGenerator);
		}

		/// <summary>
		/// Returns a shared <see cref="MarsagliaGenerator"/>.
		/// </summary>
		[NotNull]
		public MarsagliaGenerator sharedMarsagliaGenerator
		{
			[Pure]
			get => m_MarsagliaGenerator;
		}
	}
}
