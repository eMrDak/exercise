﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Main.Extensions;

namespace Main
{
    public class Move : IOperation
    {
        public Move(IEnumerable<IFile> files, IFilter filter = null)
        {
            Files = files.Filter(filter);
        }

        public IEnumerable<IFile> Files { get; set; }

        public OperationResult EngageOperation(Argument source, Argument destination)
        {
            var stopwatch = Stopwatch.StartNew();
            foreach (var file in this.Files)
            {
                System.IO.File.Move(file.Name.GetPath(source.Value),
                    file.Name.GetPath(destination.Value));
            }
            return new MoveResult(Files.Count(),stopwatch.ElapsedMilliseconds,Files.Select(x=>x.Size).Sum());
        }
    }
}