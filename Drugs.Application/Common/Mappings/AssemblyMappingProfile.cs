using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach(var type in types)
            {
                var instance =Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }

    /*
    Метод public AssemblyMappingProfile(Assembly assembly) => ApplyMappingsFromAssembly(assembly); представляет конструктор для класса AssemblyMappingProfile 
и он принимает входной параметр assembly. Он вызывает метод ApplyMappingsFromAssembly, передавая ему входной параметр assembly.
    Метод ApplyMappingsFromAssembly принимает сборку (Assembly) в качестве входного параметра. Он выполняет следующие операции:
        1. Получает все открытые типы (типы, которые доступны извне сборки) из входной сборки и сохраняет их список.
        2. Для каждого типа в списке выполняет следующие операции:
            a. Создает экземпляр этого типа с помощью Activator.CreateInstance. Это позволяет создать объект типа во время выполнения.
            b. Получает информацию о методе "Mapping" для этого типа с помощью type.GetMethod("Mapping").
            c. Если метод "Mapping" найден, то вызывает его и передает ему текущий экземпляр this в качестве параметра. 
Обратите внимание, что this относится к текущему объекту AssemblyMappingProfile.
    Таким образом, данный код выполняет автоматическую регистрацию всех типов, которые реализуют обобщенный интерфейс IMapWith<>, 
и вызывает их метод Mapping, передавая текущий экземпляр AssemblyMappingProfile в качестве параметра. Предполагается, что каждый тип, 
реализующий данный интерфейс, содержит свою собственную логику сопоставления объектов.
     */
}
