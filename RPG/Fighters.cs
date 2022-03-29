using System;

namespace RPG
{
    public class Fighters
    {
        public delegate void EventTwoFighters (Fighters f1, Fighters f2);
        public delegate void EventFighter (Fighters f);
        public event EventFighter OnEnemyDamage;
        public event EventFighter OnEnemyKilled;
        public event EventTwoFighters OnSwordAttack;
        public Fighters(string name, int hp, int mp, int atk, int def)
        {
            m_name = name;
            m_health = hp;
            m_mana = mp;
            m_attack = atk;
            m_defense = def;
        }

        virtual public void Fight()
        {
            if (this.HP <= 0)
            {
                Console.WriteLine("Oh no, {0} died!\n", this.Name);
            }
        }

        public virtual void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }

            m_health -= damage;

            if(OnEnemyDamage != null)
            {
                OnEnemyDamage(this);
            }

            if (!(m_health > 0))
            
            {
                m_health = 0;
                if (OnEnemyKilled != null)
                {
                    OnEnemyKilled(this);
                }
            }
        }

        public virtual void Attack(Fighters target)
        {
            if (OnSwordAttack != null)
            {
                OnSwordAttack(this, target);
            }
            Random random = new Random();
            int randAtk = random.Next(0, this.ATK);
            int randDef = random.Next(0, target.DEF);

            int damage = Math.Max((this.ATK + randAtk) - (target.DEF + randDef), 0);

            target.TakeDamage(damage);
        }

        private string m_name;
        private int m_health;
        private int m_mana;
        private int m_attack;
        private int m_defense;
        private Fighters m_enemy = null;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public int HP
        {
            get { return m_health; }
            set { m_health = value; }
        }

        public int MP
        {
            get { return m_mana; }
            set { m_mana = value; }
        }

        public int ATK
        {
            get { return m_attack; }
            set { m_attack = value; }
        }

        public int DEF
        {
            get { return m_defense; }
            set { m_defense = value; }
        }

        public Fighters Enemy
        {
            get { return m_enemy; }
            set { m_enemy = value; }
        }
    }
}