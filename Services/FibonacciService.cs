using System;
using Models;

namespace Services;
public class FibonacciService {
  public static ulong[] GetFibonacci(int n) {
    if (n < 0)
    {
      throw new ArgumentException("The number is not valid.");
    }
    if (n > 92)
    {
      throw new ArgumentException("The number is too large.");
    }
    ulong[] fibonacci = new ulong[n];
    fibonacci[0] = 0;
    if (n > 1)
    {
      fibonacci[1] = 1;
    }
    for (int i = 2; i < n; i++)
    {
      fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
    }
    return fibonacci;
  }
}