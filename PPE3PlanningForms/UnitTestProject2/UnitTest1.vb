Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace UnitTestProject2
    <TestClass>
    Public Class UnitTest1
        <TestMethod>
        Sub TestSub()
            [TestMethod]
            Public void TestAdditionner()
            {
                Calculette c = New Calculette();
                Double r = c.additionner(4, 6);
                Assert.AreEqual(r, 10, "Incoh�rence du r�sultat d'addition");
            }
        End Sub
    End Class
End Namespace

