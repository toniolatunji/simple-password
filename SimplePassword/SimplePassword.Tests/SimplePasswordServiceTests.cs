using NUnit.Framework;
using SimplePassword.Service.Contract;
using SimplePassword.Service.Implementation;

namespace SimplePassword.Tests
{
    public class SimplePasswordServiceTests
    {
        ISimplePasswordService simplePasswordService;

        [SetUp]
        public void SetUp()
        {
            simplePasswordService = new SimplePasswordService();
        }

        [TestCase("passWord123!!!!", ExpectedResult = false)]
        [TestCase("turkey90AAA=", ExpectedResult = true)]
        [TestCase("apple!M7", ExpectedResult = true)]
        [TestCase("franceBBB+-=", ExpectedResult = false)]
        [TestCase("indigo99AB@+===", ExpectedResult = true)]
        [TestCase("D%bh^+BW~Uh_[Xdr6<h<x,Zk,<rv#", ExpectedResult = true)]
        [TestCase("A3R<r@MZWhNcSmJ4;QA@7pC7u&jY745u", ExpectedResult = false)]
        [TestCase("fr12B-=", ExpectedResult = false)]
        public bool SimplePassword_Returns_CorrectPasswordValidity(string password)
        {
            var response = simplePasswordService.SimplePassword(password);

            return response.IsValid;
        }

        [TestCase("passWord123!!!!", ExpectedResult = "Password cannot have the word \"password\" in the string")]
        [TestCase("turkey90AAA=", ExpectedResult = "")]
        [TestCase("franceBBB+-=", ExpectedResult = "Password must contain at least one number")]
        [TestCase("mikeonetwo@+-=", ExpectedResult = "Password must have a capital letter")]
        [TestCase("indigo99AB122", ExpectedResult = "Password must contain a punctuation mark or mathematical symbol")]
        [TestCase("D%bh^+BW~Uh_[Xdr6<h<x,Zk,<rv#", ExpectedResult = "")]
        [TestCase("A3R<r@MZWhNcSmJ4;QA@7pC7u&jY745u", ExpectedResult = "Password must be longer than 7 characters and shorter than 31 characters")]
        [TestCase("fr12B-=", ExpectedResult = "Password must be longer than 7 characters and shorter than 31 characters")]
        public string SimplePassword_Returns_CorrectValidityError(string password)
        {
            var response = simplePasswordService.SimplePassword(password);

            return response.Error;
        }
    }
}
