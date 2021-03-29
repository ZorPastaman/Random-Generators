// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Provides <see cref="AddModificator{T}"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.ContinuousModificatorsFolder + "Add Modificator Provider",
		fileName = "AddModificatorProvider",
		order = CreateAssetMenuConstants.ModificatorOrder
		)]
	public sealed class AddModificatorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private ContinuousGeneratorProviderReference m_DependedGeneratorProvider;
		[SerializeField] private float m_Item = AddModificatorDefaults.DefaultItem;
#pragma warning restore CS0649

		private AddModificator<IContinuousGenerator> m_sharedModificator;

		/// <summary>
		/// Creates a new <see cref="AddModificator{T}"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => addModificator;
		}

		/// <summary>
		/// Returns a shared <see cref="AddModificator{T}"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator => sharedAddModificator;

		/// <summary>
		/// Creates a new <see cref="AddModificator{T}"/> and returns it.
		/// </summary>
		[NotNull]
		public AddModificator<IContinuousGenerator> addModificator
		{
			[Pure]
			get => new AddModificator<IContinuousGenerator>(m_DependedGeneratorProvider.generator, m_Item);
		}

		/// <summary>
		/// Returns a shared <see cref="AddModificator{T}"/>.
		/// </summary>
		[NotNull]
		public AddModificator<IContinuousGenerator> sharedAddModificator
		{
			get
			{
				if (m_sharedModificator == null)
				{
					m_sharedModificator = addModificator;
				}

				return m_sharedModificator;
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
				m_sharedModificator = null;
			}
		}

		public float item
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Item;
			set
			{
				if (m_Item == value)
				{
					return;
				}

				m_Item = value;
				m_sharedModificator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedModificator = null;
		}

		private void OnValidate()
		{
			m_sharedModificator = null;
		}
	}
}
