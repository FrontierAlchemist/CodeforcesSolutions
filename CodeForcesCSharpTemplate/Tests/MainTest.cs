using System;

using Xunit;
using CodeForces;

namespace Tests;

public class MainTest
{
	[Fact]
	public void Test()
	{
		Assert.Throws<NullReferenceException>(Solver.Run);
	}
}
