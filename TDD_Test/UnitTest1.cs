[TestClass]
public class StringCalculatorTests
{
    [TestMethod]
    public void Add_EmptyString_ReturnsZero()
    {
        // Arrange
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add("");

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Add_OneNumber_ReturnsNumber()
    {
        // Arrange
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add("7");

        // Assert
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add("7,8");

        // Assert
        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Add_UnlimitedNumbers_ReturnsSum()
    {
        // Arrange
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add("7,8,3,4");

        // Assert
        Assert.AreEqual(22, result);
    }

    [TestMethod]
    public void Add_NewLineBetweenNumbers_ReturnsSum()
    {
        // Arrange
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add("1\n2,3");

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Add_CustomDelimiter_ReturnsSum()
    {
        // Arrange
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add("//;\n1;2");

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Add_NegativeNumbers_ThrowsException()
    {
        // Arrange
        StringCalculator calculator = new StringCalculator();

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() => calculator.Add("1,-2,3,-4"));
    }

    [TestMethod]
    public void Add_NumbersGreaterThan1000_AreIgnored()
    {
        // Arrange
        StringCalculator calculator = new StringCalculator();

        // Act
        int result = calculator.Add("2,1001,5");

        // Assert
        Assert.AreEqual(7, result);
    }
}