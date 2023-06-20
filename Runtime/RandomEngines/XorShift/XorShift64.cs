// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.RandomEngines
{
	/// <summary>
	/// Pseudo-random number engine using XorShift64 algorithm.
	/// </summary>
	public struct XorShift64
	{
		private ulong m_state;

		/// <summary>
		/// Creates a <see cref="XorShift64"/> with the specified initial state.
		/// </summary>
		/// <param name="state">Initial state. Must be non-zero.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public XorShift64(ulong state)
		{
			m_state = state;
		}

		/// <summary>
		/// Creates a <see cref="XorShift64"/> with the specified seed.
		/// </summary>
		/// <param name="seed">Seed. Used as initial state. Must be non-zero.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public XorShift64(long seed)
		{
			unchecked
			{
				m_state = (ulong)seed;
			}
		}

		/// <summary>
		/// Current state. Must be non-zero.
		/// </summary>
		public ulong state
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_state;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => m_state = value;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="bool"/> value.
		/// </summary>
		/// <returns>Generated <see cref="bool"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool NextBool()
		{
			NextState();
			return (m_state & 1UL) == 1UL;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="byte"/> value
		/// in range [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="byte"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte NextByte()
		{
			NextState();

			unchecked
			{
				return (byte)m_state;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="byte"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="byte"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte NextByte(byte max)
		{
			NextState();
			return (byte)(max * (m_state >> 32) >> 32);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="byte"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="byte"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte NextByte(byte min, byte max)
		{
			NextState();
			return (byte)((((ulong)max - min) * (m_state >> 32) >> 32) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="sbyte"/> value
		/// in range [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>).
		/// </summary>
		/// <returns>Generated <see cref="sbyte"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte NextSbyte()
		{
			NextState();

			unchecked
			{
				return (sbyte)m_state;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="sbyte"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="sbyte"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte NextSbyte(sbyte max)
		{
			NextState();
			return (sbyte)((ulong)max * (m_state >> 32) >> 32);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="sbyte"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="sbyte"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte NextSbyte(sbyte min, sbyte max)
		{
			NextState();
			return (sbyte)((int)((ulong)(max - min) * (m_state >> 32) >> 32) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="short"/> value
		/// in range [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="short"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short NextShort()
		{
			NextState();

			unchecked
			{
				return (short)m_state;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="short"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="short"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short NextShort(short max)
		{
			NextState();
			return (short)((ulong)max * (m_state >> 32) >> 32);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="short"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="short"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short NextShort(short min, short max)
		{
			NextState();
			return (short)((int)((ulong)(max - min) * (m_state >> 32) >> 32) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="ushort"/> value
		/// in range [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="ushort"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort NextUshort()
		{
			NextState();

			unchecked
			{
				return (ushort)m_state;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="ushort"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="ushort"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort NextUshort(ushort max)
		{
			NextState();
			return (ushort)(max * (m_state >> 32) >> 32);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="ushort"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="ushort"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort NextUshort(ushort min, ushort max)
		{
			NextState();
			return (ushort)((((ulong)max - min) * (m_state >> 32) >> 32) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="int"/> value
		/// in range [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="int"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt()
		{
			NextState();

			unchecked
			{
				return (int)m_state;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="int"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="int"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt(int max)
		{
			NextState();
			return (int)((ulong)max * (m_state >> 32) >> 32);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="int"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="int"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt(int min, int max)
		{
			NextState();
			return (int)((ulong)(max - min) * (m_state >> 32) >> 32) + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="uint"/> value
		/// in range [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="uint"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUint()
		{
			NextState();

			unchecked
			{
				return (uint)m_state;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="uint"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="uint"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUint(uint max)
		{
			NextState();
			return (uint)(max * (m_state >> 32) >> 32);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="uint"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="uint"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUint(uint min, uint max)
		{
			NextState();
			return (uint)((max - min) * (m_state >> 32) >> 32) + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="long"/> value
		/// in range (<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="long"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long NextLong()
		{
			NextState();

			unchecked
			{
				return (long)m_state ^ long.MinValue;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="long"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="long"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long NextLong(long max)
		{
			return (long)(max * NextDouble());
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="long"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="long"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long NextLong(long min, long max)
		{
			return (long)((max - min) * NextDouble()) + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="ulong"/> value
		/// in range [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>).
		/// </summary>
		/// <returns>Generated <see cref="ulong"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong NextUlong()
		{
			NextState();
			return ~m_state;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="ulong"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="ulong"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong NextUlong(ulong max)
		{
			return (ulong)(max * NextDouble());
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="ulong"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="ulong"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong NextUlong(ulong min, ulong max)
		{
			return (ulong)((max - min) * NextDouble()) + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="float"/> value in range [0, 1).
		/// </summary>
		/// <returns>Generated <see cref="float"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe float NextFloat()
		{
			// First 9 bits stand for sign and exponent. 0x3F800000u sets exponent for range [1, 2).
			uint answer = NextUint() >> 9 | 0x3F800000u;
			return *(float*)&answer - 1f;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="float"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="float"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloat(float max)
		{
			return max * NextFloat();
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="float"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="float"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloat(float min, float max)
		{
			return (max - min) * NextFloat() + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="float"/> value in range [0, 1].
		/// </summary>
		/// <returns>Generated <see cref="float"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloatInclusive()
		{
			return (float)NextUshort() / ushort.MaxValue;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="float"/> value in range [0, <paramref name="max"/>].
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="float"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloatInclusive(float max)
		{
			return max * NextFloatInclusive();
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="float"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>].
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="float"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float NextFloatInclusive(float min, float max)
		{
			return (max - min) * NextFloatInclusive() + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="double"/> value in range [0, 1).
		/// </summary>
		/// <returns>Generated <see cref="double"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe double NextDouble()
		{
			NextState();
			// First 12 bits stand for sign and exponent. 0x3FF0000000000000UL sets exponent for range [1, 2).
			ulong answer = (m_state >> 12) | 0x3FF0000000000000UL;
			return *(double*)&answer - 1D;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="double"/> value in range [0, <paramref name="max"/>).
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="double"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDouble(double max)
		{
			return max * NextDouble();
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="double"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>).
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="double"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDouble(double min, double max)
		{
			return (max - min) * NextDouble() + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="double"/> value in range [0, 1].
		/// </summary>
		/// <returns>Generated <see cref="double"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDoubleInclusive()
		{
			return (double)NextUint() / uint.MaxValue;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="double"/> value in range [0, <paramref name="max"/>].
		/// </summary>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="double"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDoubleInclusive(double max)
		{
			return max * NextDoubleInclusive();
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="double"/> value
		/// in range [<paramref name="min"/>, <paramref name="max"/>].
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns>Generated <see cref="double"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double NextDoubleInclusive(double min, double max)
		{
			return (max - min) * NextDoubleInclusive() + min;
		}

		/// <summary>
		/// Jumps forward.
		/// </summary>
		/// <param name="steps">How many steps to jump.</param>
		public void Forward(int steps)
		{
			for (int i = 0; i < steps; ++i)
			{
				NextState();
			}
		}

		/// <summary>
		/// XorShift64 algorithm.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void NextState()
		{
			m_state ^= m_state << 13;
			m_state ^= m_state >> 7;
			m_state ^= m_state << 17;
		}
	}
}
