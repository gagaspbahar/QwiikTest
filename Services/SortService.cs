using System;

namespace Services;
public class QuickSortService
{
  public static void QuickSort(int[] array)
  {
    QuickSort(array, 0, array.Length - 1);
  }
  public static void QuickSort(int[] array, int left, int right)
  {
    if (left < right)
    {
      int pivot = Partition(array, left, right);

      if (pivot > 1)
      {
        QuickSort(array, left, pivot - 1);
      }
      if (pivot + 1 < right)
      {
        QuickSort(array, pivot + 1, right);
      }
    }
  }

  private static int Partition(int[] array, int left, int right)
  {
    int pivot = array[left];
    while (true)
    {
      while (array[left] < pivot)
      {
        left++;
      }
      while (array[right] > pivot)
      {
        right--;
      }
      if (left < right)
      {
        if (array[left] == array[right]) return right;
        int temp = array[left];
        array[left] = array[right];
        array[right] = temp;
      }
      else
      {
        return right;
      }
    }
  }
}