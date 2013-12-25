using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator {
	public static class GenericFunctions {
		public static Function TrigFunction(string name, Func<double, double> trig) {
			return new Function(name, (runtime) => {
				double arg = runtime.Pop();
				switch(runtime.DegreeType) {
					case DegreeType.Radians:
						runtime.Push(trig(arg));
						break;

					case DegreeType.Degrees:
						runtime.Push(trig(arg * Math.PI / 180));
						break;
				}
			});
		}

		public static Function InverseTrigFunction(string name, Func<double, double> exec) {
			return new Function(name, (runtime) => {
				double result = exec(runtime.Pop());
				if(runtime.DegreeType == DegreeType.Degrees)
					result = result * 180 / Math.PI;
				runtime.Push(result);
			});
		}

		public static Function StandardFunction(string name, Func<double, double> exec) {
			return new Function(name, (runtime) => {
				runtime.Push(exec(runtime.Pop()));
			});
		}

		public static Function StandardFunction(string name, Func<double, double, double> exec) {
			return new Function(name, (runtime) => {
				var first = runtime.Pop();
				runtime.Push(exec(runtime.Pop(), first));
			});
		}

	}
}
