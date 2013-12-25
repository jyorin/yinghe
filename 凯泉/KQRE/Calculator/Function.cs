using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator {
	public delegate void ExecuteFunctionAction(IRuntime stack);

	public class Function {
		public string Name { get; private set; }
		public ExecuteFunctionAction Execute { get; private set; }
		public bool VariableArgs { get; set; }

		public Function(string name, ExecuteFunctionAction execute) {
			Name = name;
			Execute = execute;
		}
	}
}
