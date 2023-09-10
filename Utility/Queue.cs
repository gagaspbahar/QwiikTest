using System;


// Queue implementation using static array

namespace Utility {
  public class Queue {
    private int[] _queue;
    private int _front;
    private int _rear;
    private int _size;
    private int _capacity;

    public Queue(int capacity) {
      _queue = new int[capacity];
      _front = 0;
      _rear = -1;
      _size = 0;
      _capacity = capacity;
    }

    public void Enqueue(int item) {
      if (IsFull()) {
        throw new System.Exception("Queue is full.");
      }
      _rear = (_rear + 1) % _capacity;
      _queue[_rear] = item;
      _size++;
    }

    public int Dequeue() {
      if (IsEmpty()) {
        throw new System.Exception("Queue is empty.");
      }
      int item = _queue[_front];
      _front = (_front + 1) % _capacity;
      _size--;
      return item;
    }

    public int Front() {
      if (IsEmpty()) {
        throw new System.Exception("Queue is empty.");
      }
      return _queue[_front];
    }

    public int Rear() {
      if (IsEmpty()) {
        throw new System.Exception("Queue is empty.");
      }
      return _queue[_rear];
    }

    public bool IsEmpty() {
      return _size == 0;
    }

    public bool IsFull() {
      return _size == _capacity;
    }

    public int Size() {
      return _size;
    }

    public void Resize(int n) {
      if (n < _size) {
        throw new System.Exception("New size is smaller than current size.");
      }
      int[] newQueue = new int[n];
      for (int i = 0; i < _size; i++) {
        newQueue[i] = _queue[(_front + i) % _capacity];
      }
      _queue = newQueue;
      _front = 0;
      _rear = _size - 1;
      _capacity = n;
    }

    public void Shrink(int n) {
      if (n > _size) {
        throw new System.Exception("New size is larger than current size.");
      }
      int[] newQueue = new int[n];
      for (int i = 0; i < n; i++) {
        newQueue[i] = _queue[(_front + i) % _capacity];
      }
      _queue = newQueue;
      _front = 0;
      _rear = n - 1;
      _capacity = n;
    }

    public int Capacity() {
      return _capacity;
    }
  }
}