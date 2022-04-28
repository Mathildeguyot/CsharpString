using System;

namespace CsharpString
{
    public class String : IEquatable<String>
    {
        public String(char[] value)
        {
            charArray = value ?? throw new ArgumentNullException(nameof(value), "Parameter cannot be null");
        }

        public String(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Parameter cannot be null");
            charArray = value.ToCharArray();
        }

        public static String Concat(String s1, String s2)
        {
            char[] concatenated = new char[s1.Length + s2.Length];

            s1.charArray.CopyTo(concatenated, 0);
            s2.charArray.CopyTo(concatenated, s1.Length);

            return new String(concatenated);
        }

        public bool Equals(String other)
        {
            if (Length == other.Length)
            {
                if (Length == 0 && other.Length == 0)
                {
                    return true;
                }
                for (int i = 0; i < Length; i++)
                {
                    if (charArray[i] != other.charArray[i])
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || obj.GetType() != typeof(string))
                return false;

            return Equals(new String(obj as string));
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int IndexOf(char value)
        {
            return Array.IndexOf(charArray, value);
        }

        public String Insert(int index, String s1)
        {
            if (index < 0 || index > Length)
                throw new ArgumentOutOfRangeException("index", index, "Argument is out of range");

            char[] inserted = new char[s1.Length + charArray.Length];

            Array.Copy(charArray, 0, inserted, 0, index);
            Array.Copy(s1.charArray, 0, inserted, index, s1.Length);
            Array.Copy(charArray, index, inserted, index + s1.Length, Length - index);

            return new String(inserted);
        }

        public override string ToString()
        {
            return new string(charArray);
        }

        public char this[int index] => charArray[index];
        public int Length => charArray.Length;

        private readonly char[] charArray;
    }
}
