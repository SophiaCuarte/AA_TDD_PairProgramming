[TestClass]
public class StringCalculatorTests
{
    [TestMethod]
    public void Add_EmptyString_ReturnsZero()
    {
        StringCalculator calculator = new StringCalculator();

        int result = calculator.Add("");

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Add_OneNumber_ReturnsNumber()
    {
        StringCalculator calculator = new StringCalculator();

        int result = calculator.Add("7");

        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        StringCalculator calculator = new StringCalculator();

        int result = calculator.Add("7,8");

        Assert.AreEqual(15, result);
    }

    [TestMethod]
    public void Add_UnlimitedNumbers_ReturnsSum()
    {
        StringCalculator calculator = new StringCalculator();

        int result = calculator.Add("7,8,3,4");

        Assert.AreEqual(22, result);
    }

    [TestMethod]
    public void Add_NewLineBetweenNumbers_ReturnsSum()
    {
        StringCalculator calculator = new StringCalculator();

        int result = calculator.Add("1\n2,3");

        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Add_CustomDelimiter_ReturnsSum()
    {
        StringCalculator calculator = new StringCalculator();

        int result = calculator.Add("//;\n1;2");

        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Add_NegativeNumbers_ThrowsException()
    {
        StringCalculator calculator = new StringCalculator();

        Assert.ThrowsException<InvalidOperationException>(() => calculator.Add("1,-2,3,-4"));
    }

    [TestMethod]
    public void Add_NumbersGreaterThan1000_AreIgnored()
    {
        StringCalculator calculator = new StringCalculator();

        int result = calculator.Add("2,1001,5");

        Assert.AreEqual(7, result);
    }
}