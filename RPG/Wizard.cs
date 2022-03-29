using System;

namespace RPG
{
    internal class Wizard : Fighters
    {
        public event EventTwoFighters OnSpellAttack;
        public event EventFighter OnSpellHeal;

        private const int _MAX_HP = 100;
        private const int _MAX_MP = 50;
        private const int _MAX_ATK = 8;
        private const int _MAX_DEF = 8;
        private const int _COST = 5;
        private const int _HEAL = 30;
        private const int _FIREBALL = 20;

        public Wizard(string name) :
            base(name, _MAX_HP, _MAX_MP, _MAX_ATK, _MAX_DEF)
        {
        }

        public override void Fight()
        {
            if (!m_heal && Enemy != null)
            {
                Attack(Enemy);
            }

            if (this.HP < (_MAX_HP / 4) && this.MP > 0)
            {
                Heal();
            }

            if(this.HP > (_MAX_HP / 4))
            {
                m_heal = false;
            }
        }

        public override void Attack(Fighters target)
        {
            if (!(this.MP == 0))
            {
                if (OnSpellAttack != null)
                {
                    OnSpellAttack(this, target);
                }
                Random random = new Random();
                int randSpell = random.Next(0, _FIREBALL);
                int damage = _FIREBALL + randSpell;

                this.MP -= _COST;
                Enemy.TakeDamage(damage);
            }
            else
            {
                base.Attack(target);
            }
        }

        private void Heal()
        {
            m_heal = true;
            this.MP -= _COST;
            this.HP += _HEAL;
            if (OnSpellHeal != null)
            {
                OnSpellHeal(this);
            }

            if (MP <= 0)
            {
                this.MP = 0;
                Console.WriteLine("No mana left!\n");
            }
        }

        private bool m_heal = false;
    }
}