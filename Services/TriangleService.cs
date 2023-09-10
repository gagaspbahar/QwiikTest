using System;
using Models;

namespace Services;
public class TriangleService {
  public static Boolean CheckValidity(Triangle triangle) {
    if (triangle.A <= 0 || triangle.B <= 0 || triangle.C <= 0) {
      return false;
    }

    if (triangle.A + triangle.B <= triangle.C || triangle.A + triangle.C <= triangle.B || triangle.B + triangle.C <= triangle.A) {
      return false;
    }

    return true;
  }

  public static double CalculatePerimeter(Triangle triangle) {
    return triangle.A + triangle.B + triangle.C;
  }

  public static double CalculateArea(Triangle triangle) {
    var perimeter = CalculatePerimeter(triangle);
    return Math.Sqrt(perimeter / 2 * (perimeter / 2 - triangle.A) * (perimeter / 2 - triangle.B) * (perimeter / 2 - triangle.C));
  }
}