/*
 * SumList - a helper class
 * used in Problem 76
 */
using System.Diagnostics.CodeAnalysis;

namespace Problems70to79
{
    internal class SumList
    {
        public List<int> intList { get; }

        public SumList()
        {
            intList = new List<int>();
        }

        public SumList(IEnumerable<int> list)
        {
            intList = new List<int>(list);
        }

        public void AddToList(int n)
        {
            intList.Add(n);
        }

        public int GetSum()
        {
            return intList.Sum();
        }

        public bool CheckSorted()
        {
            for (int i = 1; i < intList.Count; i++)
            {
                if (intList[i] > intList[i - 1])
                    return false;
            }
            return true;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is SumList)
            {
                SumList sl = (SumList)obj;
                return this.intList.SequenceEqual(sl.intList);
            }
            return false;
        }

        public override string ToString()
        {
            return string.Join(" + ", intList) + " = " + GetSum().ToString();
        }

        public override int GetHashCode()
        {
            return intList.GetHashCode();
        }
    }
}
