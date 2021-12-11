using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// Implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';
        private const char OperationNull = '\0';
        private string _onDisplay = "null";
        private Complex _num;
        private char _op = OperationNull;

        //Proprietà-> Value, passi i valori da sommare/sottrarre, mostrato su display (ritornabile)
        public Complex Value
        {
            get => _num;
            set
            {
                if (_op.Equals(OperationNull))
                {
                    _num = new Complex(value.Real, value.Imaginary);
                    _onDisplay = _num.ToString();
                }
                else
                {
                    //Ho un operazione, per forza e' legale
                    if (_op.Equals(OperationPlus))
                    {
                        _num.Plus(value);
                    }
                    else
                    {
                        _num.Minus(value);
                    }
                    _onDisplay = null;
                    _op = OperationNull;
                }
            }
        }


        //Proprietà-> Operation, passi un char Operation, azzera il numero mostrato in display e memorizzi op
        public char Operation
        {
            get => _op;

            set
            {
                if (value.Equals(OperationMinus) || value.Equals(OperationPlus))
                {
                    _op = value;
                    _onDisplay = "null";
                }
                else
                {
                    _op = OperationNull;
                }
            }
        }

        //Metodo -> to string, mostra il valore in output (o null)
        public override string ToString()
        {
            return _onDisplay;

        }

        //Metodo -> ComputeResult, mette in ToString il risulato finale, azzera op, e mette il risulato in value (ritornabile)
        public void ComputeResult()
        {
            _op = OperationNull;
            _onDisplay = _num.ToString();
            return;
        }

        //Metodo -> Reset, resetta tutto, op e value
        public void Reset()
        {
            _onDisplay = "null";
            _num = null;
            _op=OperationNull;
            return;
        }

    }
}