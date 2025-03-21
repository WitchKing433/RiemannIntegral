using System.Reflection;

namespace DynamicLibraryTool
{
    public static class DinamicLibraryLoader
    {
        public static T LoadAssembly<T>(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException(path);
                }
                Assembly assemblyLoaded = Assembly.LoadFrom(Path.GetFullPath(path));
                AppDomain.CurrentDomain.Load(assemblyLoaded.GetName());

                Type interfaceType = typeof(T);
                Type[] types = assemblyLoaded.GetTypes();
                foreach (Type type in types)
                {
                    if (interfaceType.IsAssignableFrom(type))
                    {
                        object? instance = Activator.CreateInstance(type);
                        if (instance == null)
                        {
                            throw new Exception($"Unable to create instance of type '{type.FullName}'");
                        }
                        LoadReferencedAssemblies(assemblyLoaded);
                        return (T)instance;
                    }
                }
                throw new Exception($"Unable to find any public interfaces of type '{typeof(T).FullName}'");
            }
            catch (Exception exc)
            {
                throw new Exception($"Unable to load assembly from route '{path}': {exc.Message}");
            }
        }

        private static void LoadReferencedAssemblies(Assembly assemblyLoaded)
        {
            try
            {
                AssemblyName[] referencedAssemblies = assemblyLoaded.GetReferencedAssemblies();
                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (AssemblyName currentAssemblyName in referencedAssemblies)
                {
                    if (loadedAssemblies.FirstOrDefault(currentLoadedAssembly => currentLoadedAssembly.FullName == currentAssemblyName.FullName) == null)
                    {
                        Assembly? referencedAssembly = null;
                        try
                        {
                            //First try to load using the assembly name just in case its a system dll    
                            referencedAssembly = Assembly.Load(currentAssemblyName);
                        }
                        catch (FileNotFoundException)
                        {
                            string assembyPath = "";
                            try
                            {
                                string? directoryName = Path.GetDirectoryName(assemblyLoaded.Location);
                                if (directoryName == null)
                                {
                                    throw new Exception($"Failed to get directory name from assembly location '{assemblyLoaded.Location}'");
                                }
                                assembyPath = Path.Combine(directoryName, currentAssemblyName.Name + ".dll");
                                referencedAssembly = Assembly.LoadFrom(assembyPath);
                            }
                            catch (Exception exc)
                            {
                                throw new Exception($"Unable to load assembly from route '{assembyPath}': {exc.Message}");
                            }
                        }
                        if (referencedAssembly == null)
                        {
                            throw new Exception($"Unable to load assembly {currentAssemblyName.FullName}");
                        }
                        try
                        {
                            LoadReferencedAssemblies(referencedAssembly);
                            AppDomain.CurrentDomain.Load(referencedAssembly.GetName());
                        }
                        catch (Exception exc)
                        {
                            throw new Exception($"Unable to load referenced assemblies of {currentAssemblyName.FullName}: {exc.Message}");
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception($"Unable to load referenced assemblies: {exc.Message}");
            }
        }
    }
}