// Copyright (c) 2020 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/Random-Generators

namespace Zor.RandomGenerators
{
	public static class NumberConstants
	{
		/// <summary>
		/// Normal epsilon. We need to use it because <see cref="float.Epsilon"/> is denormal
		/// and some CPUs don't support it.
		/// </summary>
		public const float NormalEpsilon = 1.17549435082e-38f;

		/// <summary>
		/// One bit before 1.
		/// </summary>
		public const float SubOne = 0.999999940395f;
	}
}
