using Models;

namespace Services;

// Service Aggregator
public interface IMainService {
    ulong[] GetFibonacci(int n);
    void QuickSort(int[] array);
    double CalculateArea(double a, double b, double c);
    double CalculatePerimeter(double a, double b, double c);
    bool CheckValidity(double a, double b, double c);
}

public class MainService {
  public ulong[] GetFibonacci(int n) {
    return FibonacciService.GetFibonacci(n);
  }
  public void QuickSort(int[] array) {
    QuickSortService.QuickSort(array);
  }

  public double CalculateArea(Triangle triangle) {
    return TriangleService.CalculateArea(triangle);
  }

  public double CalculatePerimeter(Triangle triangle) {
    return TriangleService.CalculatePerimeter(triangle);
  }

  public bool CheckValidity(Triangle triangle) {
    return TriangleService.CheckValidity(triangle);
  }
}