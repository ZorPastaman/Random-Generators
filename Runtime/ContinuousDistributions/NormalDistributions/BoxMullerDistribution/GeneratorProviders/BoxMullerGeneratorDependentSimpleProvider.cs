// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Provides <see cref="BoxMullerGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.BoxMullerDistributionFolder + "Box-Muller Generator Dependent Simple Provider",
		fileName = "Box-Muller Generator Dependent Simple Provider",
		order = CreateAssetMenuConstants.Order
	)]
	public sealed class BoxMullerGeneratorDependentSimpleProvider : ContinuousGeneratorProvider
	{
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;

		private BoxMullerGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="BoxMullerGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new BoxMullerGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="BoxMullerGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = boxMullerGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new
		/// <see cref="BoxMullerGeneratorDependentSimple{T}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public BoxMullerGeneratorDependentSimple<IContinuousGenerator> boxMullerGenerator
		{
			[Pure]
			get => new BoxMullerGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="BoxMullerGeneratorDependentSimple{T}"/>.
		/// </summary>
		[NotNull]
		public BoxMullerGeneratorDependentSimple<IContinuousGenerator> sharedBoxMullerGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = boxMullerGenerator;
				}

				return m_sharedGenerator;
			}
		}
	}
}
