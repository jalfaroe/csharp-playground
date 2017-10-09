using System;

namespace IoCContainerDemo
{
    public class Shooter 
    {
        private readonly IFirearm _firearm;

        public Shooter(IFirearm firearm)
        {
            _firearm = firearm;
        }

        public void Shoot()
        {
            var shotMessage = _firearm.Shoot();
            Console.WriteLine(shotMessage);
        }
    }
}
