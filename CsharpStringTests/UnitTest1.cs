using System;
using Xunit;

namespace CsharpStringTests;

public class UnitTest1
{
    [Theory]
    [InlineData("toto", "tata", "tototata")]
    [InlineData("", "tata", "tata")]
    [InlineData("toto", "", "toto")]
    public void Concat_ShouldReturnTwoStringsConcatenated(string s1, string s2, string s3)
    {
        CsharpString.String value1 = new(s1);
        CsharpString.String value2 = new(s2);
        CsharpString.String expected = new(s3);

        CsharpString.String actual = CsharpString.String.Concat(value1, value2);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("tut", null, false)]
    [InlineData("tata", "tat", false)]
    [InlineData("tata", 1, false)]
    public void Equals_ShouldReturnFalseIfTwoSObjectsHaveNotTheSameContent(string s1, object o1, bool expected)
    {
        CsharpString.String first = new(s1);

        bool actual = first.Equals(o1);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("tut", "", false)]
    [InlineData("tata", "taa", false)]
    public void Equals_ShouldReturnFalseIfTwoStringsHaveNotTheSameContent(string s1, string s2, bool expected)
    {
        CsharpString.String first = new(s1);
        CsharpString.String second = new(s2);

        bool actual = first.Equals(second);

        Assert.Equal(expected, actual);
    }


    [Theory]
    [InlineData("", "", true)]
    [InlineData("tata", "tata", true)]
    public void Equals_ShouldReturnTrueIfTwoObjectsHaveTheSameContent(string s1, object o1, bool expected)
    {
        CsharpString.String first = new(s1);

        bool actual = first.Equals(o1);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("tata", "tata", true)]
    public void Equals_ShouldReturnTrueIfTwoStringsHaveTheSameContent(string s1, string s2, bool expected)
    {
        CsharpString.String first = new(s1);
        CsharpString.String second = new(s2);

        bool actual = first.Equals(second);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("tata", "tat")]
    [InlineData("tata", "toto")]
    public void GetHashCode_ShouldNotReturnTheSameValueForTwoStringsWithDifferentContent(string s1, string s2)
    {
        CsharpString.String first = new(s1);
        CsharpString.String second = new(s2);

        int firstHashCode = first.GetHashCode();
        int secondHashCode = second.GetHashCode();

        Assert.NotEqual(firstHashCode, secondHashCode);
    }

    [Theory]
    [InlineData("tata", "tata")]
    [InlineData("", "")]
    public void GetHashCode_ShouldReturnTheSameValueForTwoStringsWithTheSameContent(string s1, string s2)
    {
        CsharpString.String first = new(s1);
        CsharpString.String second = new(s2);

        int firstHashCode = first.GetHashCode();
        int secondHashCode = second.GetHashCode();

        Assert.Equal(firstHashCode, secondHashCode);
    }


    [Theory]
    [InlineData("tato", 3, 'o')]
    [InlineData("tato", 0, 't')]
    public void GetIndex_ShouldReturnTheCharacterOfTheGivenIndex(string s1, int index, char expected)
    {
        CsharpString.String value = new(s1);

        char actual = value[index];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("toto", 'o', 1)]
    [InlineData("toto", 'a', -1)]
    public void IndexOf_ShouldReturnTheIndexOfTheGivenCharacter(string s1, char c1, int expected)
    {
        CsharpString.String value = new(s1);

        int actual = value.IndexOf(c1);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("toto", " ", 2, "to to")]
    [InlineData("tata", "tutu", 0, "tututata")]
    public void Insert_ShouldReturnANewStringWithInsertedValueAtCorrectIndex(string s1, string s2, int index, string s3)
    {
        CsharpString.String first = new(s1);
        CsharpString.String second = new(s2);
        CsharpString.String expected = new(s3);

        CsharpString.String actual = first.Insert(index, second);

        Assert.Equal(actual, expected);
    }

    [Theory]
    [InlineData("tata", "tutu", -10)]
    [InlineData("tata", "tutu", 10)]
    public void Insert_SouldThrowExceptionWhenIndexIsOutOfRange(string s1, string s2, int index)
    {
        CsharpString.String first = new(s1);
        CsharpString.String second = new(s2);

        Assert.Throws<ArgumentOutOfRangeException>(() => first.Insert(index, second));
    }

    [Theory]
    [InlineData("toto", 4)]
    [InlineData("", 0)]
    public void Length_ShouldReturnTheNumberOfCharactersInTheString(string s1, int expectedLength)
    {
        CsharpString.String value = new(s1);

        int actual = value.Length;

        Assert.Equal(expectedLength, actual);
    }

    [Fact]
    public void String_ConstructorWithNullArgumentShouldThrowArgumentException()
    {
        string nullString = null;

        Assert.Throws<ArgumentNullException>(() => new CsharpString.String(nullString));
    }

    [Theory]
    [InlineData("toto")]
    [InlineData("")]
    public void ToString_ShouldReturnASystemString(string s1)
    {
        CsharpString.String value = new(s1);

        var actual = value.ToString();

        Assert.IsType<string>(actual);
    }
}
