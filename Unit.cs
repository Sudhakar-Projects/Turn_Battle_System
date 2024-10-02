using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Battle_System
{
    internal class Unit
    {
        private int cuurentHp;
        private int maxHp;
        private int attackPower;
        private int healPower;
        private string unitName;
        private Random random;

        public int Hp { get { return cuurentHp;} }
        public string UnitName { get { return unitName; } }
        public bool IsDead { get { return cuurentHp <= 0; } }

        public Unit(int maxHp, int attackPower, int healpower, string unitName) 
        {
            this.maxHp = maxHp;
            this.cuurentHp = maxHp;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.random = new Random();
        }

        public void Attack(Unit unitToAttack)
        { 
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int randDamage = (int)(attackPower * rng);
            unitToAttack.TakeDamage(randDamage);
            Console.WriteLine(unitName + " attacks " + unitToAttack.unitName + " and deals" + randDamage + " damage"); 
        }

        public void TakeDamage(int damage)
        {
            cuurentHp -= damage;

            if (IsDead)
                Console.WriteLine(unitName + " has been defeated!");
        }

        public void Heal()
        {
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            int heal = (int)(rng * healPower);
            cuurentHp = heal + cuurentHp > maxHp ? maxHp : heal;
            Console.WriteLine(unitName + "heals " + heal);
        }
    }
}
