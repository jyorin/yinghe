using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator {
	public enum TokenType {
		EndOfStream, Identifier, Real, Integer, Operator, String
	}

	sealed class Token {
		public TokenType Type { get; private set; }
		public string Value { get; private set; }

		internal Token(string value, TokenType type) {
			Value = value;
			Type = type;
		}

		public override string ToString() {
			return string.Format("{0} ({1})", Value, Type);
		}
	}

	[Serializable]
	class ScannerException : Exception {
		public ScannerException() { }
		public ScannerException(string message) : base(message) { }
		public ScannerException(string message, Exception inner) : base(message, inner) { }
		protected ScannerException(
		 System.Runtime.Serialization.SerializationInfo info,
		 System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}

	class Scanner {
		public char StringDelimiter { get; set; }
		public char StringEscape { get; set; }

		public Scanner() {
			StringDelimiter = '"';
		}

		public void AddOperators(params string[] ops) {
			foreach(var op in ops) {
				_operators.Add(op);
				foreach(var ch in op)
					if(!_opChars.Contains(ch))
						_opChars.Add(ch);
			}
		}

		private enum ScannerState {
			Start, Numeric, Identifier, Operator, String, PlusMinus
		}

		[Flags]
		private enum StateFlags {
			None = 0, Dot = 1, Exponent = 2
		}

		ScannerState _state;
		StateFlags _stateFlags;
		StringBuilder _lexeme = new StringBuilder(32);
		HashSet<char> _opChars = new HashSet<char>();
		HashSet<string> _operators = new HashSet<string>();

		private void ResetState() {
			_state = ScannerState.Start;
			_stateFlags = StateFlags.None;
			_lexeme.Clear();
		}

		public IEnumerable<Token> TokenizeLine(string text) {
			int index = -1;
			ResetState();
			text = text.Trim() + " ";

			foreach(var ch in text) {
				index++;
				switch(_state) {
					case ScannerState.Start:
						if(char.IsWhiteSpace(ch))
							continue;
						if(char.IsNumber(ch) || ch == '.' || ch == '-' || ch == '+') {
							_state = ScannerState.Numeric;
							goto case ScannerState.Numeric;
						}
						if(ch == StringDelimiter) {
							_state = ScannerState.String;
							continue;
						}
						if(_opChars.Contains(ch)) {
							_state = ScannerState.Operator;
							goto case ScannerState.Operator;
						}
						_state = ScannerState.Identifier;
						goto case ScannerState.Identifier;

					case ScannerState.Numeric:
						if(ch == '+' || ch == '-') {
							if(_lexeme.Length > 0 && char.ToLower(_lexeme.ToString().Last()) != 'e') {
								if(_stateFlags != StateFlags.None)
									throw new ScannerException("Illegal character: '" + ch + "'");
								// probably an operator
								yield return new Token(_lexeme.ToString(), TokenType.Integer);
								ResetState();
								_state = ScannerState.Operator;
								goto case ScannerState.Operator;
							}
							else {
								//if(ch == '+') continue;
								break;
							}
						}
						if(ch == '.') {
							if((_stateFlags & StateFlags.Dot) == StateFlags.Dot)
								throw new ScannerException("Two many dots in a number");
							else
								_stateFlags |= StateFlags.Dot;
							break;
						}
						if(ch == 'e' || ch == 'E') {
							if((_stateFlags & StateFlags.Exponent) == StateFlags.Exponent)
								throw new ScannerException("Invalid number");
							else
								_stateFlags |= StateFlags.Exponent;
							break;
						}
						if(char.IsWhiteSpace(ch) || !char.IsNumber(ch)) {
							if(_lexeme.Length == 1 && (_lexeme[0] == '+' || _lexeme[0] == '-')) {
								_state = ScannerState.Operator;
								goto case ScannerState.Operator;
							}
							else
								yield return new Token(_lexeme.ToString(), _stateFlags == StateFlags.None ? TokenType.Integer : TokenType.Real);
							ResetState();
							if(char.IsWhiteSpace(ch))
								continue;
							goto case ScannerState.Start;
						}
						break;

					case ScannerState.Identifier:
						if(char.IsWhiteSpace(ch) || (!char.IsLetterOrDigit(ch) && ch != '_')) {
							yield return new Token(_lexeme.ToString(), TokenType.Identifier);
							ResetState();
							if(char.IsWhiteSpace(ch))
								continue;
							else
								goto case ScannerState.Start;
						}
						break;

					case ScannerState.Operator:
						if(!_opChars.Contains(ch)) {
							string lexeme = _lexeme.ToString();
							int n = 0;
							for(n = _lexeme.Length; n > 0; n--) {
								string op = lexeme.Substring(0, n);
								if(_operators.Contains(op)) {
									yield return new Token(op, TokenType.Operator);
									lexeme = lexeme.Substring(n);
									n = lexeme.Length + 1;
								}
							}
							if(n > 0)
								throw new ScannerException("Unrecognized operator");
							ResetState();
							goto case ScannerState.Start;
						}
						break;

					case ScannerState.String:
						if(ch == StringDelimiter) {
							yield return new Token(_lexeme.ToString(), TokenType.String);
							ResetState();
							continue;
						}
						break;
				}
				_lexeme.Append(ch);
			}
			yield break;
		}

	}
}
