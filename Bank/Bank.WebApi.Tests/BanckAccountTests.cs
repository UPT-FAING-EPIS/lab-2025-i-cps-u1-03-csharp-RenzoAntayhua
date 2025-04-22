using Bank.WebApi.Models;
using NUnit.Framework;

namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [Test]
        public void Constructor_WithNullCustomerName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BankAccount(null, 100.0));
        }


        [Test]
        public void Debit_WithAmountGreaterThanBalance_ThrowsArgumentOutOfRangeException()
        {
            BankAccount account = new BankAccount("Test User", 50.0);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(60.0));
        }

        [Test]
        public void Debit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            BankAccount account = new BankAccount("Test User", 50.0);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(-10.0));
        }

        [Test]
        public void Credit_WithNegativeAmount_ThrowsArgumentOutOfRangeException()
        {
            BankAccount account = new BankAccount("Test User", 50.0);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(-10.0));
        }



    }
}