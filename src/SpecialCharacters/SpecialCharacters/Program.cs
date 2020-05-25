using System;

namespace SpecialCharacters
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.Unicode;
      Console.WriteLine("\u03B8");
      Console.WriteLine("ΛλᴧⲖⲗ");
      Console.WriteLine("\u039B");
      Console.ReadLine();

    }
  }
}
