using Xunit;

namespace DeepSigma.UnitTest
{
    /// <summary>
    /// This class contains examples of unit tests using xUnit.
    /// </summary>
    public class Examples
    {
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

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(0, 0, 0)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        public void Add_SimpleValuesShouldCalculate_Inline(double x, double y, double expected)
        {
            // Act
            double actual = Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LoadTextFile_ValidNameShouldWork()
        {
            string actual = LoadTextFile("This is a valid name!");
            Assert.True(actual.Length > 0);
        }

        [Fact]
        public void LoadTextFile_InvalidNameShouldFail()
        {
            Assert.Throws<FileNotFoundException>(() => LoadTextFile(""));
        }

        [Fact]
        public void LoadTextFile_ArgumentInvalidException()
        {
            Assert.Throws<ArgumentException>("ArgExcept", () => LoadTextFile2(""));
        }

        [Theory]
        [MemberData(nameof(GetTestDataFromCsv))]
        public void MyTest(string stringValue, int intValue, bool boolValue)
        {
            // Arrange
            // Act
            // Assert
            Assert.True(boolValue); // Example assertion
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
            return x + y; // This is a placeholder for the actual method you would test
        }


        // Static method to read data from CSV
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
}
