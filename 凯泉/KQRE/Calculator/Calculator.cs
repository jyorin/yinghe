using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator {
	[Serializable]
	public class CalculatorException : Exception {
		public CalculatorException() { }
		public CalculatorException(string message) : base(message) { }
		public CalculatorException(string message, Exception inner) : base(message, inner) { }
		protected CalculatorException(
		 System.Runtime.Serialization.SerializationInfo info,
		 System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}

	public class Calculator {
		Parser _parser;
		Scanner _scanner;

		public Calculator() {
			_scanner = new Scanner();
			_scanner.AddOperators("+", "-", "*", "/", "%", "(", ")", "=", ",");

			_parser = new Parser(_scanner);
			_parser.AddFunction(GenericFunctions.TrigFunction("sin", Math.Sin));
			_parser.AddFunction(GenericFunctions.TrigFunction("cos", Math.Cos));
			_parser.AddFunction(GenericFunctions.TrigFunction("tan", Math.Tan));

			_parser.AddFunction(GenericFunctions.StandardFunction("sqrt", Math.Sqrt));
			_parser.AddFunction(GenericFunctions.StandardFunction("abs", Math.Abs));
			_parser.AddFunction(GenericFunctions.StandardFunction("log", Math.Log10));
			_parser.AddFunction(GenericFunctions.StandardFunction("ln", (Func<double, double>)Math.Log));
			_parser.AddFunction(GenericFunctions.StandardFunction("exp", Math.Exp));

			_parser.AddFunction(GenericFunctions.InverseTrigFunction("asin", Math.Asin));
			_parser.AddFunction(GenericFunctions.InverseTrigFunction("acos", Math.Acos));
			_parser.AddFunction(GenericFunctions.InverseTrigFunction("atan", Math.Atan));

			_parser.AddFunction(GenericFunctions.StandardFunction("pow", Math.Pow));
			_parser.AddFunction(GenericFunctions.StandardFunction("max", Math.Max));
			_parser.AddFunction(GenericFunctions.StandardFunction("min", Math.Min));

			_parser.AddVariable(new Variable("pi", Math.PI) { IsConstant = true });
			_parser.AddVariable(new Variable("e", Math.E) { IsConstant = true });
			_parser.AddVariable(new Variable("ans"));

		}

		public bool Execute(string expression) {
			return _parser.Parse(expression);
		}

		public double Answer {
			get {
				double result = _parser.Pop();
				_parser.SetVariable("ans", result);
				return result;
			}
		}

		public IEnumerable<string> Functions {
			get {
				return _parser.Functions.Select(f => f.Name).OrderBy(n => n);
			}
		}

		public IEnumerable<Variable> Variables {
			get { return _parser.Variables.OrderBy(v => v.Name); }
		}
	}
}
