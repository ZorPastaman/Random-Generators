// Copyright (c) 2020-2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Zor.RandomGenerators.RandomEngines
{
	/// <summary>
	/// Pseudo-random number engine using XorShift128 algorithm.
	/// </summary>
	public unsafe struct XorShift128
	{
		private uint m_a;
		private uint m_b;
		private uint m_c;
		private uint m_d;

		/// <summary>
		/// Creates a <see cref="XorShift128"/> with the specified initial state.
		/// </summary>
		/// <param name="a">Initial state a.</param>
		/// <param name="b">Initial state b.</param>
		/// <param name="c">Initial state c.</param>
		/// <param name="d">Initial state d.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public XorShift128(uint a, uint b, uint c, uint d)
		{
			m_a = a;
			m_b = b;
			m_c = c;
			m_d = d;
		}

		/// <summary>
		/// Creates a <see cref="XorShift128"/> with specified seed.
		/// </summary>
		/// <param name="a">Seed a.</param>
		/// <param name="b">Seed b.</param>
		/// <param name="c">Seed c.</param>
		/// <param name="d">Seed d.</param>
		/// <remarks>
		/// At least one parameter must be non-zero.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public XorShift128(int a, int b, int c, int d)
		{
			unchecked
			{
				m_a = (uint)a;
				m_b = (uint)b;
				m_c = (uint)c;
				m_d = (uint)d;
			}
		}

		/// <summary>
		/// Creates a <see cref="XorShift128"/> with the specified initial state.
		/// </summary>
		/// <param name="state">Initial state. At least one item must be non-zero.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public XorShift128((uint, uint, uint, uint) state)
		{
			m_a = state.Item1;
			m_b = state.Item2;
			m_c = state.Item3;
			m_d = state.Item4;
		}

		/// <summary>
		/// Creates a <see cref="XorShift128"/> with the specified seed.
		/// </summary>
		/// <param name="seed">Seed. At least one item must be non-zero.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public XorShift128((int, int, int, int) seed)
		{
			unchecked
			{
				m_a = (uint)seed.Item1;
				m_b = (uint)seed.Item2;
				m_c = (uint)seed.Item3;
				m_d = (uint)seed.Item4;
			}
		}

		/// <summary>
		/// Current state. At least one item must be non-zero.
		/// </summary>
		public (uint, uint, uint, uint) state
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => (m_a, m_b, m_c, m_d);
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				m_a = value.Item1;
				m_b = value.Item2;
				m_c = value.Item3;
				m_d = value.Item4;
			}
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="bool"/> value.
		/// </summary>
		/// <returns>Generated <see cref="bool"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool NextBool()
		{
			NextState();
			uint answer = m_a & 1u;
			return *(bool*)&answer;
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
				return (byte)m_a;
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
			return (byte)(max * (m_a >> 16) >> 16);
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
			return (byte)((((uint)max - min) * (m_a >> 16) >> 16) + min);
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
				return (sbyte)m_a;
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
			return (sbyte)((uint)max * (m_a >> 16) >> 16);
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
			return (sbyte)(((uint)(max - min) * (m_a >> 16) >> 16) + min);
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
				return (short)m_a;
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
			return (short)((uint)max * (m_a >> 16) >> 16);
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
			return (short)(((uint)(max - min) * (m_a >> 16) >> 16) + min);
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
				return (ushort)m_a;
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
			return (ushort)(max * (m_a >> 16) >> 16);
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
			return (ushort)((((uint)max - min) * (m_a >> 16) >> 16) + min);
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="int"/> value
		/// in range (<see cref="int.MinValue"/>, <see cref="int.MaxValue"/>].
		/// </summary>
		/// <returns>Generated <see cref="int"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int NextInt()
		{
			NextState();

			unchecked
			{
				return (int)m_a;
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
			return (int)((ulong)max * m_a >> 32);
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
			return (int)((ulong)(max - min) * m_a >> 32) + min;
		}

		/// <summary>
		/// Generates a pseudo-random <see cref="uint"/> value
		/// in range [<see cref="uint.MinValue"/>, <see cref="uint.MaxValue"/>).
		/// </summary>
		/// <returns>Generated <see cref="uint"/> value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint NextUint()
		{
			NextState();
			return m_a;
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
			return (uint)((ulong)max * m_a >> 32);
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
			return (uint)((ulong)(max - min) * m_a >> 32) + min;
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
			return ((long)m_a << 32) | m_d;
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
			return ((ulong)m_a << 32) | m_d;
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
		public float NextFloat()
		{
			NextState();
			// First 9 bits stand for sign and exponent. 0x3F800000u sets exponent for range [1, 2).
			uint answer = (m_a >> 9) | 0x3F800000u;
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
		public double NextDouble()
		{
			NextState();
			ulong answer = ((ulong)m_a << 32) | m_d;
			// First 12 bits stand for sign and exponent. 0x3FF0000000000000UL sets exponent for range [1, 2).
			answer = (answer >> 12) | 0x3FF0000000000000UL;
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
		/// XorShift128 algorithm.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void NextState()
		{
			uint t = m_d;

			m_d = m_c;
			m_c = m_b;
			m_b = m_a;

			t ^= t << 11;
			t ^= t >> 8;

			m_a = t ^ m_a ^ (m_a >> 19);
		}
	}
}
