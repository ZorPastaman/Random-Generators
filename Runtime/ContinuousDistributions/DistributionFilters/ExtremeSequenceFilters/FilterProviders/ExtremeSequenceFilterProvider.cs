// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="ExtremeSequenceFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ExtremeSequenceContinuousFiltersFolder + "Extreme Sequence Filter Provider",
		fileName = "Extreme Sequence Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class ExtremeSequenceFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ExtremeSequenceFilter m_ExtremeSequenceFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="ExtremeSequenceFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new ExtremeSequenceFilter(m_ExtremeSequenceFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeSequenceFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_ExtremeSequenceFilter;
		}

		/// <summary>
		/// Creates a new <see cref="ExtremeSequenceFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public ExtremeSequenceFilter extremeSequenceFilter
		{
			[Pure]
			get => new ExtremeSequenceFilter(m_ExtremeSequenceFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="ExtremeSequenceFilter"/>.
		/// </summary>
		[NotNull]
		public ExtremeSequenceFilter sharedExtremeSequenceFilter
		{
			[Pure]
			get => m_ExtremeSequenceFilter;
		}
	}
}
