using langlopende_taak;
using Moq;

namespace UnitTesting
{
    [TestClass]
    public class PokemonUnitTest
    {
        [TestMethod]
        // MOCK
        public void Attack_Should_Call_TakeDamage_On_Target()
        {
            
            // Arrange
            var attacker = new Pokemon("Pikachu", 100, 20);
            var mockTarget = new Mock<IPokemon>();

            // Act
            attacker.Attack(mockTarget.Object);

            // Assert
            mockTarget.Verify(target => target.TakeDamage(20), Times.Once);

        }

        [TestMethod]
        // ZERO
        public void Pokemon_With_Zero_Health_Should_Be_Fainted()
        {
            // Arrange
            var pikachu = new Pokemon("Pikachu", 0, 20);

            // Act

            //Assert
            Assert.IsTrue(pikachu.IsFainted);
        }

        [TestMethod]
        // ONE
        public void Pokemon_Should_Lose_Health_After_One_Attack()
        {
            // Arrange
            var pikachu = new Pokemon("Pikachu", 100, 20);
            var charmander = new Pokemon("Charmander", 80, 15);

            // Act
            pikachu.Attack(charmander);

            // Assert
            Assert.AreEqual(60, charmander.Health);
        }

        [TestMethod]
        // MANY
        public void Pokemon_Should_Have_Zero_Health_After_Multiple_Attacks()
        {
            // Arrange
            var pikachu = new Pokemon("Pikachu", 100, 40);
            var charmander = new Pokemon("Charmander", 120, 15);

            // ACT
            pikachu.Attack(charmander); // 120 -> 80
            pikachu.Attack(charmander); // 80 -> 40
            pikachu.Attack(charmander); // 40 -> 0

            // ASSERT
            Assert.AreEqual(0, charmander.Health);
            Assert.IsTrue(charmander.IsFainted);
        }

        [TestMethod]
        // BOUNDARY
        public void Health_Should_Not_Go_Below_Zero()
        {
            // Arrange
            var pikachu = new Pokemon("Pikachu", 100, 50);
            var bulbasaur = new Pokemon("Bulbasaur", 30, 10);

            // Act
            pikachu.Attack(bulbasaur); // 30 -> 0
            pikachu.Attack(bulbasaur); // Al 0, zou niet in negatieve mogen gaan

            // Assert
            Assert.AreEqual(0, bulbasaur.Health);
            Assert.IsTrue(bulbasaur.IsFainted);
        }

        [TestMethod]
        // EXCEPTION
        public void Attack_Should_Throw_Exception_If_Target_Is_Fainted()
        {
            // Arrange
            var pikachu = new Pokemon("Pikachu", 100, 50);
            var charmander = new Pokemon("Charmander", 40, 15);

            pikachu.Attack(charmander); // Charmander zou nu fainted moeten zijn

            // Act

            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => pikachu.Attack(charmander));
        }

        [TestMethod]
        // SIMPLE
        public void Pokemon_Should_Be_Created_With_Valid_Properties()
        {
            // Arrange
            var pikachu = new Pokemon("Pikachu", 100, 20);

            // Act

            // Assert
            Assert.AreEqual("Pikachu", pikachu.Name);
            Assert.AreEqual(100, pikachu.Health);
            Assert.AreEqual(20, pikachu.AttackPower);
            Assert.IsFalse(pikachu.IsFainted);

        }
    }
}