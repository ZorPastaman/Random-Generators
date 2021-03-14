// Copyright (c) 2020-2021 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Zor.RandomGenerators.ContinuousDistributions
{
	/// <summary>
	/// Provides <see cref="UnityGenerator"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = CreateAssetMenuConstants.UnityContinuousDistributionFolder + "Unity Generator Provider",
		fileName = "UnityGeneratorProvider",
		order = CreateAssetMenuConstants.DistributionOrder
	)]
	public sealed class UnityGeneratorProvider : ContinuousGeneratorProvider
	{
#pragma warning disable CS0649
		[SerializeField] private float m_Min = UnityGeneratorDefaults.DefaultMin;
		[SerializeField] private float m_Max = UnityGeneratorDefaults.DefaultMax;
#pragma warning restore CS0649

		[NonSerialized] private UnityGenerator m_sharedGenerator;

		/// <summary>
		/// Creates a new <see cref="UnityGenerator"/> and returns it as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator generator
		{
			[Pure]
			get => new UnityGenerator(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="UnityGenerator"/> as <see cref="IContinuousGenerator"/>.
		/// </summary>
		public override IContinuousGenerator sharedGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = unityGenerator;
				}

				return m_sharedGenerator;
			}
		}

		/// <summary>
		/// Creates a new <see cref="UnityGenerator"/> and returns it.
		/// </summary>
		[NotNull]
		public UnityGenerator unityGenerator
		{
			[Pure]
			get => new UnityGenerator(m_Min, m_Max);
		}

		/// <summary>
		/// Returns a shared <see cref="UnityGenerator"/>.
		/// </summary>
		[NotNull]
		public UnityGenerator sharedUnityGenerator
		{
			get
			{
				if (m_sharedGenerator == null)
				{
					m_sharedGenerator = unityGenerator;
				}

				return m_sharedGenerator;
			}
		}

		public float min
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Min;
			set
			{
				if (m_Min == value)
				{
					return;
				}

				m_Min = value;
				m_sharedGenerator = null;
			}
		}

		public float max
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_Max;
			set
			{
				if (m_Max == value)
				{
					return;
				}

				m_Max = value;
				m_sharedGenerator = null;
			}
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void DropSharedGenerator()
		{
			m_sharedGenerator = null;
		}

		private void OnValidate()
		{
			m_sharedGenerator = null;
		}
	}
}
