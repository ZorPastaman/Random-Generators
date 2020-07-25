// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using JetBrains.Annotations;

namespace Zor.RandomGenerators.ContinuousDistributions.NormalDistributions
{
	/// <summary>
	/// Irwin-Hall Generator using <see cref="IrwinHallDistribution.Generate{T}(T,float,byte)"/>.
	/// </summary>
	public sealed class IrwinHallRandomGeneratorRandomGeneratorDependent<T> : IIrwinHallRandomGenerator
		where T : IContinuousRandomGenerator
	{
		[NotNull] private T m_dependedRandomGenerator;
		private float m_startPoint;
		private byte m_iids;

		/// <summary>
		/// Creates an <see cref="IrwinHallRandomGeneratorRandomGeneratorDependent{T}"/> with the specified parameters.
		/// </summary>
		/// <param name="dependedRandomGenerator">
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </param>
		/// <param name="iids">How many independent and identically distributed random variables are generated.</param>
		public IrwinHallRandomGeneratorRandomGeneratorDependent([NotNull] T dependedRandomGenerator, float startPoint,
			byte iids = IrwinHallDistribution.DefaultIids)
		{
			m_dependedRandomGenerator = dependedRandomGenerator;
			m_startPoint = startPoint;
			m_iids = iids;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public IrwinHallRandomGeneratorRandomGeneratorDependent(
			[NotNull] IrwinHallRandomGeneratorRandomGeneratorDependent<T> other)
		{
			m_dependedRandomGenerator = other.m_dependedRandomGenerator;
			m_startPoint = other.m_startPoint;
			m_iids = other.m_iids;
		}

		/// <summary>
		/// Random generator that returns independent and identically distributed random variable in range [0, 1].
		/// </summary>
		[NotNull]
		public T dependedRandomGenerator
		{
			[Pure]
			get => m_dependedRandomGenerator;
			set => m_dependedRandomGenerator = value;
		}

		public float startPoint
		{
			[Pure]
			get => m_startPoint;
			set => m_startPoint = value;
		}

		/// <inheritdoc/>
		public byte iids
		{
			[Pure]
			get => m_iids;
			set => m_iids = value;
		}

		/// <inheritdoc/>
		[Pure]
		public float Generate()
		{
			return IrwinHallDistribution.Generate(m_dependedRandomGenerator, m_startPoint, m_iids);
		}
	}
}
