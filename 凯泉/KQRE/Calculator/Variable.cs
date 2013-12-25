using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator {
	public class Variable {
		public string Name { get; private set; }
		public bool IsConstant { get; set; }
		public double Value { get; set; }

		public Variable(string name, double value = 0.0) {
			Name = name;
			Value = value;
		}
	}
}
