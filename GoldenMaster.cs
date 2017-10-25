﻿using System;
using System.Collections.Generic;
using System.IO;
using Algorithm;
using Xunit;

namespace Refactoring_1
{
  // Observe output from current implementation
  public class GoldenMaster
  {
    readonly StringWriter _output = new StringWriter();

    public GoldenMaster()
    {
      Console.SetOut(_output);
    }
    
    [Fact]
    public void Approve_implemenation()
    {
      Program.Run();
      
      Assert.Equal("286.00:00:00\nM\nA\n19221.00:00:00\nW\nB\n", _output.ToString());
    }

    [Fact]
    public void Approve_nothing_found_because_list_is_empty()
    {
      var finder = new Finder(new List<Thing>());
      var result = finder.Find(FT.One);

      Assert.NotNull(result);
      Assert.Null(result.First);
      Assert.Null(result.Second);
      Assert.Equal(TimeSpan.Zero, result.Duration);
    }
  }
}
