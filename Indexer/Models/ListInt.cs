namespace Indexer.Models;

public class ListInt
{
    private int[] _numbers;

    public ListInt(int listLength)
    {
        _numbers = new int[listLength];
    }

    public int this[int index]
    {
        get
        {
            return _numbers[index];
        }
        set
        {
            if (index < 0 || index > _numbers.Length - 1) throw new IndexOutOfRangeException();
            _numbers[index] = value;
        }
    }


    public void Add(int num)
    {
        int[] newArr = new int[_numbers.Length + 1];
        for (int i = 0; i < _numbers.Length; i++)
        {
            newArr[i] = _numbers[i];
        }
        newArr[newArr.Length - 1] = num;
        _numbers = newArr;
    }
    public void Add(params int[] nums)
    {
        int length = _numbers.Length + nums.Length;
        int[] newArr = new int[length];
        for (int i = 0; i < length; i++)
        {
            if (i < _numbers.Length)
                newArr[i] = _numbers[i];
            else
                newArr[i] = nums[i - _numbers.Length];
        }
        _numbers = newArr;
    }
    public bool Contains(int num)
    {
        for (int i = 0; i < _numbers.Length; i++)
        {
            if (_numbers[i] == num) return true;
        }
        return false;
    }
    public int Pop()
    {
        int num = _numbers[_numbers.Length - 1];
        int[] newArr = new int[_numbers.Length - 1];
        for (int i = 0; i < _numbers.Length - 1; i++)
        {
            newArr[i] = _numbers[i];
        }
        _numbers = newArr;
        return num;
    }
    public int Sum()
    {
        int sum = 0;
        foreach (int num in _numbers)
        {
            sum += num;
        }
        return sum;
    }
    public override string ToString()
    {
        string output = string.Empty;
        foreach (int num in _numbers)
        {
            output += num + " ";
        }
        return output;
    }
    public int IndexOf(int num)
    {
        for (int i = 0; i < _numbers.Length; i++)
        {
            if (_numbers[i] == num) return i;
        }
        return -1;
    }
    public int LastIndexOf(int num)
    {
        int mem = 0;
        for (int i = 0; i < _numbers.Length; i++)
        {
            if (_numbers[i] == num) mem = i;
        }
        return mem;
    }
    public void Insert(int value, int index)
    {
        int[] newArr = new int[_numbers.Length + 1];
        int plusOne = 0;
        for (int i = 0; i < _numbers.Length; i++)
        {

            if (i != index) newArr[i + plusOne] = _numbers[i];
            else
            {
                newArr[index] = value;
                newArr[index + 1] = _numbers[i];
                plusOne++;
            }
        }
        _numbers = newArr;
    }
    public float Average()
    {
        float sum = 0f;
        foreach (int num in _numbers)
        {
            sum += num;
        }
        return sum / _numbers.Length;
    }
}
