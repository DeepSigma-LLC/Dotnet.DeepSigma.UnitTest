using Xunit;

namespace DeepSigma.UnitTest;

/// <summary>
/// This class contains examples of unit tests using xUnit.
/// </summary>
public class Examples
{
    /// <summary>
    /// A simple test to verify addition functionality.
    /// </summary>
    [Fact]
    public void Add_SimpleValuesShouldCalculate()
    {
        // Arrange
        double expected = 2;

        // Act
        double actual = Add(1, 1);

        // Assert
        Assert.Equal(expected, actual);
    }

    /// <summary>
    /// A parameterized test to verify addition with multiple data sets.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="expected"></param>
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(0, 0, 0)]
    [InlineData(0, 2, 2)]
    [InlineData(double.MaxValue, 5, double.MaxValue)]
    public void Add_SimpleValuesShouldCalculate_Inline(double x, double y, double expected)
    {
        // Act
        double actual = Add(x, y);

        // Assert
        Assert.Equal(expected, actual);
    }

    /// <summary>
    /// A test to verify file loading functionality with valid and invalid inputs.
    /// </summary>
    [Fact]
    public void LoadTextFile_ValidNameShouldWork()
    {
        string actual = LoadTextFile("This is a valid name!");
        Assert.True(actual.Length > 0);
    }

    /// <summary>
    /// A test to verify that loading a file with an invalid name throws a FileNotFoundException.
    /// </summary>
    [Fact]
    public void LoadTextFile_InvalidNameShouldFail()
    {
        Assert.Throws<FileNotFoundException>(() => LoadTextFile(""));
    }

    /// <summary>
    /// A test to verify that loading a file with an invalid name throws an ArgumentException with a specific parameter name.
    /// </summary>
    [Fact]
    public void LoadTextFile_ArgumentInvalidException()
    {
        Assert.Throws<ArgumentException>("ArgExcept", () => LoadTextFile2(""));
    }

    /// <summary>
    /// A parameterized test that reads data from a CSV file to perform assertions.
    /// </summary>
    /// <param name="stringValue"></param>
    /// <param name="intValue"></param>
    /// <param name="boolValue"></param>
    [Theory]
    [MemberData(nameof(GetTestDataFromCsv))]
    public void MyCSVTest_ShouldBeFalse(string stringValue, int intValue, bool boolValue)
    {
        Assert.True(stringValue.Length >= 1); // Example assertion
        Assert.True(intValue >= 0); // Example assertion
        Assert.True(boolValue == false); // Example assertion
    }

    private string LoadTextFile(string filePath)
    {
        if (filePath.Length < 5)
        {
            throw new FileNotFoundException("File path cannot be null or empty", nameof(filePath));
        }
        return filePath;
    }


    private string LoadTextFile2(string filePath)
    {
        if (filePath.Length < 5)
        {
            throw new ArgumentException("File path cannot be null or empty", "ArgExcept");
        }
        return filePath;
    }


    private double Add(double x, double y)
    {
        return x + y;
    }

    /// <summary>
    /// Static method to read data from CSV
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> GetTestDataFromCsv()
    {
        var lines = File.ReadAllLines("TestData.csv");
        foreach (var line in lines)
        {
            var parts = line.Split(','); // Assuming comma-separated values
                                         // Convert parts to appropriate types if needed
            yield return new object[] { parts[0], int.Parse(parts[1]), bool.Parse(parts[2]) };
        }
    }
}
