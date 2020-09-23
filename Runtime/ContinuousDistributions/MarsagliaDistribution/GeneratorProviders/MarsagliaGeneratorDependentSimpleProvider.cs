// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="MarsagliaGeneratorDependentSimple{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.MarsagliaDistributionFolder + "Marsaglia Generator Depended Simple Provider",
		fileName = "Marsaglia Generator Depended Simple Provider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class MarsagliaGeneratorDependentSimpleProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
#pragma warning restore CS0649

		private MarsagliaGeneratorDependentSimple<IContinuousGenerator> m_sharedGenerator;

		/// <summary>
		/// Creates a new
		/// <see cref="MarsagliaGeneratorDependentSimple{T}"/>
		/// and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new MarsagliaGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="MarsagliaGeneratorDependentSimple{T}"/>
		/// as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = marsagliaGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new
		/// <see cref="MarsagliaGeneratorDependentSimple{T}"/>
		/// and returns it.
		/// </summary>
		[NotNull]
		public MarsagliaGeneratorDependentSimple<IContinuousGenerator> marsagliaGenerator
		{
			[Pure]
			get => new MarsagliaGeneratorDependentSimple<IContinuousGenerator>(
				m_DependedGeneratorProvider.generator);
		}

		/// <summary>
		/// Returns a shared
		/// <see cref="MarsagliaGeneratorDependentSimple{T}"/>.
		/// </summary>
		[NotNull]
		public MarsagliaGeneratorDependentSimple<IContinuousGenerator> sharedMarsagliaGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = marsagliaGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public ContinuousGeneratorProviderReference dependedGeneratorProvider
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_DependedGeneratorProvider;
			set
			{
				if (m_DependedGeneratorProvider == value)
				{
					return;
				}

				m_DependedGeneratorProvider = value;
				m_sharedGenerator = null;
			}
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
