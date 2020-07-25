// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="MarsagliaRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Random Generator Random Generator Depended Simple Provider",
		fileName = "Marsaglia Random Generator Random Generator Depended Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class MarsagliaRandomGeneratorRandomGeneratorDependentSimpleProvider : ContinuousRandomGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousRandomGeneratorProviderReference m_DependedRandomGenerator;
#pragma warning restore CS0649

		private MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			m_sharedRandomGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="MarsagliaRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// and returns it as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator randomGenerator
		{
			[Pure]
			get =>
				new MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
					m_DependedRandomGenerator.randomGenerator);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="MarsagliaRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// as <see cref="IContinuousRandomGenerator"/>.
		/// </summary>
		public override IContinuousRandomGenerator sharedRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = marsagliaRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}

		/// <summary>
		/// Creates a new
		/// <see cref="MarsagliaRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			marsagliaRandomGenerator
		{
			[Pure]
			get =>
				new MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>(
					m_DependedRandomGenerator.randomGenerator);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="MarsagliaRandomGeneratorRandomGeneratorDependentSimple{IContinuousRandomGenerator}"/>.
		/// </summary>
		[NotNull]
		public MarsagliaRandomGeneratorRandomGeneratorDependentSimple<IContinuousRandomGenerator>
			sharedMarsagliaRandomGenerator
		{
			get
			{
				if (m_sharedRandomGenerator == null)
				{
					m_sharedRandomGenerator = marsagliaRandomGenerator;
				}

				return m_sharedRandomGenerator;
			}
		}
	}
}
