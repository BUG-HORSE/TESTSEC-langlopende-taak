using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace langlopende_taak
{
    public class Pokemon : IPokemon
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int AttackPower { get; private set; }
        public bool IsFainted => Health <= 0;

        public Pokemon(string name, int health, int attackPower) {
            if (string.IsNullOrEmpty(name))
                { throw new ArgumentNullException("Name can not be null or empty"); }

            if (health <= 0)
                { throw new ArgumentOutOfRangeException("Health must greater than zero"); }

            if (attackPower <= 0) 
                { throw new ArgumentOutOfRangeException("AttackPower must be greater than zero"); }

            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void Attack(IPokemon target)
        {
            if (target.IsFainted) 
            { throw new InvalidOperationException($"{target.Name} has already fainted."); }

            target.TakeDamage(AttackPower);
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(Health - damage, 0);
        }
    }
}
