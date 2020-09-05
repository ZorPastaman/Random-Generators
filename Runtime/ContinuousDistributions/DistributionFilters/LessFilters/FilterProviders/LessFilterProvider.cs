// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionFilters
{
	/// <summary>
	/// Provides <see cref="LessFilter"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.LessContinuousFiltersFolder + "Less Filter Provider",
		fileName = "Less Filter Provider",
		order = CreateAssetMenuConstants.FilterOrder
	)]
	public sealed class LessFilterProvider : ContinuousFilterProvider
	{
#pragma warning disable CS0649
		[SerializeField] private LessFilter m_LessFilter;
#pragma warning restore CS0649

		/// <summary>
		/// Creates a new <see cref="LessFilter"/> and returns it as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter filter
		{
			[Pure]
			get => new LessFilter(m_LessFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="LessFilter"/> as <see cref="IContinuousFilter"/>.
		/// </summary>
		public override IContinuousFilter sharedFilter
		{
			[Pure]
			get => m_LessFilter;
		}

		/// <summary>
		/// Creates a new <see cref="LessFilter"/> and returns it.
		/// </summary>
		[NotNull]
		public LessFilter lessFilter
		{
			[Pure]
			get => new LessFilter(m_LessFilter);
		}

		/// <summary>
		/// Returns a shared <see cref="LessFilter"/>.
		/// </summary>
		[NotNull]
		public LessFilter sharedLessFilter
		{
			[Pure]
			get => m_LessFilter;
		}
	}
}
