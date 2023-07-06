// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.RandomEngines
{
	public struct Xoroshiro128Plus
	{
		private ulong m_a;
		private ulong m_b;

		/// <summary>
		/// Creates a <see cref="Xoroshiro128Plus"/> with the specified initial state.
		/// </summary>
		/// <param name="a">Initial state a.</param>
		/// <param name="b">Initial state b.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Xoroshiro128Plus(ulong a, ulong b)
		{
			m_a = a;
			m_b = b;
		}

		/// <summary>
		/// Creates a <see cref="Xoroshiro128Plus"/> with specified seed.
		/// </summary>
		/// <param name="a">Seed a.</param>
		/// <param name="b">Seed b.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Xoroshiro128Plus(long a, long b)
		{
			unchecked
			{
				m_a = (ulong)a;
				m_b = (ulong)b;
			}
		}

		/// <summary>
		/// Current state. At least one item must be non-zero.
		/// </summary>
		public (ulong, ulong) state
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => (m_a, m_b);
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_a = value.Item1;
				m_b = value.Item2;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="bool"/> value.
		/// </summary>
		/// <returns>Generated <see cref="bool"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool NextBool()
		{
			const ulong number = 1UL << 63;
			return (NextUlong() & number) == number;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="byte"/> value
		/// in range [<see cref="byte.MinValue"/>, <see cref="byte.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="byte"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte NextByte()
		{
			unchecked
			{
				return (byte)NextUlong();
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
			return (byte)(max * (NextUlong() >> 32) >> 32);
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
			return (byte)((((ulong)max - min) * (NextUlong() >> 32) >> 32) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="sbyte"/> value
		/// in range [<see cref="sbyte.MinValue"/>, <see cref="sbyte.MaxValue"/>).
		/// </summary>
		/// <returns>Generated <see cref="sbyte"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte NextSbyte()
		{
			unchecked
			{
				return (sbyte)NextUlong();
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
			return (sbyte)((ulong)max * (NextUlong() >> 32) >> 32);
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
			return (sbyte)((int)((ulong)(max - min) * (NextUlong() >> 32) >> 32) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="short"/> value
		/// in range [<see cref="short.MinValue"/>, <see cref="short.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="short"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short NextShort()
		{
			unchecked
			{
				return (short)NextUlong();
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
			return (short)((ulong)max * (NextUlong() >> 32) >> 32);
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
			return (short)((int)((ulong)(max - min) * (NextUlong() >> 32) >> 32) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="ushort"/> value
		/// in range [<see cref="ushort.MinValue"/>, <see cref="ushort.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="ushort"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort NextUshort()
		{
			unchecked
			{
				return (ushort)NextUlong();
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
			return (ushort)(max * (NextUlong() >> 32) >> 32);
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
			return (ushort)((((ulong)max - min) * (NextUlong() >> 32) >> 32) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="int"/> value
		/// in range [<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="int"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt()
		{
			unchecked
			{
				return (int)NextUlong();
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
			return (int)((ulong)max * (NextUlong() >> 32) >> 32);
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
			return (int)((ulong)(max - min) * (NextUlong() >> 32) >> 32) + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="uint"/> value
		/// in range [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="uint"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUint()
		{
			unchecked
			{
				return (uint)NextUlong();
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
			return (uint)(max * (NextUlong() >> 32) >> 32);
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
			return (uint)((max - min) * (NextUlong() >> 32) >> 32) + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="long"/> value
		/// in range [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="long"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long NextLong()
		{
			unchecked
			{
				return (long)NextUlong();
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
		/// in range [<see cref="ulong.MinValue"/>, <see cref="ulong.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="ulong"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong NextUlong()
		{
			NextState();

			unchecked
			{
				return m_a + m_b;
			}
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
			// First 12 bits stand for sign and exponent. 0x3FF0000000000000UL sets exponent for range [1, 2).
			ulong answer = (NextUlong() >> 12) | 0x3FF0000000000000UL;
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void NextState()
		{
			m_b ^= m_a;
			m_a = Rotl(m_a, 24) ^ m_b ^ (m_b << 16);
			m_b = Rotl(m_b, 37);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		private static ulong Rotl(ulong x, int k)
		{
			return (x << k) | (x >> (64 - k));
		}
	}
}
