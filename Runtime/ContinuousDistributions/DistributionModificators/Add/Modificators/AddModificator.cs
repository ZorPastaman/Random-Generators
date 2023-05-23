// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.DistributionModificators
{
	/// <summary>
	/// Add modificator for <see cref="IContinuousGenerator"/>.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class AddModificator<T> : IAddModificator where T : IContinuousGenerator
	{
		[NotNull] private T m_dependedGenerator;
		private float m_item;

		/// <summary>
		/// Creates <see cref="AddModificator{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedGenerator"></param>
		/// <param name="item"></param>
		public AddModificator([NotNull] T dependedGenerator, float item)
		{
			m_dependedGenerator = dependedGenerator;
			m_item = item;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="other"></param>
		public AddModificator([NotNull] AddModificator<T> other)
		{
			m_dependedGenerator = other.m_dependedGenerator;
			m_item = other.m_item;
		}

		[NotNull]
		public T dependedGenerator
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_dependedGenerator;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_dependedGenerator = value;
		}

		public float item
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_item;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_item = value;
		}

		/// <inheritdoc/>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public float Generate()
		{
			return m_dependedGenerator.Generate() + m_item;
		}
	}
}
