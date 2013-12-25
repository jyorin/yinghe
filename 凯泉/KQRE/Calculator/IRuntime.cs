using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator {
	public enum DegreeType {
		Radians, Degrees
	}

	public interface IRuntime {
		double Pop();
		void Push(double value);
		DegreeType DegreeType { get; }
	}
}
