using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langlopende_taak
{
    public interface IPokemon
    {
        string Name {  get; }
        int Health {  get; }
        int AttackPower { get; }
        bool IsFainted { get; }

        void Attack(IPokemon target);
        void TakeDamage(int damage);
    }
}
