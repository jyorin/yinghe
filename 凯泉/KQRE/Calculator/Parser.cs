using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator {
	class Parser : IRuntime {
		Scanner _scanner;
		Stack<double> _dataStack = new Stack<double>();
		Stack<string> _opStack = new Stack<string>();
		List<Token> _tokens = new List<Token>();
		int _currentToken;
		Dictionary<string, Variable> _variables = new Dictionary<string, Variable>();
		Dictionary<string, Function> _functions = new Dictionary<string, Function>();

		public static readonly Token EndOfStream = new Token(string.Empty, TokenType.EndOfStream);

		public DegreeType DegreeType { get; set; }

		public Parser(Scanner scanner) {
			_scanner = scanner;
		}

		public void AddFunction(Function func) {
			_functions.Add(func.Name, func);
		}

		public IEnumerable<Function> Functions {
			get { return _functions.Values; }
		}

		public void AddVariable(Variable var) {
			_variables.Add(var.Name, var);
		}

		public IEnumerable<Variable> Variables {
			get { return _variables.Values.Where(v => !v.IsConstant); }
		}

		public void SetVariable(string name, double value) {
			Variable var;
			_variables.TryGetValue(name, out var);
			if(var != null && var.IsConstant)
				throw new CalculatorException("Cannot change read only variable '" + name + "'");
			if(var == null)
				_variables.Add(name, new Variable(name, value));
			else
				_variables[name].Value = value;
		}

		public bool Parse(string text) {
			_tokens.Clear();
			_tokens.AddRange(_scanner.TokenizeLine(text));
			_currentToken = -1;

			return ParseStatement();
		}

		public Token NextToken() {
			return _tokens[++_currentToken];
		}

		public Token PeekToken(int offset = 0) {
			if(offset + _currentToken + 1 >= _tokens.Count)
				return EndOfStream;
			return _tokens[_currentToken + offset + 1];
		}

		public void Push(double data) {
			_dataStack.Push(data);
		}

		public double Pop() {
			if(_dataStack.Count == 0)
				throw new CalculatorException("Not enough arguments.");

			return _dataStack.Pop();
		}

		bool Match(string value) {
			if(PeekToken().Value == value) {
				NextToken();
				return true;
			}
			return false;
		}

		#region Parse methods

		void ParseFactor() {
			var token = PeekToken();
			switch(token.Type) {
				case TokenType.Integer:
				case TokenType.Real:
					NextToken();
					Push(double.Parse(token.Value));
					return;

				case TokenType.Identifier:
					if(PeekToken(1).Value == "(")
						ParseFunction();
					else
						ParseIdentifier();
					return;

				case TokenType.Operator:
					if(token.Value == "(") {
						Match("(");
						ParseExpression();
						Match(")");
						return;
					}
					break;
			}
			throw new CalculatorException("Syntax error.");
		}

		void ParseTerm() {
			ParseFactor();
			Token op;
			do {
				op = PeekToken();
				if(op.Type == TokenType.EndOfStream)
					break;
				if(op.Type != TokenType.Operator)
					throw new CalculatorException("Operator expected.");
				if(op.Value == "*" || op.Value == "/" || op.Value == "%") {
					NextToken();
					ParseFactor();
					switch(op.Value) {
						case "*":
							Push(Pop() * Pop());
							break;
						case "/":
							Push(1 / Pop() * Pop());
							break;
						case "%":
							var first = Pop();
							Push(Pop() % first);
							break;
					}
				}
				else
					break;
			} while(true);
		}

		void ParseExpression() {
			ParseTerm();
			Token op;
			do {
				op = PeekToken();
				if(op.Type == TokenType.EndOfStream)
					break;
				if(op.Type != TokenType.Operator)
					throw new CalculatorException("Operator expected.");
				if(op.Value == "+" || op.Value == "-") {
					NextToken();
					ParseTerm();
					switch(op.Value) {
						case "+":
							Push(Pop() + Pop());
							break;
						case "-":
							Push(-Pop() + Pop());
							break;
					}
				}
				else
					break;
			} while(true);
		}

		bool ParseStatement() {
			var token = PeekToken();
			bool result = true;
			switch(token.Type) {
				case TokenType.Identifier:
					if(PeekToken(1).Value == "=")
						ParseAssign();
					else if(PeekToken(1).Type == TokenType.Identifier) {
						ParseCommand();
						result = false;
					}
					else
						ParseExpression();
					break;

				default:
					ParseExpression();
					break;
			}
			return result;
		}

		private void ParseCommand() {
			string cmd = NextToken().Value;
			switch(cmd) {
				case "set":
					ParseSet();
					break;

				case "delete":
					ParseDelete();
					break;

				case "clear":
					ParseClear();
					break;

				case "display":
					ParseDisplay();
					break;

				default:
					throw new CalculatorException("Unrecognized command: '" + cmd + "'");
			}
		}

		private void ParseDisplay() {
			if(Match("all")) {
				foreach(var v in Variables)
					Console.WriteLine("{0} = {1}", v.Name, v.Value);
			}
		}

		private void ParseDelete() {
			string var = NextToken().Value;
			if(!_variables.ContainsKey(var))
				throw new CalculatorException("Variable does not exist.");
			if(_variables[var].IsConstant)
				throw new CalculatorException("Cannot remove a constant.");
			_variables.Remove(var);
		}

		private void ParseClear() {
			Match("all");
			var all = _variables.Values.Where(vr => !vr.IsConstant).ToArray();
			foreach(var v in all)
				_variables.Remove(v.Name);
		}

		private void ParseSet() {
			string param = NextToken().Value;
			switch(param) {
				case "rad":
				case "radians":
					DegreeType = DegreeType.Radians;
					break;

				case "deg":
				case "degrees":
					DegreeType = DegreeType.Degrees;
					break;

				default:
					throw new CalculatorException("Unrecognized parameter: '" + param + "'");
			}
		}

		private void ParseAssign() {
			var ident = NextToken().Value;
			Match("=");
			ParseExpression();
			var peek = _dataStack.Peek();
			if(!_variables.ContainsKey(ident))
				_variables.Add(ident, new Variable(ident, Pop()));
			else {
				if(_variables[ident].IsConstant)
					throw new CalculatorException("Cannot modify constant.");
				_variables[ident].Value = Pop();
			}
			Push(peek);
		}

		private void ParseFunction() {
			var func = NextToken();
			Function fun;
			if(!_functions.TryGetValue(func.Value, out fun))
				throw new CalculatorException("Unknown function: '" + func.Value + "'");
			Match("(");
			ParseExpression();
			while(PeekToken().Value == ",") {
				Match(",");
				ParseExpression();
			}
			Match(")");
			fun.Execute(this);
		}

		private void ParseIdentifier() {
			var ident = NextToken();
			Variable var;
			if(!_variables.TryGetValue(ident.Value, out var))
				throw new CalculatorException("Unknown variable: '" + ident.Value + "'");
			Push(var.Value);

		}
		#endregion

	}
}
