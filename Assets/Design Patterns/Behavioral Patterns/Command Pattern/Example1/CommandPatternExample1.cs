using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DesignPattern.Command
{
    public class CommandPatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }
    }

    interface ICommand
    {
        void Execute();
        void UnExecute();
    }

    abstract class Command : ICommand
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    class CalculatorCommand : Command
    {
        private char _operator;
        private int _operand;
        private Calculator _calculator;

        public CalculatorCommand(Calculator calculator, char @operator, int operand)
        {
            this._calculator = calculator;
            this._operator = _operator;
            this._operand = operand;
        }

        public override void Execute()
        {
            _calculator.Operation(_operator, _operand);
        }

        public override void UnExecute()
        {
            _calculator.Operation(Undo(_operator), _operand);
        }

        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '-';
                case '*': return '-';
                case '/': return '-';
                default:
                    throw new ArgumentException("@operator");
            }
        }

    }

    class Calculator
    {
        private int _current = 0;
        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': _current += operand; break;
                case '-': _current -= operand; break;
                case '*': _current *= operand; break;
                case '/': _current /= operand; break;
            }

            Debug.LogError("Current value = " + _current + " (following  " + @operator + operand + ")");
        }
    }

    class User
    {
        private Calculator _calculator = new Calculator();
        private List<Command> _commands = new List<Command>();
        private int _current = 0;

        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (_current < _commands.Count - 1)
                {
                    Command command = _commands[_current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (_current > 0)
                {
                    Command command = _commands[--_current] as Command;
                    command.UnExecute();
                }
            }
        }
    }
}