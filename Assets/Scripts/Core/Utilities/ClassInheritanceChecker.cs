using System;

namespace Asteroids.Utilities
{
    public static class ClassInheritanceChecker
    {
        public static bool CheckIfClassInheritsAnotherClass(Type inheritor, Type inheritedClass)
        {
            return inheritor.IsSubclassOf(inheritedClass) || inheritor == inheritedClass;
        }
    }
}