﻿using System;
using System.Collections.Generic;
using System.Linq;
using IO;

namespace ConsoleIO
{
    public class InputReader : IInput
    {
        public InputReader()
        {
        }

        public IEnumerable<IArgument> Read(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentOutOfRangeException();

            yield return new Argument("Input", args[0]);
            yield return new Argument("Output", args[1]);
            yield return new Argument("Filter", args[2]);
        }
    }
}