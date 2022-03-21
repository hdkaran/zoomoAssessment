using System;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;
using Zoomo.Problem1;
using Zoomo.Problem2;
using Zoomo.Problem3;

namespace ZoomoTests
{
    public class AllTests
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("a", false)]
        [InlineData(null, true)]
        [InlineData("null", false)]
        public void Should_Check_Only_Strings_For_Null_Or_Empty(string str, bool expectedResult)
        {
            Assert.Equal(expectedResult, str.IsStringNullOrEmpty());
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(32, 43, 54, 687.916)]
        [InlineData(25, 25, 25, 270.633)]
        public void Should_Return_Correct_Area_Of_Triangle(double sideA, double sideB, double sideC,
            double expectedArea)
        {
            var result = Triangle.GetArea(sideA, sideB, sideC);

            Assert.Equal(expectedArea, result);
        }

        [Fact]
        public void Should_Throw_Error_When_Triangle_Has_Invalid_Sides()
        {
            var ex = Assert.Throws<InvalidTriangleException>(() => Triangle.GetArea(1, 1, 5));

            Assert.Equal("The sides entered does not represent a Valid Triangle.", ex.Message);
        }

        [Fact]
        public void Should_Throw_Error_When_Triangle_Has_Negative_Sides()
        {
            var ex = Assert.Throws<InvalidTriangleException>(() => Triangle.GetArea(3, -4, 5));

            Assert.Equal("The sides entered does not represent a Valid Triangle.", ex.Message);
        }

        [Fact]
        public void Should_Throw_An_Exception_If_File_Is_Not_Html()
        {
            var pathToFile = "TestFiles/InvalidFile.txt";
            var fullPathToFile =
                Path.Combine(Directory.GetCurrentDirectory().Replace("/bin/Debug/net5.0", ""), pathToFile);

            var ex = Assert.Throws<FileFormatNotCorrectException>(() => UrlScanner.ScanHtmlFile(fullPathToFile));

            Assert.Equal("File not valid HTML.", ex.Message);
        }

        [Theory]
        [InlineData("TestFiles/Test_1.html", 1, 1)]
        [InlineData("TestFiles/Test_2.html", 513, 4)]
        public void Should_Return_Correct_Response_After_Scan(string path, int expectedWorkingLinks,
            int expectedNotWorkingLinks)
        {
            var fullPathToFile = Path.Combine(Directory.GetCurrentDirectory().Replace("/bin/Debug/net5.0", ""), path);

            var responseModel = UrlScanner.ScanHtmlFile(fullPathToFile);

            Assert.Equal(expectedWorkingLinks, responseModel.LinksWorking);
            Assert.Equal(expectedNotWorkingLinks, responseModel.LinksNotWorking);
        }
    }
}