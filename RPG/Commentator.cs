using System;

namespace RPG
{
    internal class Commentator
    {
        static public void CommentMatch(Wizard wizard)
        {
            wizard.OnSpellAttack += (Fighters f1, Fighters f2) =>
            {
                Console.WriteLine($"Commentator:  {f1.Name} throws a massive chungus fireball in {f2.Name}'s face.\n");
            };

            wizard.OnSpellHeal += (Fighters f) =>
            {
                Console.WriteLine($"Commentator:  {f.Name} cast Soothing Sunlight on himself and gain 20 HP.\n");
            };

            wizard.OnSwordAttack += SwordAtkAction;
            wizard.OnEnemyDamage += DamageAction;
            wizard.OnEnemyKilled += EnemyKilled;
        }

        static public void CommentMatch(Warrior warrior)
        {
            warrior.OnSwordAttack += SwordAtkAction;
            warrior.OnEnemyDamage += DamageAction;
            warrior.OnEnemyKilled += EnemyKilled;
            warrior.OnPotionTake += (Fighters f) =>
            {
                Console.WriteLine($"Commentator:  {f.Name} takes a potion, {warrior.Pots} left.\n");
            };

            warrior.OnShieldSwap += (Fighters f) =>
            {
                Console.WriteLine($"Commentator:  {f.Name} swaps weapon, he is now wielding 'The Surrender' his Ezomyte Tower Shield.\n");
            };

            warrior.OnSwordSwap += (Fighters f) =>
            {
                Console.WriteLine($"Commentator:  {f.Name} swaps weapon, he is now wielding 'Cospri's Malice' his Jewelled Foil.\n");
            };
        }

        static private void SwordAtkAction(Fighters f1, Fighters f2)
        {
            Console.WriteLine($"Commentator:  {f1.Name} swing his sword violently on {f2.Name}.\n");
        }

        static private void DamageAction(Fighters f)
        {
            Console.WriteLine($"Commentator:  Ouch {f.Name} is wounded!\n");
        }

        static private void EnemyKilled(Fighters f)
        {
            Console.WriteLine($"Commentator:  Oh noooo {f.Name} just died!\n");
        }
    }
}