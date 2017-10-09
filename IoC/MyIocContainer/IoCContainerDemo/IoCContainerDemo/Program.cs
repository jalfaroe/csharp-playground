using System;

namespace IoCContainerDemo
{
    class Program
    {
        static void Main()
        {
            var iocContainer = new IocContainer();

            iocContainer.Register<Shooter, Shooter>();
            iocContainer.Register<IFirearm, Handgun>();
            // iocContainer.Register<IFirearm, Rifle>();

            var shooter = iocContainer.Resolve<Shooter>();
            shooter.Shoot();
            
            Console.Read();
        }
    }
}
