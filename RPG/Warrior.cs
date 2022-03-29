using System;

namespace RPG
{
    internal class Warrior : Fighters
    {
        public event EventFighter OnPotionTake;
        public event EventFighter OnShieldSwap;
        public event EventFighter OnSwordSwap;

        private const int _MAX_HP = 200;
        private const int _MAX_MP = 0;
        private const int _MAX_ATK = 10;
        private const int _MAX_DEF = 8;

        public Warrior(string name) :
               base(name, _MAX_HP, _MAX_MP, _MAX_ATK, _MAX_DEF)
        {
        }

        public override void Fight()
        {
            Attack(Enemy);

            if (this.HP < (_MAX_HP / 4) && m_pots > 0)
            {
                UsePot();
            }

            if (this.HP < (_MAX_HP / 2) && Enemy.MP > 0)
            {
                SwapWeapon();
            }

            else
            {
                if (m_shield)
                {
                    if (OnSwordSwap != null)
                    {
                        OnSwordSwap(this);
                    }
                    this.ATK = _MAX_ATK;
                    m_shield = false;
                }
            }
        }

        public void UsePot()
        {
            m_pots -= 1;
            base.HP += 20;

            if (OnPotionTake != null)
            {
                OnPotionTake(this);
            }

            if (m_pots == 0)
                Console.WriteLine("No potions left! Feelsbadman.\n");
        }

        private void SwapWeapon()
        {
            if (!m_shield)
            {
                if (OnShieldSwap != null)
                {
                    OnShieldSwap(this);
                }
                this.ATK /= 2;
                m_shield = true;
            }
        }

        public override void TakeDamage(int damage)
        {
            if (m_shield)
                damage /= 2;

            base.TakeDamage(damage);
        }

        private int m_pots = 2;
        private bool m_shield = false;

        public int Pots
        {
            get { return m_pots; }
            set { m_pots = value; }
        }
    }
}